namespace SalaoBeleza.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatingRequiredFieldsCustomer : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Customers", "DtRegister", c => c.DateTime());
            AlterColumn("dbo.Customers", "DtBirthDay", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Customers", "DtBirthDay", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Customers", "DtRegister", c => c.DateTime(nullable: false));
        }
    }
}
