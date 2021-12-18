namespace HekaEye.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AdaptiveBorder : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RegionProperties", "AdaptiveBorder", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.RegionProperties", "AdaptiveBorder");
        }
    }
}
