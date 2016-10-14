using System.Linq;
using System.Web.Http;
using Eron.core.Encode;
using Eron.core.Models.FileHelper;
using Eron.core.Services;

namespace Eron.webApi.Controllers.SelectListControllers
{
    public class PageSelectListController : BaseApiController
    {
        public PageSelectListController(IRepositoryService repositoryService, IEncode encode, IFileHelper fileHelper) : base(repositoryService, encode, fileHelper)
        {
        }

        public IHttpActionResult Get()
        {
            var model = Service.Pages.Get().Select(x => ModelFactory.SelectList(x.Title,x.Slug));
            return Ok(model);
        }
    }
}
