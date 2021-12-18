namespace HekaEye.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Inspection",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(maxLength: 4000),
                        Enabled = c.Boolean(),
                        RegionId = c.Int(),
                        PropertyId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Region", t => t.RegionId)
                .ForeignKey("dbo.RegionProperties", t => t.PropertyId)
                .Index(t => t.RegionId)
                .Index(t => t.PropertyId);
            
            CreateTable(
                "dbo.Region",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(maxLength: 4000),
                        Enabled = c.Boolean(),
                        RecipeId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Recipe", t => t.RecipeId)
                .Index(t => t.RecipeId);
            
            CreateTable(
                "dbo.Recipe",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RecipeCode = c.String(maxLength: 4000),
                        RecipeName = c.String(maxLength: 4000),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.RegionProperties",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(maxLength: 4000),
                        OffsetX = c.Int(),
                        OffsetY = c.Int(),
                        Enabled = c.Boolean(),
                        RegionType = c.Int(),
                        ConvertToGray = c.Boolean(),
                        ConvertToHsv = c.Boolean(),
                        Laplacian = c.Boolean(),
                        LaplaceSize = c.Boolean(),
                        EqualizeHist = c.Boolean(),
                        AdaptiveThr = c.Boolean(),
                        AdaptiveSize = c.Int(),
                        AdaptiveParam = c.Single(),
                        ManualThr = c.Boolean(),
                        ManualStart = c.Int(),
                        ManualEnd = c.Int(),
                        NokThreshold = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.MatchHistory",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductId = c.Int(),
                        InspectionId = c.Int(),
                        Result = c.Boolean(),
                        MatchDate = c.DateTime(),
                        PrintStatus = c.Int(),
                        FaultImagePath = c.String(maxLength: 4000),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Inspection", t => t.InspectionId)
                .ForeignKey("dbo.Product", t => t.ProductId)
                .Index(t => t.ProductId)
                .Index(t => t.InspectionId);
            
            CreateTable(
                "dbo.Product",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductCode = c.String(maxLength: 4000),
                        ProductName = c.String(maxLength: 4000),
                        RecipeId = c.Int(nullable: false),
                        IsActive = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Recipe", t => t.RecipeId, cascadeDelete: true)
                .Index(t => t.RecipeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MatchHistory", "ProductId", "dbo.Product");
            DropForeignKey("dbo.Product", "RecipeId", "dbo.Recipe");
            DropForeignKey("dbo.MatchHistory", "InspectionId", "dbo.Inspection");
            DropForeignKey("dbo.Inspection", "PropertyId", "dbo.RegionProperties");
            DropForeignKey("dbo.Inspection", "RegionId", "dbo.Region");
            DropForeignKey("dbo.Region", "RecipeId", "dbo.Recipe");
            DropIndex("dbo.Product", new[] { "RecipeId" });
            DropIndex("dbo.MatchHistory", new[] { "InspectionId" });
            DropIndex("dbo.MatchHistory", new[] { "ProductId" });
            DropIndex("dbo.Region", new[] { "RecipeId" });
            DropIndex("dbo.Inspection", new[] { "PropertyId" });
            DropIndex("dbo.Inspection", new[] { "RegionId" });
            DropTable("dbo.Product");
            DropTable("dbo.MatchHistory");
            DropTable("dbo.RegionProperties");
            DropTable("dbo.Recipe");
            DropTable("dbo.Region");
            DropTable("dbo.Inspection");
        }
    }
}
