namespace HekaEye.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RecipeCamera : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.RecipeCamera",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RecipeId = c.Int(nullable: false),
                        CameraName = c.String(maxLength: 4000),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Recipe", t => t.RecipeId, cascadeDelete: true)
                .Index(t => t.RecipeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RecipeCamera", "RecipeId", "dbo.Recipe");
            DropIndex("dbo.RecipeCamera", new[] { "RecipeId" });
            DropTable("dbo.RecipeCamera");
        }
    }
}
