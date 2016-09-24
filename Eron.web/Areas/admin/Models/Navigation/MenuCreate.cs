using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Eron.core.App_GlobalResources;
using Eron.core.ValueObjects;

namespace Eron.web.Areas.admin.Models.Navigation
{
    public class MenuCreate
    {
        [Display(Name = "Id",ResourceType = typeof(GlobalResources))]
        public int? Id { get; set; }

        [Required(ErrorMessageResourceType = typeof(GlobalResources), ErrorMessageResourceName = "Required")]
        [Display(Name = "Name", ResourceType = typeof(GlobalResources))]
        public string Name { get; set; }

        [Required(ErrorMessageResourceType = typeof(GlobalResources),ErrorMessageResourceName = "Required")]
        [Display(Name = "Url", ResourceType = typeof(GlobalResources))]
        public string Url { get; set; }

        [Display(Name = "MenuTarget", ResourceType = typeof(GlobalResources))]
        public bool? Target { get; set; }

        [Display(Name = "ParentMenu", ResourceType = typeof(GlobalResources))]
        public string MenuId { get; set; }

        [Display(Name = "SubMenu", ResourceType = typeof(GlobalResources))]
        public bool? IsSubMenu { get; set; }

        [Display(Name = "Category", ResourceType = typeof(GlobalResources))]
        public string Category { get; set; }

        [Display(Name = "Content", ResourceType = typeof(GlobalResources))]
        public string Content { get; set; }

        [Display(Name = "Page", ResourceType = typeof(GlobalResources))]
        public string Page { get; set; }

        //[Display(Name = "Gallery", ResourceType = typeof(GlobalResources))]
        //public string Gallery { get; set; }

        public MenuType Type { get; set; }
    }
}