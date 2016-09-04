using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Eron.core.App_GlobalResources;

namespace Eron.web.Areas.admin.Models.Category
{
    public class CategoryList
    {
        public string Id { get; set; }

        [Display(Name = "Name", ResourceType = typeof(GlobalResources))]
        public string Name { get; set; }

        [Display(Name = "Description", ResourceType = typeof(GlobalResources))]
        public string Description { get; set; }

        [Display(Name = "CreateTime", ResourceType = typeof(GlobalResources))]
        public string CreateTime { get; set; }

        [Display(Name = "ModifiedTime", ResourceType = typeof(GlobalResources))]
        public string ModifiedTime { get; set; }

        [Display(Name = "ContentState", ResourceType = typeof(GlobalResources))]
        public string State { get; set; }
    }
}