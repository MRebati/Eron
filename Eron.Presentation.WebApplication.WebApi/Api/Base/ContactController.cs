using System.Web.Http;
using Eron.Business.Core.Services.Base.Contact.Dto;
using Eron.Presentation.WebApplication.WebApi.Infrastructure;

namespace Eron.Presentation.WebApplication.WebApi.Api.Base
{
    public class ContactController: BaseApiController
    {
        public IHttpActionResult Post(ContactCreateDto input)
        {
            return Ok("Message Delivered Successfully!");
        }
    }
}