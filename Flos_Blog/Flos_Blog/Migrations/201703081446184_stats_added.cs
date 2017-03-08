namespace Flos_Blog.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class stats_added : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.StayDurations",
                c => new
                    {
                        StayDurationId = c.Guid(nullable: false),
                        Duration = c.Int(nullable: false),
                        Page = c.String(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                        Text_TextId = c.Guid(),
                    })
                .PrimaryKey(t => t.StayDurationId)
                .ForeignKey("dbo.Texts", t => t.Text_TextId)
                .Index(t => t.Text_TextId);
            
            AddColumn("dbo.Texts", "TextViews", c => c.Int(nullable: false));
            AddColumn("dbo.Texts", "TextShared", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.StayDurations", "Text_TextId", "dbo.Texts");
            DropIndex("dbo.StayDurations", new[] { "Text_TextId" });
            DropColumn("dbo.Texts", "TextShared");
            DropColumn("dbo.Texts", "TextViews");
            DropTable("dbo.StayDurations");
        }
    }
}
