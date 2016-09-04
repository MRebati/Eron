using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Eron.core.App_GlobalResources;
using Eron.core.Encode;
using Eron.core.Services;
using Eron.web.Areas.admin.Models.Category;
using Eron.web.Models.FileHelper;

namespace Eron.web.Areas.admin.Controllers
{
    public class ContentCategoryController : BaseController
    {
        public ContentCategoryController(IRepositoryService repositoryService, IEncode encode, IFileHelper fileHelper) : base(repositoryService, encode, fileHelper)
        {
        }

        public ActionResult Index()
        {
            ViewBag.Title = GlobalResources.AllCategories;
            var model = Service.Categories.Get().Select(x => ModelFactory.ListCreate(x)).ToList();
            return PartialView(model);
        }

        public ActionResult Create()
        {
            ViewBag.Title = GlobalResources.CreateCategory;
            return PartialView();
        }

        [HttpPost]
        public ActionResult Create(CategoryCreate model, HttpPostedFileBase background, HttpPostedFileBase image)
        {
            if (ModelState.IsValid)
            {

                var category = ModelFactory.Create(model);

                if (background != null)
                    category.BackgroundUrl = FileHelper.Create(FileType.CategoryBackground, background, model.Name);
                if (image != null)
                    category.ImageUrl = FileHelper.Create(FileType.CategoryImage, image, model.Name);

                Service.Categories.Insert(category);
                ViewBag.Message = "success";
                return PartialView();
            }
            ViewBag.Message = "fail";
            return PartialView(model);
        }

        public ActionResult Edit(string id)
        {
            var model = ModelFactory.EditCreate(Service.Categories.Get(id));
            return PartialView(model);
        }

        [HttpPost]
        public ActionResult Edit(CategoryEdit model, HttpPostedFileBase image, HttpPostedFileBase background)
        {
            if (ModelState.IsValid)
            {
                var category = ModelFactory.Create(model);

                //check for background file
                if (background != null && background.ContentLength > 0)
                    category.BackgroundUrl = FileHelper.Update(category.BackgroundUrl, background, category.Name,
                        FileType.CategoryBackground);

                //check for Image file
                if (image!= null && image.ContentLength > 0)
                    category.ImageUrl = FileHelper.Update(category.ImageUrl, image, category.Name,
                        FileType.CategoryImage);

                Service.Categories.Update(category);
                return RedirectToAction("Index");
            }
            return PartialView(model);
        }

        public ActionResult Delete(string id)
        {
            ViewBag.Title = GlobalResources.DeleteCategory;
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var model = ModelFactory.ListCreate(Service.Categories.Get(id));
            if (model == null) return new HttpStatusCodeResult(HttpStatusCode.NotFound);
            return PartialView(model);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(string id)
        {
            var model = Service.Categories.Get(id);
            if (!string.IsNullOrEmpty(model.ImageUrl))
                FileHelper.Remove(model.ImageUrl);
            if (!string.IsNullOrEmpty(model.BackgroundUrl))
                FileHelper.Remove(model.BackgroundUrl);
            int i = Service.Categories.Remove(id);
            return RedirectToAction("Index");
        }
    }
}