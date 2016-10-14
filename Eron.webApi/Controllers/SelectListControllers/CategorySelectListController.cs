using System.Linq;
using System.Web.Http;
using Eron.core.Encode;
using Eron.core.Models.FileHelper;
using Eron.core.Services;

namespace Eron.webApi.Controllers.SelectListControllers
{
    public class CategorySelectListController : BaseApiController
    {
        public CategorySelectListController(IRepositoryService repositoryService, IEncode encode, IFileHelper fileHelper) : base(repositoryService, encode, fileHelper)
        {
        }

        public IHttpActionResult Get()
        {
            var model = Service.Categories.Get().Select(x => ModelFactory.SelectList(x.Name, x.Name));
            return Ok(model);
        }
    }
}
