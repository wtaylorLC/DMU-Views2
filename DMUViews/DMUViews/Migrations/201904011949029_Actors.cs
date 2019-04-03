namespace DMUViews.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Actors : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Actors", "FullName", c => c.String());
            AddColumn("dbo.Directors", "FullName", c => c.String());
            DropColumn("dbo.Actors", "FirstName");
            DropColumn("dbo.Actors", "LastName");
            DropColumn("dbo.Directors", "FirstName");
            DropColumn("dbo.Directors", "LastName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Directors", "LastName", c => c.String());
            AddColumn("dbo.Directors", "FirstName", c => c.String());
            AddColumn("dbo.Actors", "LastName", c => c.String());
            AddColumn("dbo.Actors", "FirstName", c => c.String());
            DropColumn("dbo.Directors", "FullName");
            DropColumn("dbo.Actors", "FullName");
        }
    }
}
