using Eron.Core.Entities.Blog;
using Eron.DataAccess.Contract.Infrastructure;

namespace Eron.DataAccess.Contract.Repositories.Blog
{
    public interface IBlogRepository: IRepository<Core.Entities.Blog.Blog>
    {
    }

    public interface IBlogArchiveRepository : IRepository<BlogArchive>
    {

    }

    public interface ICommentRepository : IRepository<Comment>
    {
    }

    public interface ILikeRepository : IRepository<Like>
    {
    }

    public interface IHashTagRepository : IRepository<HashTag>
    {
    }
}
