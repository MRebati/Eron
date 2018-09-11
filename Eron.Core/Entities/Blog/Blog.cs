using System;
using System.Collections.Generic;
using Eron.Core.Entities.Base;
using Eron.Core.Entities.User;
using Eron.Core.Infrastructure;

namespace Eron.Core.Entities.Blog
{
    public class Blog: Entity<long>
    {
        public string Title { get; set; }

        public string AlternativeTitle { get; set; }

        public string Slug { get; set; }

        public string Description { get; set; }

        public string Content { get; set; }

        public ICollection<HashTag> HashTags { get; set; }

        public ICollection<BlogCategory> Categories { get; set; }

        public ICollection<Comment> Comments { get; set; }

        public ICollection<Like> Likes { get; set; }

        public int LikesCount { get; set; }

        public bool IsPromoted { get; set; }

        public bool IsPeriodic { get; set; }

        public DateTime PublishStartDate { get; set; }

        public DateTime PublishEndDate { get; set; }

        public bool ShowOwner { get; set; }

        public ApplicationUser Owner { get; set; }

        public bool HasImage { get; set; }

        public bool HasCoverImage { get; set; }

        public EronFile Image { get; set; }

        public EronFile CoverImage { get; set; }

        public ICollection<EronFile> Gallery { get; set; }

        public bool IsArchived { get; set; }

        public bool ShowInArchive { get; set; }

        public ICollection<Blog> Children { get; set; }

        public Blog Parent { get; set; }

        public long ParentId { get; set; }

        public virtual BlogArchive Archive { get; set; }
        public int? ArchiveId { get; set; }
    }

    public class BlogCategory: Entity<int>
    {
        public string Title { get; set; }

        public string Slug { get; set; }

        public ICollection<Blog> Blogs { get; set; }

        public ICollection<BlogCategory> Children { get; set; }

        public int ParentId { get; set; }

        public BlogCategory Parent { get; set; }
    }
}
