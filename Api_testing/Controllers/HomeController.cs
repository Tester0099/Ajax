using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Api_testing.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }

        public ActionResult INSERT()
        {
            return View();
        }

        public ActionResult SHOW()
        {
            return View();
        }

        public ActionResult edit()
        {
            return View();
        }
    }
}
