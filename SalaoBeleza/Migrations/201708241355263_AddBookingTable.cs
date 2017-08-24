namespace SalaoBeleza.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddBookingTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Bookings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Descricao = c.String(maxLength: 255),
                        DtAgendamento = c.DateTime(nullable: false),
                        DtRegistro = c.DateTime(nullable: false),
                        CustomerId = c.Byte(nullable: false),
                        Customer_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.Customer_Id)
                .Index(t => t.Customer_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Bookings", "Customer_Id", "dbo.Customers");
            DropIndex("dbo.Bookings", new[] { "Customer_Id" });
            DropTable("dbo.Bookings");
        }
    }
}
