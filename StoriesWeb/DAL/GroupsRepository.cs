using StoriesWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StoriesWeb.DAL
{
    public interface IGroupsRepository
    {
        IEnumerable<GroupViewModel> GetGroupsInfo();
        IEnumerable<Group> GetAll();
        Group GetbyId(int id);
        void Add(Group group);
        void Update(Group group);
        void Delete(Group group);

        ICollection<Group> GetGroups(string groupIds);

        void JoinGroup(int id, int userid);
        void ShareStory(int id, int storyid);

        IEnumerable<Group> Search(string term);
    }
    public class GroupRepository : Repository, IGroupsRepository
    {
        public GroupRepository(StoriesContext context):base(context)
        {

        }
        public Group GetbyId(int id)
        {
            return _dbContext.Groups.Find(id);
        }

        public void Add(Group group)
        {
            _dbContext.Groups.Add(group);
        }

        public void Update(Group group)
        {
            _dbContext.Entry(group).State = System.Data.Entity.EntityState.Modified;
        }

        public void Delete(Group group)
        {
            _dbContext.Groups.Remove(group);
        }

        public void JoinGroup(int id, int userid)
        {
            throw new NotImplementedException();
        }

        public void ShareStory(int id, int storyid)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Group> GetAll()
        {
           return _dbContext.Groups.ToList();
        }

        public IEnumerable<GroupViewModel> GetGroupsInfo()
        {
            return _dbContext.Groups.Select(x => new GroupViewModel { Name = x.Name, GroupId = x.GroupId, Description = x.Description, StoriesCount = x.Stories.Count(), UsersCount = x.Users.Count() }).ToList();

        }


        public IEnumerable<Group> Search(string term)
        {
            return _dbContext.Groups.Where(x => x.Name.Contains(term)).ToList();
        }

        public ICollection<Group> GetGroups(string groupIds)
        {
            List<Group> result = new List<Group>();
            if (string.IsNullOrEmpty(groupIds))
                return result;
            var ids = groupIds.Split(',');
            int id = -1;
            foreach (var sid in ids)
            {
                if (int.TryParse(sid,out id))
                {
                    var g = _dbContext.Groups.Find(id);
                    if (g != null)
                    {
                        result.Add(g);
                    }
                }
            }
            return result;
        }
    }

}