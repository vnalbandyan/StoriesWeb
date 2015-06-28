using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StoriesWeb.Models
{
    public class User
    {
        public int UserId { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Story> Stories { get; set; }

        public virtual ICollection<Group> Groups { get; set; }
    }
}