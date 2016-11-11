using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Schoolapp1.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your Application Description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your Contact page.";

            return View();
        }
    }
}