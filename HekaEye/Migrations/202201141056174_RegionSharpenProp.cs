namespace HekaEye.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RegionSharpenProp : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RegionProperties", "Sharpen", c => c.Boolean());
        }
        
        public override void Down()
        {
            DropColumn("dbo.RegionProperties", "Sharpen");
        }
    }
}
