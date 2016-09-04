using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Eron.core.DataModel.Navigation;

namespace Eron.core.DataAccess.Repositories.Navigation
{
    public class MenuRepository :Repository<Menu>
    {
        public MenuRepository(ApplicationDbContext context, Encode.Encode encode) : base(context, encode)
        {
        }
    }
}