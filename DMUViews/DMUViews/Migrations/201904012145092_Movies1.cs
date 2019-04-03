namespace DMUViews.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Movies1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Genres", "MovieId", "dbo.Movies");
            DropIndex("dbo.Genres", new[] { "MovieId" });
            CreateTable(
                "dbo.GenreMovies",
                c => new
                    {
                        Genre_GenreId = c.Int(nullable: false),
                        Movie_MovieId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Genre_GenreId, t.Movie_MovieId })
                .ForeignKey("dbo.Genres", t => t.Genre_GenreId, cascadeDelete: true)
                .ForeignKey("dbo.Movies", t => t.Movie_MovieId, cascadeDelete: true)
                .Index(t => t.Genre_GenreId)
                .Index(t => t.Movie_MovieId);
            
            DropColumn("dbo.Genres", "MovieId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Genres", "MovieId", c => c.Int(nullable: false));
            DropForeignKey("dbo.GenreMovies", "Movie_MovieId", "dbo.Movies");
            DropForeignKey("dbo.GenreMovies", "Genre_GenreId", "dbo.Genres");
            DropIndex("dbo.GenreMovies", new[] { "Movie_MovieId" });
            DropIndex("dbo.GenreMovies", new[] { "Genre_GenreId" });
            DropTable("dbo.GenreMovies");
            CreateIndex("dbo.Genres", "MovieId");
            AddForeignKey("dbo.Genres", "MovieId", "dbo.Movies", "MovieId", cascadeDelete: true);
        }
    }
}
