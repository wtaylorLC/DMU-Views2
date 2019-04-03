namespace DMUViews.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewStars : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Stars", "Role");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Stars", "Role", c => c.String());
        }
    }
}
