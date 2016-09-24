using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Eron.core.DataAccess;
using Eron.core.DataAccess.Repositories;
using Eron.core.DataAccess.Repositories.Articles;
using Eron.core.DataAccess.Repositories.Location;
using Eron.core.DataAccess.Repositories.Navigation;
using Eron.core.DataAccess.Repositories.Page;
using Eron.core.DataAccess.Repositories.Search;
using Eron.core.DataModel.Articles;
using Eron.core.DataModel.Content;
using Eron.core.DataModel.Location;
using Eron.core.DataModel.Navigation;
using Eron.core.DataModel.Page;
using Eron.core.DataModel.Search;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Eron.core.Services
{
    public class RepositoryService:IRepositoryService
    {
        private ApplicationDbContext _context;
        private IdentityDbContext<ApplicationUser> user;
        private Encode.Encode _encode;
        private Repository<Article,long> _article;
        private Repository<Content,long> _content;
        private Repository<ArticleCategory,long> _articleCategory;
        private Repository<Category,long> _contentCategory;
        private Repository<LikeArticle,Guid> _articleLike;
        private Repository<LikeContent, Guid> _contentLike;
        private Repository<CommentArticle, Guid> _articleComment;
        private Repository<CommentContent, Guid> _contentComment;
        private Repository<Tag,long> _tag;
        private Repository<State, long> _state;
        private Repository<SubState, long> _subState;
        private Repository<GoogleMap, Guid> _map;
        private Repository<Language, int> _language;
        private Repository<Page, int> _page;
        private Repository<Menu, int> _menu;
        private Repository<Footer, int> _footer;  

        public RepositoryService(Encode.Encode encode)
        {
            this._context = new ApplicationDbContext();
            this.user = new IdentityDbContext<ApplicationUser>();
            this._encode = encode;
        }

        public Repository<Article,long> ArticleContents
        {
            get
            {
                if(_article == null)
                    _article = new ArticleRepository(_context,_encode);
                return _article;
            }
        }

        public Repository<Content,long> Contents
        {
            get
            {
                if(_content == null)
                    _content = new DataAccess.Repositories.Content.ContentRepository(_context,_encode);
                return _content;
            }
        }

        public Repository<Category,long> Categories
        {
            get
            {
                if(_contentCategory == null)
                    _contentCategory = new DataAccess.Repositories.Content.CategoryRepository(_context,_encode);
                return _contentCategory;
            }
        }

        public Repository<ArticleCategory, long> ArticleCategories
        {
            get
            {
                if(_articleCategory == null)
                    _articleCategory = new DataAccess.Repositories.Articles.ArticleCategoryRepository(_context,_encode);
                return _articleCategory;
            }
        }

        public Repository<CommentArticle, Guid> ArticleComments
        {
            get
            {
                if(_articleComment == null)
                    _articleComment = new CommentRepository(_context,_encode);
                return _articleComment;
            }
        }

        public Repository<LikeArticle, Guid> ArticleLikes
        {
            get
            {
                if(_articleLike == null)
                    _articleLike = new ArticleLikeRepository(_context,_encode);
                return _articleLike;
            }
        }

        public Repository<Tag,long> Tags
        {
            get
            {
                if (_tag == null)
                    _tag = new TagRepository(_context, _encode);
                return _tag;
            }
        }

        public Repository<GoogleMap, Guid> Maps
        {
            get
            {
                if(_map == null)
                    _map = new GoogleMapRepository(_context,_encode);
                return _map;
            }
        }

        public Repository<State, long> States
        {
            get
            {
                if(_state == null)
                    _state = new StateRepository(_context,_encode);
                return _state;
            }
        }

        public Repository<SubState, long> SubStates
        {
            get
            {
                if(_subState == null)
                    _subState = new SubStateRepository(_context,_encode);
                return _subState;
            }
        }

        public Repository<Language,int> Languages
        {
            get
            {
                if(_language == null)
                    _language = new LanguageRepository(_context,_encode);
                return _language;
            }
        }

        public IdentityDbContext<ApplicationUser> User { get { return user; } }

        public Repository<Page,int> Pages
        {
            get
            {
                if(_page == null)
                    _page = new PageRepository(_context,_encode);
                return _page;
            }
        }

        public Repository<Menu,int> Menues
        {
            get
            {
                if(_menu == null)
                    _menu = new MenuRepository(_context,_encode);
                return _menu;
            }
        }

        public Repository<Footer,int> Footers
        {
            get
            {
                if(_footer == null)
                    _footer = new FooterRepository(_context,_encode);
                return _footer;
            }
        }

        public Repository<CommentContent,Guid> ContentComments
        {
            get
            {
                if(_contentComment == null)
                    _contentComment = new DataAccess.Repositories.Content.CommentRepository(_context,_encode);
                return _contentComment;
            }
        }

        public Repository<LikeContent,Guid> ContentLikes
        {
            get
            {
                if(_contentLike == null)
                    _contentLike = new DataAccess.Repositories.Content.LikeRepository(_context,_encode);
                return _contentLike;
            }
        }
    }
}