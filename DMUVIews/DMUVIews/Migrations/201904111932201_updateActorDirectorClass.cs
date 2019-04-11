namespace DMUViews.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateActorDirectorClass : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Actors", "City");
            DropColumn("dbo.Actors", "State");
            DropColumn("dbo.Actors", "Country");
            DropColumn("dbo.Directors", "City");
            DropColumn("dbo.Directors", "State");
            DropColumn("dbo.Directors", "Country");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Directors", "Country", c => c.String());
            AddColumn("dbo.Directors", "State", c => c.String());
            AddColumn("dbo.Directors", "City", c => c.String());
            AddColumn("dbo.Actors", "Country", c => c.String());
            AddColumn("dbo.Actors", "State", c => c.String());
            AddColumn("dbo.Actors", "City", c => c.String());
        }
    }
}
