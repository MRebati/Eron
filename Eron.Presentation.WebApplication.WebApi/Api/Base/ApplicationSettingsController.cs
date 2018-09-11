using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Eron.Business.Core.Services.Base.AppSetting;
using Eron.Core.ManagementSettings;
using Eron.Presentation.WebApplication.WebApi.Infrastructure;

namespace Eron.Presentation.WebApplication.WebApi.Api.Base
{
    [RoutePrefix("api/appsettings")]
    public class ApplicationSettingsController: BaseApiController
    {
        private readonly IApplicationSettingsAppService _service;

        public ApplicationSettingsController(IApplicationSettingsAppService service)
        {
            _service = service;
        }

        [Route("client/{appSettingsKey}")]
        public IHttpActionResult GetClientAppSetting(string appSettingsKey)
        {
            var result = _service.GetClientAppSetting(appSettingsKey);
            return Ok(result);
        }
    }
}