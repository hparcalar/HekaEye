namespace HekaEye.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BilateralFilterToRegion : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RegionProperties", "BilateralFilter", c => c.Boolean());
            AddColumn("dbo.RegionProperties", "BilateralD", c => c.Int());
            AddColumn("dbo.RegionProperties", "BilateralSigmaColor", c => c.Double());
            AddColumn("dbo.RegionProperties", "BilateralSigmaSpace", c => c.Double());
        }
        
        public override void Down()
        {
            DropColumn("dbo.RegionProperties", "BilateralSigmaSpace");
            DropColumn("dbo.RegionProperties", "BilateralSigmaColor");
            DropColumn("dbo.RegionProperties", "BilateralD");
            DropColumn("dbo.RegionProperties", "BilateralFilter");
        }
    }
}
