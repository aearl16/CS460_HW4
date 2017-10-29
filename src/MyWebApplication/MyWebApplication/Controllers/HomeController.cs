using MyWebApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyWebApplication.Controllers
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

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpGet]
        public ActionResult Page2()
        {
            ViewBag.Message = "app test page";

            return View();
        }

        [HttpPost]
        public ViewResult SimpleQueryView(QueryResponse simpleQueryView)
        {
            if(ModelState.IsValid)
            {
                return View(simpleQueryView);
            }
            else
            {
                return View("Error");
            }
        }
    }
}