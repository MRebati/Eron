using Eron.Core.Infrastructure;

namespace Eron.Core.AppEnums
{
    public enum TenantType
    {
        [DisplayName("وبسایت")]
        WebApplication,

        [DisplayName("نرم افزار موبایل")]
        MobileApplication,

        [DisplayName("وب سرویس")]
        WebService
    }
}
