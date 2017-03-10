namespace Flos_Blog.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class text_publish : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Texts", "TextShares", c => c.Int(nullable: false));
            AddColumn("dbo.Texts", "TextPublished", c => c.Boolean(nullable: false));
            DropColumn("dbo.Texts", "TextShared");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Texts", "TextShared", c => c.Int(nullable: false));
            DropColumn("dbo.Texts", "TextPublished");
            DropColumn("dbo.Texts", "TextShares");
        }
    }
}
