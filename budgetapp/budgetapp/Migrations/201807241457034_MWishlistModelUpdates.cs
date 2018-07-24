namespace budgetapp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MWishlistModelUpdates : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.WishLists", "ItemType", c => c.String());
            AddColumn("dbo.WishLists", "DisplayNumber", c => c.Int(nullable: false));
            AddColumn("dbo.WishLists", "DisplayFirst", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.WishLists", "DisplayFirst");
            DropColumn("dbo.WishLists", "DisplayNumber");
            DropColumn("dbo.WishLists", "ItemType");
        }
    }
}
