namespace HekaEye.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DetectDefaultRect : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RegionProperties", "DetectDefaultRect", c => c.String(maxLength: 4000));
        }
        
        public override void Down()
        {
            DropColumn("dbo.RegionProperties", "DetectDefaultRect");
        }
    }
}
