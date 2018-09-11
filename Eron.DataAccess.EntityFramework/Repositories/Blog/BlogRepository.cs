using System.Data.Entity;
using Eron.DataAccess.Contract.Repositories.Blog;
using Eron.DataAccess.EntityFramework.Infrastructure;

namespace Eron.DataAccess.EntityFramework.Repositories.Blog
{
    public class BlogRepository : Repository<Core.Entities.Blog.Blog>, IBlogRepository
    {
        public BlogRepository(DbContext context) : base(context)
        {
        }
    }
}
