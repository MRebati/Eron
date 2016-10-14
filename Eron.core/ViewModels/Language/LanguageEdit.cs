using System.ComponentModel.DataAnnotations;
using Eron.core.App_GlobalResources;

namespace Eron.core.ViewModels.Language
{
    public class LanguageEdit
    {
        public int Id { get; set; }

        [Display(Name = "LocalName", ResourceType = typeof(GlobalResources))]
        public string LocalName { get; set; }

        [Display(Name = "EnglishName", ResourceType = typeof(GlobalResources))]
        public string EnglishName { get; set; }

        [Display(Name = "Flag", ResourceType = typeof(GlobalResources))]
        public string FlagUrl { get; set; }

        [Display(Name = "LanguageCode", ResourceType = typeof(GlobalResources))]
        public string LanguageCode { get; set; }
    }
}