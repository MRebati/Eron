using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Eron.core.ValueObjects;

namespace Eron.core.DataModel.Registry
{
    public class ContentRegistry:EntityBase<string>
    {
        public ContentRegistryType Type { get; set; }

        public string Value { get; set; }
    }
}