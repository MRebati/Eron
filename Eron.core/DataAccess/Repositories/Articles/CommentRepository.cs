using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Eron.core.DataModel.Articles;

namespace Eron.core.DataAccess.Repositories.Articles
{
    public class CommentRepository:Repository<CommentArticle,Guid>
    {
        public CommentRepository(ApplicationDbContext context, Encode.Encode encode) : base(context, encode) { }
    }
}