using Eron.Business.Core.Infrastructure;
using Eron.Core.AppEnums;

namespace Eron.Business.Core.Services.Financial.Base.Bank.Dto
{
    public class BankPaymentRequestResponseDto: CommonDto
    {
        public PaymentRequestType PaymentRequestType { get; set; }

        public string PaymentRequestTypeTitle { get; set; }

        public string Response { get; set; }

        public BankNameType BankName { get; set; }

        public string BankPaymentRequestUrl { get; set; }

        public string Error { get; set; }

        public bool HasError { get; set; }
    }
}
