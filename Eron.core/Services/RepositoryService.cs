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
        private Repository<Article> _article;
        private Repository<Content> _content;
        private Repository<ArticleCategory> _articleCategory;
        private Repository<Category> _contentCategory;
        private Repository<LikeArticle> _articleLike;
        private Repository<LikeContent> _contentLike;
        private Repository<CommentArticle> _articleComment;
        private Repository<CommentContent> _contentComment;
        private Repository<Tag> _tag;
        private Repository<State> _state;
        private Repository<SubState> _subState;
        private Repository<GoogleMap> _map;
        private Repository<Language> _language;
        private Repository<Page> _page;
        private Repository<Menu> _menu;
        private Repository<Footer> _footer;  

        public RepositoryService(Encode.Encode encode)
        {
            this._context = new ApplicationDbContext();
            this.user = new IdentityDbContext<ApplicationUser>();
            this._encode = encode;
        }

        public Repository<Article> ArticleContents
        {
            get
            {
                if(_article == null)
                    _article = new ArticleRepository(_context,_encode);
                return _article;
            }
        }

        public Repository<Content> Contents
        {
            get
            {
                if(_content == null)
                    _content = new DataAccess.Repositories.Content.ContentRepository(_context,_encode);
                return _content;
            }
        }

        public Repository<Category> Categories
        {
            get
            {
                if(_contentCategory == null)
                    _contentCategory = new DataAccess.Repositories.Content.CategoryRepository(_context,_encode);
                return _contentCategory;
            }
        }

        public Repository<ArticleCategory> ArticleCategories
        {
            get
            {
                if(_articleCategory == null)
                    _articleCategory = new DataAccess.Repositories.Articles.ArticleCategoryRepository(_context,_encode);
                return _articleCategory;
            }
        }

        public Repository<CommentArticle> ArticleComments
        {
            get
            {
                if(_articleComment == null)
                    _articleComment = new CommentRepository(_context,_encode);
                return _articleComment;
            }
        }

        public Repository<LikeArticle> ArticleLikes
        {
            get
            {
                if(_articleLike == null)
                    _articleLike = new ArticleLikeRepository(_context,_encode);
                return _articleLike;
            }
        }

        public Repository<Tag> Tags
        {
            get
            {
                if (_tag == null)
                    _tag = new TagRepository(_context, _encode);
                return _tag;
            }
        }

        public Repository<GoogleMap> Maps
        {
            get
            {
                if(_map == null)
                    _map = new GoogleMapRepository(_context,_encode);
                return _map;
            }
        }

        public Repository<State> States
        {
            get
            {
                if(_state == null)
                    _state = new StateRepository(_context,_encode);
                return _state;
            }
        }

        public Repository<SubState> SubStates
        {
            get
            {
                if(_subState == null)
                    _subState = new SubStateRepository(_context,_encode);
                return _subState;
            }
        }

        public Repository<Language> Languages
        {
            get
            {
                if(_language == null)
                    _language = new LanguageRepository(_context,_encode);
                return _language;
            }
        }

        public IdentityDbContext<ApplicationUser> User { get { return user; } }

        public Repository<Page> Pages
        {
            get
            {
                if(_page == null)
                    _page = new PageRepository(_context,_encode);
                return _page;
            }
        }

        public Repository<Menu> Menues
        {
            get
            {
                if(_menu == null)
                    _menu = new MenuRepository(_context,_encode);
                return _menu;
            }
        }

        public Repository<Footer> Footers
        {
            get
            {
                if(_footer == null)
                    _footer = new FooterRepository(_context,_encode);
                return _footer;
            }
        }

        public Repository<CommentContent> ContentComments
        {
            get
            {
                if(_contentComment == null)
                    _contentComment = new DataAccess.Repositories.Content.CommentRepository(_context,_encode);
                return _contentComment;
            }
        }

        public Repository<LikeContent> ContentLikes
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