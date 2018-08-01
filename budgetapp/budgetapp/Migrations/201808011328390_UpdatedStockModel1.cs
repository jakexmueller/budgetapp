namespace budgetapp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedStockModel1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Stocks", "Symbol", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Stocks", "Symbol");
        }
    }
}
