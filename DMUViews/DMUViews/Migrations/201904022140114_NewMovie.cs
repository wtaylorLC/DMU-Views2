namespace DMUViews.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewMovie : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Movies", "Director");
            DropColumn("dbo.Movies", "Star");
            DropColumn("dbo.Movies", "FullCast");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Movies", "FullCast", c => c.String());
            AddColumn("dbo.Movies", "Star", c => c.String());
            AddColumn("dbo.Movies", "Director", c => c.String());
        }
    }
}
