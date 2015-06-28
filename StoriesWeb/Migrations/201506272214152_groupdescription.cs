namespace StoriesWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class groupdescription : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Groups", "Description", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Groups", "Description");
        }
    }
}
