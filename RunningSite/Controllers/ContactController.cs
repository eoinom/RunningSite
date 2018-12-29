using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using RunningSite.Models;

namespace RunningSite.Controllers
{
    public class ContactController : Controller
    {
        static DataSet ds;
        static DataTable dt;
        
        
        // GET: Contact
        public ActionResult ContactUs()
        {

            if (System.IO.File.Exists(Server.MapPath("~/App_Data/ContactUs.xml")))
            {
                ds = new DataSet();
                ds.ReadXml(Server.MapPath("~/App_Data/ContactUs.xml"));
                dt = ds.Tables["Contacts"];
                Response.Write(dt.Rows.Count);
            }
            else
            {
                ds = new DataSet("ContactUs");
                dt = new DataTable("Contacts");
                dt.Columns.Add("Name");
                dt.Columns.Add("Email");
                dt.Columns.Add("Phone");
                dt.Columns.Add("Message");
                ds.Tables.Add(dt);
            }

            return View();
        }

        [HttpPost]
        public ActionResult ContactUs(Contact contact)
        {
            if (ModelState.IsValid)
            {
                DataRow row = dt.NewRow();
                row["Name"] = contact.Name;
                row["Email"] = contact.Email;
                row["Phone"] = contact.Phone;
                row["Message"] = contact.Message;
                dt.Rows.Add(row);
                ds.AcceptChanges();
                ds.WriteXml(Server.MapPath("~/App_Data/ContactUs.xml"));
                ModelState.Clear();
                return View();
            }

            return View(contact);
        }

        public ActionResult ShowAllContactUs()
        {
            List<Contact> list = new List<Contact>();

            DataSet set = new DataSet();
            DataTable table = new DataTable();
            if (System.IO.File.Exists(Server.MapPath("~/App_Data/ContactUs.xml")))
            {
                set.ReadXml(Server.MapPath("~/App_Data/ContactUs.xml"));
                table = set.Tables[0];
                foreach (DataRow row in table.Rows)
                {
                    Contact contact = new Contact();
                    contact.Name = row["Name"].ToString();
                    contact.Email = row["Email"].ToString();
                    contact.Phone = row["Phone"].ToString();
                    contact.Message = row["Message"].ToString();
                    list.Add(contact);
                }
                
            }
            else
            {
                ViewBag.message = "No ContactUs Messages found";
            }

            return View(list);
        }

    }
}