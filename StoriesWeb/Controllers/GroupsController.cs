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
    public class GroupsController : Controller
    {
        
        private IUnitOfWork _uow;

        public GroupsController():base()
        {
            _uow = new DBUnitOfWork(new StoriesContext());
        }
        // ctor for Unit testing with fake Repositories
        public GroupsController(IUnitOfWork unitofWork):base()
        {
            _uow = unitofWork;
        }

        // GET: Groups
        public ActionResult Index()
        {
            return View(_uow.GroupsRepo.GetGroupsInfo());
        }

        // GET: Groups/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Group group = _uow.GroupsRepo.GetbyId(id.Value);
            if (group == null)
            {
                return HttpNotFound();
            }
            return View(group);
        }

        // GET: Groups/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Groups/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "GroupId,Name,Description")] Group group)
        {
            if (ModelState.IsValid)
            {
                _uow.GroupsRepo.Add(group);
                _uow.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(group);
        }

        // GET: Groups/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Group group = _uow.GroupsRepo.GetbyId(id.Value);
            if (group == null)
            {
                return HttpNotFound();
            }
            return View(group);
        }

        // POST: Groups/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "GroupId,Name,Description")] Group group)
        {
            if (ModelState.IsValid)
            {
                _uow.GroupsRepo.Update(group);
                _uow.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(group);
        }

        // GET: Groups/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Group group = _uow.GroupsRepo.GetbyId(id.Value);
            if (group == null)
            {
                return HttpNotFound();
            }
            return View(group);
        }

        // POST: Groups/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Group group = _uow.GroupsRepo.GetbyId(id);
            _uow.GroupsRepo.Delete(group);
            _uow.SaveChanges();
            return RedirectToAction("Index");
        }

        public JsonResult Search(string term)
        {
            var result = _uow.GroupsRepo.Search(term);
            return Json(result.Select(x => new { label = x.Name, value = x.GroupId }),JsonRequestBehavior.AllowGet);
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
