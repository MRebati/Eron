using Eron.Business.Core.Infrastructure;

namespace Eron.Business.Core.Services.Base.AppSetting
{
    public interface IApplicationSettingsAppService: IApplicationService
    {
        string GetClientAppSetting(string appSettingsKey);
    }
}