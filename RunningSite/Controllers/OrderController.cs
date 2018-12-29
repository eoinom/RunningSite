using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RunningSite.Models;

namespace MarathonFestival3.Controllers
{
    public class OrderController : Controller
    {
        DAO dao = new DAO();

        // GET: Order
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult AddOrder()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddOrder(Order order)
        {
            ModelState.Remove("OrderNo");
            ModelState.Remove("OrderDate");
            ModelState.Remove("TotalAmount");
            ModelState.Remove("AgreeRaceDisclaimer");
            ModelState.Remove("AgreeTermsAndConditions");

            if (ModelState.IsValid) { 
                int counter = 0;
                order.Email = Session["email"].ToString();
                counter = dao.EnterOrder(order);

                if (counter == 1)
                {
                    Response.Write("Your order is complete and you have now secured your place in the Festival.");
                    ModelState.Clear();
                    return RedirectToAction("Index", "Account");
                }
                else
                {
                    Response.Write("Error, " + dao.message);
                }
            }
            return View();
        }


        [HttpGet]
        public ActionResult AlterOrder()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AlterOrder(Order order)
        {
            int counter = 0;
            counter = dao.AlterOrder(order);

            if (counter == 1)
            {
                Response.Write("Thank you, your order details have been updated.");
                ModelState.Clear();
            }
            else
            {
                Response.Write("Error, " + dao.message);
            }

            return View();
        }
    }
}