using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RunningSite.Models;

namespace RunningSite.Controllers
{
    public class RaceController : Controller
    {
        DAO dao = new DAO();
        // GET: Race
        public ActionResult Index()
        {
            return View();
        }
        
        public ActionResult Marathon()
        {
            return View();
        }

        public ActionResult HalfMarathon()
        {
            return View();
        }

        public ActionResult TenK()
        {
            return View();
        }

        public ActionResult Family5K()
        {
            return View();
        }




        [HttpGet]
        public ActionResult AddRace()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddRace(Race race)
        {
            int counter = 0;
            counter = dao.EnterRace(race);

            if (counter == 1)
            {
                Response.Write("Race details have been entered successfully");
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