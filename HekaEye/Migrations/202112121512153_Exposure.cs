namespace HekaEye.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Exposure : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Recipe", "Exposure", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Recipe", "Exposure");
        }
    }
}
