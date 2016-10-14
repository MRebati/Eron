using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Eron.web.Areas.admin.Models
{
    public class SelectListItem<TKey>
    {
        public TKey Id { get; set; }

        public string Name { get; set; }
    }

    public class SelectListItem
    {
        public string Id { get; set; }

        public string Name { get; set; }
    }

}