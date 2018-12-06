using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MarathonFestival3.Models;

namespace MarathonFestival3.Models
{
    public class HomeController : Controller
    {
        DAO dao = new DAO();
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult AddVisitor()
        {

            return View();
        }

        

        [HttpPost]

        public ActionResult AddVisitor(Visitor visitor)
        {
            int counter = 0;
            counter = dao.EnterVisitor(visitor);

                if (counter == 1)
            {
                Response.Write("Welcome to our Marathon Festival");
                ModelState.Clear();
            }

            else

                Response.Write("Error, " + dao.message);
            return View();
        }

        

        
    }
}
