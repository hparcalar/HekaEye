namespace HekaEye.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CombinedProduct_NullableFix : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Product", new[] { "CombinedProductId" });
            AlterColumn("dbo.Product", "CombinedProductId", c => c.Int());
            CreateIndex("dbo.Product", "CombinedProductId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Product", new[] { "CombinedProductId" });
            AlterColumn("dbo.Product", "CombinedProductId", c => c.Int(nullable: false));
            CreateIndex("dbo.Product", "CombinedProductId");
        }
    }
}
