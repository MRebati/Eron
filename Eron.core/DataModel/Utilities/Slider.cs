using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Eron.core.DataModel.Utilities
{
    public class Slider:EntityBase<long>
    {
        public string Name { get; set; }

        public string Title { get; set; }

        public string BackgroundUrl { get; set; }

        public string LinkUrl { get; set; }

        public string LinkName { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public bool Endable { get; set; }

        public bool ShowCaption { get; set; }

        public bool ShowTitle { get; set; }

        public ICollection<SliderCategory> SliderCategories { get; set; }
    }
}