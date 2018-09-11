namespace Eron.DataAccess.EntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class confaddblogcategory2018091001 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BlogCategories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Slug = c.String(),
                        ParentId = c.Int(nullable: false),
                        CreateDateTime = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BlogCategories", t => t.ParentId)
                .Index(t => t.ParentId);
            
            CreateTable(
                "dbo.BlogCategoryBlogs",
                c => new
                    {
                        BlogCategory_Id = c.Int(nullable: false),
                        Blog_Id = c.Long(nullable: false),
                    })
                .PrimaryKey(t => new { t.BlogCategory_Id, t.Blog_Id })
                .ForeignKey("dbo.BlogCategories", t => t.BlogCategory_Id, cascadeDelete: true)
                .ForeignKey("dbo.Blogs", t => t.Blog_Id, cascadeDelete: true)
                .Index(t => t.BlogCategory_Id)
                .Index(t => t.Blog_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BlogCategories", "ParentId", "dbo.BlogCategories");
            DropForeignKey("dbo.BlogCategoryBlogs", "Blog_Id", "dbo.Blogs");
            DropForeignKey("dbo.BlogCategoryBlogs", "BlogCategory_Id", "dbo.BlogCategories");
            DropIndex("dbo.BlogCategoryBlogs", new[] { "Blog_Id" });
            DropIndex("dbo.BlogCategoryBlogs", new[] { "BlogCategory_Id" });
            DropIndex("dbo.BlogCategories", new[] { "ParentId" });
            DropTable("dbo.BlogCategoryBlogs");
            DropTable("dbo.BlogCategories");
        }
    }
}
