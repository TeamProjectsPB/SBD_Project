using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SBD_Project.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult IndexUser()
        {
            if (User.IsInRole("Administrator"))
            {
//                return Redirect("IndexAdmin");
                return View("IndexAdmin");
            }
            else if (User.IsInRole("Pracownik"))
            {
                return View("IndexEmployee");
            }
            else if (User.IsInRole("Kierowca"))
            {
                return View("IndexDriver");
            }
            else
            {
                return View("Index");
            }
        }

        public ActionResult IndexAdmin()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        public ActionResult IndexDriver()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        
            public ActionResult IndexEmployee()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        public ActionResult Career()
        {
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}