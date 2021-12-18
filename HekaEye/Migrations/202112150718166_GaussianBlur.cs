namespace HekaEye.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class GaussianBlur : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RegionProperties", "GaussianBlur", c => c.Boolean());
            AddColumn("dbo.RegionProperties", "GaussianSize", c => c.Int());
            AddColumn("dbo.RegionProperties", "GaussianSigma", c => c.Double());
        }
        
        public override void Down()
        {
            DropColumn("dbo.RegionProperties", "GaussianSigma");
            DropColumn("dbo.RegionProperties", "GaussianSize");
            DropColumn("dbo.RegionProperties", "GaussianBlur");
        }
    }
}
