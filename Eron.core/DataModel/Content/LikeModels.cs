using System;

namespace Eron.core.DataModel.Content
{
    public class LikeContent:ReportingBase
    {

        public Guid ContentId { get; set; }

        public string UserId { get; set; }

        public bool Viewed { get; set; }
    }
}