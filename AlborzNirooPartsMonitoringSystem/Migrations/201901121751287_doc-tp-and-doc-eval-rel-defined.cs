namespace AlborzNirooPartsMonitoringSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class doctpanddocevalreldefined : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Evaluations",
                c => new
                    {
                        EvaluationId = c.Int(nullable: false, identity: true),
                        EvaluationDate = c.DateTime(nullable: false),
                        EvaluationResult = c.Int(nullable: false),
                        DocumentReferenceId = c.Int(),
                    })
                .PrimaryKey(t => t.EvaluationId)
                .ForeignKey("dbo.DocumentReferences", t => t.DocumentReferenceId)
                .Index(t => t.DocumentReferenceId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Evaluations", "DocumentReferenceId", "dbo.DocumentReferences");
            DropIndex("dbo.Evaluations", new[] { "DocumentReferenceId" });
            DropTable("dbo.Evaluations");
        }
    }
}
