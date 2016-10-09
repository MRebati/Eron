using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Eron.core.Encode;
using Eron.core.Services;
using Eron.web.Areas.admin.Models;
using Eron.web.Areas.admin.Models.Slider;
using Eron.web.Models.FileHelper;

namespace Eron.web.Areas.admin.Controllers.Addons
{

    //todo: Check for categories CRUD operations. These categories are * - * related with Slides
    public class SliderController : BaseController
    {
        public SliderController(IRepositoryService repositoryService, IEncode encode, IFileHelper fileHelper) : base(repositoryService, encode, fileHelper)
        {
        }

        public ActionResult Index()
        {
            return PartialView();
        }

        public ActionResult List()
        {
            var slides = Service.Sliders.Get();
            var model = slides.Select(x => ModelFactory.ListCreate(x));
            return PartialView(model);
        }

        public ActionResult Create()
        {

            return PartialView(new SliderViewModel());
        }

        [HttpPost]
        public async Task<ActionResult> Create(SliderViewModel model)
        {
            if (ModelState.IsValid)
            {
                var slider = ModelFactory.Create(model);
                await Service.Sliders.InsertAsync(slider);
                return PartialView();
            }
            return PartialView(model);
        }

        public ActionResult Edit()
        {
            return PartialView();
        }

        [HttpPost]
        public async Task<ActionResult> Edit(SliderViewModel model)
        {
            if (ModelState.IsValid)
            {
                var slider = ModelFactory.Create(model);
                await Service.Sliders.UpdateAsync(slider);
            }
            return PartialView();
        }

        public async Task<ActionResult> Delete(long? id)
        {
            if(id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var slider = await Service.Sliders.GetAsync(id.Value);
            var model = ModelFactory.ListCreate(slider);
            return PartialView(model);
        }

        [HttpPost,ActionName("Delete")]
        public async Task<ActionResult> DeleteConfirm(long id)
        {
            var slider =await Service.Sliders.GetAsync(id);
            if(slider.BackgroundUrl!=null)
                FileHelper.Remove(slider.BackgroundUrl);
            await Service.Sliders.RemoveAsync(id);
            return PartialView();
        }
    }
}