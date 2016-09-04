using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Eron.core.App_GlobalResources;

namespace Eron.web.Areas.admin.Models.Language
{
    public class LanguageList
    {
        public string Id { get; set; }

        [Display(Name = "LocalName",ResourceType = typeof(GlobalResources))]
        public string LocalName { get; set; }

        [Display(Name = "EnglishName", ResourceType = typeof(GlobalResources))]
        public string EnglishName { get; set; }

        [Display(Name = "Flag", ResourceType = typeof(GlobalResources))]
        public string FlagUrl { get; set; }

        [Display(Name = "LanguageCode", ResourceType = typeof(GlobalResources))]
        public string LanguageCode { get; set; }
    }
}