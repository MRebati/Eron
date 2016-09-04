using System;
using System.Collections.Generic;

namespace Eron.core.DataModel.Navigation
{
    public class Footer : EntityBase
    {
        public bool IsParent { get; set; }

        public string Name { get; set; }

        public string Url { get; set; }

        public string Target { get; set; }

        public Guid? FooterId { get; set; }

        public ICollection<Footer> Footers { get; set; }
    }
}