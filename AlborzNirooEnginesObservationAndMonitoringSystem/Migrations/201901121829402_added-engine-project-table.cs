namespace AlborzNirooEnginesObservationAndMonitoringSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedengineprojecttable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EngineProjects",
                c => new
                    {
                        ProjectId = c.Int(nullable: false, identity: true),
                        StartDate = c.DateTime(nullable: false),
                        FinishDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ProjectId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.EngineProjects");
        }
    }
}
