using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Eron.core.DataAccess.Repositories.Page
{
    public class PageRepository:Repository<DataModel.Page.Page,int>
    {
        public PageRepository(ApplicationDbContext context, Encode.Encode encode) : base(context, encode)
        {
        }
    }
}