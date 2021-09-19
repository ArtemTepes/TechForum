namespace TechForum.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Posts",
                c => new
                    {
                        PostId = c.Int(nullable: false, identity: true),
                        PostTitle = c.String(),
                        PostText = c.String(),
                        PostDate = c.DateTime(),
                        UserName = c.String(),
                        TopicId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PostId)
                .ForeignKey("dbo.Topics", t => t.TopicId, cascadeDelete: true)
                .Index(t => t.TopicId);
            
            CreateTable(
                "dbo.Topics",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PostDate = c.DateTime(),
                        Text = c.String(),
                        Title = c.String(),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Posts", "TopicId", "dbo.Topics");
            DropIndex("dbo.Posts", new[] { "TopicId" });
            DropTable("dbo.Topics");
            DropTable("dbo.Posts");
        }
    }
}
