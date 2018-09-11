using System;
using Eron.Core.Infrastructure;

namespace Eron.Core.Entities.Blog
{
    public class Like: Entity<Guid>
    {
        public virtual Blog Blog { get; set; }

        public long? BlogId { get; set; }

        public virtual Comment Comment { get; set; }

        public Guid? CommentId { get; set; }
    }
}