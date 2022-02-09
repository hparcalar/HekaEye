namespace HekaEye.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class HsvColorCompare_And_MovementDetection : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RecipeCamera", "AutoExposure", c => c.Boolean());
            AddColumn("dbo.RegionProperties", "DetectMovement", c => c.Boolean());
            AddColumn("dbo.RegionProperties", "DetectHistoryFrame", c => c.Int());
            AddColumn("dbo.RegionProperties", "CompareColor", c => c.Boolean());
            AddColumn("dbo.RegionProperties", "CmpHueRange", c => c.String(maxLength: 4000));
            AddColumn("dbo.RegionProperties", "CmpSatRange", c => c.String(maxLength: 4000));
            AddColumn("dbo.RegionProperties", "CmpValRange", c => c.String(maxLength: 4000));
        }
        
        public override void Down()
        {
            DropColumn("dbo.RegionProperties", "CmpValRange");
            DropColumn("dbo.RegionProperties", "CmpSatRange");
            DropColumn("dbo.RegionProperties", "CmpHueRange");
            DropColumn("dbo.RegionProperties", "CompareColor");
            DropColumn("dbo.RegionProperties", "DetectHistoryFrame");
            DropColumn("dbo.RegionProperties", "DetectMovement");
            DropColumn("dbo.RecipeCamera", "AutoExposure");
        }
    }
}
