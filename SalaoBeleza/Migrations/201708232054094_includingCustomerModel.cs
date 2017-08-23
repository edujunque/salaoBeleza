namespace SalaoBeleza.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class includingCustomerModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        Email = c.String(maxLength: 50),
                        PhoneNumber = c.String(nullable: false, maxLength: 20),
                        Observations = c.String(maxLength: 255),
                        CPF = c.String(maxLength: 14),
                        DtRegister = c.DateTime(nullable: false),
                        DtBirthDay = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Customers");
        }
    }
}
