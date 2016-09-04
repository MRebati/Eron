using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Eron.core.App_GlobalResources;

namespace Eron.core.ValueObjects
{
    public enum MenuType
    {
        [Display(Name="Page",ResourceType = typeof(GlobalResources))]
        Page,
        [Display(Name = "Content", ResourceType = typeof(GlobalResources))]
        Content,
        [Display(Name = "InternalLink", ResourceType = typeof(GlobalResources))]
        InternalLink,
        [Display(Name = "ExternalLink", ResourceType = typeof(GlobalResources))]
        ExternalLink,
        [Display(Name = "Category", ResourceType = typeof(GlobalResources))]
        Category
    }
}