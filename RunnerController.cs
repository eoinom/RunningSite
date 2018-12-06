using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MarathonFestival3.Models;

namespace MarathonFestival3.Controllers
{
    public class RunnerController : Controller
    {
        
        DAO dao = new DAO();
        // GET: Runner
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]

        public ActionResult AddRunner()
        {
            return View();
        }

        [HttpPost]

        public ActionResult AddRunner(Runner runner)

        {
            int counter = 0;
            counter = dao.EnterRunner(runner);

            if (counter == 1)
            {
                Response.Write("Runner Details have been entered successfully");
                ModelState.Clear();
            }

            else
                Response.Write("Error, " + dao.message);
            return View();

        }


    }
}