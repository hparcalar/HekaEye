namespace HekaEye.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CannyThresholds : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RegionProperties", "CannyThreshold1", c => c.Double());
            AddColumn("dbo.RegionProperties", "CannyThreshold2", c => c.Double());
        }
        
        public override void Down()
        {
            DropColumn("dbo.RegionProperties", "CannyThreshold2");
            DropColumn("dbo.RegionProperties", "CannyThreshold1");
        }
    }
}
