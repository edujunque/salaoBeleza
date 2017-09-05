namespace SalaoBeleza.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class alterBookingTableAddingEmployeeReference : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Bookings", "EmployeesId", c => c.Byte(nullable: false));
            AddColumn("dbo.Bookings", "Employee_Id", c => c.Int());
            CreateIndex("dbo.Bookings", "Employee_Id");
            AddForeignKey("dbo.Bookings", "Employee_Id", "dbo.Employees", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Bookings", "Employee_Id", "dbo.Employees");
            DropIndex("dbo.Bookings", new[] { "Employee_Id" });
            DropColumn("dbo.Bookings", "Employee_Id");
            DropColumn("dbo.Bookings", "EmployeesId");
        }
    }
}
