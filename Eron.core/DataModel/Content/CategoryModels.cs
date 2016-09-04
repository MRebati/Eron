using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using Eron.core.ValueObjects;

namespace Eron.core.DataModel.Content
{
    public class Category:ReportingBase,IInsight
    {
        public string Name { get; set; }

        [AllowHtml]
        [DataType(DataType.Html)]
        public string Description { get; set; }

        public string ImageUrl { get; set; }

        public string BackgroundUrl { get; set; }

        public DateTime PublishTime { get; set; }

        public bool Published { get; set; }

        public ICollection<Content> Contents { get; set; }
        public long Views { get; set; }
    }
}