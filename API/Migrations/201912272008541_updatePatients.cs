namespace API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatePatients : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Patients", "DateNaissance", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Patients", "DateNaissance", c => c.DateTime(nullable: false));
        }
    }
}
