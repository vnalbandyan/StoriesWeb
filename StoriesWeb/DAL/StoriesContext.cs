using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using StoriesWeb.Models;

namespace StoriesWeb.DAL
{
    public class StoriesContext : DbContext
    {
        public StoriesContext()
            : base("StoriesDB")
        {
           // Database.SetInitializer<StoriesContext>(new StoriesDBInitializer());
        }

        public DbSet<Story> Stories { get; set; }

        public DbSet<Group> Groups { get; set; }

        public DbSet<User> Users { get; set; }
    }

    public class StoriesDBInitializer : DropCreateDatabaseAlways<StoriesContext>
    {
        protected override void Seed(StoriesContext context)
        {
            IList<User> users = new List<User>();

            users.Add(new User { Name = "User 1" });
            users.Add(new User { Name = "User 2" });

            context.Users.AddRange(users);
            base.Seed(context);
        }
    }
}