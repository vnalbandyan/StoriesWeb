using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace StoriesWeb.Models
{
    public class Story
    {
        public int StoryId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Content { get; set; }

        public DateTime PostedOn { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }

        public virtual User User { get; set; }

        public virtual ICollection<Group> Groups { get; set; }
    }

    public class StoryViewModel
    {
        public int StoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }
        public DateTime PostedOn { get; set; }
        public int UserId { get; set; }

        public string SharedGroupIds { get; set; }
    }
}