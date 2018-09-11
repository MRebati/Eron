namespace Eron.DataAccess.EntityFramework.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class conftransactionbanknametype20180614 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.FinanceTransactions", "BankName", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.FinanceTransactions", "BankName");
        }
    }
}
