using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PayPal.Api;
using RunningSite.Models;

namespace MarathonFestival3.Controllers
{
    public class OrderController : Controller
    {
        DAO dao = new DAO();

        [HttpGet]
        public ActionResult AddOrder()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddOrder(RunningSite.Models.Order order)
        {
            ModelState.Remove("OrderNo");
            ModelState.Remove("OrderDate");
            ModelState.Remove("TotalAmount");

            if (ModelState.IsValid)
            {
                // Fetch the festival info from the server and NOT from the POST data.
                // Otherwise users could manipulate the data
                var orderInfo = GetNextFestivalInfo();
                                
                int orderNo = 0;
                order.Email = Session["email"].ToString();
                decimal orderTotal = GetOrderTotal(order.RaceId, order.OrderMedalInsert);
                order.TotalAmount = orderTotal;
                orderNo = dao.EnterOrder(order);

                if (orderNo >= 1)
                {
                    Response.Write("Order entered into DB successfully");
                }
                else
                {
                    Response.Write("Error, " + dao.message);
                }


                // Get PayPal API Context using configuration from web.config
                var apiContext = GetApiContext();

                // Create a new payment object
                var payment = new Payment
                {
                    experience_profile_id = "XP-SB88-M79Q-E8EU-FE8P", // Created in the WebExperienceProfilesController. This one is for NoShipping3.

                    intent = "sale",
                    payer = new Payer
                    {
                        payment_method = "paypal"
                    },
                    transactions = new List<Transaction>
                    {
                        new Transaction
                        {
                            description = $"Marathon Festival entry for {orderInfo.FestivalDate:dddd, dd MMMM yyyy}",
                            amount = new Amount
                            {
                                currency = "EUR",
                                total = orderTotal.ToString() // PayPal expects string amounts, eg. "20.00" 
                            },
                            item_list = new ItemList()
                            {
                                items = new List<Item>()
                                {
                                    new Item()
                                    {
                                        description = $"Marathon Festival entry for {orderInfo.FestivalDate:dddd, dd MMMM yyyy}",
                                        currency = "EUR",
                                        quantity = "1",
                                        price = orderTotal.ToString() // PayPal expects string amounts, eg. "20.00"  
                                    }
                                }
                            }
                        }
                    },
                    redirect_urls = new RedirectUrls
                    {
                        return_url = Url.Action("Return", "Order", null, Request.Url.Scheme),  //Request.Url.Scheme will create a full URL
                        cancel_url = Url.Action("Cancel", "Order", null, Request.Url.Scheme)
                    }
                };

                // Send the payment to PayPal
                var createdPayment = payment.Create(apiContext);

                // Save a reference to the paypal payment
                order.PayPalReference = createdPayment.id;
                int counter = 0;
                counter = dao.AddOrderPayPalRef(order);
                if (counter == 1)
                {
                    Response.Write("Order entered into DB successfully");
                }
                else
                {
                    Response.Write("Error, " + dao.message);
                }
                
                // Find the Approval URL to send our user to
                var approvalUrl =
                    createdPayment.links.FirstOrDefault(
                        x => x.rel.Equals("approval_url", StringComparison.OrdinalIgnoreCase));

                // Send the user to PayPal to approve the payment
                return Redirect(approvalUrl.href);

            }
            return View(order);
        }

        public ActionResult Return(string payerId, string paymentId)
        {
            // Fetch the existing ticket
            //var ticket = _dbContext.Tickets.FirstOrDefault(x => x.PayPalReference == paymentId);

            // Get PayPal API Context using configuration from web.config
            var apiContext = GetApiContext();

            // Set the payer for the payment
            var paymentExecution = new PaymentExecution()
            {
                payer_id = payerId
            };

            // Identify the payment to execute
            var payment = new Payment()
            {
                id = paymentId
            };

            //Get Order No. from Database
            int orderNo = 0;
            orderNo = dao.GetOrderNoFromPayPalRef(payment.id);
            
            // Execute the Payment
            var executedPayment = payment.Execute(apiContext, paymentExecution);

            return RedirectToAction("ThankYou", new { payment.id, orderNo });
        }

        public ActionResult Cancel()
        {
            return View();
        }

        public ActionResult ThankYou(string id, int orderNo)
        {
            ViewBag.paymentId = id;
            ViewBag.orderNo = orderNo;

            return View();
        }

        private Festival GetNextFestivalInfo()
        {
            return new Festival()
            {
                FestivalDate = DateTime.Parse("29/09/2019")
                //FestivalDate = DateTime.Parse("09/29/2019")

                //// Represent price in cents to avoid rounding errors
                //Price_5K = 2000,
                //Price_10K = 2500,
                //Price_HalfMarathon = 3000,
                //Price_Marathon = 5000,
                //Price_MedalInsert = 400
            };
        }

        private APIContext GetApiContext()
        {
            // Authenticate with PayPal
            var config = ConfigManager.Instance.GetProperties();
            var accessToken = new OAuthTokenCredential(config).GetAccessToken();
            var apiContext = new APIContext(accessToken);
            return apiContext;
        }

        private decimal GetOrderTotal(RacesCurrentYearEnum raceId, bool medalInsertIncluded)
        {
            decimal total = 0m;

            switch (raceId)
            {
                case RacesCurrentYearEnum.R2019_05:
                    total = 20m;
                    break;
                case RacesCurrentYearEnum.R2019_10:
                    total = 25m;
                    break;
                case RacesCurrentYearEnum.R2019_21:
                    total = 30m;
                    break;
                case RacesCurrentYearEnum.R2019_42:
                    total = 50m;
                    break;
                default:
                    total = 50m;
                    break;
            }

            if (medalInsertIncluded)
                total += 4m;

            return total;
        }



        [HttpGet]
        public ActionResult AlterOrder()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AlterOrder(RunningSite.Models.Order order)
        {
            int counter = 0;
            counter = dao.AlterOrder(order);

            if (counter == 1)
            {
                Response.Write("Thank you, your order details have been updated.");
                ModelState.Clear();
            }
            else
            {
                Response.Write("Error, " + dao.message);
            }

            return View();
        }
    }
}