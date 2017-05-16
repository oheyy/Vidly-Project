namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlteredGenreIdToByte : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Movies", "Genre_Id", "dbo.Genres");
            DropIndex("dbo.Movies", new[] { "Genre_Id" });
            DropColumn("dbo.Movies", "GenreId");
            RenameColumn(table: "dbo.Movies", name: "Genre_Id", newName: "GenreId");
            DropPrimaryKey("dbo.Movies");
            DropPrimaryKey("dbo.Genres");
            AlterColumn("dbo.Movies", "Id", c => c.Byte(nullable: false));
            AlterColumn("dbo.Movies", "GenreId", c => c.Byte(nullable: false));
            AlterColumn("dbo.Movies", "GenreId", c => c.Byte(nullable: false));
            AlterColumn("dbo.Genres", "Id", c => c.Byte(nullable: false));
            AddPrimaryKey("dbo.Movies", "Id");
            AddPrimaryKey("dbo.Genres", "Id");
            CreateIndex("dbo.Movies", "GenreId");
            AddForeignKey("dbo.Movies", "GenreId", "dbo.Genres", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Movies", "GenreId", "dbo.Genres");
            DropIndex("dbo.Movies", new[] { "GenreId" });
            DropPrimaryKey("dbo.Genres");
            DropPrimaryKey("dbo.Movies");
            AlterColumn("dbo.Genres", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Movies", "GenreId", c => c.Int(nullable: false));
            AlterColumn("dbo.Movies", "GenreId", c => c.String());
            AlterColumn("dbo.Movies", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Genres", "Id");
            AddPrimaryKey("dbo.Movies", "Id");
            RenameColumn(table: "dbo.Movies", name: "GenreId", newName: "Genre_Id");
            AddColumn("dbo.Movies", "GenreId", c => c.String());
            CreateIndex("dbo.Movies", "Genre_Id");
            AddForeignKey("dbo.Movies", "Genre_Id", "dbo.Genres", "Id", cascadeDelete: true);
        }
    }
}
