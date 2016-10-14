using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Eron.core.App_GlobalResources;
using Eron.core.Encode;
using Eron.core.Services;
using Eron.web.Areas.admin.Models.Navigation;
using Eron.web.Models.FileHelper;

namespace Eron.web.Areas.admin.Controllers.Settings
{
    public class MenuController : BaseController
    {
        public MenuController(IRepositoryService repositoryService, IEncode encode, IFileHelper fileHelper) : base(repositoryService, encode, fileHelper)
        {
        }

        public ActionResult Index()
        {
            ViewBag.Title = GlobalResources.MenuSettings;
            return PartialView();
        }

        public ActionResult List()
        {
            var model = Service.Menues.Get();
            var vModel = model.Select(x => ModelFactory.ListCreate(x));
            return PartialView(vModel);
        }

        public ActionResult Create()
        {
            ViewBag.MenuId =
                new SelectList(Service.Menues.Get().Select(x => ModelFactory.SelectList(x.Name, x.Id)), "Id",
                    "Name");
            ViewBag.Page = new SelectList(
                Service.Pages.Get().Select(x => ModelFactory.SelectList(x.Title, x.Id)), "Id", "Name");
            ViewBag.Category = new SelectList(
                Service.Categories.Get().Select(x => ModelFactory.SelectList(x.Name, x.Id)), "Id", "Name");
            return PartialView();
        }

        [HttpPost]
        public async Task<ActionResult> Create(MenuCreate model)
        {
            ViewBag.MenuId =
                new SelectList(Service.Menues.GetIQueryable().Select(x => ModelFactory.SelectList(x.Name, x.Id)), "Id",
                    "Name",model.MenuId);
            ViewBag.Page = new SelectList(
                Service.Pages.GetIQueryable().Select(x => ModelFactory.SelectList(x.Title, x.Id)), "Id", "Name",model.Page);
            ViewBag.Category = new SelectList(
                Service.Categories.GetIQueryable().Select(x => ModelFactory.SelectList(x.Name, x.Id)), "Id", "Name",model.Category);

            if (ModelState.IsValid)
            {
                var obj = ModelFactory.Create(model);
                await Service.Menues.InsertAsync(obj);
            }
            return PartialView();
        }

        public async Task<ActionResult> Edit(int? id)
        {
            if(id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var model = await Service.Menues.GetAsync(id.Value);
            if(model == null)
                return new HttpNotFoundResult();
            ViewBag.MenuId =
                new SelectList(Service.Menues.GetIQueryable().Select(x => ModelFactory.SelectList(x.Name, x.Id)), "Id",
                    "Name", model.Id);
            return PartialView(model);
        }

        [HttpPost]
        public async Task<ActionResult> Edit(MenuCreate model)
        {
            if (ModelState.IsValid)
            {
                var obj = ModelFactory.Create(model);
                await Service.Menues.UpdateAsync(obj);
            }
            return PartialView();
        }

        public async Task<ActionResult> Delete(int? id)
        {
            if(id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var model = await Service.Menues.GetAsync(id.Value);
            if (model == null)
                return new HttpNotFoundResult();
            return PartialView(model);
        }

        [HttpPost,ActionName("Delete")]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            await Service.Menues.RemoveAsync(id);
            return PartialView();
        }
    }
}