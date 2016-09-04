using System;
using System.Collections.Generic;
using Eron.core.ValueObjects;

namespace Eron.core.DataModel.Navigation
{
    public class Menu: EntityBase
    {
        public string Name { get; set; }

        public string Url { get; set; }

        public string Target { get; set; }

        public Guid? MenuId { get; set; }

        public ICollection<Menu> Menus { get; set; }

        public MenuType Type { get; set; }
    }
}