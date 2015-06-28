using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace StoriesWeb.DAL
{
    public abstract class Repository
    {
        protected StoriesContext _dbContext;

        protected Repository(StoriesContext dataContext)
        {
            _dbContext = dataContext;
        }
    }
}