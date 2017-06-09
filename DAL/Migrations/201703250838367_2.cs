namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _2 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Songs", "MyProperty");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Songs", "MyProperty", c => c.Int(nullable: false));
        }
    }
}
