using System.Collections.Generic;
using System.Threading.Tasks;
using Eron.Core.Entities.Base;
using Eron.DataAccess.Contract.Infrastructure;

namespace Eron.DataAccess.Contract.Repositories.Base
{
    public interface IEronFileRepository: IRepository<EronFile>
    {
        Task<IEnumerable<EronFile>> GetProductImages(long productId);
    }
}
