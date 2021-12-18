namespace HekaEye.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CameraName : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Recipe", "CameraName", c => c.String(maxLength: 4000));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Recipe", "CameraName");
        }
    }
}
