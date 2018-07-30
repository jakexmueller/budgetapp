namespace budgetapp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedSpendingHabits : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SpendingHabits", "AccountTotal", c => c.Double(nullable: false));
            DropColumn("dbo.SpendingHabits", "Date");
            DropColumn("dbo.SpendingHabits", "BudgetIndicator");
        }
        
        public override void Down()
        {
            AddColumn("dbo.SpendingHabits", "BudgetIndicator", c => c.Boolean(nullable: false));
            AddColumn("dbo.SpendingHabits", "Date", c => c.DateTime(nullable: false));
            DropColumn("dbo.SpendingHabits", "AccountTotal");
        }
    }
}
