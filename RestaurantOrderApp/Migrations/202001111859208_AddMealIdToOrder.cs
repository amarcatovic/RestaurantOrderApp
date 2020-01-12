namespace RestaurantOrderApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMealIdToOrder : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "mealId", c => c.Int(nullable: true));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Orders", "mealId");
        }
    }
}
