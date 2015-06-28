using StoriesWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StoriesWeb.DAL
{
    public interface IStoriesRepository
    {
        Story GetbyId(int id);
        IEnumerable<Story> GetUserStories(int userid);
        void Add(Story newStory);
        void Delete(Story story);
        void Update(Story story);

    }
    public class StoriesRepository : Repository , IStoriesRepository
    {
        public StoriesRepository(StoriesContext _dbContext) :base(_dbContext)
        {
        }
        public Story GetbyId(int id)
        {
            return _dbContext.Stories.Find(id);
        }

        public IEnumerable<Story> GetUserStories(int userid)
        {
            return _dbContext.Stories.Where(x => x.UserId == userid);
        }


        public void Add(Story newstory)
        {
            _dbContext.Stories.Add(newstory);
        }


        public void Delete(Story story)
        {
            _dbContext.Stories.Remove(story);
        }
        public void Update(Story story)
        {
            // to trigger foreign key update (groups)
            var s = _dbContext.Stories.Find(story.StoryId);
            s.Name = story.Name;
            s.Description = story.Description;
            s.Content = story.Content;
            s.Groups = story.Groups;
            s.PostedOn = story.PostedOn;
            s.UserId = story.UserId;

            //_dbContext.Entry(story).State = System.Data.Entity.EntityState.Modified;
        }
    }
}