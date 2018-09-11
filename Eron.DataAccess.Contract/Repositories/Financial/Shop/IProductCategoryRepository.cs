using System.Collections.Generic;
using System.Threading.Tasks;
using Eron.Core.Entities.Financial.Shop;
using Eron.DataAccess.Contract.Infrastructure;

namespace Eron.DataAccess.Contract.Repositories.Financial.Shop
{
    public interface IProductCategoryRepository: IRepository<ProductCategory>
    {
        Task<List<ProductCategory>> GetFullCategories();

        Task<List<ProductCategory>> GetHomePageCategories();
        
    }
}
