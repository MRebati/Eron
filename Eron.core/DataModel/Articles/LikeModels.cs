using System;

namespace Eron.core.DataModel.Articles
{
    public class LikeArticle:EntityBase<Guid>
    {
        public Guid ArticleId { get; set; }

        public string UserId { get; set; }

        public bool Viewed { get; set; }
        public bool Positive { get; set; }
    }
}