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

    }
}