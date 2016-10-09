using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using Eron.core.DataModel.Articles;
using Eron.core.DataModel.Content;
using Eron.core.DataModel.Location;
using Eron.core.DataModel.Navigation;
using Eron.core.DataModel.Page;
using Eron.core.DataModel.Search;
using Eron.core.DataModel.Utilities;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Eron.core.DataAccess
{
    public class Context
    {
    }
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }

        public string PostalCode { get; set; }

        public string SocialNumber { get; set; }

        public string Address { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
    }

    public class AppUser : IdentityDbContext<ApplicationUser>
    {
        public AppUser() : base("DefaultConnection", throwIfV1Schema: false) { }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        //Entities.Articles
        public DbSet<Article> Article { get; set; }
        public DbSet<ArticleCategory> ArticleCategories { get; set; }
        public DbSet<CommentArticle> ArticleComments { get; set; }
        public DbSet<LikeArticle> ArticleLikes { get; set; }

        //Entities.Content
        public DbSet<Content> Content { get; set; }
        public DbSet<Category> ContentCategories { get; set; }
        public DbSet<CommentContent> ContentComments { get; set; }
        public DbSet<LikeContent> ContentLikes { get; set; }

        //Entites.Search
        public DbSet<Tag> Tags { get; set; }

        //Entites.Location
        public DbSet<GoogleMap> GoogleMaps { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<SubState> SubStates { get; set; }
        public DbSet<Language> Languages { get; set; }

        //Page
        public DbSet<Page> Pages { get; set; }

        //Navigation
        public DbSet<Menu> Menus { get; set; }

        public DbSet<Footer> Footers { get; set; }

        //Utilities
        public DbSet<Slider> Sliders { get; set; }
        public DbSet<SliderCategory> SliderCategories { get; set; }
    }
}