namespace Eron.core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class confaddinsight : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Contents", "Views", c => c.Long(nullable: false));
            AddColumn("dbo.Categories", "Views", c => c.Long(nullable: false));
            AddColumn("dbo.Pages", "Views", c => c.Long(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Pages", "Views");
            DropColumn("dbo.Categories", "Views");
            DropColumn("dbo.Contents", "Views");
        }
    }
}
