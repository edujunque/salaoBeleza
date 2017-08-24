namespace SalaoBeleza.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updating_Model_Booking_DataAnnotations_RequiredCUstomerID : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Bookings", "Customer_Id", "dbo.Customers");
            DropIndex("dbo.Bookings", new[] { "Customer_Id" });
            AlterColumn("dbo.Bookings", "Customer_Id", c => c.Int());
            CreateIndex("dbo.Bookings", "Customer_Id");
            AddForeignKey("dbo.Bookings", "Customer_Id", "dbo.Customers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Bookings", "Customer_Id", "dbo.Customers");
            DropIndex("dbo.Bookings", new[] { "Customer_Id" });
            AlterColumn("dbo.Bookings", "Customer_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.Bookings", "Customer_Id");
            AddForeignKey("dbo.Bookings", "Customer_Id", "dbo.Customers", "Id", cascadeDelete: true);
        }
    }
}
