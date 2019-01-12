namespace AlborzNirooEnginesObservationAndMonitoringSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedmonpartrel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MontageParts",
                c => new
                    {
                        MontageId = c.Int(nullable: false),
                        PartId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.MontageId, t.PartId })
                .ForeignKey("dbo.Montages", t => t.MontageId, cascadeDelete: true)
                .ForeignKey("dbo.Parts", t => t.PartId, cascadeDelete: true)
                .Index(t => t.MontageId)
                .Index(t => t.PartId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MontageParts", "PartId", "dbo.Parts");
            DropForeignKey("dbo.MontageParts", "MontageId", "dbo.Montages");
            DropIndex("dbo.MontageParts", new[] { "PartId" });
            DropIndex("dbo.MontageParts", new[] { "MontageId" });
            DropTable("dbo.MontageParts");
        }
    }
}
