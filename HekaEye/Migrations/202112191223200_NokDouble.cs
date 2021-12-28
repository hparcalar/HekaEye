namespace HekaEye.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NokDouble : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.RegionProperties", "NokThreshold", c => c.Double());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.RegionProperties", "NokThreshold", c => c.Int());
        }
    }
}
