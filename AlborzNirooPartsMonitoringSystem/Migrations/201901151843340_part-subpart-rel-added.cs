namespace AlborzNirooPartsMonitoringSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class partsubpartreladded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Parts", "ParentPartId", c => c.Int());
            CreateIndex("dbo.Parts", "ParentPartId");
            AddForeignKey("dbo.Parts", "ParentPartId", "dbo.Parts", "PartId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Parts", "ParentPartId", "dbo.Parts");
            DropIndex("dbo.Parts", new[] { "ParentPartId" });
            DropColumn("dbo.Parts", "ParentPartId");
        }
    }
}
