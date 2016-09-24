using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Eron.core.App_GlobalResources;
using Eron.core.Encode;
using Eron.core.Services;
using Eron.web.Areas.admin.Models.Language;
using Eron.web.Models.FileHelper;

namespace Eron.web.Areas.admin.Controllers
{
    public class LanguageController : BaseController
    {
        public LanguageController(IRepositoryService repositoryService, IEncode encode, IFileHelper fileHelper) : base(repositoryService, encode, fileHelper)
        {
        }

        // GET: admin/Language
        public ActionResult Index()
        {
            ViewBag.Title = GlobalResources.LanguageSetting;
            var model = Service.Languages.Get().Select(x => ModelFactory.ListCreate(x));
            return PartialView(model);
        }

        public ActionResult Create()
        {
            ViewBag.Title = GlobalResources.CreateLanguage;
            return PartialView();
        }

        [HttpPost]
        public ActionResult Create(LanguageCreate model, HttpPostedFileBase image)
        {
            ViewBag.Title = GlobalResources.CreateLanguage;
            if (ModelState.IsValid)
            {
                if (image != null && image.ContentLength > 0)
                    model.FlagUrl = FileHelper.Create(FileType.Image, image, model.LanguageCode);
                var language = ModelFactory.Create(model);
                var duplicate = Service.Languages.Get().Any(x => x.LanguageCode == model.LanguageCode);
                if (!duplicate)
                    Service.Languages.Insert(language);
                else
                {
                    ModelState.AddModelError("LanguageCode", GlobalResources.DuplicationErrorMessage);
                    return PartialView(model);
                }
                return PartialView();
            }
            return PartialView(model);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var model = Service.Languages.Get(id.Value);
            if (model == null)
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);
            var category = ModelFactory.EditCreate(model);
            return PartialView(category);
        }

        [HttpPost]
        public ActionResult Edit(LanguageEdit model, HttpPostedFileBase image)
        {
            if (ModelState.IsValid)
            {
                var duplicate = Service.Languages.Get().Any(x => x.LanguageCode == model.LanguageCode);
                if (!duplicate)
                {
                    var language = ModelFactory.Create(model);
                    if (image != null && image.ContentLength > 0)
                        language.FlagUrl = FileHelper.Update(language.FlagUrl, image, model.LanguageCode, FileType.Image);
                    Service.Languages.Update(language);
                    return RedirectToAction("Index");
                }
                else
                    ModelState.AddModelError("LanguageCode", GlobalResources.DuplicationErrorMessage);

            }
            return PartialView(model);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var model = Service.Languages.Get(id.Value);
            //if (model == null)
            //    return new HttpStatusCodeResult(HttpStatusCode.NotFound);
            var category = ModelFactory.ListCreate(model);
            return PartialView(category);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            var model = Service.Languages.Get(id);
            if (!String.IsNullOrEmpty(model.FlagUrl))
                FileHelper.Remove(model.FlagUrl);
            Service.Languages.Remove(id);
            return RedirectToAction("Index");
        }
    }
}