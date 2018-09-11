using System.Collections.Generic;
using Eron.Core.Infrastructure;

namespace Eron.Core.Entities.Blog
{
    public class HashTag: Entity<string>
    {
        public ICollection<Blog> Blogs { get; set; }

        public ICollection<Comment> Comments { get; set; }
    }
}