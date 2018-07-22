namespace budgetapp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedBudgetModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Budgets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        WeeklyWage = c.Int(nullable: false),
                        Bills = c.Int(nullable: false),
                        Groceries = c.Int(nullable: false),
                        Transportation = c.Int(nullable: false),
                        GoingOutFund = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Budgets");
        }
    }
}
