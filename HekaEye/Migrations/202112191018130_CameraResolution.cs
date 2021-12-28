namespace HekaEye.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CameraResolution : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Recipe", "RW", c => c.Int());
            AddColumn("dbo.Recipe", "RH", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Recipe", "RH");
            DropColumn("dbo.Recipe", "RW");
        }
    }
}
