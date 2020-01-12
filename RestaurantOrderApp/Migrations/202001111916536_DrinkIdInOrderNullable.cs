namespace RestaurantOrderApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DrinkIdInOrderNullable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Orders", "drinkId", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Orders", "drinkId", c => c.Int(nullable: false));
        }
    }
}
