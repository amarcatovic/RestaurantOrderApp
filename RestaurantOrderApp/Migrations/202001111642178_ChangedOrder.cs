namespace RestaurantOrderApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedOrder : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Orders", "DrinkId", "dbo.Drinks");
            DropForeignKey("dbo.Orders", "MealId", "dbo.Meals");
            DropIndex("dbo.Orders", new[] { "MealId" });
            DropIndex("dbo.Orders", new[] { "DrinkId" });
            AddColumn("dbo.Orders", "TableId", c => c.Int(nullable: false));
            AddColumn("dbo.Orders", "DateOrdered", c => c.DateTime(nullable: false));
            DropColumn("dbo.Orders", "MealId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Orders", "MealId", c => c.Int(nullable: false));
            DropColumn("dbo.Orders", "DateOrdered");
            DropColumn("dbo.Orders", "TableId");
            CreateIndex("dbo.Orders", "DrinkId");
            CreateIndex("dbo.Orders", "MealId");
            AddForeignKey("dbo.Orders", "MealId", "dbo.Meals", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Orders", "DrinkId", "dbo.Drinks", "Id", cascadeDelete: true);
        }
    }
}
