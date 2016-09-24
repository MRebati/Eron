using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Eron.core.DataModel.Content;

namespace Eron.core.DataAccess.Repositories.Content
{
    public class CommentRepository:Repository<CommentContent,Guid>
    {
        public CommentRepository(ApplicationDbContext context, Encode.Encode encode) : base(context, encode) { }
    }
}