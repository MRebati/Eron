namespace Eron.core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class confinit : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Articles",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Slug = c.String(nullable: false),
                        Title = c.String(nullable: false),
                        ContentData = c.String(),
                        Summery = c.String(nullable: false),
                        Author = c.String(),
                        Keywords = c.String(),
                        CategoryId = c.Guid(nullable: false),
                        ImageUrl = c.String(),
                        Language = c.String(),
                        Tag = c.String(),
                        UserId = c.String(),
                        PositiveVote = c.Long(nullable: false),
                        NegativeVote = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ArticleCategories", t => t.CategoryId, cascadeDelete: true)
                .Index(t => t.CategoryId);
            
            CreateTable(
                "dbo.ArticleCategories",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        Description = c.String(),
                        IsBlog = c.Boolean(nullable: false),
                        ImageUrl = c.String(),
                        Modified = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Files",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        FileUrl = c.String(),
                        Downloaded = c.Long(nullable: false),
                        ContentId = c.String(),
                        Content_Id = c.Guid(),
                        Article_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Contents", t => t.Content_Id)
                .ForeignKey("dbo.Articles", t => t.Article_Id)
                .Index(t => t.Content_Id)
                .Index(t => t.Article_Id);
            
            CreateTable(
                "dbo.Contents",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Slug = c.String(),
                        Title = c.String(),
                        ContentData = c.String(),
                        Summery = c.String(),
                        Author = c.String(),
                        ShowAuthor = c.Boolean(nullable: false),
                        ShowDateTime = c.Boolean(nullable: false),
                        Keywords = c.String(),
                        CategoryId = c.Guid(nullable: false),
                        ImageUrl = c.String(),
                        Language = c.String(),
                        IsGlobal = c.Boolean(nullable: false),
                        Tag = c.String(),
                        UserId = c.String(),
                        Published = c.Boolean(nullable: false),
                        PublishStartTime = c.DateTime(nullable: false),
                        PublishEndTime = c.DateTime(nullable: false),
                        ModifiedTime = c.DateTime(nullable: false),
                        CreateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .Index(t => t.CategoryId);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        Description = c.String(),
                        ImageUrl = c.String(),
                        BackgroundUrl = c.String(),
                        PublishTime = c.DateTime(nullable: false),
                        Published = c.Boolean(nullable: false),
                        ModifiedTime = c.DateTime(nullable: false),
                        CreateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CommentArticles",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        UserId = c.String(),
                        ContentData = c.String(),
                        ReplyToComment = c.Boolean(nullable: false),
                        BadAnswer = c.Int(nullable: false),
                        ArticleId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Articles", t => t.ArticleId, cascadeDelete: true)
                .Index(t => t.ArticleId);
            
            CreateTable(
                "dbo.LikeArticles",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        ArticleId = c.Guid(nullable: false),
                        UserId = c.String(),
                        Viewed = c.Boolean(nullable: false),
                        Positive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CommentContents",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        ContentId = c.Guid(nullable: false),
                        UserName = c.String(),
                        UserId = c.String(),
                        ContentData = c.String(),
                        ReplyToComment = c.Boolean(nullable: false),
                        BadAnswer = c.Int(nullable: false),
                        ModifiedTime = c.DateTime(nullable: false),
                        CreateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Contents", t => t.ContentId, cascadeDelete: true)
                .Index(t => t.ContentId);
            
            CreateTable(
                "dbo.LikeContents",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        ContentId = c.Guid(nullable: false),
                        UserId = c.String(),
                        Viewed = c.Boolean(nullable: false),
                        ModifiedTime = c.DateTime(nullable: false),
                        CreateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.GoogleMaps",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Lat = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Lng = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Languages",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        LocalName = c.String(),
                        EnglishName = c.String(),
                        FlagUrl = c.String(),
                        LanguageCode = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Pages",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Title = c.String(),
                        Slug = c.String(),
                        Content = c.String(),
                        UserId = c.String(),
                        Language = c.String(),
                        Description = c.String(),
                        Keywords = c.String(),
                        ModifiedTime = c.DateTime(nullable: false),
                        CreateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.States",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SubStates",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Tags",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        TagName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        PostalCode = c.String(),
                        SocialNumber = c.String(),
                        Address = c.String(),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.CommentContents", "ContentId", "dbo.Contents");
            DropForeignKey("dbo.CommentArticles", "ArticleId", "dbo.Articles");
            DropForeignKey("dbo.Files", "Article_Id", "dbo.Articles");
            DropForeignKey("dbo.Files", "Content_Id", "dbo.Contents");
            DropForeignKey("dbo.Contents", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.Articles", "CategoryId", "dbo.ArticleCategories");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.CommentContents", new[] { "ContentId" });
            DropIndex("dbo.CommentArticles", new[] { "ArticleId" });
            DropIndex("dbo.Contents", new[] { "CategoryId" });
            DropIndex("dbo.Files", new[] { "Article_Id" });
            DropIndex("dbo.Files", new[] { "Content_Id" });
            DropIndex("dbo.Articles", new[] { "CategoryId" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Tags");
            DropTable("dbo.SubStates");
            DropTable("dbo.States");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Pages");
            DropTable("dbo.Languages");
            DropTable("dbo.GoogleMaps");
            DropTable("dbo.LikeContents");
            DropTable("dbo.CommentContents");
            DropTable("dbo.LikeArticles");
            DropTable("dbo.CommentArticles");
            DropTable("dbo.Categories");
            DropTable("dbo.Contents");
            DropTable("dbo.Files");
            DropTable("dbo.ArticleCategories");
            DropTable("dbo.Articles");
        }
    }
}
