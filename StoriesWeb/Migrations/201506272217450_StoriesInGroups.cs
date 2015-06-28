namespace StoriesWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class StoriesInGroups : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.StoryGroups",
                c => new
                    {
                        Story_StoryId = c.Int(nullable: false),
                        Group_GroupId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Story_StoryId, t.Group_GroupId })
                .ForeignKey("dbo.Stories", t => t.Story_StoryId, cascadeDelete: true)
                .ForeignKey("dbo.Groups", t => t.Group_GroupId, cascadeDelete: true)
                .Index(t => t.Story_StoryId)
                .Index(t => t.Group_GroupId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.StoryGroups", "Group_GroupId", "dbo.Groups");
            DropForeignKey("dbo.StoryGroups", "Story_StoryId", "dbo.Stories");
            DropIndex("dbo.StoryGroups", new[] { "Group_GroupId" });
            DropIndex("dbo.StoryGroups", new[] { "Story_StoryId" });
            DropTable("dbo.StoryGroups");
        }
    }
}
