namespace budgetapp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ApplicationUserException : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.WishLists",
                c => new
                    {
                        ItemId = c.Int(nullable: false, identity: true),
                        UserId = c.String(maxLength: 128),
                        ItemName = c.String(),
                        ItemPrice = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ItemId)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.WishLists", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.WishLists", new[] { "UserId" });
            DropTable("dbo.WishLists");
        }
    }
}
