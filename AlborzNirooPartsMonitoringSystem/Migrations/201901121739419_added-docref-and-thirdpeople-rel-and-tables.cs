namespace AlborzNirooPartsMonitoringSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addeddocrefandthirdpeoplerelandtables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DocumentReferences",
                c => new
                    {
                        DocumentReferenceId = c.Int(nullable: false, identity: true),
                        ReferenceCode = c.String(),
                        ThirdPersonId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.DocumentReferenceId)
                .ForeignKey("dbo.ThirdPersons", t => t.ThirdPersonId, cascadeDelete: true)
                .Index(t => t.ThirdPersonId);
            
            CreateTable(
                "dbo.ThirdPersons",
                c => new
                    {
                        ThirdPersonId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ThirdPersonId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DocumentReferences", "ThirdPersonId", "dbo.ThirdPersons");
            DropIndex("dbo.DocumentReferences", new[] { "ThirdPersonId" });
            DropTable("dbo.ThirdPersons");
            DropTable("dbo.DocumentReferences");
        }
    }
}
