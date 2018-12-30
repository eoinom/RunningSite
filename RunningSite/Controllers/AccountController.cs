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
        public ActionResult Index()
        {
            if (Session["name"] == null)
                return RedirectToAction("Login");
            else
                return View();
        }


        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Account account)
        {
            ModelState.Remove("FirstName");
            ModelState.Remove("LastName");
            ModelState.Remove("ConfirmPassword");
            ModelState.Remove("Country");

            if (ModelState.IsValid)
            {
                //Admin login details: Email = "webdev@outlook.com", Password == "webAdmin"
                if (account.Email == "webdev@outlook.com" && dao.CheckLogin(account) == "Web")
                {
                    Session["name"] = "Admin";
                    Session["email"] = account.Email;

                    return RedirectToAction("Index", "Admin");
                }
                else
                {
                    account.FirstName = dao.CheckLogin(account);
                    if (account.FirstName != null)
                    {
                        Session["name"] = account.FirstName;
                        Session["email"] = account.Email;

                        return RedirectToAction("Index", "Account");
                    }
                    else
                    {
                        ViewBag.Status = "Error " + dao.message;

                        //return View("Status");
                        return View();
                    }
                }
            }
            //return View("Status");
            return View();
        }


        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult Register(Account visitor)
        {
            int counter = 0;
            if (ModelState.IsValid)
            {
                counter = dao.EnterAccount(visitor);
                //if (counter == 1)
                //    ViewBag.Status = "Account created successfully";
                //else
                //    ViewBag.Status = "Error! " + dao.message;

                if (counter == 1)
                {
                    Session["name"] = visitor.FirstName;
                    Session["email"] = visitor.Email;

                    return RedirectToAction("Index", "Account");
                }
                else
                {
                    ViewBag.Status = "Error! " + dao.message;
                    //return View("Status");
                    return View();
                }
                
            }
            return View(visitor);
        }


        [HttpGet]
        public ActionResult Manage()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Manage(Account visitor)
        {
            int counter = 0;
            if (ModelState.IsValid)
            {
                counter = dao.ManageAccount(visitor);       //Need to create dao method for ManageAccount
                if (counter == 1)
                    ViewBag.Status = "Account details updated";
                else
                    ViewBag.Status = "Error! " + dao.message;

                return View("Status");
                //return View();
            }
            return View(visitor);

        }

        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Login");
        }
    }
}