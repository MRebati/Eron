using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Eron.core.Encode;
using Eron.core.Models.FileHelper;
using Eron.core.Services;

namespace Eron.webApi.Controllers
{
    public class RegisteryController : BaseApiController
    {
        public RegisteryController(IRepositoryService repositoryService, IEncode encode, IFileHelper fileHelper) : base(repositoryService, encode, fileHelper)
        {
        }

        public IHttpActionResult Get(string id)
        {
            if(string.IsNullOrEmpty(id))
                return BadRequest("Id is null");
            //todo must create registry data model and Repo.
            return Ok();
        }
    }
}
