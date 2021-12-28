namespace HekaEye.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CameraOfRegion : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Region", "CameraId", c => c.Int());
            CreateIndex("dbo.Region", "CameraId");
            AddForeignKey("dbo.Region", "CameraId", "dbo.RecipeCamera", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Region", "CameraId", "dbo.RecipeCamera");
            DropIndex("dbo.Region", new[] { "CameraId" });
            DropColumn("dbo.Region", "CameraId");
        }
    }
}
