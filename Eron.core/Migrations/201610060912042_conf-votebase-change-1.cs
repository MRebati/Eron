namespace Eron.core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class confvotebasechange1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Articles", "PositiveVote", c => c.Long());
            AlterColumn("dbo.Articles", "NegativeVote", c => c.Long());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Articles", "NegativeVote", c => c.Long(nullable: false));
            AlterColumn("dbo.Articles", "PositiveVote", c => c.Long(nullable: false));
        }
    }
}
