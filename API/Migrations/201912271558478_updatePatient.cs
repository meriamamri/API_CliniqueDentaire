namespace API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatePatient : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Patients", "tel", c => c.String());
            AddColumn("dbo.Patients", "carteSoin", c => c.String());
            AddColumn("dbo.Patients", "DateNaissance", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Patients", "DateNaissance");
            DropColumn("dbo.Patients", "carteSoin");
            DropColumn("dbo.Patients", "tel");
        }
    }
}
