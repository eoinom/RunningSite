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

        [HttpPost]
        public ActionResult Login(Account account)
        {
            ModelState.Remove("FirstName");
            ModelState.Remove("LastName");
            ModelState.Remove("ConfirmPassword");

            if(ModelState.IsValid)
            {
                if(account.AccountRole == RoleEnum.Admin 
                    && account.Email == "webdev@outlook.com" 
                    && account.Password == "webAdmin")
                {
                    Session["name"] = "Admin";
                    Session["email"] = "webdev@outlook.com";

                    return RedirectToAction("Index", "Admin");
                }

                else if(account.AccountRole == RoleEnum.Customer)
                {
                    account.FirstName = dao.CheckLogin(account);
                    if(account.FirstName != null)
                    {
                        Session["name"] = account.FirstName;
                        Session["email"] = account.Email;

                        return RedirectToAction("index", "Home");
                    }
                    else
                    {
                        ViewBag.Status = "Error " + dao.message;

                        return View("Status");
                    }
                }
            }
            return View("Status");
        }

    }
}