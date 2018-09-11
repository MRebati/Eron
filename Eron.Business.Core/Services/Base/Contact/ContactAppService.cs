using Eron.Business.Core.Infrastructure;
using Eron.Core.AppEnums;
using Eron.DataAccess.Contract.UnitOfWorks;

namespace Eron.Business.Core.Services.Base.Contact
{
    public class ContactAppService : ManagementSystemService, IContactAppService
    {
        public ContactAppService(
            IManagementUnitOfWork unitOfWork,
            TenantType tenantType = TenantType.WebService
        ) : base(unitOfWork, tenantType)
        {
        }
    }

    public interface IContactAppService : IApplicationService
    {
    }
}
