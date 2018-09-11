using System.Collections.Generic;
using System.Threading.Tasks;
using Eron.Core.Entities.Financial.Base;
using Eron.DataAccess.Contract.Infrastructure;

namespace Eron.DataAccess.Contract.Repositories.Financial.Base
{
    public interface IInvoiceRepository: IRepository<Invoice>
    {
        Task<List<Invoice>> GetByNumberListAsync(List<string> invoiceNumberList);

        int GetInvoiceAmount(long invoiceId);

        Task<int> GetInvoiceAmountAsync(long invoiceId);
    }
}
