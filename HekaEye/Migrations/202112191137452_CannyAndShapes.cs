namespace HekaEye.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CannyAndShapes : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RegionProperties", "ApplyCanny", c => c.Boolean());
            AddColumn("dbo.RegionProperties", "CannyEpsilon", c => c.Double());
            AddColumn("dbo.RegionProperties", "MinShapeArea", c => c.Double());
        }
        
        public override void Down()
        {
            DropColumn("dbo.RegionProperties", "MinShapeArea");
            DropColumn("dbo.RegionProperties", "CannyEpsilon");
            DropColumn("dbo.RegionProperties", "ApplyCanny");
        }
    }
}
