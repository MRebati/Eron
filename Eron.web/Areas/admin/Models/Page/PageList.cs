using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Eron.core.App_GlobalResources;

namespace Eron.web.Areas.admin.Models.Page
{
    public class PageList
    {
        public string Id { get; set; }

        [Display(Name ="Title",ResourceType = typeof(GlobalResources))]
        public string Title { get; set; }

        [Display(Name = "Address", ResourceType = typeof(GlobalResources))]
        public string PageUrl { get; set; }

        [Display(Name = "User", ResourceType = typeof(GlobalResources))]
        public string UserName { get; set; }

        [Display(Name = "CreateTime", ResourceType = typeof(GlobalResources))]
        public string CreateTime { get; set; }

        [Display(Name = "Language", ResourceType = typeof(GlobalResources))]
        public string Language { get; set; }
    }
}