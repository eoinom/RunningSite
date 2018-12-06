using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RunningSite.Controllers
{
    public class ResultController : Controller
    {
        // GET: Result
        public ActionResult Search()
        {
            return View();
        }

        public ActionResult SearchResult()
        {
            return View();
        }
    }
}