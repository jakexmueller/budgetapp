namespace budgetapp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class APIMVC : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Stocks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CurrentPrice = c.Int(nullable: false),
                        OneMonthAgoPrice = c.Int(nullable: false),
                        TwoMonthsAgoPrice = c.Int(nullable: false),
                        ThreeMonthsAgoPrice = c.Int(nullable: false),
                        FourMonthsAgoPrice = c.Int(nullable: false),
                        FiveMonthsAgoPrice = c.Int(nullable: false),
                        SixMonthsAgoPrice = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Stocks");
        }
    }
}
