using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using StoriesWeb.DAL;
using StoriesWeb.Models;


namespace StoriesWeb.Controllers
{
    public class StoriesController : Controller
    {
        private IUnitOfWork _uow;

        public StoriesController():base()
        {
            _uow = new DBUnitOfWork(new StoriesContext());
        }

        // constructor for pluging fake data store for unit testing
        public StoriesController(IUnitOfWork unitofWork):base()
        {
            _uow = unitofWork;
        }
        
        
        // GET: Stories
        public ActionResult Index()
        {
            //get curent user id from identity 
            int userid = 1;
            
            var stories = _uow.StoriesRepo.GetUserStories(userid);
            return View(stories);
        }

        // GET: Stories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Story story = _uow.StoriesRepo.GetbyId(id.Value);
            if (story == null)
            {
                return HttpNotFound();
            }
            return View(story);
        }

        // GET: Stories/Create
        public ActionResult Create()
        {
            ViewBag.UserId = new SelectList(_uow.UsersRepo.Query(), "UserId", "Name");
            return View();
        }

        // POST: Stories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Name,Description,Content,PostedOn,UserId,SharedGroupIds")] StoryViewModel storyVM)
        {
            if (ModelState.IsValid)
            {
                var groupstoShare = _uow.GroupsRepo.GetGroups(storyVM.SharedGroupIds);

                _uow.StoriesRepo.Add(new Story { Name = storyVM.Name, Content = storyVM.Content, PostedOn = DateTime.Now, Description = storyVM.Description, UserId = storyVM.UserId, Groups = groupstoShare });
                _uow.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UserId = new SelectList(_uow.UsersRepo.Query(), "UserId", "Name", storyVM.UserId);
            return View(storyVM);
        }

        // GET: Stories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Story story = _uow.StoriesRepo.GetbyId(id.Value);
            if (story == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserId = new SelectList(_uow.UsersRepo.Query(), "UserId", "Name", story.UserId);
            return View(new StoryViewModel { StoryId = story.StoryId, Content = story.Content, Description = story.Description, Name = story.Name, PostedOn = story.PostedOn, UserId = story.UserId, SharedGroupIds = string.Join(",", story.Groups.Select(x => x.GroupId)) });
        }

        // POST: Stories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "StoryId,Name,Description,Content,PostedOn,UserId,SharedGroupIds")] StoryViewModel storyVM)
        {
            if (ModelState.IsValid)
            {
                var groupstoShare = _uow.GroupsRepo.GetGroups(storyVM.SharedGroupIds);

                _uow.StoriesRepo.Update(new Story {StoryId = storyVM.StoryId, Name = storyVM.Name, Content = storyVM.Content, PostedOn = DateTime.Now, Description = storyVM.Description, UserId = storyVM.UserId, Groups = groupstoShare });
                _uow.SaveChanges();

                return RedirectToAction("Index");
            }
            ViewBag.UserId = new SelectList(_uow.UsersRepo.Query(), "UserId", "Name", storyVM.UserId);
            return View(storyVM);
        }

        // GET: Stories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Story story = _uow.StoriesRepo.GetbyId(id.Value); 
            if (story == null)
            {
                return HttpNotFound();
            }
            return View(story);
        }

        // POST: Stories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Story story = _uow.StoriesRepo.GetbyId(id);
            _uow.StoriesRepo.Delete(story);
            _uow.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                var d = _uow as IDisposable;
                if (d != null)
                {
                    d.Dispose();
                }
            }
            base.Dispose(disposing);
        }
    }
}
