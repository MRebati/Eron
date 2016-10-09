using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Eron.core.DataModel.Articles
{
    public class CommentArticle:EntityBase<Guid>
    {
        public string UserId { get; set; }

        public string ContentData { get; set; }

        public bool ReplyToComment { get; set; }

        public int BadAnswer { get; set; }

        public long ArticleId { get; set; }

        [ForeignKey("ArticleId")]
        public Article Article { get; set; }
    }
}