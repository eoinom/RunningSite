using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RunningSite.Models;

namespace RunningSite.Controllers
{
    public class AccountController : Controller
    {
        DAO dao = new DAO();

        // GET: Account
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Account visitor)
        {
            //Add code for checking email and password credentials against stored DB values
            return View("AddOrder");
        }

        //[HttpGet]
        //public ActionResult AddAccount()
        //{
        //    return View("Login");
        //}

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult Register(Account visitor)
        {
            int counter = 0;
            counter = dao.EnterAccount(visitor);

            if (counter == 1)
            {
                
                ModelState.Clear();
                return View("AddOrder");
            }
            else
            {
                Response.Write("Error, " + dao.message);
                return View();
            }
        }
    }
}