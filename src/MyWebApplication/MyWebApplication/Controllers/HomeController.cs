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


        [HttpGet]
        public ViewResult SimpleQueryView()
        {
            return View();
        }

        [HttpPost]
        public ViewResult Page2(FormCollection fc)
        {
            ViewBag.FirstName = fc["FirstName"];
            ViewBag.LastName = fc["LastName"];
            return View();
        }

        [HttpGet]
        public ViewResult LoanCalculator()
        {
            return View();
        }

        [HttpPost]
        public ViewResult LoanCalculator(decimal? iRate, int? loanAmt, int? downPayment, int? term)
        {
            return View();
        }
    }
}