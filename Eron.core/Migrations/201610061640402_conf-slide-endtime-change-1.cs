namespace Eron.core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class confslideendtimechange1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Sliders",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                        Title = c.String(),
                        BackgroundUrl = c.String(),
                        LinkUrl = c.String(),
                        LinkName = c.String(),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(),
                        Endable = c.Boolean(nullable: false),
                        ShowCaption = c.Boolean(nullable: false),
                        ShowTitle = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Sliders");
        }
    }
}
