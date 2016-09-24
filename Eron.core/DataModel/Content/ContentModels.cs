using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;
using Eron.core.ValueObjects;

namespace Eron.core.DataModel.Content
{
    public class Content : ReportingBase<long>,IInsight
    {
        public string Slug { get; set; }

        public string Title { get; set; }

        [DataType(DataType.Html)]
        [AllowHtml]
        public string ContentData { get; set; }

        [Display(Name = "خلاصه")]
        public string Summery { get; set; }

        [Display(Name = "نویسنده ( اختیاری )")]
        public string Author { get; set; }

        public bool ShowAuthor { get; set; }

        public bool ShowDateTime { get; set; }

        [Display(Name = "کلمات کلیدی")]
        public string Keywords { get; set; }

        [Display(Name = "مجموعه")]
        public Guid CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        public Category Category { get; set; }

        public ICollection<File.File> Files { get; set; }

        [Display(Name = "تصویر")]
        public string ImageUrl { get; set; }

        public string Language { get; set; }

        public bool IsGlobal { get; set; }

        public string Tag { get; set; }

        public string UserId { get; set; }

        public bool Published { get; set; }

        public DateTime PublishStartTime { get; set; }

        public DateTime PublishEndTime { get; set; }
        public long Views { get; set; }
    }
}