namespace HekaEye.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CameraExposure : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RecipeCamera", "Exposure", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.RecipeCamera", "Exposure");
        }
    }
}
