namespace Flos_Blog.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class text_type : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Texts", "TextProse", c => c.Boolean(nullable: false));
            AddColumn("dbo.Texts", "TextPoetry", c => c.Boolean(nullable: false));
            AddColumn("dbo.Texts", "TextBlog", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Texts", "TextBlog");
            DropColumn("dbo.Texts", "TextPoetry");
            DropColumn("dbo.Texts", "TextProse");
        }
    }
}
