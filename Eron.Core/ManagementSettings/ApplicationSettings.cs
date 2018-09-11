using System;
using Eron.Core.AppEnums;

namespace Eron.Core.ManagementSettings
{
    public static class ApplicationSettings
    {
        public static TimeSpan TransactionTimeout = new TimeSpan(0, 5, 0);
        public static MapperType MapperType = MapperType.AutoMapper;
        public static Language DefaultLanguage= Language.Persian;
        public static BankNameType DefaultBankName = BankNameType.ZarinPal;

        public const string Domain = "rebati.net";
        public const string DefaultAdminUsername = "admin";
        public const string ForgetPasswordEmail = "no-reply@rebati.net";
        public const string DefaultEmailAddress = "info@rebati.net";
        public const string DefaultMobileNumber = "09381616622";

        public const string DefaultAdminPassword = "alpha007";

        public const string DefaultHeroChars = "Re";

        public const string DefaultKey = "3a4f836a-7603-4009-b2b1-e7b88e94cd13";

        public static class Pagination
        {
            public const int PageSize = 20;
        }

        public static class FinancialSettings
        {
            public const int MaximumInvoiceProgressSteps = 6;
            public const int MaximumOrderProgressSteps = 6;

            public static class ZarinPal
            {
                public const string DefaultPaymentGatewayUrl = "https://www.zarinpal.com/pg/StartPay/";
                public const string DefaultCallBackUrl = "http://127.0.0.1:4200/bank/callback/zarinpal";
            }
        }


        
    }
}
