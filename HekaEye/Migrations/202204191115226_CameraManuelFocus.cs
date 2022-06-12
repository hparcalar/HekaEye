namespace HekaEye.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CameraManuelFocus : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RecipeCamera", "AutoFocus", c => c.Boolean());
            AddColumn("dbo.RecipeCamera", "Focus", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.RecipeCamera", "Focus");
            DropColumn("dbo.RecipeCamera", "AutoFocus");
        }
    }
}
