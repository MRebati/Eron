using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Eron.core.App_GlobalResources;

namespace Eron.web.Areas.admin.Models.Content
{
    public class ContentListView
    {
        public long Id { get; set; }

        [Display(Name = "Title",ResourceType = typeof(GlobalResources))]
        public string Title { get; set; }

        [Display(Name = "Slug", ResourceType = typeof(GlobalResources))]
        public string Slug { get; set; }

        [Display(Name = "CreateTime", ResourceType = typeof(GlobalResources))]
        public string CreateTime { get; set; }

        [Display(Name = "ModifiedTime", ResourceType = typeof(GlobalResources))]
        public string ModifiedTime { get; set; }

        [Display(Name = "Author", ResourceType = typeof(GlobalResources))]
        public string Author { get; set; }

        [Display(Name = "Category", ResourceType = typeof(GlobalResources))]
        public string CategoryName { get; set; }

        [Display(Name = "ContentState", ResourceType = typeof(GlobalResources))]
        public string State { get; set; }

        [Display(Name = "PublishStartTime", ResourceType = typeof(GlobalResources))]
        public string PublishStartTime { get; set; }

        [Display(Name = "PublishEndTime", ResourceType = typeof(GlobalResources))]
        public string PublishEndTime { get; set; }
    }
}