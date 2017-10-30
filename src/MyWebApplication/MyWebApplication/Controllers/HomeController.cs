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
        public ViewResult LoanCalculator(decimal iRate, decimal purchasePrice, decimal downPayment, int term)
        {
            const int MonthsInYear = 12;
            decimal payment = 0;
            decimal loanAmt = purchasePrice - downPayment;
            int numYrs = term / MonthsInYear;

            if(numYrs > 0)
            {
                if(iRate != 0)
                {
                    decimal rate = (iRate / MonthsInYear) / 100;
                    decimal factor = (rate + (rate / (decimal)(Math.Pow((double)rate + 1, term) - 1)));
                    payment = (loanAmt * factor);
                }
                else
                {
                    payment = loanAmt / term;
                }
            }
            payment = Math.Round(payment, 2);
            ViewBag.MonthlyPayment = payment;

            return View();
        }
    }
}