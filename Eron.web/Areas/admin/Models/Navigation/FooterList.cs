using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Eron.web.Areas.admin.Models.Navigation
{
    public class FooterList
    {
        public bool IsParent { get; set; }

        public string Name { get; set; }

        public string Url { get; set; }

        public string Target { get; set; }

        public string FooterId { get; set; }

        public string FooterName { get; set; }
    }
}