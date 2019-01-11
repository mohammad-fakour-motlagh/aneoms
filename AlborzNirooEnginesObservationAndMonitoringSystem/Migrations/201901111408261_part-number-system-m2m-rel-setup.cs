namespace AlborzNirooEnginesObservationAndMonitoringSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class partnumbersystemm2mrelsetup : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PartDefinitionPartNumberModel",
                c => new
                    {
                        PartDefinitionId = c.Int(nullable: false),
                        PartNumberModelId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.PartDefinitionId, t.PartNumberModelId })
                .ForeignKey("dbo.PartDefinitions", t => t.PartDefinitionId, cascadeDelete: true)
                .ForeignKey("dbo.PartNumberModels", t => t.PartNumberModelId, cascadeDelete: true)
                .Index(t => t.PartDefinitionId)
                .Index(t => t.PartNumberModelId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PartDefinitionPartNumberModel", "PartNumberModelId", "dbo.PartNumberModels");
            DropForeignKey("dbo.PartDefinitionPartNumberModel", "PartDefinitionId", "dbo.PartDefinitions");
            DropIndex("dbo.PartDefinitionPartNumberModel", new[] { "PartNumberModelId" });
            DropIndex("dbo.PartDefinitionPartNumberModel", new[] { "PartDefinitionId" });
            DropTable("dbo.PartDefinitionPartNumberModel");
        }
    }
}
