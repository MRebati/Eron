using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Web.DynamicData;
using Eron.core.DataAccess;
using Eron.core.DataAccess.Repositories;
using Eron.core.DataModel.Articles;
using Eron.core.DataModel.Content;
using Eron.core.DataModel.Location;
using Eron.core.DataModel.Page;
using Eron.core.DataModel.Search;

namespace Eron.service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IRepositoryService" in both code and config file together.
    [ServiceContract]
    public interface IRepositoryService
    {
        [OperationContract]
        Repository<Content> Contents();

        [OperationContract]
        Repository<Category> Categories();

        [OperationContract]
        Repository<CommentContent> ContentComments();

        [OperationContract]
        Repository<LikeContent> ContentLikes();

        //Article
        [OperationContract]
        Repository<Article> ArticleContents();

        [OperationContract]
        Repository<ArticleCategory> ArticleCategories();

        [OperationContract]
        Repository<CommentArticle> ArticleComments();

        [OperationContract]
        Repository<LikeArticle> ArticleLikes();

        //Search
        [OperationContract]
        Repository<Tag> Tags();

        //Location
        [OperationContract]
        Repository<GoogleMap> Maps();

        [OperationContract]
        Repository<State> States();

        [OperationContract]
        Repository<SubState> SubStates();

        [OperationContract]
        Repository<Language> Languages();

        //Page
        [OperationContract]
        Repository<Page> Pages();
    }
}
