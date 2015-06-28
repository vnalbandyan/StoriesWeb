using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StoriesWeb.DAL
{
    public interface IUnitOfWork
    {
        IStoriesRepository StoriesRepo { get; }

        IUsersRepository UsersRepo { get; }

        IGroupsRepository GroupsRepo { get; }

        void SaveChanges();
    }

    public class DBUnitOfWork : IDisposable , IUnitOfWork
    {
        private StoriesContext context;

        public DBUnitOfWork(StoriesContext ctx)
        {
            this.context = ctx;
        }

        private StoriesRepository _storiesRepo;

        public IStoriesRepository StoriesRepo 
        {
            get
            {
                if (_storiesRepo == null)
                {
                    _storiesRepo = new StoriesRepository(context);
                }
                return _storiesRepo;
            }
        }

        private UsersRepository _usersRepo;
        public IUsersRepository UsersRepo 
        {
            get 
            {
                if (_usersRepo == null)
                {
                    _usersRepo = new UsersRepository(context);
                }
                return _usersRepo;
            }
        }
        private GroupRepository _groupsRepo;
        public IGroupsRepository GroupsRepo
        {
            get 
            {
                if (_groupsRepo == null)
                {
                    _groupsRepo = new GroupRepository(context);
                }
                return _groupsRepo;
            }
        }

        public void SaveChanges()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}