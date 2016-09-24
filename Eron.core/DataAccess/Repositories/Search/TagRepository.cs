using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Eron.core.DataModel.Search;

namespace Eron.core.DataAccess.Repositories.Search
{
    public class TagRepository:Repository<Tag,long>
    {
        public TagRepository(ApplicationDbContext context, Encode.Encode encode) : base(context, encode)
        {
        }
    }
}