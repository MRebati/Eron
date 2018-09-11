namespace Eron.DataAccess.EntityFramework.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class confupdatepage : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Pages", "Views", c => c.Long());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Pages", "Views", c => c.Long(nullable: false));
        }
    }
}
