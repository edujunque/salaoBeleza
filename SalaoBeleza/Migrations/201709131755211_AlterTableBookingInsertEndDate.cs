namespace SalaoBeleza.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlterTableBookingInsertEndDate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Bookings", "DtAgendamentoInicio", c => c.DateTime(nullable: false));
            AddColumn("dbo.Bookings", "DtAgendamentoFim", c => c.DateTime(nullable: false));
            DropColumn("dbo.Bookings", "DtAgendamento");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Bookings", "DtAgendamento", c => c.DateTime(nullable: false));
            DropColumn("dbo.Bookings", "DtAgendamentoFim");
            DropColumn("dbo.Bookings", "DtAgendamentoInicio");
        }
    }
}
