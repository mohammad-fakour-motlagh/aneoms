namespace AlborzNirooPartsMonitoringSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class partpartdefrelcreated : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Parts",
                c => new
                    {
                        PartId = c.Int(nullable: false, identity: true),
                        SerialNumber = c.String(),
                        TransportCondition = c.Int(nullable: false),
                        AssemblyPartDefinitionId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PartId)
                .ForeignKey("dbo.AssemblyPartDefinitions", t => t.AssemblyPartDefinitionId, cascadeDelete: true)
                .Index(t => t.AssemblyPartDefinitionId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Parts", "AssemblyPartDefinitionId", "dbo.AssemblyPartDefinitions");
            DropIndex("dbo.Parts", new[] { "AssemblyPartDefinitionId" });
            DropTable("dbo.Parts");
        }
    }
}
