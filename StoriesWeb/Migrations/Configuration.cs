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

            users.Add(new User { Name = "User 1" });
            users.Add(new User { Name = "User 2" });

            context.Users.AddRange(users);

            IList<Group> groups = new List<Group>();

            groups.Add(new Group { Name = "Group 1" , Description = "Test Group 1" , Users = users});
            groups.Add(new Group { Name = "Group 2" , Description = "Test Group 2"});

            context.Groups.AddRange(groups);

            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
