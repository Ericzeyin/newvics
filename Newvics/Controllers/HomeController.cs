using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Newvics.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(string username,string password)
        {
            if (username == "dvoyagers" && password == "abc123")
            {
                return RedirectToAction("Index", "Main");
            }
            else if (String.IsNullOrEmpty(username) && String.IsNullOrEmpty(password)) {             
                return View();

            }
            else {
                ViewData["Message"] = "Sorry, your username or password is not correct";
                return View();
            }
           
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