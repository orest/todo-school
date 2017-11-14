using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TimeTracker_ng4.Data;

namespace TimeTracker_ng4.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var context=new ToDoContext();
            context.ToDos.ToList();
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