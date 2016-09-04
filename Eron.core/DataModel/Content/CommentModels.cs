using System;
using System.ComponentModel.DataAnnotations.Schema;
using Eron.core.ValueObjects;

namespace Eron.core.DataModel.Content
{
    public class CommentContent:ReportingBase
    {
        public Guid ContentId { get; set; }

        public string UserName { get; set; }

        public string UserId { get; set; }

        public string ContentData { get; set; }

        public bool ReplyToComment { get; set; }

        public int BadAnswer { get; set; }

        [ForeignKey("ContentId")]
        public Content Content { get; set; }
    }
}