using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Eron.core.App_GlobalResources;

namespace Eron.web.Areas.admin.Models.Category
{
    public class CategoryEdit
    {
        
        public long Id { get; set; }

        [Display(Name = "Name",ResourceType = typeof(GlobalResources))]
        public string Name { get; set; }

        [Display(Name = "Description", ResourceType = typeof(GlobalResources))]
        public string Description { get; set; }

        [Display(Name = "Image", ResourceType = typeof(GlobalResources))]
        public string Image { get; set; }

        [Display(Name = "Background", ResourceType = typeof(GlobalResources))]
        public string Background { get; set; }

        [Display(Name = "Published", ResourceType = typeof(GlobalResources))]
        public bool Published { get; set; }

        [Display(Name = "CreateTime", ResourceType = typeof(GlobalResources))]
        public DateTime CreateTime { get; set; }

        [Display(Name = "PublishTime", ResourceType = typeof(GlobalResources))]
        public string PublishTime { get; set; }
    }
}