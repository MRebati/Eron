using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Eron.core.DataModel.Articles;

namespace Eron.core.DataAccess.Repositories.Articles
{
    public class ArticleLikeRepository:Repository<LikeArticle>
    {
        public ArticleLikeRepository(ApplicationDbContext context,Encode.Encode encode) : base(context,encode)
        {
        }
    }
}