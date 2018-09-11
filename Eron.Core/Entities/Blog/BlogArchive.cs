using System.Collections.Generic;
using Eron.Core.Infrastructure;

namespace Eron.Core.Entities.Blog
{
    public class BlogArchive: Entity<int>
    {
        public string Title { get; set; }

        public ICollection<Blog> Blogs { get; set; }

        public bool IsPublic { get; set; }
    }
}