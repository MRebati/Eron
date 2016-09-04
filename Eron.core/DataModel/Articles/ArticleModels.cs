using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace Eron.core.DataModel.Articles
{
    public class Article : VoteBase
    {

        [Required(ErrorMessage = "*")] 
        [Display(Name = "آدرس متن")]
        public string Slug { get; set; }

        [Required(ErrorMessage = "*")] 
        [Display(Name = "عنوان")]
        public string Title { get; set; }

        [DataType(DataType.Html)]
        [AllowHtml]
        public string ContentData { get; set; }

        [Required(ErrorMessage = "*")] 
        [Display(Name = "خلاصه")]
        public string Summery { get; set; }

        [Display(Name = "نویسنده ( اختیاری )")]
        public string Author { get; set; }

        [Display(Name = "کلمات کلیدی")]
        public string Keywords { get; set; }

        [Display(Name = "مجموعه")]
        public Guid CategoryId { get; set; }
 
        [ForeignKey("CategoryId")]
        public ArticleCategory Category { get; set; }

        public ICollection<File.File> Files { get; set; }

        [Display(Name = "تصویر")]
        public string ImageUrl { get; set; }

        public string Language { get; set; }

        public string Tag { get; set; }

        public string UserId { get; set; }
    }
}