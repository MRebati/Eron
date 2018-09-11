using System;
using System.Collections.Generic;
using Eron.Core.Infrastructure;

namespace Eron.Core.Entities.Blog
{
    public class Comment: Entity<Guid>
    {
        public string EmailAddress { get; set; }

        public string Message { get; set; }

        public virtual Blog Blog { get; set; }

        public long? BlogId { get; set; }

        public Guid? ParentId { get; set; }

        public virtual Comment Parent { get; set; }

        public ICollection<Comment> Children { get; set; }

        public bool IsPublic { get; set; }
    }
}