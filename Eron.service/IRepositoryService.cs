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
        Repository<Content,long> Contents();

        [OperationContract]
        Repository<Category,long> Categories();

        [OperationContract]
        Repository<CommentContent, Guid> ContentComments();

        [OperationContract]
        Repository<LikeContent, Guid> ContentLikes();

        //Article
        [OperationContract]
        Repository<Article,long> ArticleContents();

        [OperationContract]
        Repository<ArticleCategory,long> ArticleCategories();

        [OperationContract]
        Repository<CommentArticle, Guid> ArticleComments();

        [OperationContract]
        Repository<LikeArticle, Guid> ArticleLikes();

        //Search
        [OperationContract]
        Repository<Tag,long> Tags();

        //Location
        [OperationContract]
        Repository<GoogleMap,Guid> Maps();

        [OperationContract]
        Repository<State,long> States();

        [OperationContract]
        Repository<SubState,long> SubStates();

        [OperationContract]
        Repository<Language,int> Languages();

        //Page
        [OperationContract]
        Repository<Page,int> Pages();
    }
}
