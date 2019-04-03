namespace DMUViews.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class StarsDeleted : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Casts", "StarId", "dbo.Stars");
            DropIndex("dbo.Casts", new[] { "StarId" });
            DropColumn("dbo.Casts", "StarId");
            DropTable("dbo.Stars");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Stars",
                c => new
                    {
                        StarId = c.Int(nullable: false, identity: true),
                        FullName = c.String(),
                    })
                .PrimaryKey(t => t.StarId);
            
            AddColumn("dbo.Casts", "StarId", c => c.Int(nullable: false));
            CreateIndex("dbo.Casts", "StarId");
            AddForeignKey("dbo.Casts", "StarId", "dbo.Stars", "StarId", cascadeDelete: true);
        }
    }
}
