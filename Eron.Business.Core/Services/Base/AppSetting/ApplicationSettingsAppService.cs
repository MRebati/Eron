using Eron.Business.Core.Infrastructure;
using Eron.Core.AppEnums;
using Eron.DataAccess.Contract.UnitOfWorks;
using Eron.SharedKernel.Helpers.AppSettingsHelper;

namespace Eron.Business.Core.Services.Base.AppSetting
{
    public class ApplicationSettingsAppService : ManagementSystemService, IApplicationSettingsAppService
    {
        public ApplicationSettingsAppService(IManagementUnitOfWork unitOfWork, TenantType tenantType = TenantType.WebService) : base(unitOfWork, tenantType)
        {
        }

        public string GetClientAppSetting(string appSettingKey)
        {
            return ApplicationSettingsHelper.AppSetting("client." + appSettingKey);
        }

        public string GetServerSetting(string appSettingKey)
        {
            return ApplicationSettingsHelper.AppSetting(appSettingKey);
        }

        public TType GetServerSetting<TType>(string appSettingKey)
        {
            return ApplicationSettingsHelper.AppSetting<TType>(appSettingKey);
        }
    }
}
