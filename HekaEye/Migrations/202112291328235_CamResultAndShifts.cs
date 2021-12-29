namespace HekaEye.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CamResultAndShifts : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CamResult",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductNo = c.String(maxLength: 4000),
                        SerialNo = c.String(maxLength: 4000),
                        Explanation = c.String(maxLength: 4000),
                        FaultExplanation = c.String(maxLength: 4000),
                        IsOk = c.Boolean(nullable: false),
                        FaultImage = c.Binary(maxLength: 4000),
                        ResultDate = c.DateTime(nullable: false),
                        ShiftId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.WorkingShift", t => t.ShiftId)
                .Index(t => t.ShiftId);
            
            CreateTable(
                "dbo.WorkingShift",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ShiftCode = c.String(maxLength: 4000),
                        ShiftName = c.String(maxLength: 4000),
                        StartTime = c.String(maxLength: 4000),
                        EndTime = c.String(maxLength: 4000),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CamResult", "ShiftId", "dbo.WorkingShift");
            DropIndex("dbo.CamResult", new[] { "ShiftId" });
            DropTable("dbo.WorkingShift");
            DropTable("dbo.CamResult");
        }
    }
}
