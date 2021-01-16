namespace API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class first : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Medecins",
                c => new
                    {
                        MedecinID = c.Int(nullable: false, identity: true),
                        MedecinNom = c.String(),
                        MedecinPrenom = c.String(),
                        UserID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MedecinID)
                .ForeignKey("dbo.Users", t => t.UserID, cascadeDelete: true)
                .Index(t => t.UserID);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        Email = c.String(),
                        Password = c.String(),
                        Type = c.String(),
                    })
                .PrimaryKey(t => t.UserId);
            
            CreateTable(
                "dbo.Patients",
                c => new
                    {
                        PatientID = c.Int(nullable: false, identity: true),
                        Nom = c.String(),
                        Prenom = c.String(),
                        Adresse = c.String(),
                        UserID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PatientID)
                .ForeignKey("dbo.Users", t => t.UserID, cascadeDelete: true)
                .Index(t => t.UserID);
            
            CreateTable(
                "dbo.Rdvs",
                c => new
                    {
                        RdvID = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        Hdebut = c.DateTime(nullable: false),
                        Hfin = c.DateTime(nullable: false),
                        PatientID = c.Int(nullable: false),
                        MedecinID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.RdvID)
                .ForeignKey("dbo.Medecins", t => t.MedecinID, cascadeDelete: false)
                .ForeignKey("dbo.Patients", t => t.PatientID, cascadeDelete: false)
                .Index(t => t.PatientID)
                .Index(t => t.MedecinID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Rdvs", "PatientID", "dbo.Patients");
            DropForeignKey("dbo.Rdvs", "MedecinID", "dbo.Medecins");
            DropForeignKey("dbo.Patients", "UserID", "dbo.Users");
            DropForeignKey("dbo.Medecins", "UserID", "dbo.Users");
            DropIndex("dbo.Rdvs", new[] { "MedecinID" });
            DropIndex("dbo.Rdvs", new[] { "PatientID" });
            DropIndex("dbo.Patients", new[] { "UserID" });
            DropIndex("dbo.Medecins", new[] { "UserID" });
            DropTable("dbo.Rdvs");
            DropTable("dbo.Patients");
            DropTable("dbo.Users");
            DropTable("dbo.Medecins");
        }
    }
}
