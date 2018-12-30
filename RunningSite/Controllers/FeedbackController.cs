using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using RunningSite.Models;

namespace RunningSite.Controllers
{
    public class FeedbackController : Controller
    {
        static DataSet ds;
        static DataTable dt;

        // GET: Feedback       
        public ActionResult FeedBack()
        {
            if (System.IO.File.Exists(Server.MapPath("~/App_Data/feedback.xml")))
            {
                ds = new DataSet();
                ds.ReadXml(Server.MapPath("~/App_Data/feedback.xml"));
                dt = ds.Tables["FeedBack"];
                Response.Write(dt.Rows.Count);
            }
            else
            {
                ds = new DataSet("RaceFeedBack");
                dt = new DataTable("FeedBack");
                dt.Columns.Add("Name");
                dt.Columns.Add("Email");
                dt.Columns.Add("Phone");
                dt.Columns.Add("Race");
                dt.Columns.Add("Message");
                ds.Tables.Add(dt);
            }
            
            return View();
        }


        [HttpPost]
        public ActionResult Feedback(Feedback feedback)
        {
            if (ModelState.IsValid)
            {
                DataRow row = dt.NewRow();
                row["Name"] = feedback.Name;
                row["Email"] = feedback.Email;
                row["Phone"] = feedback.Phone;
                row["Race"] = feedback.Race;
                row["Message"] = feedback.Message;
                dt.Rows.Add(row);
                ds.AcceptChanges();
                ds.WriteXml(Server.MapPath("~/App_Data/feedback.xml"));
                ModelState.Clear();
                return View();
            }

            return View(feedback);
        }

        public ActionResult ShowAllFeedback()
        {
            List<Feedback> list = new List<Feedback>();

            DataSet set = new DataSet();
            DataTable table = new DataTable();
            if (System.IO.File.Exists(Server.MapPath("~/App_Data/feedback.xml")))
            {
                set.ReadXml(Server.MapPath("~/App_Data/feedback.xml"));
                table = set.Tables[0];
                foreach (DataRow row in table.Rows)
                {
                    Feedback feedback = new Feedback();
                    feedback.Name = row["Name"].ToString();
                    feedback.Email = row["Email"].ToString();
                    feedback.Phone = row["Phone"].ToString();
                    feedback.Message = row["Message"].ToString();
                    list.Add(feedback);
                }

            }
            else
            {
                ViewBag.message = "No Feedback Messages found";
            }

            return View(list);
        }

    }
    
}