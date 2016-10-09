using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Eron.core.App_GlobalResources;
using Eron.core.Encode;
using Eron.core.Services;
using Eron.web.Areas.admin.Models.Page;
using Eron.web.Models.FileHelper;

namespace Eron.web.Areas.admin.Controllers
{
    public class PageController : BaseController
    {
        public PageController(IRepositoryService repositoryService, IEncode encode, IFileHelper fileHelper) : base(repositoryService, encode, fileHelper)
        {
        }

        // GET: admin/Page
        public async Task<ActionResult> Index()
        {
            ViewBag.Title = GlobalResources.AllPages;
            var model = await Service.Pages.GetAsync();
            var data = model.Select(x => ModelFactory.ListCreate(x)).ToList();
            return PartialView(data);
        }

        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.Title = GlobalResources.CreatePage;
            ViewBag.Language =
                new SelectList(Service.Languages.Get().Select(x => ModelFactory.SelectList(x.LocalName, x.LanguageCode)), "Id", "Name");
            return PartialView();
        }

        [HttpPost]
        public async Task<ActionResult> Create(PageCreate model)
        {
            
            if (ModelState.IsValid)
            {
                var page = ModelFactory.Create(model);
                await Service.Pages.InsertAsync(page);
                return RedirectToAction("Index");
            }

            ViewBag.Language =
                new SelectList(Service.Languages.Get().Select(x => ModelFactory.SelectList(x.LocalName, x.LanguageCode)),"Id","Name",model.Language);
            ViewBag.Title = GlobalResources.CreatePage;
            return PartialView(model);
        }

        public async Task<ActionResult> Edit(int? id)
        {
            if(id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var page = await Service.Pages.GetAsync(id.Value);
            if(page == null)
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);
            var model = ModelFactory.ListCreate(page);
            return PartialView(model);
        }

        [HttpPost]
        public async Task<ActionResult> Edit(PageCreate model)
        {
            if (ModelState.IsValid)
            {
                var page = ModelFactory.Create(model);
                await Service.Pages.UpdateAsync(page);
                return RedirectToAction("Index");
            }
            return PartialView(model);
        }
    }
}