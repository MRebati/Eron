using Eron.Core.AppEnums;
using Eron.DataAccess.Contract.UnitOfWorks;

namespace Eron.Business.Core.Infrastructure
{
    public class ManagementSystemService : ISystemService
    {
        protected IManagementUnitOfWork UnitOfWork;
        protected TenantType TenantType;

        public ManagementSystemService(IManagementUnitOfWork unitOfWork, TenantType tenantType = TenantType.WebService)
        {
            UnitOfWork = unitOfWork;
        }
    }
}