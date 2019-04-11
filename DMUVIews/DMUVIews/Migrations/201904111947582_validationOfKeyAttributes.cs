namespace DMUViews.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class validationOfKeyAttributes : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Actors", "ActorName", c => c.String(nullable: false));
            AlterColumn("dbo.Movies", "MovieTitle", c => c.String(nullable: false));
            AlterColumn("dbo.Directors", "DirectorName", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Directors", "DirectorName", c => c.String());
            AlterColumn("dbo.Movies", "MovieTitle", c => c.String());
            AlterColumn("dbo.Actors", "ActorName", c => c.String());
        }
    }
}
