using System.Threading.Tasks;
using Eron.Business.Core.Infrastructure;
using Eron.Business.Core.Services.Financial.Base.Bank.Dto;
using Eron.Core.AppEnums;

namespace Eron.Business.Core.Services.Financial.Base.Bank
{
    public interface IBankAppService : IApplicationService
    {
        Task<BankPaymentRequestResponseDto> CreateReference(BankNameType bankName, string userId, long invoiceId);
    }
}