using System.Web.Mvc;

namespace Eron.Presentation.WebApplication.Website.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }
    }
}
