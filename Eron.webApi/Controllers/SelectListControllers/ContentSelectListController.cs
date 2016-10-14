using System.Data.Entity;
using System.Linq;
using System.Web.Http;
using Eron.core.Encode;
using Eron.core.Models.FileHelper;
using Eron.core.Services;

namespace Eron.webApi.Controllers.SelectListControllers
{
    public class ContentSelectListController : BaseApiController
    {
        public ContentSelectListController(IRepositoryService repositoryService, IEncode encode, IFileHelper fileHelper) : base(repositoryService, encode, fileHelper)
        {
        }

        /// <summary>
        ///     Get All Contents
        /// </summary>
        /// <returns>List of All Contents in SelectList Form</returns>
        public IHttpActionResult Get()
        {
            var model = Service.Contents.Get().Select(x => ModelFactory.SelectList(x.Title, x.Slug));
            return Ok(model);
        }

        /// <summary>
        ///     Get Content SelectList based on Content Categories
        /// </summary>
        /// <param name="id">Name of Content Category</param>
        /// <returns>List of Content [name,slug] SelectList</returns>
        public IHttpActionResult Get(string id)
        {
            var category = Service.Categories.GetIQueryable().FirstOrDefault(x => x.Name == id);
            if(category == null)
                return BadRequest();
            var model = Service.Contents.GetIQueryable().Include(x => x.Category).Where(x => x.Category.Name == id).Select(x => ModelFactory.SelectList(x.Title, x.Slug)).ToList();
            return Ok(model);
        }
    }
}
