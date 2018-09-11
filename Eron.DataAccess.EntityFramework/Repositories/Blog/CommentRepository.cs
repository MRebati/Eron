using System.Data.Entity;
using Eron.Core.Entities.Blog;
using Eron.DataAccess.Contract.Repositories.Blog;
using Eron.DataAccess.EntityFramework.Infrastructure;

namespace Eron.DataAccess.EntityFramework.Repositories.Blog
{
    public class CommentRepository : Repository<Comment>, ICommentRepository
    {
        public CommentRepository(DbContext context) : base(context)
        {
        }
    }
}