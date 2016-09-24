using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Eron.core.DataModel.Navigation;

namespace Eron.core.DataAccess.Repositories.Navigation
{
    public class FooterRepository:Repository<Footer,int>
    {
        public FooterRepository(ApplicationDbContext context, Encode.Encode encode) : base(context, encode)
        {
        }
    }
}