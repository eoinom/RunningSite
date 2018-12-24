using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
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

        [HttpPost]
        public ActionResult Search(Result resultSearch)
        {
            Thread.Sleep(2000);         //delay for 2s

            ModelState.Remove("BibNo");
            ModelState.Remove("Name");
            ModelState.Remove("FinishPlace");
            ModelState.Remove("FinishTime");
            ModelState.Remove("ChipTime");
            ModelState.Remove("Email");

            if (ModelState.IsValid)
            {
                var searchResultsList = dao.SearchResults(resultSearch);
                if (searchResultsList.ResultList.Count == 0)
                    return Content(dao.message);
                else
                {
                    return PartialView("SearchResultsTable", searchResultsList);
                }
            }
            return ViewBag.Status = "Input Error";
        }

        #endregion


        #region Admin Actions 

        [HttpGet]
        public ActionResult AddResult()
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult AddResult(Results results)
        {
            int counter = 0;
            int noResults = results.ResultList_IEnumerable.Count();

            if (results == null)
            {
                ViewBag.Status = "Please add some results";
            }
            else
            {
                counter = dao.EnterResult(results);

                if (counter == 0)
                {
                    ViewBag.Status = "Error, no rows entered";
                }
                else if (counter > 0)
                {
                    if (counter == 1)
                        ViewBag.Status = "1 row has been entered successfully.";
                    else
                        ViewBag.Status = counter.ToString() + " rows have been entered successfully.";

                    if (dao.message != "")
                    {
                        ViewBag.Status2 = "Error, " + dao.message;
                    }
                    else if (noResults > counter)
                    {
                        if (noResults - counter == 1)
                            ViewBag.Status2 = "1 row has not been entered.";
                        else
                            ViewBag.Status2 = (noResults - counter).ToString() + " rows have not been entered.";

                        ViewBag.Status2 += " Please ensure you enter a valid existing Race Id and Bib No. combination.";
                    }
                    ModelState.Clear();
                }
                else
                {
                    ViewBag.Status = "Error, " + dao.message;
                }
            }

            return View();
        }

        #endregion
    }
}