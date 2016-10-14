﻿using System.ComponentModel.DataAnnotations;
using Eron.core.App_GlobalResources;

namespace Eron.core.ViewModels.Category
{
    public class CategoryList
    {
        public long Id { get; set; }

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