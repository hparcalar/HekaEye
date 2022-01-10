namespace HekaEye.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProcessSteps_And_CombinedProduct : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ProcessStep",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RegionId = c.Int(nullable: false),
                        ProcessType = c.Int(nullable: false),
                        ProcessParams = c.String(maxLength: 4000),
                        OrderNo = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Region", t => t.RegionId, cascadeDelete: true)
                .Index(t => t.RegionId);
            
            AddColumn("dbo.Product", "CombinedProductId", c => c.Int(nullable: false));
            CreateIndex("dbo.Product", "CombinedProductId");
            AddForeignKey("dbo.Product", "CombinedProductId", "dbo.Product", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProcessStep", "RegionId", "dbo.Region");
            DropForeignKey("dbo.Product", "CombinedProductId", "dbo.Product");
            DropIndex("dbo.ProcessStep", new[] { "RegionId" });
            DropIndex("dbo.Product", new[] { "CombinedProductId" });
            DropColumn("dbo.Product", "CombinedProductId");
            DropTable("dbo.ProcessStep");
        }
    }
}
