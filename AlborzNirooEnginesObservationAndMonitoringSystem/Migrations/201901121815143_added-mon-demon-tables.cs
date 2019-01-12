namespace AlborzNirooEnginesObservationAndMonitoringSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedmondemontables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Demontages",
                c => new
                    {
                        DemontageId = c.Int(nullable: false, identity: true),
                        StartDate = c.DateTime(nullable: false),
                        FinishDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.DemontageId);
            
            CreateTable(
                "dbo.Montages",
                c => new
                    {
                        MontageId = c.Int(nullable: false, identity: true),
                        StartDate = c.DateTime(nullable: false),
                        FinishDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.MontageId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Montages");
            DropTable("dbo.Demontages");
        }
    }
}
