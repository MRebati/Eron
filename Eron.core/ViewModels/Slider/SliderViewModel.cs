using System.ComponentModel.DataAnnotations;
using Eron.core.App_GlobalResources;

namespace Eron.core.ViewModels.Slider
{
    public class SliderViewModel
    {
        [Display(Name = "Id", ResourceType = typeof(GlobalResources))]
        public long? Id { get; set; }

        [Required(ErrorMessageResourceType = typeof(GlobalResources),ErrorMessageResourceName = "Required")]
        [Display(Name = "Name", ResourceType = typeof(GlobalResources))]
        public string Name { get; set; }

        [Display(Name = "Title", ResourceType = typeof(GlobalResources))]
        public string Title { get; set; }

        [Required(ErrorMessageResourceType = typeof(GlobalResources), ErrorMessageResourceName = "Required")]
        [Display(Name = "Background", ResourceType = typeof(GlobalResources))]
        public string BackgroundUrl { get; set; }

        [Display(Name = "LinkUrl", ResourceType = typeof(GlobalResources))]
        public string LinkUrl { get; set; }

        [Display(Name = "LinkName", ResourceType = typeof(GlobalResources))]
        public string LinkName { get; set; }

        [Display(Name = "PublishStartTime", ResourceType = typeof(GlobalResources))]
        public string StartDate { get; set; }

        [Display(Name = "PublishEndTime", ResourceType = typeof(GlobalResources))]
        public string EndDate { get; set; }

        [Display(Name = "Endable", ResourceType = typeof(GlobalResources))]
        public bool Endable { get; set; }

        [Display(Name = "ShowCaption", ResourceType = typeof(GlobalResources))]
        public bool ShowCaption { get; set; }

        [Display(Name = "ShowTitle", ResourceType = typeof(GlobalResources))]
        public bool ShowTitle { get; set; }
    }
}