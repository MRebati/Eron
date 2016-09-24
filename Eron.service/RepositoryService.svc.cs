using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Eron.core.DataAccess;
using Eron.core.DataAccess.Repositories;
using Eron.core.DataAccess.Repositories.Articles;
using Eron.core.DataAccess.Repositories.Content;
using Eron.core.DataAccess.Repositories.Location;
using Eron.core.DataAccess.Repositories.Page;
using Eron.core.DataAccess.Repositories.Search;
using Eron.core.DataModel.Articles;
using Eron.core.DataModel.Content;
using Eron.core.DataModel.Location;
using Eron.core.DataModel.Page;
using Eron.core.DataModel.Search;
using CommentRepository = Eron.core.DataAccess.Repositories.Content.CommentRepository;

namespace Eron.service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "RepositoryService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select RepositoryService.svc or RepositoryService.svc.cs at the Solution Explorer and start debugging.
    public class RepositoryService : IRepositoryService
    {
        private ApplicationDbContext _context;
        private AppUser user;
        private core.Encode.Encode _encode;
        private Repository<Article,long> _article;
        private Repository<Content,long> _content;
        private Repository<ArticleCategory,long> _articleCategory;
        private Repository<Category,long> _contentCategory;
        private Repository<LikeArticle,Guid> _articleLike;
        private Repository<LikeContent,Guid> _contentLike;
        private Repository<CommentArticle,Guid> _articleComment;
        private Repository<CommentContent,Guid> _contentComment;
        private Repository<Tag,long> _tag;
        private Repository<State,long> _state;
        private Repository<SubState,long> _subState;
        private Repository<GoogleMap, Guid> _map;
        private Repository<Language,int> _language;
        private Repository<Page,int> _page;

        public Repository<Content,long> Contents()
        {
            return _content ?? (_content = new ContentRepository(_context, _encode));
        }

        public Repository<Category,long> Categories()
        {
            return _contentCategory ?? (_contentCategory = new CategoryRepository(_context, _encode));
        }

        public Repository<CommentContent, Guid> ContentComments()
        {
            return _contentComment ?? (_contentComment = new CommentRepository(_context, _encode));
        }

        public Repository<LikeContent, Guid> ContentLikes()
        {
            return _contentLike ?? (_contentLike = new LikeRepository(_context, _encode));
        }

        public Repository<Article, long> ArticleContents()
        {
            return _article ?? (_article = new ArticleRepository(_context, _encode));
        }

        public Repository<ArticleCategory, long> ArticleCategories()
        {
            return _articleCategory ?? (_articleCategory = new ArticleCategoryRepository(_context, _encode));
        }

        public Repository<CommentArticle, Guid> ArticleComments()
        {
            return _articleComment ??
                   (_articleComment = new core.DataAccess.Repositories.Articles.CommentRepository(_context, _encode));
        }

        public Repository<LikeArticle, Guid> ArticleLikes()
        {
            return _articleLike ?? (_articleLike = new ArticleLikeRepository(_context, _encode));
        }

        public Repository<Tag, long> Tags()
        {
            return _tag ?? (_tag = new TagRepository(_context, _encode));
        }

        public Repository<GoogleMap, Guid> Maps()
        {
            return _map ?? (_map = new GoogleMapRepository(_context, _encode));
        }

        public Repository<State, long> States()
        {
            return _state ?? (_state = new StateRepository(_context, _encode));
        }

        public Repository<SubState, long> SubStates()
        {
            return _subState ?? (_subState = new SubStateRepository(_context, _encode));
        }

        public Repository<Language, int> Languages()
        {
            return _language ?? (_language = new LanguageRepository(_context, _encode));
        }

        public Repository<Page, int> Pages()
        {
            return _page ?? (_page = new PageRepository(_context, _encode));
        }
    }
}
