using System.Web.Http;
using Eron.core.Encode;
using Eron.core.Models.FileHelper;
using Eron.core.Services;
using Eron.core.ViewModels;

namespace Eron.webApi.Controllers
{
    public class BaseApiController : ApiController
    {
        private IFileHelper _fileHelper;
        private IRepositoryService _repositoryService;
        private IModelFactory _modelFactory;
        private IEncode _encode;
        public BaseApiController(IRepositoryService repositoryService, IEncode encode, IFileHelper fileHelper)
        {
            _fileHelper = fileHelper;
            _encode = encode;
            _modelFactory = new ModelFactory(encode, System.Web.HttpContext.Current, repositoryService);
            _repositoryService = repositoryService;
        }

        protected IFileHelper FileHelper => _fileHelper;
        protected IEncode Encode => _encode;
        protected IRepositoryService Service => _repositoryService;
        protected IModelFactory ModelFactory => _modelFactory;
    }
}