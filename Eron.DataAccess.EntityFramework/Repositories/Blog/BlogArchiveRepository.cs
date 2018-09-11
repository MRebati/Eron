using System.Data.Entity;
using Eron.Core.Entities.Blog;
using Eron.DataAccess.Contract.Repositories.Blog;
using Eron.DataAccess.EntityFramework.Infrastructure;

namespace Eron.DataAccess.EntityFramework.Repositories.Blog
{
    public class BlogArchiveRepository : Repository<BlogArchive>, IBlogArchiveRepository
    {
        public BlogArchiveRepository(DbContext context) : base(context)
        {
        }
    }
}