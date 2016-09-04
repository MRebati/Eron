using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Eron.core.DataAccess;
using Eron.core.Encode;
using Eron.core.Services;
using Eron.web.Areas.admin.Models;
using Eron.web.Models.FileHelper;

namespace Eron.web.Areas.admin.Controllers
{
    public class BaseController : Controller
    {
        private IFileHelper _fileHelper;
        private IRepositoryService _repositoryService;
        private IModelFactory _modelFactory;
        private IEncode _encode;
        public BaseController(IRepositoryService repositoryService,IEncode encode,IFileHelper fileHelper)
        {
            _fileHelper = fileHelper;
            _encode = encode;
            _modelFactory = new ModelFactory(encode,System.Web.HttpContext.Current, repositoryService);
            _repositoryService = repositoryService;
        }

        protected IFileHelper FileHelper => _fileHelper;
        protected IEncode Encode => _encode;
        protected IRepositoryService Service => _repositoryService;
        protected IModelFactory ModelFactory => _modelFactory;
    }
}