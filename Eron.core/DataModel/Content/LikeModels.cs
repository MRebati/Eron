using System;

namespace Eron.core.DataModel.Content
{
    public class LikeContent:EntityBase<Guid>
    {

        public Guid ContentId { get; set; }

        public string UserId { get; set; }

        public bool Viewed { get; set; }

        public DateTime DateTime { get; set; }
    }
}