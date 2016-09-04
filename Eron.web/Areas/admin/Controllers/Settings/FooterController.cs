using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Eron.core.Encode;
using Eron.core.Services;
using Eron.web.Areas.admin.Models.Navigation;
using Eron.web.Models.FileHelper;

namespace Eron.web.Areas.admin.Controllers.Settings
{
    public class FooterController : BaseController
    {
        public FooterController(IRepositoryService repositoryService, IEncode encode, IFileHelper fileHelper) : base(repositoryService, encode, fileHelper)
        {
        }

        public ActionResult Index()
        {
            return PartialView();
        }

        public async Task<ActionResult> List()
        {
            var model = await Service.Menues.GetIQueryable().Select(x => ModelFactory.ListCreate(x)).ToListAsync();
            return PartialView(model);
        }

        public ActionResult Create()
        {
            ViewBag.MenuId =
                new SelectList(Service.Menues.GetIQueryable().Select(x => ModelFactory.SelectList(x.Name, x.Id)), "Id",
                    "Name");
            return PartialView();
        }

        [HttpPost]
        public async Task<ActionResult> Create(MenuCreate model)
        {
            ViewBag.MenuId =
                new SelectList(Service.Menues.GetIQueryable().Select(x => ModelFactory.SelectList(x.Name, x.Id)), "Id",
                    "Name",model.MenuId);
            if (ModelState.IsValid)
            {
                var obj = ModelFactory.Create(model);
                await Service.Menues.InsertAsync(obj);
            }
            return PartialView();
        }

        public async Task<ActionResult> Edit(string id)
        {
            if(id == null || id.Length != 11)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var model = await Service.Menues.GetAsync(id);
            if(model == null)
                return new HttpNotFoundResult();
            ViewBag.MenuId =
                new SelectList(Service.Menues.GetIQueryable().Select(x => ModelFactory.SelectList(x.Name, x.Id)), "Id",
                    "Name", model.MenuId);
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

        public async Task<ActionResult> Delete(string id)
        {
            if(id == null || id.Length != 11)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var model = await Service.Menues.GetAsync(id);
            if (model == null)
                return new HttpNotFoundResult();
            return PartialView(model);
        }

        [HttpPost,ActionName("Delete")]
        public async Task<ActionResult> DeleteConfirmed(string id)
        {
            await Service.Footers.RemoveAsync(id);
            return PartialView();
        }
    }
}