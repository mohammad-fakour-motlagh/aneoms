namespace AlborzNirooPartsMonitoringSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedengineprojectdocrefrel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DocumentReferences", "EngineProjectId", c => c.Int());
            CreateIndex("dbo.DocumentReferences", "EngineProjectId");
            AddForeignKey("dbo.DocumentReferences", "EngineProjectId", "dbo.EngineProjects", "ProjectId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DocumentReferences", "EngineProjectId", "dbo.EngineProjects");
            DropIndex("dbo.DocumentReferences", new[] { "EngineProjectId" });
            DropColumn("dbo.DocumentReferences", "EngineProjectId");
        }
    }
}
