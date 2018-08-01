namespace budgetapp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedStockModel : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Stocks", "CurrentPrice", c => c.Double(nullable: false));
            AlterColumn("dbo.Stocks", "OneMonthAgoPrice", c => c.Double(nullable: false));
            AlterColumn("dbo.Stocks", "TwoMonthsAgoPrice", c => c.Double(nullable: false));
            AlterColumn("dbo.Stocks", "ThreeMonthsAgoPrice", c => c.Double(nullable: false));
            AlterColumn("dbo.Stocks", "FourMonthsAgoPrice", c => c.Double(nullable: false));
            AlterColumn("dbo.Stocks", "FiveMonthsAgoPrice", c => c.Double(nullable: false));
            AlterColumn("dbo.Stocks", "SixMonthsAgoPrice", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Stocks", "SixMonthsAgoPrice", c => c.Int(nullable: false));
            AlterColumn("dbo.Stocks", "FiveMonthsAgoPrice", c => c.Int(nullable: false));
            AlterColumn("dbo.Stocks", "FourMonthsAgoPrice", c => c.Int(nullable: false));
            AlterColumn("dbo.Stocks", "ThreeMonthsAgoPrice", c => c.Int(nullable: false));
            AlterColumn("dbo.Stocks", "TwoMonthsAgoPrice", c => c.Int(nullable: false));
            AlterColumn("dbo.Stocks", "OneMonthAgoPrice", c => c.Int(nullable: false));
            AlterColumn("dbo.Stocks", "CurrentPrice", c => c.Int(nullable: false));
        }
    }
}
