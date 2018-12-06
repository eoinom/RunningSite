﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MarathonFestival3.Models;

namespace MarathonFestival3.Controllers
{
    public class RaceController : Controller
    {
        DAO dao = new DAO();
        // GET: Race
        public ActionResult Index()
        {
            return View();
        }

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
                Response.Write("Race Details have been entered successfully");
                ModelState.Clear();
            }

            else
                Response.Write("Error, " + dao.message);
            return View();

        }
    }
}