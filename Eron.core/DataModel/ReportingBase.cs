using System;
using System.ComponentModel.DataAnnotations;
using Eron.core.App_GlobalResources;

namespace Eron.core.DataModel
{
    public class ReportingBase:EntityBase
    {
        [Display(Name = "UpdateTime",ResourceType = typeof(GlobalResources))]
        public DateTime ModifiedTime { get; set; }

        [Display(Name = "CreateTime",ResourceType = typeof(GlobalResources))]
        public DateTime CreateTime { get; set; }
    }
}