using StoriesWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StoriesWeb.DAL
{
    public interface IUsersRepository
    {
        IQueryable<User> Query();
        User GetbyId(int id);
        void Add(User user);
        void Update(User user);
        void Delete(User user);
 
    }
    public class UsersRepository : Repository , IUsersRepository
    {
        public UsersRepository(StoriesContext context):base(context)
        {

        }

        public User GetbyId(int id)
        {
            return _dbContext.Users.Find(id);
        }

        public void Add(User user)
        {
            _dbContext.Users.Add(user);
        }

        public void Update(User user)
        {
            _dbContext.Entry(user).State = System.Data.Entity.EntityState.Modified;
        }

        public void Delete(User user)
        {
            _dbContext.Users.Remove(user);
        }

        public IQueryable<User> Query()
        {
            return _dbContext.Users;
        }
    }
}