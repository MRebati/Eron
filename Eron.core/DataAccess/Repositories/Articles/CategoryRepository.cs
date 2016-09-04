using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Eron.core.DataModel.Articles;

namespace Eron.core.DataAccess.Repositories.Articles
{
    public class ArticleCategoryRepository: Repository<ArticleCategory>
    {
        public ArticleCategoryRepository(ApplicationDbContext context, Encode.Encode encode) : base(context, encode) { }
    }
}