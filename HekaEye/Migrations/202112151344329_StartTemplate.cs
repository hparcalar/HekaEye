namespace HekaEye.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class StartTemplate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Recipe", "StartTemplate", c => c.String(maxLength: 4000));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Recipe", "StartTemplate");
        }
    }
}
