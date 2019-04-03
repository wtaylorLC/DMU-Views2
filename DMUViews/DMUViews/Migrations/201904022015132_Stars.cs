namespace DMUViews.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Stars : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Stars", "CastId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Stars", "CastId", c => c.Int(nullable: false));
        }
    }
}
