using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StoriesWeb.DAL;
using StoriesWeb.Models;

namespace StoriesWeb.Controllers
{
    public class HomeController : Controller
    {
        StoriesContext db = new StoriesContext();

        public ActionResult Index()
        {
            db.Users.Add(new User { Name = "Test User" });

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}