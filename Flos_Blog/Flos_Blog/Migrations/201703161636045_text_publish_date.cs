namespace Flos_Blog.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class text_publish_date : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Texts", "TextPublishDate", c => c.DateTime(nullable: false));
        }

        public override void Down()
        {
            DropColumn("dbo.Texts", "TextPublishDate");
        }
    }
}