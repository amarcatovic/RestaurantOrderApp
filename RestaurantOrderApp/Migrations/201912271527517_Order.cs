namespace RestaurantOrderApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Order : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MealId = c.Int(nullable: true),
                        DrinkId = c.Int(nullable: true),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Drinks", t => t.DrinkId, cascadeDelete: true)
                .ForeignKey("dbo.Meals", t => t.MealId, cascadeDelete: true)
                .Index(t => t.MealId)
                .Index(t => t.DrinkId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "MealId", "dbo.Meals");
            DropForeignKey("dbo.Orders", "DrinkId", "dbo.Drinks");
            DropIndex("dbo.Orders", new[] { "DrinkId" });
            DropIndex("dbo.Orders", new[] { "MealId" });
            DropTable("dbo.Orders");
        }
    }
}
