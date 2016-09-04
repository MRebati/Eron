using System.Web;
using System.Web.Mvc;
using Eron.web.Filters;

namespace Eron.web
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            //filters.Add(new CompressionFilters());
        }
    }
}
