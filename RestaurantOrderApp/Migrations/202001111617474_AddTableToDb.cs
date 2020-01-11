namespace RestaurantOrderApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTableToDb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Tables",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Tables");
        }
    }
}
