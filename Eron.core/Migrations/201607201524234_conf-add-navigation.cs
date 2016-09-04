namespace Eron.core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class confaddnavigation : DbMigration
    {
        public override void Up()
        {
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
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Footers", t => t.FooterId)
                .Index(t => t.FooterId);
            
            CreateTable(
                "dbo.Menus",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        Url = c.String(),
                        Target = c.String(),
                        MenuId = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Menus", t => t.MenuId)
                .Index(t => t.MenuId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Menus", "MenuId", "dbo.Menus");
            DropForeignKey("dbo.Footers", "FooterId", "dbo.Footers");
            DropIndex("dbo.Menus", new[] { "MenuId" });
            DropIndex("dbo.Footers", new[] { "FooterId" });
            DropTable("dbo.Menus");
            DropTable("dbo.Footers");
        }
    }
}
