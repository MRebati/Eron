using System.ComponentModel.DataAnnotations;
using Eron.core.App_GlobalResources;

namespace Eron.core.ViewModels.Navigation
{
    public class MenuList
    {
        [Display(Name="Id",ResourceType = typeof(GlobalResources))]
        public int Id { get; set; }

        [Display(Name = "Name", ResourceType = typeof(GlobalResources))]
        public string Name { get; set; }

        [Display(Name = "Url", ResourceType = typeof(GlobalResources))]
        public string Url { get; set; }

        [Display(Name = "MenuTarget", ResourceType = typeof(GlobalResources))]
        public string Target { get; set; }

        [Display(Name = "ParentMenu", ResourceType = typeof(GlobalResources))]
        public string MenuName { get; set; }

        [Display(Name = "ParentMenu", ResourceType = typeof(GlobalResources))]
        public string MenuId { get; set; }

        [Display(Name = "SubMenu", ResourceType = typeof(GlobalResources))]
        public bool IsSubMenu { get; set; }

        [Display(Name="MenuType",ResourceType = typeof(GlobalResources))]
        public string Type { get; set; }
    }
}