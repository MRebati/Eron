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
                        Id = c.Long(nullable: false, identity: true),
                        Slug = c.String(nullable: false),
                        Title = c.String(nullable: false),
                        ContentData = c.String(),
                        Summery = c.String(nullable: false),
                        Author = c.String(),
                        Keywords = c.String(),
                        CategoryId = c.Long(nullable: false),
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
                        Id = c.Long(nullable: false, identity: true),
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
                        Content_Id = c.Long(),
                        Article_Id = c.Long(),
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
                        Id = c.Long(nullable: false, identity: true),
                        Slug = c.String(),
                        Title = c.String(),
                        ContentData = c.String(),
                        Summery = c.String(),
                        Author = c.String(),
                        ShowAuthor = c.Boolean(nullable: false),
                        ShowDateTime = c.Boolean(nullable: false),
                        Keywords = c.String(),
                        CategoryId = c.Long(nullable: false),
                        ImageUrl = c.String(),
                        Language = c.String(),
                        IsGlobal = c.Boolean(nullable: false),
                        Tag = c.String(),
                        UserId = c.String(),
                        Published = c.Boolean(nullable: false),
                        PublishStartTime = c.DateTime(nullable: false),
                        PublishEndTime = c.DateTime(nullable: false),
                        Views = c.Long(nullable: false),
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
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        ImageUrl = c.String(),
                        BackgroundUrl = c.String(),
                        PublishTime = c.DateTime(nullable: false),
                        Published = c.Boolean(nullable: false),
                        Views = c.Long(nullable: false),
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
                        ArticleId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Articles", t => t.ArticleId, cascadeDelete: true)
                .Index(t => t.ArticleId);
            
            CreateTable(
                "dbo.LikeArticles",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        ArticleId = c.Long(nullable: false),
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
                        ContentId = c.Long(nullable: false),
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
                        ContentId = c.Long(nullable: false),
                        UserId = c.String(),
                        Viewed = c.Boolean(nullable: false),
                        DateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Footers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsParent = c.Boolean(nullable: false),
                        Name = c.String(),
                        Url = c.String(),
                        Target = c.String(),
                        FooterId = c.Guid(),
                        Footer_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Footers", t => t.Footer_Id)
                .Index(t => t.Footer_Id);
            
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
                        Id = c.Int(nullable: false, identity: true),
                        LocalName = c.String(),
                        EnglishName = c.String(),
                        FlagUrl = c.String(),
                        LanguageCode = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Menus",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Url = c.String(),
                        Target = c.String(),
                        MenuId = c.Guid(),
                        Type = c.Int(nullable: false),
                        Menu_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Menus", t => t.Menu_Id)
                .Index(t => t.Menu_Id);
            
            CreateTable(
                "dbo.Pages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Slug = c.String(),
                        Content = c.String(),
                        UserId = c.String(),
                        Language = c.String(),
                        Description = c.String(),
                        Keywords = c.String(),
                        Views = c.Long(nullable: false),
                        ModifiedTime = c.DateTime(nullable: false),
                        CreateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.States",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SubStates",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Tags",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        TagName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Menus", "Menu_Id", "dbo.Menus");
            DropForeignKey("dbo.Footers", "Footer_Id", "dbo.Footers");
            DropForeignKey("dbo.CommentContents", "ContentId", "dbo.Contents");
            DropForeignKey("dbo.CommentArticles", "ArticleId", "dbo.Articles");
            DropForeignKey("dbo.Files", "Article_Id", "dbo.Articles");
            DropForeignKey("dbo.Files", "Content_Id", "dbo.Contents");
            DropForeignKey("dbo.Contents", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.Articles", "CategoryId", "dbo.ArticleCategories");
            DropIndex("dbo.Menus", new[] { "Menu_Id" });
            DropIndex("dbo.Footers", new[] { "Footer_Id" });
            DropIndex("dbo.CommentContents", new[] { "ContentId" });
            DropIndex("dbo.CommentArticles", new[] { "ArticleId" });
            DropIndex("dbo.Contents", new[] { "CategoryId" });
            DropIndex("dbo.Files", new[] { "Article_Id" });
            DropIndex("dbo.Files", new[] { "Content_Id" });
            DropIndex("dbo.Articles", new[] { "CategoryId" });
            DropTable("dbo.Tags");
            DropTable("dbo.SubStates");
            DropTable("dbo.States");
            DropTable("dbo.Pages");
            DropTable("dbo.Menus");
            DropTable("dbo.Languages");
            DropTable("dbo.GoogleMaps");
            DropTable("dbo.Footers");
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
