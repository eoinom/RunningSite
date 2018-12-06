using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MarathonFestival3.Models;

namespace MarathonFestival3.Controllers
{
    public class OrderController : Controller
    {
        DAO dao = new DAO();
        // GET: Order

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AddOrder()
        {
            return View();
        }

        [HttpPost]

        public ActionResult AddOrder(Order order)

        {
            int counter = 0;
            counter = dao.EnterOrder(order);

            if (counter == 1)
            {
                Response.Write("Thank you for you order");
                ModelState.Clear();
            }

            else
                Response.Write("Error, " + dao.message);
            return View();

        }
    }
}