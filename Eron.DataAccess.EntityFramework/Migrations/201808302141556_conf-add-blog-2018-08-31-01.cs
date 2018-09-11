namespace Eron.DataAccess.EntityFramework.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class confaddblog2018083101 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BlogArchives",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        IsPublic = c.Boolean(nullable: false),
                        CreateDateTime = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Blogs",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Title = c.String(),
                        AlternativeTitle = c.String(),
                        Slug = c.String(),
                        Description = c.String(),
                        Content = c.String(),
                        LikesCount = c.Int(nullable: false),
                        IsPromoted = c.Boolean(nullable: false),
                        IsPeriodic = c.Boolean(nullable: false),
                        PublishStartDate = c.DateTime(nullable: false),
                        PublishEndDate = c.DateTime(nullable: false),
                        ShowOwner = c.Boolean(nullable: false),
                        HasImage = c.Boolean(nullable: false),
                        HasCoverImage = c.Boolean(nullable: false),
                        IsArchived = c.Boolean(nullable: false),
                        ShowInArchive = c.Boolean(nullable: false),
                        ParentId = c.Long(nullable: false),
                        ArchiveId = c.Int(),
                        CreateDateTime = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        CoverImage_Id = c.Guid(),
                        Image_Id = c.Guid(),
                        Owner_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BlogArchives", t => t.ArchiveId)
                .ForeignKey("dbo.Blogs", t => t.ParentId)
                .ForeignKey("dbo.EronFiles", t => t.CoverImage_Id)
                .ForeignKey("dbo.EronFiles", t => t.Image_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.Owner_Id)
                .Index(t => t.ParentId)
                .Index(t => t.ArchiveId)
                .Index(t => t.CoverImage_Id)
                .Index(t => t.Image_Id)
                .Index(t => t.Owner_Id);
            
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        EmailAddress = c.String(),
                        Message = c.String(),
                        BlogId = c.Long(),
                        ParentId = c.Guid(),
                        IsPublic = c.Boolean(nullable: false),
                        CreateDateTime = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        HashTag_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Blogs", t => t.BlogId)
                .ForeignKey("dbo.Comments", t => t.ParentId)
                .ForeignKey("dbo.HashTags", t => t.HashTag_Id)
                .Index(t => t.BlogId)
                .Index(t => t.ParentId)
                .Index(t => t.HashTag_Id);
            
            CreateTable(
                "dbo.HashTags",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        CreateDateTime = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Likes",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        BlogId = c.Long(),
                        CommentId = c.Guid(),
                        CreateDateTime = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Blogs", t => t.BlogId)
                .ForeignKey("dbo.Comments", t => t.CommentId)
                .Index(t => t.BlogId)
                .Index(t => t.CommentId);
            
            CreateTable(
                "dbo.HashTagBlogs",
                c => new
                    {
                        HashTag_Id = c.String(nullable: false, maxLength: 128),
                        Blog_Id = c.Long(nullable: false),
                    })
                .PrimaryKey(t => new { t.HashTag_Id, t.Blog_Id })
                .ForeignKey("dbo.HashTags", t => t.HashTag_Id, cascadeDelete: true)
                .ForeignKey("dbo.Blogs", t => t.Blog_Id, cascadeDelete: true)
                .Index(t => t.HashTag_Id)
                .Index(t => t.Blog_Id);
            
            AddColumn("dbo.EronFiles", "Blog_Id", c => c.Long());
            AddColumn("dbo.Tariffs", "ImmediateResponsePrice", c => c.Long());
            AddColumn("dbo.Tariffs", "ImmediateResponseDuration", c => c.String());
            AddColumn("dbo.Tariffs", "ImmediateResponseDescription", c => c.String());
            CreateIndex("dbo.EronFiles", "Blog_Id");
            AddForeignKey("dbo.EronFiles", "Blog_Id", "dbo.Blogs", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Blogs", "Owner_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Likes", "CommentId", "dbo.Comments");
            DropForeignKey("dbo.Likes", "BlogId", "dbo.Blogs");
            DropForeignKey("dbo.Blogs", "Image_Id", "dbo.EronFiles");
            DropForeignKey("dbo.Comments", "HashTag_Id", "dbo.HashTags");
            DropForeignKey("dbo.HashTagBlogs", "Blog_Id", "dbo.Blogs");
            DropForeignKey("dbo.HashTagBlogs", "HashTag_Id", "dbo.HashTags");
            DropForeignKey("dbo.EronFiles", "Blog_Id", "dbo.Blogs");
            DropForeignKey("dbo.Blogs", "CoverImage_Id", "dbo.EronFiles");
            DropForeignKey("dbo.Comments", "ParentId", "dbo.Comments");
            DropForeignKey("dbo.Comments", "BlogId", "dbo.Blogs");
            DropForeignKey("dbo.Blogs", "ParentId", "dbo.Blogs");
            DropForeignKey("dbo.Blogs", "ArchiveId", "dbo.BlogArchives");
            DropIndex("dbo.HashTagBlogs", new[] { "Blog_Id" });
            DropIndex("dbo.HashTagBlogs", new[] { "HashTag_Id" });
            DropIndex("dbo.Likes", new[] { "CommentId" });
            DropIndex("dbo.Likes", new[] { "BlogId" });
            DropIndex("dbo.Comments", new[] { "HashTag_Id" });
            DropIndex("dbo.Comments", new[] { "ParentId" });
            DropIndex("dbo.Comments", new[] { "BlogId" });
            DropIndex("dbo.Blogs", new[] { "Owner_Id" });
            DropIndex("dbo.Blogs", new[] { "Image_Id" });
            DropIndex("dbo.Blogs", new[] { "CoverImage_Id" });
            DropIndex("dbo.Blogs", new[] { "ArchiveId" });
            DropIndex("dbo.Blogs", new[] { "ParentId" });
            DropIndex("dbo.EronFiles", new[] { "Blog_Id" });
            DropColumn("dbo.Tariffs", "ImmediateResponseDescription");
            DropColumn("dbo.Tariffs", "ImmediateResponseDuration");
            DropColumn("dbo.Tariffs", "ImmediateResponsePrice");
            DropColumn("dbo.EronFiles", "Blog_Id");
            DropTable("dbo.HashTagBlogs");
            DropTable("dbo.Likes");
            DropTable("dbo.HashTags");
            DropTable("dbo.Comments");
            DropTable("dbo.Blogs");
            DropTable("dbo.BlogArchives");
        }
    }
}
