namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class INIT : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Albums",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Year = c.Int(nullable: false),
                        Status = c.String(),
                        Genre_Id = c.Int(),
                        Band_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Genres", t => t.Genre_Id)
                .ForeignKey("dbo.Bands", t => t.Band_Id)
                .Index(t => t.Genre_Id)
                .Index(t => t.Band_Id);
            
            CreateTable(
                "dbo.Genres",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        YearOfMeaning = c.Int(nullable: false),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Songs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Duration = c.Single(nullable: false),
                        MyProperty = c.Int(nullable: false),
                        Appearances = c.String(),
                        IsCover = c.Boolean(nullable: false),
                        Genre_Id = c.Int(),
                        Album_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Genres", t => t.Genre_Id)
                .ForeignKey("dbo.Albums", t => t.Album_Id)
                .Index(t => t.Genre_Id)
                .Index(t => t.Album_Id);
            
            CreateTable(
                "dbo.Bands",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        NumberOfMembers = c.Int(nullable: false),
                        YearOfFoundation = c.Int(nullable: false),
                        YearOfEnd = c.Int(nullable: false),
                        Genre_Id = c.Int(),
                        Studio_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Genres", t => t.Genre_Id)
                .ForeignKey("dbo.Studios", t => t.Studio_Id)
                .Index(t => t.Genre_Id)
                .Index(t => t.Studio_Id);
            
            CreateTable(
                "dbo.Members",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Instrument = c.String(),
                        Gender = c.Int(nullable: false),
                        Band_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Bands", t => t.Band_Id)
                .Index(t => t.Band_Id);
            
            CreateTable(
                "dbo.Studios",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Address = c.String(),
                        Phone = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Bands", "Studio_Id", "dbo.Studios");
            DropForeignKey("dbo.Members", "Band_Id", "dbo.Bands");
            DropForeignKey("dbo.Bands", "Genre_Id", "dbo.Genres");
            DropForeignKey("dbo.Albums", "Band_Id", "dbo.Bands");
            DropForeignKey("dbo.Songs", "Album_Id", "dbo.Albums");
            DropForeignKey("dbo.Songs", "Genre_Id", "dbo.Genres");
            DropForeignKey("dbo.Albums", "Genre_Id", "dbo.Genres");
            DropIndex("dbo.Members", new[] { "Band_Id" });
            DropIndex("dbo.Bands", new[] { "Studio_Id" });
            DropIndex("dbo.Bands", new[] { "Genre_Id" });
            DropIndex("dbo.Songs", new[] { "Album_Id" });
            DropIndex("dbo.Songs", new[] { "Genre_Id" });
            DropIndex("dbo.Albums", new[] { "Band_Id" });
            DropIndex("dbo.Albums", new[] { "Genre_Id" });
            DropTable("dbo.Studios");
            DropTable("dbo.Members");
            DropTable("dbo.Bands");
            DropTable("dbo.Songs");
            DropTable("dbo.Genres");
            DropTable("dbo.Albums");
        }
    }
}
