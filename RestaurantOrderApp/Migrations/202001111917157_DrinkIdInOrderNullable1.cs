namespace RestaurantOrderApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DrinkIdInOrderNullable1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Orders", "drinkId", c => c.Int(nullable: true));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Orders", "drinkId", c => c.Int());
        }
    }
}
