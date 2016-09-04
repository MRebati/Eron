using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Eron.core.Encode;
using Eron.core.Services;
using Eron.web.Areas.admin.Models;
using Eron.web.Models.FileHelper;


namespace Eron.web.Areas.admin.Controllers
{
    public class DashboardController : BaseController
    {
        public DashboardController(IRepositoryService repositoryService, IEncode encode, IFileHelper fileHelper) : base(repositoryService, encode, fileHelper)
        {
        }

        // GET: admin/Dashboard
        public ActionResult Index()
        {
            
            return View();
        }

        public ActionResult IndexPartial()
        {
            return PartialView();
        }

        public ActionResult BreadCrump(string parent,string mid,string last,string url,string title,bool nav)
        {
            ViewBag.Nav = nav ? "whitenav" : "blacknav";
            ViewBag.Title = title;
            ViewBag.Url = url;
            ViewBag.Parent = parent;
            ViewBag.Mid = mid;
            ViewBag.Last = last;
            return PartialView();
        }
    }
}