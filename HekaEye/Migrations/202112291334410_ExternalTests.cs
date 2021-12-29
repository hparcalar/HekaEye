namespace HekaEye.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ExternalTests : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ExternalTest",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TestCode = c.String(maxLength: 4000),
                        TestName = c.String(maxLength: 4000),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.CamResult", "ExternalTestId", c => c.Int());
            CreateIndex("dbo.CamResult", "ExternalTestId");
            AddForeignKey("dbo.CamResult", "ExternalTestId", "dbo.ExternalTest", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CamResult", "ExternalTestId", "dbo.ExternalTest");
            DropIndex("dbo.CamResult", new[] { "ExternalTestId" });
            DropColumn("dbo.CamResult", "ExternalTestId");
            DropTable("dbo.ExternalTest");
        }
    }
}
