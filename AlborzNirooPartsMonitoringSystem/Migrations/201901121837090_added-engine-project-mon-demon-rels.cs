namespace AlborzNirooPartsMonitoringSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedengineprojectmondemonrels : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Demontages", "EngineProjectId", c => c.Int());
            AddColumn("dbo.Montages", "EngineProjectId", c => c.Int());
            CreateIndex("dbo.Demontages", "EngineProjectId");
            CreateIndex("dbo.Montages", "EngineProjectId");
            AddForeignKey("dbo.Montages", "EngineProjectId", "dbo.EngineProjects", "ProjectId");
            AddForeignKey("dbo.Demontages", "EngineProjectId", "dbo.EngineProjects", "ProjectId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Demontages", "EngineProjectId", "dbo.EngineProjects");
            DropForeignKey("dbo.Montages", "EngineProjectId", "dbo.EngineProjects");
            DropIndex("dbo.Montages", new[] { "EngineProjectId" });
            DropIndex("dbo.Demontages", new[] { "EngineProjectId" });
            DropColumn("dbo.Montages", "EngineProjectId");
            DropColumn("dbo.Demontages", "EngineProjectId");
        }
    }
}
