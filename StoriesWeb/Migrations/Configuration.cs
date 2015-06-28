namespace StoriesWeb.Migrations
{
    using StoriesWeb.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<StoriesWeb.DAL.StoriesContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "StoriesWeb.DAL.StoriesContext";
        }

        protected override void Seed(StoriesWeb.DAL.StoriesContext context)
        {

            IList<User> users = new List<User>();

            users.Add(new User { Name = "User 1" , UserId = 1 });
            users.Add(new User { Name = "User 2"  , UserId = 2 });

            foreach (var item in users)
            {
                context.Users.AddOrUpdate(item);
            }

            IList<Group> groups = new List<Group>();

            groups.Add(new Group { Name = "Group 1" , Description = "Test Group 1" , Users = users});
            groups.Add(new Group { Name = "Group 2" , Description = "Test Group 2"});

            foreach (var item in groups)
            {
                context.Groups.AddOrUpdate(item);
            }

            IList<Story> stories = new List<Story>();

            stories.Add(new Story { Name = "Story 1", Description = "first story", Content = "First Story Content", UserId = 1, PostedOn = DateTime.Now, StoryId = 1, Groups = groups });
            stories.Add(new Story { Name = "Story 2", Description = "second story", Content = "Second Story Content", UserId = 1, PostedOn = DateTime.Now, StoryId = 2 });

            foreach (var item in stories)
            {
                context.Stories.AddOrUpdate(item);
            }

        }
    }
}
