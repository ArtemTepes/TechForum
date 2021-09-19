namespace TechForum.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Posts", "Title", c => c.String());
            AddColumn("dbo.Posts", "Text", c => c.String());
            DropColumn("dbo.Posts", "PostTitle");
            DropColumn("dbo.Posts", "PostText");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Posts", "PostText", c => c.String());
            AddColumn("dbo.Posts", "PostTitle", c => c.String());
            DropColumn("dbo.Posts", "Text");
            DropColumn("dbo.Posts", "Title");
        }
    }
}
