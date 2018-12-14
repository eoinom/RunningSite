using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RunningSite.Models;

namespace RunningSite.Controllers
{
    public class ResultController : Controller
    {
        DAO dao = new DAO();

        #region User Actions  
        // GET: Result
        public ActionResult Search()
        {
            return View();
        }

        #endregion

        #region Admin Actions        
        [HttpGet]
        public ActionResult AddResult()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddResult(Result runner)
        {
            int counter = 0;
            counter = dao.EnterResult(runner);

            if (counter == 1)
            {
                Response.Write("Runner Details have been entered successfully");
                ModelState.Clear();
            }
            else
            {
                Response.Write("Error, " + dao.message);
            }
                
            return View();
        }
        #endregion

    }
}