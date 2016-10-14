using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using Eron.core.App_GlobalResources;

namespace Eron.core.ViewModels.Category
{
    [DataContract]
    public class CategoryCreate
    {
        [DataMember]
        [Display(Name = "Name", ResourceType = typeof(GlobalResources))]
        public string Name { get; set; }

        [DataMember]
        [Display(Name = "Description", ResourceType = typeof(GlobalResources))]
        public string Description { get; set; }

        [DataMember]
        [Display(Name = "Image", ResourceType = typeof(GlobalResources))]
        public string Image { get; set; }

        [DataMember]
        [Display(Name = "Background", ResourceType = typeof(GlobalResources))]
        public string Background { get; set; }

        [DataMember]
        [Display(Name = "Published", ResourceType = typeof(GlobalResources))]
        public bool Published { get; set; }

        [DataMember]
        [Display(Name = "PublishTime", ResourceType = typeof(GlobalResources))]
        public string PublishTime { get; set; }
    }
}