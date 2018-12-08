using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RunningSite.Models;

namespace RunningSite.Controllers
{
    public class HomeController : Controller
    {
        DAO dao = new DAO();
        // GET: Home
        public ActionResult Index()
        {
            return View("Index");
        }

        public ActionResult FAQ()
        {
            return View("FAQ");
        }
    }
}