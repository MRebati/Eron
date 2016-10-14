using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using Eron.core.App_GlobalResources;

namespace Eron.core.ViewModels.Page
{
    public class PageCreate
    {
        public int Id { get; set; }

        [Display(Name = "Title", ResourceType = typeof(GlobalResources))]
        public string Title { get; set; }

        [Display(Name = "Slug", ResourceType = typeof(GlobalResources))]
        public string Slug { get; set; }

        [Required]
        [AllowHtml]
        [DataType(DataType.Html)]
        [Display(Name = "Content", ResourceType = typeof(GlobalResources))]
        public string Content { get; set; }

        [Display(Name = "Language", ResourceType = typeof(GlobalResources))]
        public string Language { get; set; }

        [Display(Name = "CreateTime", ResourceType = typeof(GlobalResources))]
        public DateTime? CreateTime { get; set; }

        [Display(Name = "Description", ResourceType = typeof(GlobalResources))]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [Display(Name = "Keywords", ResourceType = typeof(GlobalResources))]
        public string Keywords { get; set; }
    }
}