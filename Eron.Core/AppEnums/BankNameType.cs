using Eron.Core.Infrastructure;

namespace Eron.Core.AppEnums
{
    public enum BankNameType
    {
        [DisplayName("بانک ملت", 0)]
        Mellat = 0,

        //[DisplayName("بانک کشاورزی", 1)]
        //Keshavarzi = 1

        [DisplayName("زرین پال", 2)]
        ZarinPal = 2
    }

    public enum PaymentRequestType
    {
        [DisplayName("آدرس ارجاع", 0)]
        Url = 0,

        [DisplayName("شناسه ارجاع", 1)]
        RefId = 1
    }
}