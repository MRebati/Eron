using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Eron.core.App_GlobalResources;
using Eron.core.Encode;
using Eron.core.Services;
using System.Data.Entity;
using System.Net;
using Eron.web.Areas.admin.Models.Content;
using Eron.web.Models.FileHelper;

namespace Eron.web.Areas.admin.Controllers
{
    public class ContentController : BaseController
    {
        public ContentController(IRepositoryService repositoryService, IEncode encode, IFileHelper fileHelper) : base(repositoryService, encode, fileHelper)
        {
        }

        // GET: admin/Content
        public ActionResult Index()
        {
            ViewBag.Title = GlobalResources.AllContent;
            var model = Service.Contents.GetIQueryable().Include(x => x.Category).ToList().Select(x => ModelFactory.Create(x));
            return PartialView(model);
        }

        public ActionResult Create()
        {
            ViewBag.Title = GlobalResources.CreateContent;
            ViewBag.CategoryId = new SelectList(Service.Categories.Get().Select(x => ModelFactory.SelectList(x.Name, x.Id)).ToList(), "Id",
                "Name");
            ViewBag.Language =
                new SelectList(
                    Service.Languages.Get().Select(x => ModelFactory.SelectList(x.EnglishName, x.LanguageCode)), "Id",
                    "Name");
            return PartialView();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ContentCreate model, HttpPostedFileBase image)
        {
            ViewBag.CategoryId = new SelectList(Service.Categories.Get().Select(x => ModelFactory.SelectList(x.Name, x.Id)).ToList(), "Id",
                "Name");
            ViewBag.Language =
                new SelectList(
                    Service.Languages.Get().Select(x => ModelFactory.SelectList(x.EnglishName, x.LanguageCode)), "Id",
                    "Name");
            if (ModelState.IsValid)
            {

                model.ImageUrl = FileHelper.Create(FileType.Image, image, model.Title);
                var content = ModelFactory.Create(model);

                var duplicate =
                    Service.Contents.GetIQueryable()
                        .Include(x => x.Category)
                        .Any(x => x.CategoryId == content.CategoryId && x.Slug == content.Slug && x.Language == content.Language);
                if (duplicate)
                {
                    ModelState.AddModelError("Slug", GlobalResources.DuplicationErrorMessage);
                    return PartialView(model);
                }

                Service.Contents.Insert(content);
                return PartialView();
            }
            return PartialView(model);
        }

        public ActionResult Edit(string id)
        {
            if(id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var model = Service.Contents.Get(id);
            if(model == null)
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);
            var content = ModelFactory.EditCreate(model);

            ViewBag.CategoryId = new SelectList(Service.Categories.Get().Select(x => ModelFactory.SelectList(x.Name, x.Id)).ToList(), "Id",
                "Name");
            ViewBag.Language =
                new SelectList(
                    Service.Languages.Get().Select(x => ModelFactory.SelectList(x.EnglishName, x.LanguageCode)), "Id",
                    "Name");

            return PartialView(content);
        }

        [HttpPost]
        public ActionResult Edit(ContentEdit model,HttpPostedFileBase image)
        {
            ViewBag.CategoryId = new SelectList(Service.Categories.Get().Select(x => ModelFactory.SelectList(x.Name, x.Id)).ToList(), "Id",
                "Name");
            ViewBag.Language =
                new SelectList(
                    Service.Languages.Get().Select(x => ModelFactory.SelectList(x.EnglishName, x.LanguageCode)), "Id",
                    "Name");

            if (ModelState.IsValid)
            {
                var content = ModelFactory.Create(model);

                //check for duplication
                var duplicate =
                    Service.Contents.GetIQueryable()
                        .Any(
                            x =>
                                x.Slug == content.Slug && x.Language == content.Language &&
                                x.IsGlobal == content.IsGlobal && x.CategoryId == content.CategoryId && x.Id != content.Id);
                if (duplicate)
                {
                    ModelState.AddModelError("Slug", GlobalResources.DuplicationErrorMessage);
                    return PartialView(model);
                }
                if (image != null && image.ContentLength > 0)
                {
                    content.ImageUrl = FileHelper.Update(content.ImageUrl, image, content.Title, FileType.Image);
                }
                Service.Contents.Update(content);
                return RedirectToAction("Index");
            }
            return PartialView(model);
        }

        public ActionResult Delete(string id)
        {
            if(String.IsNullOrEmpty(id))
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var code = Encode.GetGuid(id);
            var content = Service.Contents.GetIQueryable().Include(x => x.Category).FirstOrDefault(x => x.Id == code);
            var model = ModelFactory.Create(content);
            if(model== null)
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);
            return PartialView(model);
        }

        [HttpPost,ActionName("Delete")]
        public ActionResult DeleteConfirmed(string id)
        {
            var model = Service.Contents.Get(id);
            if (!String.IsNullOrEmpty(model.ImageUrl))
            {
                FileHelper.Remove(model.ImageUrl);
            }
            return RedirectToAction("Index");
        }
    }
}