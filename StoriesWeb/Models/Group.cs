using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StoriesWeb.Models
{
    public class Group
    {
        public int GroupId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public virtual ICollection<User> Users { get; set; }

        public virtual ICollection<Story> Stories { get; set; }
    }

    public class GroupViewModel
    {
        public int GroupId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int UsersCount { get; set; }

        public int StoriesCount { get; set; }
    }
}