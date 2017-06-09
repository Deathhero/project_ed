namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _123 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Albums", "Genre_Id", "dbo.Genres");
            DropForeignKey("dbo.Songs", "Genre_Id", "dbo.Genres");
            DropForeignKey("dbo.Bands", "Genre_Id", "dbo.Genres");
            DropIndex("dbo.Albums", new[] { "Genre_Id" });
            DropIndex("dbo.Songs", new[] { "Genre_Id" });
            DropIndex("dbo.Bands", new[] { "Genre_Id" });
            RenameColumn(table: "dbo.Albums", name: "Genre_Id", newName: "GenreId");
            RenameColumn(table: "dbo.Songs", name: "Genre_Id", newName: "GenreId");
            RenameColumn(table: "dbo.Bands", name: "Genre_Id", newName: "GenreId");
            AlterColumn("dbo.Albums", "GenreId", c => c.Int(nullable: false));
            AlterColumn("dbo.Songs", "GenreId", c => c.Int(nullable: false));
            AlterColumn("dbo.Bands", "GenreId", c => c.Int(nullable: false));
            CreateIndex("dbo.Albums", "GenreId");
            CreateIndex("dbo.Songs", "GenreId");
            CreateIndex("dbo.Bands", "GenreId");
            AddForeignKey("dbo.Albums", "GenreId", "dbo.Genres", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Songs", "GenreId", "dbo.Genres", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Bands", "GenreId", "dbo.Genres", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Bands", "GenreId", "dbo.Genres");
            DropForeignKey("dbo.Songs", "GenreId", "dbo.Genres");
            DropForeignKey("dbo.Albums", "GenreId", "dbo.Genres");
            DropIndex("dbo.Bands", new[] { "GenreId" });
            DropIndex("dbo.Songs", new[] { "GenreId" });
            DropIndex("dbo.Albums", new[] { "GenreId" });
            AlterColumn("dbo.Bands", "GenreId", c => c.Int());
            AlterColumn("dbo.Songs", "GenreId", c => c.Int());
            AlterColumn("dbo.Albums", "GenreId", c => c.Int());
            RenameColumn(table: "dbo.Bands", name: "GenreId", newName: "Genre_Id");
            RenameColumn(table: "dbo.Songs", name: "GenreId", newName: "Genre_Id");
            RenameColumn(table: "dbo.Albums", name: "GenreId", newName: "Genre_Id");
            CreateIndex("dbo.Bands", "Genre_Id");
            CreateIndex("dbo.Songs", "Genre_Id");
            CreateIndex("dbo.Albums", "Genre_Id");
            AddForeignKey("dbo.Bands", "Genre_Id", "dbo.Genres", "Id");
            AddForeignKey("dbo.Songs", "Genre_Id", "dbo.Genres", "Id");
            AddForeignKey("dbo.Albums", "Genre_Id", "dbo.Genres", "Id");
        }
    }
}
