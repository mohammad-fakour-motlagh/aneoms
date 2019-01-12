namespace AlborzNirooEnginesObservationAndMonitoringSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedpartevalrelation : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Evaluations", "PartId", c => c.Int(nullable: false));
            CreateIndex("dbo.Evaluations", "PartId");
            AddForeignKey("dbo.Evaluations", "PartId", "dbo.Parts", "PartId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Evaluations", "PartId", "dbo.Parts");
            DropIndex("dbo.Evaluations", new[] { "PartId" });
            DropColumn("dbo.Evaluations", "PartId");
        }
    }
}
