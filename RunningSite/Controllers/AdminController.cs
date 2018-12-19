using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RunningSite.Models;

namespace RunningSite.Controllers
{
    public class AdminController : Controller
    {
        DAO dao = new DAO();

        // GET: Admin
        public ActionResult Index()
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