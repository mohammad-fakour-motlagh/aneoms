namespace AlborzNirooPartsMonitoringSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addeddemonpartrel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DemontageParts",
                c => new
                    {
                        DemontageId = c.Int(nullable: false),
                        PartId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.DemontageId, t.PartId })
                .ForeignKey("dbo.Demontages", t => t.DemontageId, cascadeDelete: true)
                .ForeignKey("dbo.Parts", t => t.PartId, cascadeDelete: true)
                .Index(t => t.DemontageId)
                .Index(t => t.PartId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DemontageParts", "PartId", "dbo.Parts");
            DropForeignKey("dbo.DemontageParts", "DemontageId", "dbo.Demontages");
            DropIndex("dbo.DemontageParts", new[] { "PartId" });
            DropIndex("dbo.DemontageParts", new[] { "DemontageId" });
            DropTable("dbo.DemontageParts");
        }
    }
}
