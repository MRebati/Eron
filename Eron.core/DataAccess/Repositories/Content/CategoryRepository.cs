using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Eron.core.DataModel.Content;

namespace Eron.core.DataAccess.Repositories.Content
{
    public class CategoryRepository: Repository<Category>
    {
        public CategoryRepository(ApplicationDbContext context, Encode.Encode encode) : base(context, encode) { }
    }
}