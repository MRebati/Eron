using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Eron.core.DataModel.Utilities
{
    public class SliderCategory:EntityBase<long>
    {
        public string Name { get; set; }

        public ICollection<Slider> Slides  { get; set; }
    }
}