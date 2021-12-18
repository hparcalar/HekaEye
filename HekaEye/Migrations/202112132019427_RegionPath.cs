namespace HekaEye.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RegionPath : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.RegionPath",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RegionId = c.Int(),
                        X = c.Int(nullable: false),
                        Y = c.Int(nullable: false),
                        PointOrder = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Region", t => t.RegionId)
                .Index(t => t.RegionId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RegionPath", "RegionId", "dbo.Region");
            DropIndex("dbo.RegionPath", new[] { "RegionId" });
            DropTable("dbo.RegionPath");
        }
    }
}
