using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyWebApplication.Controllers
{
    /// <summary>
    /// This class is the main controller for all of the MVC pages in the program
    /// </summary>
    public class HomeController : Controller
    {
        /// <summary>
        /// This is the Home page ActionResult
        /// </summary>
        /// <returns>Index</returns>
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Returns the About page view
        /// </summary>
        /// <returns>About</returns>
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        /// <summary>
        /// Returns the contact page
        /// </summary>
        /// <returns>Contact</returns>
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        /// <summary>
        /// This generates the get page for Page2
        /// </summary>
        /// <returns>Page 2</returns>
        [HttpGet]
        public ActionResult Page2()
        {
            ViewBag.Message = "app test page";
            return View();
        }


        /// <summary>
        /// Get page for the simple query
        /// </summary>
        /// <returns>SimpleQueryView</returns>
        [HttpGet]
        public ViewResult SimpleQueryView()
        {
            string FirstName = Request.QueryString["FirstName"];
            string LastName = Request.QueryString["LastName"];

            ViewBag.FirstName = FirstName;
            ViewBag.LastName = LastName;

            return View();
        }

        /// <summary>
        /// This method is the post for Page2
        /// </summary>
        /// <param name="fc"></param>
        /// <returns>Page2 Post</returns>
        [HttpPost]
        public ViewResult Page2(FormCollection fc)
        {
            ViewBag.FirstName = fc["FirstName"];
            ViewBag.LastName = fc["LastName"];
            return View();
        }

        /// <summary>
        /// Get Page for the Loan Calculator
        /// </summary>
        /// <returns>LoanCalculator</returns>
        [HttpGet]
        public ViewResult LoanCalculator()
        {
            return View();
        }

        /// <summary>
        /// Post method for the Loan Calculator
        /// </summary>
        /// <param name="iRate"></param>
        /// <param name="purchasePrice"></param>
        /// <param name="downPayment"></param>
        /// <param name="term"></param>
        /// <returns>Loan Calculator</returns>
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