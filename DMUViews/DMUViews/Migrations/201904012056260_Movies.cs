namespace DMUViews.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Movies : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Actors", "MovieId", "dbo.Movies");
            DropForeignKey("dbo.Directors", "MovieId", "dbo.Movies");
            DropIndex("dbo.Actors", new[] { "MovieId" });
            DropIndex("dbo.Directors", new[] { "MovieId" });
            RenameColumn(table: "dbo.Actors", name: "MovieId", newName: "Movie_MovieId");
            RenameColumn(table: "dbo.Directors", name: "MovieId", newName: "Movie_MovieId");
            CreateTable(
                "dbo.Casts",
                c => new
                    {
                        CastId = c.Int(nullable: false, identity: true),
                        MovieId = c.Int(nullable: false),
                        ActorId = c.Int(nullable: false),
                        IsStar = c.Boolean(nullable: false),
                        Role = c.String(),
                    })
                .PrimaryKey(t => t.CastId)
                .ForeignKey("dbo.Actors", t => t.ActorId, cascadeDelete: true)
                .ForeignKey("dbo.Movies", t => t.MovieId, cascadeDelete: true)
                .Index(t => t.MovieId)
                .Index(t => t.ActorId);
            
            CreateTable(
                "dbo.Filmographies",
                c => new
                    {
                        FilmographyId = c.Int(nullable: false, identity: true),
                        MovieId = c.Int(nullable: false),
                        DirectorId = c.Int(nullable: false),
                        IsWriter = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.FilmographyId)
                .ForeignKey("dbo.Directors", t => t.DirectorId, cascadeDelete: true)
                .ForeignKey("dbo.Movies", t => t.MovieId, cascadeDelete: true)
                .Index(t => t.MovieId)
                .Index(t => t.DirectorId);
            
            AddColumn("dbo.Movies", "Genre", c => c.String());
            AddColumn("dbo.Movies", "Director", c => c.String());
            AddColumn("dbo.Movies", "Writer", c => c.String());
            AddColumn("dbo.Movies", "Star", c => c.String());
            AlterColumn("dbo.Actors", "Movie_MovieId", c => c.Int());
            AlterColumn("dbo.Directors", "Movie_MovieId", c => c.Int());
            CreateIndex("dbo.Actors", "Movie_MovieId");
            CreateIndex("dbo.Directors", "Movie_MovieId");
            AddForeignKey("dbo.Actors", "Movie_MovieId", "dbo.Movies", "MovieId");
            AddForeignKey("dbo.Directors", "Movie_MovieId", "dbo.Movies", "MovieId");
            DropColumn("dbo.Actors", "IsStar");
            DropColumn("dbo.Actors", "Role");
            DropColumn("dbo.Movies", "IsPrefferedMovie");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Movies", "IsPrefferedMovie", c => c.Boolean(nullable: false));
            AddColumn("dbo.Actors", "Role", c => c.String());
            AddColumn("dbo.Actors", "IsStar", c => c.Boolean(nullable: false));
            DropForeignKey("dbo.Directors", "Movie_MovieId", "dbo.Movies");
            DropForeignKey("dbo.Actors", "Movie_MovieId", "dbo.Movies");
            DropForeignKey("dbo.Filmographies", "MovieId", "dbo.Movies");
            DropForeignKey("dbo.Filmographies", "DirectorId", "dbo.Directors");
            DropForeignKey("dbo.Casts", "MovieId", "dbo.Movies");
            DropForeignKey("dbo.Casts", "ActorId", "dbo.Actors");
            DropIndex("dbo.Filmographies", new[] { "DirectorId" });
            DropIndex("dbo.Filmographies", new[] { "MovieId" });
            DropIndex("dbo.Directors", new[] { "Movie_MovieId" });
            DropIndex("dbo.Casts", new[] { "ActorId" });
            DropIndex("dbo.Casts", new[] { "MovieId" });
            DropIndex("dbo.Actors", new[] { "Movie_MovieId" });
            AlterColumn("dbo.Directors", "Movie_MovieId", c => c.Int(nullable: false));
            AlterColumn("dbo.Actors", "Movie_MovieId", c => c.Int(nullable: false));
            DropColumn("dbo.Movies", "Star");
            DropColumn("dbo.Movies", "Writer");
            DropColumn("dbo.Movies", "Director");
            DropColumn("dbo.Movies", "Genre");
            DropTable("dbo.Filmographies");
            DropTable("dbo.Casts");
            RenameColumn(table: "dbo.Directors", name: "Movie_MovieId", newName: "MovieId");
            RenameColumn(table: "dbo.Actors", name: "Movie_MovieId", newName: "MovieId");
            CreateIndex("dbo.Directors", "MovieId");
            CreateIndex("dbo.Actors", "MovieId");
            AddForeignKey("dbo.Directors", "MovieId", "dbo.Movies", "MovieId", cascadeDelete: true);
            AddForeignKey("dbo.Actors", "MovieId", "dbo.Movies", "MovieId", cascadeDelete: true);
        }
    }
}
