using Eron.Core.ManagementSettings;

namespace Eron.SharedKernel.Helpers.FinancialHelper
{
    public static class ZarinPalHelper
    {
        public static string GetUrl(string authority)
        {
            return ApplicationSettings.FinancialSettings.ZarinPal.DefaultPaymentGatewayUrl + authority;
        }
    }
}
