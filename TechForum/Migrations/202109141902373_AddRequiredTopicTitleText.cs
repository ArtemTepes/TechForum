namespace TechForum.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRequiredTopicTitleText : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Posts", "Title", c => c.String(nullable: false));
            AlterColumn("dbo.Posts", "Text", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Posts", "Text", c => c.String());
            AlterColumn("dbo.Posts", "Title", c => c.String());
        }
    }
}
