using System;
using System.Configuration;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Eron.Business.Core.Connected_Services.MellatBankService;
using Eron.Business.Core.Connected_Services.ZarinPalService;
using Eron.Business.Core.Infrastructure;
using Eron.Business.Core.Services.Financial.Base.Bank.Dto;
using Eron.Business.Core.Services.Financial.Base.Invoice.Dto;
using Eron.Core.AppEnums;
using Eron.Core.Entities.Financial.Base;
using Eron.Core.ManagementSettings;
using Eron.DataAccess.Contract.UnitOfWorks;
using Eron.SharedKernel.Helpers.AppSettingsHelper;
using Eron.SharedKernel.Helpers.FinancialHelper;
using Eron.SharedKernel.Helpers.Mapper;
using Eron.SharedKernel.Helpers.TokenGenerator;

namespace Eron.Business.Core.Services.Financial.Base.Bank
{
    public class BankAppService : ManagementSystemService, IBankAppService
    {
        public static readonly string CallBackUrl = ConfigurationManager.AppSettings["CallBackUrl"];
        public static readonly string MellatPgwSite = ConfigurationManager.AppSettings["Mellat.PgwSite"];
        public static readonly string MellatTerminalId = ConfigurationManager.AppSettings["Mellat.TerminalId"];
        public static readonly string MellatUserName = ConfigurationManager.AppSettings["Mellat.UserName"];
        public static readonly string MellatUserPassword = ConfigurationManager.AppSettings["Mellat.UserPassword"];

        public BankAppService(IManagementUnitOfWork unitOfWork, TenantType tenantType = TenantType.WebService) : base(unitOfWork, tenantType)
        {
        }

        public async Task<BankPaymentRequestResponseDto> CreateReference(BankNameType bankName, string userId, long invoiceId)
        {
            var invoice = (UnitOfWork.InvoiceRepository.GetByIdAsync(invoiceId));
            var amount = UnitOfWork.InvoiceRepository.GetInvoiceAmount(invoiceId);

            var transactionNumber = TokenGenerator.Generate(TokenType.Transaction);

            switch (bankName)
            {
                case BankNameType.Mellat:
                    try
                    {
                        string result = "";
                        BypassCertificateError();
                        PaymentGatewayClient bp = new PaymentGatewayClient();
                        result = bp.bpPayRequest(
                            Int64.Parse(MellatTerminalId),
                            MellatUserName,
                            MellatUserPassword,
                            invoiceId,
                            amount,
                            SetDefaultDate(),
                            SetDefaultTime(),
                            $"Invoice #{(await invoice).InvoiceNumber}",
                            CallBackUrl,
                            0);
                        string[] res = result.Split(',');
                        if (res[0] == "0")
                        {
                            var financialTransaction = new FinanceTransaction(invoice.Id, transactionNumber, userId, BankNameType.Mellat, res[1]);
                            UnitOfWork.FinanceTransactionRepository.Create(financialTransaction);
                            await UnitOfWork.SaveAsync();

                            return new BankPaymentRequestResponseDto()
                            {
                                BankName = BankNameType.Mellat,
                                Response = res[1],
                                PaymentRequestType = PaymentRequestType.RefId,
                                PaymentRequestTypeTitle = "REFID",
                                BankPaymentRequestUrl = MellatPgwSite
                            };
                        }
                        else
                        {
                            return new BankPaymentRequestResponseDto()
                            {
                                HasError = true,
                                Error = BankResultException(res[0], BankNameType.Mellat)
                            };
                        }
                    }
                    catch
                    {
                        return new BankPaymentRequestResponseDto()
                        {
                            HasError = true,
                            Error = BankResultException("", BankNameType.Mellat)
                        };
                    }
                case BankNameType.ZarinPal:
                    var invoiceDto = (await invoice).MapTo<InvoiceDto>();
                    return await GetZarinPalReferenceId(invoiceDto, amount, transactionNumber, userId, bankName);
                //case BankNameType.Keshavarzi:
                //    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(bankName), bankName, null);
            }
        }

        private async Task<BankPaymentRequestResponseDto> GetZarinPalReferenceId(InvoiceDto invoice, int invoiceAmount, string transactionNumber, string userId, BankNameType bankName)
        {
            try
            {
                System.Net.ServicePointManager.Expect100Continue = false;
                PaymentGatewayImplementationServicePortTypeClient zp = new PaymentGatewayImplementationServicePortTypeClient();
                string authority;

                var callBackUrl = ApplicationSettings.FinancialSettings.ZarinPal.DefaultCallBackUrl;

                int status = zp.PaymentRequest(
                    ApplicationSettingsHelper.AppSetting("ZarinPal.MerchantCode"),
                    (int)invoiceAmount,
                    $"Invoice #{invoice.InvoiceNumber}",
                    ApplicationSettings.DefaultEmailAddress,
                    ApplicationSettings.DefaultMobileNumber,
                    callBackUrl,
                    out authority);

                if (status == 100)
                {
                    var authorityUrl = ZarinPalHelper.GetUrl(authority);
                    var transaction = new FinanceTransaction(invoice.Id, transactionNumber, userId, bankName, authority);

                    UnitOfWork.FinanceTransactionRepository.Create(transaction);
                    await UnitOfWork.SaveAsync();

                    return new BankPaymentRequestResponseDto()
                    {
                        Response = authorityUrl,
                        PaymentRequestType = PaymentRequestType.Url,
                        PaymentRequestTypeTitle = "URL"
                    };
                }
                else
                {
                    return new BankPaymentRequestResponseDto()
                    {
                        HasError = true,
                        Error = BankResultException(status.ToString(), BankNameType.ZarinPal)
                    };
                }
            }
            catch
            {
                return new BankPaymentRequestResponseDto()
                {
                    HasError = true,
                    Error = BankResultException("", BankNameType.ZarinPal)
                };
            }
        }

        #region Helpers

        private void BypassCertificateError()
        {
            ServicePointManager.ServerCertificateValidationCallback +=
                delegate (
                    Object sender1,
                    X509Certificate certificate,
                    X509Chain chain,
                    SslPolicyErrors sslPolicyErrors)
                {
                    return true;
                };
        }

        private string SetDefaultDate()
        {
            return DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString().PadLeft(2, '0') + DateTime.Now.Day.ToString().PadLeft(2, '0');

        }

        private string SetDefaultTime()
        {
            return DateTime.Now.Hour.ToString().PadLeft(2, '0') + DateTime.Now.Minute.ToString().PadLeft(2, '0') + DateTime.Now.Second.ToString().PadLeft(2, '0');
        }

        private string BankResultException(string resCode, BankNameType bankName)
        {
            string result;

            switch (bankName)
            {
                case BankNameType.Mellat:
                    result = GetMellatBankResCodeResponse(resCode);
                    return result;
                //case BankNameType.Keshavarzi:
                //    result = GetKeshavarziBankResCodeResponse(resCode);
                //    return result;

                case BankNameType.ZarinPal:
                    return GetZarinPalResCodeResponse(resCode);

                default:
                    throw new ArgumentOutOfRangeException(nameof(bankName), bankName, null);
            }
        }

        private string GetZarinPalResCodeResponse(string resCode)
        {
            try
            {
                var finalResponse = "";
                var result = Int32.Parse(resCode);
                switch (result)
                {
                    case -1:
                        finalResponse = "اطلاعات ارسال شده ناقص است";
                        break;
                    case -2:
                        finalResponse = "IP و يا مرچنت كد پذيرنده صحيح نيست";
                        break;
                    case -3:
                        finalResponse = "با توجه به محدوديت هاي شاپرك امكان پرداخت با رقم درخواست شده ميسر نمي باشد";
                        break;
                    case -4:
                        finalResponse = "سطح تاييد پذيرنده پايين تر از سطح نقره اي است";
                        break;
                    case -11:
                        finalResponse = "درخواست مورد نظر يافت نشد";
                        break;
                    case -12:
                        finalResponse = "امكان ويرايش درخواست ميسر نمي باشد";
                        break;
                    case -21:
                        finalResponse = "هيچ نوع عمليات مالي براي اين تراكنش يافت نشد.";
                        break;
                    case -22:
                        finalResponse = "تراكنش نا موفق مي باشد";
                        break;
                    case -33:
                        finalResponse = "رقم تراكنش با رقم پرداخت شده مطابقت ندارد";
                        break;
                    case -34:
                        finalResponse = "سقف تقسيم تراكنش از لحاظ تعداد يا رقم عبور نموده است";
                        break;
                    case -40:
                        finalResponse = "اجازه دسترسي به متد مربوطه وجود ندارد";
                        break;
                    case -41:
                        finalResponse = "اطلاعات ارسال شده مربوط به AdditionalData غيرمعتبر ميباشد.";
                        break;
                    case -42:
                        finalResponse = "مدت زمان معتبر طول عمر شناسه پرداخت بايد بين 30 دقيه تا 45 روز مي باشد.";
                        break;
                    case -54:
                        finalResponse = "درخواست مورد نظر آرشيو شده است";
                        break;
                    case 100:
                        finalResponse = "عمليات با موفقيت انجام گرديده است";
                        break;
                    case 101:
                        finalResponse = "عمليات پرداخت موفق بوده و قبلا PaymentVerification تراكنش انجام شده است";
                        break;
                    default:
                        finalResponse = "مشکلی نامشخص از سمت بانک رخ داده است";
                        break;
                }

                return finalResponse;
            }
            catch
            {
                return "مشکلی نامشخص از سمت بانک رخ داده است";
            }
        }

        private string GetKeshavarziBankResCodeResponse(string resCode)
        {
            throw new NotImplementedException();
        }

        private string GetMellatBankResCodeResponse(string resCode)
        {
            try
            {
                var finalResponse = "";
                var result = Int32.Parse(resCode);
                switch (result)
                {
                    case 0:
                        finalResponse = "تراكنش با موفقيت انجام شد";
                        break;
                    case 11:
                        finalResponse = "شماره كارت نامعتبر است";
                        break;
                    case 12:
                        finalResponse = "موجودي كافي نيست";
                        break;
                    case 13:
                        finalResponse = "رمز نادرست است";
                        break;
                    case 14:
                        finalResponse = "تعداد دفعات وارد كردن رمز بيش از حد مجاز است";
                        break;
                    case 15:
                        finalResponse = "كارت نامعتبر است";
                        break;
                    case 16:
                        finalResponse = "دفعات برداشت وجه بيش از حد مجاز است";
                        break;
                    case 17:
                        finalResponse = "كاربر از انجام تراكنش منصرف شده است";
                        break;
                    case 18:
                        finalResponse = "تاريخ انقضاي كارت گذشته است";
                        break;
                    case 19:
                        finalResponse = "مبلغ برداشت وجه بيش از حد مجاز است";
                        break;
                    case 111:
                        finalResponse = "صادر كننده كارت نامعتبر است";
                        break;
                    case 112:
                        finalResponse = "خطاي سوييچ صادر كننده كارت";
                        break;
                    case 113:
                        finalResponse = "پاسخي از صادر كننده كارت دريافت نشد";
                        break;
                    case 114:
                        finalResponse = "دارنده كارت مجاز به انجام اين تراكنش نيست";
                        break;
                    case 21:
                        finalResponse = "پذيرنده نامعتبر است";
                        break;
                    case 23:
                        finalResponse = "خطاي امنيتي رخ داده است";
                        break;
                    case 24:
                        finalResponse = "اطلاعات كاربري پذيرنده نامعتبر است";
                        break;
                    case 25:
                        finalResponse = "مبلغ نامعتبر است";
                        break;
                    case 31:
                        finalResponse = "پاسخ نامعتبر است";
                        break;
                    case 32:
                        finalResponse = "فرمت اطلاعات وارد شده صحيح نمي باشد";
                        break;
                    case 33:
                        finalResponse = "حساب نامعتبر است";
                        break;
                    case 34:
                        finalResponse = "خطاي سيستمي";
                        break;
                    case 35:
                        finalResponse = "تاريخ نامعتبر است";
                        break;
                    case 41:
                        finalResponse = "شماره درخواست تكراري است";
                        break;
                    case 42:
                        finalResponse = "تراكنش با موفقيت انجام شد";
                        break;
                    case 43:
                        finalResponse = "تراكنش با موفقيت انجام شد";
                        break;
                    case 44:
                        finalResponse = "تراكنش با موفقيت انجام شد";
                        break;
                    case 45:
                        finalResponse = "تراكنش با موفقيت انجام شد";
                        break;
                    case 46:
                        finalResponse = "تراكنش با موفقيت انجام شد";
                        break;
                    case 47:
                        finalResponse = "تراكنش با موفقيت انجام شد";
                        break;
                    case 48:
                        finalResponse = "تراكنش با موفقيت انجام شد";
                        break;
                    case 49:
                        finalResponse = "تراكنش با موفقيت انجام شد";
                        break;
                    case 412:
                        finalResponse = "تراكنش با موفقيت انجام شد";
                        break;
                    case 413:
                        finalResponse = "تراكنش با موفقيت انجام شد";
                        break;
                    case 414:
                        finalResponse = "تراكنش با موفقيت انجام شد";
                        break;
                    case 415:
                        finalResponse = "تراكنش با موفقيت انجام شد";
                        break;
                    case 416:
                        finalResponse = "تراكنش با موفقيت انجام شد";
                        break;
                    case 417:
                        finalResponse = "تراكنش با موفقيت انجام شد";
                        break;
                    case 418:
                        finalResponse = "تراكنش با موفقيت انجام شد";
                        break;
                    case 419:
                        finalResponse = "تراكنش با موفقيت انجام شد";
                        break;
                    case 421:
                        finalResponse = "تراكنش با موفقيت انجام شد";
                        break;
                    case 51:
                        finalResponse = "تراكنش با موفقيت انجام شد";
                        break;
                    case 54:
                        finalResponse = "تراكنش با موفقيت انجام شد";
                        break;
                    case 55:
                        finalResponse = "تراكنش با موفقيت انجام شد";
                        break;
                    case 61:
                        finalResponse = "تراكنش با موفقيت انجام شد";
                        break;
                    default:
                        finalResponse = "مشکلی نامشخص از سمت بانک رخ داده است";
                        break;
                }
                return finalResponse;
            }
            catch
            {
                return "مشکلی نامشخص از سمت بانک رخ داده است";
            }
        }

        #endregion
    }
}
