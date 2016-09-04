﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls.Expressions;
using Eron.core.DataAccess;
using Eron.core.DataAccess.Repositories;
using Eron.core.DataModel.Articles;
using Eron.core.DataModel.Content;
using Eron.core.DataModel.Location;
using Eron.core.DataModel.Navigation;
using Eron.core.DataModel.Page;
using Eron.core.DataModel.Search;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Eron.core.Services
{
    public interface IRepositoryService
    {

        //Content

        /// <summary>
        /// This Repository will return CRUD Actions related to Contents.
        /// </summary>
        Repository<Content> Contents { get; }

        /// <summary>
        /// This Repository will return CRUD Actions related to Content Categories.
        /// </summary>
        Repository<Category> Categories { get; }

        /// <summary>
        /// This Repository will return CRUD Actions related to Content Comments.
        /// </summary>
        Repository<CommentContent> ContentComments { get; }

        /// <summary>
        /// This Repository will return CRUD Actions related to Content Likes.
        /// </summary>
        Repository<LikeContent> ContentLikes { get; }

        //Article

        /// <summary>
        /// This Repository will return CRUD Actions related to Articles.
        /// </summary>
        Repository<Article> ArticleContents { get; }

        /// <summary>
        /// This Repository will return CRUD Actions related to Article Categories.
        /// </summary>
        Repository<ArticleCategory> ArticleCategories { get; }

        /// <summary>
        /// This Repository will return CRUD Actions related to Article Comments.
        /// </summary>
        Repository<CommentArticle> ArticleComments { get; }

        /// <summary>
        /// This Repository will return CRUD Actions related to Article Likes.
        /// </summary>
        Repository<LikeArticle> ArticleLikes { get; }

        //Search

        /// <summary>
        /// This Repository will return CRUD Actions related to Tags.
        /// </summary>
        Repository<Tag> Tags { get; }

        //Location

        /// <summary>
        /// This Repository will return CRUD Actions related to Maps.
        /// </summary>
        Repository<GoogleMap> Maps { get; }

        /// <summary>
        /// This Repository will return CRUD Actions related to States.
        /// </summary>
        Repository<State> States { get; }

        /// <summary>
        /// This Repository will return CRUD Actions related to SubStates.
        /// </summary>
        Repository<SubState> SubStates { get; }

        /// <summary>
        /// This Repository will return CRUD Actions related to Languages.
        /// </summary>
        Repository<Language> Languages { get; }

        //Identity

        /// <summary>
        /// This Repository will return CRUD Actions related to ApplcationUsers.
        /// </summary>
        IdentityDbContext<ApplicationUser> User { get; }

        //Page

        /// <summary>
        /// This Repository will return CRUD Actions related to Pages.
        /// </summary>
        Repository<Page> Pages { get; }

        //Navigation

        /// <summary>
        /// This Repository will return CRUD Actions related to Menues.
        /// </summary>
        Repository<Menu> Menues { get; }

        /// <summary>
        /// This Repository will return CRUD Action related to Footers.
        /// </summary>
        Repository<Footer> Footers { get; } 
    }
}
