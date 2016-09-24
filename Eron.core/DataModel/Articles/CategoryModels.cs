using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Eron.core.DataModel.Articles
{
    public class ArticleCategory:EntityBase<long>
    {
        public string Name { get; set; }

        [AllowHtml]
        [DataType(DataType.Html)]
        public string Description { get; set; }

        public bool IsBlog { get; set; }

        public string ImageUrl { get; set; }

        public DateTime Modified { get; set; }

        public ICollection<Article> Articles { get; set; }
    }
}