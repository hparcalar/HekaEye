namespace HekaEye.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SobelFilter : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RegionProperties", "ApplySobel", c => c.Boolean());
            AddColumn("dbo.RegionProperties", "SobelDx", c => c.Int());
            AddColumn("dbo.RegionProperties", "SobelDy", c => c.Int());
            AddColumn("dbo.RegionProperties", "SobelKernel", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.RegionProperties", "SobelKernel");
            DropColumn("dbo.RegionProperties", "SobelDy");
            DropColumn("dbo.RegionProperties", "SobelDx");
            DropColumn("dbo.RegionProperties", "ApplySobel");
        }
    }
}
