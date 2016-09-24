using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Eron.core.DataAccess.Repositories.Content
{
    public class ContentRepository:Repository<DataModel.Content.Content,long>
    {
        public ContentRepository(ApplicationDbContext context, Encode.Encode encode) : base(context, encode) { }
    }
}