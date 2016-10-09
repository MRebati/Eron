namespace Eron.core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class confresetall : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Articles", "CategoryId", "dbo.ArticleCategories");
            DropForeignKey("dbo.Contents", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.Files", "Content_Id", "dbo.Contents");
            DropForeignKey("dbo.Files", "Article_Id", "dbo.Articles");
            DropForeignKey("dbo.CommentArticles", "ArticleId", "dbo.Articles");
            DropForeignKey("dbo.CommentContents", "ContentId", "dbo.Contents");
            DropForeignKey("dbo.Footers", "FooterId", "dbo.Footers");
            DropForeignKey("dbo.Menus", "MenuId", "dbo.Menus");
            DropIndex("dbo.Articles", new[] { "CategoryId" });
            DropIndex("dbo.Files", new[] { "Content_Id" });
            DropIndex("dbo.Files", new[] { "Article_Id" });
            DropIndex("dbo.Contents", new[] { "CategoryId" });
            DropIndex("dbo.CommentArticles", new[] { "ArticleId" });
            DropIndex("dbo.CommentContents", new[] { "ContentId" });
            DropIndex("dbo.Footers", new[] { "FooterId" });
            DropIndex("dbo.Menus", new[] { "MenuId" });
            DropTable("dbo.Articles");
            DropTable("dbo.ArticleCategories");
            DropTable("dbo.Files");
            DropTable("dbo.Contents");
            DropTable("dbo.Categories");
            DropTable("dbo.CommentArticles");
            DropTable("dbo.LikeArticles");
            DropTable("dbo.CommentContents");
            DropTable("dbo.LikeContents");
            DropTable("dbo.Footers");
            DropTable("dbo.GoogleMaps");
            DropTable("dbo.Languages");
            DropTable("dbo.Menus");
            DropTable("dbo.Pages");
            DropTable("dbo.States");
            DropTable("dbo.SubStates");
            DropTable("dbo.Tags");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Tags",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        TagName = c.String(),
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
                "dbo.States",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
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
                        Views = c.Long(nullable: false),
                        ModifiedTime = c.DateTime(nullable: false),
                        CreateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Menus",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        Url = c.String(),
                        Target = c.String(),
                        MenuId = c.Guid(),
                        Type = c.Int(nullable: false),
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
                "dbo.Footers",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        IsParent = c.Boolean(nullable: false),
                        Name = c.String(),
                        Url = c.String(),
                        Target = c.String(),
                        FooterId = c.Guid(),
                    })
                .PrimaryKey(t => t.Id);
            
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
                .PrimaryKey(t => t.Id);
            
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
                .PrimaryKey(t => t.Id);
            
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
                        Views = c.Long(nullable: false),
                        ModifiedTime = c.DateTime(nullable: false),
                        CreateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
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
                        Views = c.Long(nullable: false),
                        ModifiedTime = c.DateTime(nullable: false),
                        CreateTime = c.DateTime(nullable: false),
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
                .PrimaryKey(t => t.Id);
            
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
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.Menus", "MenuId");
            CreateIndex("dbo.Footers", "FooterId");
            CreateIndex("dbo.CommentContents", "ContentId");
            CreateIndex("dbo.CommentArticles", "ArticleId");
            CreateIndex("dbo.Contents", "CategoryId");
            CreateIndex("dbo.Files", "Article_Id");
            CreateIndex("dbo.Files", "Content_Id");
            CreateIndex("dbo.Articles", "CategoryId");
            AddForeignKey("dbo.Menus", "MenuId", "dbo.Menus", "Id");
            AddForeignKey("dbo.Footers", "FooterId", "dbo.Footers", "Id");
            AddForeignKey("dbo.CommentContents", "ContentId", "dbo.Contents", "Id", cascadeDelete: true);
            AddForeignKey("dbo.CommentArticles", "ArticleId", "dbo.Articles", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Files", "Article_Id", "dbo.Articles", "Id");
            AddForeignKey("dbo.Files", "Content_Id", "dbo.Contents", "Id");
            AddForeignKey("dbo.Contents", "CategoryId", "dbo.Categories", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Articles", "CategoryId", "dbo.ArticleCategories", "Id", cascadeDelete: true);
        }
    }
}
