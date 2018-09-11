using System.Web.Http;
using Eron.Core.AppEnums;
using Eron.Presentation.WebApplication.WebApi.Infrastructure;

namespace Eron.Presentation.WebApplication.WebApi.Api.Financial.Base
{
    public class PaymentController: BaseApiController
    {
        public IHttpActionResult Get()
        {
            return Ok();
        }

        public IHttpActionResult MakePayment(BankNameType bankNameType)
        {
            return Ok();
        }

        public IHttpActionResult VerifyPayment(string pspName)
        {
            return Ok();
        }
    }
}