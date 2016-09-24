using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using Eron.core.ValueObjects;

namespace Eron.core.DataModel.Page
{
    public class Page:ReportingBase<int>,IInsight
    {
        public string Title { get; set; }

        public string Slug { get; set; }

        [AllowHtml]
        [DataType(DataType.Html)]
        public string Content { get; set; }

        public string UserId { get; set; }

        public string Language { get; set; }

        public string Description { get; set; }

        public string Keywords { get; set; }

        public long Views { get; set; }
    }
}