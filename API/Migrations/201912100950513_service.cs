namespace API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class service : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Services",
                c => new
                    {
                        ServiceID = c.Int(nullable: false, identity: true),
                        ServiceNom = c.String(),
                    })
                .PrimaryKey(t => t.ServiceID);
            
            AddColumn("dbo.Medecins", "ServiceID", c => c.Int());
            CreateIndex("dbo.Medecins", "ServiceID");
            AddForeignKey("dbo.Medecins", "ServiceID", "dbo.Services", "ServiceID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Medecins", "ServiceID", "dbo.Services");
            DropIndex("dbo.Medecins", new[] { "ServiceID" });
            DropColumn("dbo.Medecins", "ServiceID");
            DropTable("dbo.Services");
        }
    }
}
