namespace HekaEye.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CameraAlias : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RecipeCamera", "CameraAlias", c => c.String(maxLength: 4000));
        }
        
        public override void Down()
        {
            DropColumn("dbo.RecipeCamera", "CameraAlias");
        }
    }
}
