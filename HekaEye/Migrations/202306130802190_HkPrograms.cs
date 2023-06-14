namespace HekaEye.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class HkPrograms : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.HkProgram",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProgramName = c.String(maxLength: 4000),
                        TriggerMode = c.Int(nullable: false),
                        AutoTriggerInterval = c.Int(),
                        CameraName = c.String(maxLength: 4000),
                        RunningStatus = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.HkTool",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ToolType = c.Int(),
                        ToolName = c.String(maxLength: 4000),
                        ProgramId = c.Int(),
                        ToolOrder = c.Int(),
                        ToolSettings = c.String(maxLength: 4000),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.HkProgram", t => t.ProgramId)
                .Index(t => t.ProgramId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.HkTool", "ProgramId", "dbo.HkProgram");
            DropIndex("dbo.HkTool", new[] { "ProgramId" });
            DropTable("dbo.HkTool");
            DropTable("dbo.HkProgram");
        }
    }
}
