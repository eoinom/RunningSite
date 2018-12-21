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
        //public ActionResult AddResult(Result results)
        public ActionResult AddResult(FormCollection resultsForm)
        {
            List<Result> resultsList = new List<Result>();

            int counter = 0;
            //counter = dao.EnterResult(results);

            if (counter == 1)
            {
                ViewBag.Status = "Result details have been entered successfully";
                ModelState.Clear();
            }
            else
            {
                ViewBag.Status = "Error, " + dao.message;
            }
                
            return View();
        }
        #endregion

    }
}