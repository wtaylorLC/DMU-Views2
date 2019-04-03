namespace DMUViews.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Genres : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Actors", "Movie_MovieId", "dbo.Movies");
            DropForeignKey("dbo.Directors", "Movie_MovieId", "dbo.Movies");
            DropForeignKey("dbo.GenreMovies", "Genre_GenreId", "dbo.Genres");
            DropForeignKey("dbo.GenreMovies", "Movie_MovieId", "dbo.Movies");
            DropIndex("dbo.Actors", new[] { "Movie_MovieId" });
            DropIndex("dbo.Directors", new[] { "Movie_MovieId" });
            DropIndex("dbo.GenreMovies", new[] { "Genre_GenreId" });
            DropIndex("dbo.GenreMovies", new[] { "Movie_MovieId" });
            CreateTable(
                "dbo.MovieGenres",
                c => new
                    {
                        GenreMoviesId = c.Int(nullable: false, identity: true),
                        MovieId = c.Int(nullable: false),
                        GenreId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.GenreMoviesId)
                .ForeignKey("dbo.Genres", t => t.GenreId, cascadeDelete: true)
                .ForeignKey("dbo.Movies", t => t.MovieId, cascadeDelete: true)
                .Index(t => t.MovieId)
                .Index(t => t.GenreId);
            
            CreateTable(
                "dbo.Stars",
                c => new
                    {
                        StarId = c.Int(nullable: false, identity: true),
                        CastId = c.Int(nullable: false),
                        FullName = c.String(),
                        Role = c.String(),
                    })
                .PrimaryKey(t => t.StarId);
            
            AddColumn("dbo.Casts", "StarId", c => c.Int(nullable: false));
            CreateIndex("dbo.Casts", "StarId");
            AddForeignKey("dbo.Casts", "StarId", "dbo.Stars", "StarId", cascadeDelete: true);
            DropColumn("dbo.Actors", "Movie_MovieId");
            DropColumn("dbo.Casts", "IsStar");
            DropColumn("dbo.Casts", "Role");
            DropColumn("dbo.Directors", "IsWriter");
            DropColumn("dbo.Directors", "Movie_MovieId");
            DropColumn("dbo.Filmographies", "IsWriter");
            DropTable("dbo.GenreMovies");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.GenreMovies",
                c => new
                    {
                        Genre_GenreId = c.Int(nullable: false),
                        Movie_MovieId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Genre_GenreId, t.Movie_MovieId });
            
            AddColumn("dbo.Filmographies", "IsWriter", c => c.Boolean(nullable: false));
            AddColumn("dbo.Directors", "Movie_MovieId", c => c.Int());
            AddColumn("dbo.Directors", "IsWriter", c => c.Boolean(nullable: false));
            AddColumn("dbo.Casts", "Role", c => c.String());
            AddColumn("dbo.Casts", "IsStar", c => c.Boolean(nullable: false));
            AddColumn("dbo.Actors", "Movie_MovieId", c => c.Int());
            DropForeignKey("dbo.Casts", "StarId", "dbo.Stars");
            DropForeignKey("dbo.MovieGenres", "MovieId", "dbo.Movies");
            DropForeignKey("dbo.MovieGenres", "GenreId", "dbo.Genres");
            DropIndex("dbo.MovieGenres", new[] { "GenreId" });
            DropIndex("dbo.MovieGenres", new[] { "MovieId" });
            DropIndex("dbo.Casts", new[] { "StarId" });
            DropColumn("dbo.Casts", "StarId");
            DropTable("dbo.Stars");
            DropTable("dbo.MovieGenres");
            CreateIndex("dbo.GenreMovies", "Movie_MovieId");
            CreateIndex("dbo.GenreMovies", "Genre_GenreId");
            CreateIndex("dbo.Directors", "Movie_MovieId");
            CreateIndex("dbo.Actors", "Movie_MovieId");
            AddForeignKey("dbo.GenreMovies", "Movie_MovieId", "dbo.Movies", "MovieId", cascadeDelete: true);
            AddForeignKey("dbo.GenreMovies", "Genre_GenreId", "dbo.Genres", "GenreId", cascadeDelete: true);
            AddForeignKey("dbo.Directors", "Movie_MovieId", "dbo.Movies", "MovieId");
            AddForeignKey("dbo.Actors", "Movie_MovieId", "dbo.Movies", "MovieId");
        }
    }
}
