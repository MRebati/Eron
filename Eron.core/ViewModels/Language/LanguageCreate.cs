using System.ComponentModel.DataAnnotations;
using Eron.core.App_GlobalResources;

namespace Eron.core.ViewModels.Language
{
    public class LanguageCreate
    {
        [Required(ErrorMessageResourceName = "Required",ErrorMessageResourceType = typeof(GlobalResources))]
        [Display(Name = "LocalName", ResourceType = typeof(GlobalResources))]
        public string LocalName { get; set; }

        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(GlobalResources))]
        [Display(Name = "EnglishName", ResourceType = typeof(GlobalResources))]
        public string EnglishName { get; set; }

        [Display(Name = "Flag", ResourceType = typeof(GlobalResources))]
        public string FlagUrl { get; set; }

        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(GlobalResources))]
        [Display(Name = "LanguageCode", ResourceType = typeof(GlobalResources))]
        public string LanguageCode { get; set; }
    }
}