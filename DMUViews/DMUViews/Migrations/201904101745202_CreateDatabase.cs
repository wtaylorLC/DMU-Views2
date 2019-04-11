namespace DMUViews.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateDatabase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Actors",
                c => new
                    {
                        ActorId = c.Int(nullable: false, identity: true),
                        ActorName = c.String(),
                        Gender = c.String(),
                        Biography = c.String(),
                        DateOfBirth = c.DateTime(nullable: false),
                        City = c.String(),
                        State = c.String(),
                        Country = c.String(),
                    })
                .PrimaryKey(t => t.ActorId);
            
            CreateTable(
                "dbo.Movies",
                c => new
                    {
                        MovieId = c.Int(nullable: false, identity: true),
                        MovieTitle = c.String(),
                        Image = c.String(),
                        Description = c.String(),
                        DateReleased = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.MovieId);
            
            CreateTable(
                "dbo.Directors",
                c => new
                    {
                        DirectorId = c.Int(nullable: false, identity: true),
                        DirectorName = c.String(),
                        Gender = c.String(),
                        Biography = c.String(),
                        DateOfBirth = c.DateTime(nullable: false),
                        City = c.String(),
                        State = c.String(),
                        Country = c.String(),
                    })
                .PrimaryKey(t => t.DirectorId);
            
            CreateTable(
                "dbo.Genres",
                c => new
                    {
                        GenreId = c.Int(nullable: false, identity: true),
                        GenreName = c.String(),
                        IsActive = c.Boolean(nullable: false),
                        IsDelete = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.GenreId);
            
            CreateTable(
                "dbo.MovieComments",
                c => new
                    {
                        MovieCommentId = c.Int(nullable: false, identity: true),
                        MovieId = c.Int(nullable: false),
                        UserId = c.String(maxLength: 128),
                        Comment = c.String(),
                        Rank = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CommentDate = c.DateTime(nullable: false),
                        PostId = c.Int(nullable: false),
                        Post_PostId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.MovieCommentId)
                .ForeignKey("dbo.Movies", t => t.MovieId, cascadeDelete: true)
                .ForeignKey("dbo.Posts", t => t.Post_PostId)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.MovieId)
                .Index(t => t.UserId)
                .Index(t => t.Post_PostId);
            
            CreateTable(
                "dbo.Posts",
                c => new
                    {
                        PostId = c.String(nullable: false, maxLength: 128),
                        Message = c.String(),
                        PostDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.PostId);
            
            CreateTable(
                "dbo.SubComments",
                c => new
                    {
                        SubCommentId = c.Int(nullable: false, identity: true),
                        CommentMessage = c.String(),
                        CommentDate = c.DateTime(nullable: false),
                        MovieCommentId = c.Int(nullable: false),
                        UserId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.SubCommentId)
                .ForeignKey("dbo.MovieComments", t => t.MovieCommentId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.MovieCommentId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.MovieActors",
                c => new
                    {
                        Movie_MovieId = c.Int(nullable: false),
                        Actor_ActorId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Movie_MovieId, t.Actor_ActorId })
                .ForeignKey("dbo.Movies", t => t.Movie_MovieId, cascadeDelete: true)
                .ForeignKey("dbo.Actors", t => t.Actor_ActorId, cascadeDelete: true)
                .Index(t => t.Movie_MovieId)
                .Index(t => t.Actor_ActorId);
            
            CreateTable(
                "dbo.DirectorMovies",
                c => new
                    {
                        Director_DirectorId = c.Int(nullable: false),
                        Movie_MovieId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Director_DirectorId, t.Movie_MovieId })
                .ForeignKey("dbo.Directors", t => t.Director_DirectorId, cascadeDelete: true)
                .ForeignKey("dbo.Movies", t => t.Movie_MovieId, cascadeDelete: true)
                .Index(t => t.Director_DirectorId)
                .Index(t => t.Movie_MovieId);
            
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SubComments", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.SubComments", "MovieCommentId", "dbo.MovieComments");
            DropForeignKey("dbo.MovieComments", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.MovieComments", "Post_PostId", "dbo.Posts");
            DropForeignKey("dbo.MovieComments", "MovieId", "dbo.Movies");
            DropForeignKey("dbo.GenreMovies", "Movie_MovieId", "dbo.Movies");
            DropForeignKey("dbo.GenreMovies", "Genre_GenreId", "dbo.Genres");
            DropForeignKey("dbo.DirectorMovies", "Movie_MovieId", "dbo.Movies");
            DropForeignKey("dbo.DirectorMovies", "Director_DirectorId", "dbo.Directors");
            DropForeignKey("dbo.MovieActors", "Actor_ActorId", "dbo.Actors");
            DropForeignKey("dbo.MovieActors", "Movie_MovieId", "dbo.Movies");
            DropIndex("dbo.GenreMovies", new[] { "Movie_MovieId" });
            DropIndex("dbo.GenreMovies", new[] { "Genre_GenreId" });
            DropIndex("dbo.DirectorMovies", new[] { "Movie_MovieId" });
            DropIndex("dbo.DirectorMovies", new[] { "Director_DirectorId" });
            DropIndex("dbo.MovieActors", new[] { "Actor_ActorId" });
            DropIndex("dbo.MovieActors", new[] { "Movie_MovieId" });
            DropIndex("dbo.SubComments", new[] { "UserId" });
            DropIndex("dbo.SubComments", new[] { "MovieCommentId" });
            DropIndex("dbo.MovieComments", new[] { "Post_PostId" });
            DropIndex("dbo.MovieComments", new[] { "UserId" });
            DropIndex("dbo.MovieComments", new[] { "MovieId" });
            DropTable("dbo.GenreMovies");
            DropTable("dbo.DirectorMovies");
            DropTable("dbo.MovieActors");
            DropTable("dbo.SubComments");
            DropTable("dbo.Posts");
            DropTable("dbo.MovieComments");
            DropTable("dbo.Genres");
            DropTable("dbo.Directors");
            DropTable("dbo.Movies");
            DropTable("dbo.Actors");
        }
    }
}
