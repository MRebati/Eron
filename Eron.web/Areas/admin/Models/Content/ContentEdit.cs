using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Eron.core.App_GlobalResources;

namespace Eron.web.Areas.admin.Models.Content
{
    public class ContentEdit
    {
        public long Id { get; set; }

        [Display(Name = "Title", ResourceType = typeof(GlobalResources))]
        [Required(ErrorMessageResourceType = typeof(GlobalResources), ErrorMessageResourceName = "Required")]
        public string Title { get; set; }

        [Display(Name = "Slug", ResourceType = typeof(GlobalResources))]
        [Required(ErrorMessageResourceType = typeof(GlobalResources), ErrorMessageResourceName = "Required")]
        public string Slug { get; set; }

        [Display(Name = "Summery", ResourceType = typeof(GlobalResources))]
        public string Summery { get; set; }

        [AllowHtml]
        [DataType(DataType.Html)]
        [Display(Name = "ContentData", ResourceType = typeof(GlobalResources))]
        public string Content { get; set; }

        [Display(Name = "Category", ResourceType = typeof(GlobalResources))]
        public string CategoryId { get; set; }

        [Display(Name = "PublishStartTime", ResourceType = typeof(GlobalResources))]
        public string PublishStartTime { get; set; }

        [Display(Name = "PublishEndTime", ResourceType = typeof(GlobalResources))]
        public string PublishEndTime { get; set; }

        [Display(Name = "Image", ResourceType = typeof(GlobalResources))]
        public string ImageUrl { get; set; }

        [Display(Name = "Tag", ResourceType = typeof(GlobalResources))]
        public string Tag { get; set; }

        [Display(Name = "Keywords", ResourceType = typeof(GlobalResources))]
        public string Keywords { get; set; }

        [Display(Name = "Published", ResourceType = typeof(GlobalResources))]
        public bool Published { get; set; }

        [Display(Name = "ShowDateTime", ResourceType = typeof(GlobalResources))]
        public bool ShowDateTime { get; set; }

        [Display(Name = "ShowAuthor", ResourceType = typeof(GlobalResources))]
        public bool ShowAuthor { get; set; }

        public DateTime CreateTime { get; set; }

        public DateTime ModifiedTime { get; set; }

        public string UserId { get; set; }

        [Display(Name = "Author", ResourceType = typeof(GlobalResources))]
        public string Author { get; set; }

        [Display(Name = "Language", ResourceType = typeof(GlobalResources))]
        public string Language { get; set; }

        [Display(Name = "IsGlobal", ResourceType = typeof(GlobalResources))]
        public bool IsGlobal { get; set; }
    }
}