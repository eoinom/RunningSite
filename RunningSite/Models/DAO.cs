﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Web.Configuration;
using System.Web.Helpers;


namespace RunningSite.Models
{

    public class DAO
    {
        SqlConnection con;
        public string message = "";

        #region Constructor
        public DAO()
        {
            con = new SqlConnection(WebConfigurationManager.ConnectionStrings["conString"].ConnectionString);
        }
        #endregion

        #region Accounts
        public int EnterAccount(Account account)
        {
            int count = 0;
            string password;
            SqlCommand cmd = new SqlCommand("usp_EnterAccountDetails", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Email", account.Email);
            password = Crypto.HashPassword(account.Password);
            cmd.Parameters.AddWithValue("@Pass", password);
            cmd.Parameters.AddWithValue("@FirstName", account.FirstName);
            cmd.Parameters.AddWithValue("@LastName", account.LastName);
            cmd.Parameters.AddWithValue("@Country", account.Country);
            cmd.Parameters.AddWithValue("@Gender", account.Gender);
            cmd.Parameters.AddWithValue("@DOB", account.DOB);
            cmd.Parameters.AddWithValue("@NewsletterSub", account.NewsletterSub);

            try
            {
                con.Open();
                count = cmd.ExecuteNonQuery();
            }
            catch (SystemException ex)
            {
                message = ex.Message;
            }
            finally
            {
                con.Close();
            }
            return count;
        }


        public string CheckLogin(Account account)
        {
            string password, firstName = null;
            SqlDataReader reader;
            SqlCommand cmd = new SqlCommand("usp_CheckCredentials", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Email", account.Email);

            try
            {
                con.Open();
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    password = reader["Pass"].ToString();
                    if (Crypto.VerifyHashedPassword(password, account.Password))
                    {
                        firstName = reader["FirstName"].ToString();
                    }
                    else
                    {
                        message = "password incorrect";
                    }
                }
            }
            catch (SqlException ex)
            {
                message = ex.Message;
            }
            catch (FormatException ex1)
            {
                message = ex1.Message;
            }
            finally
            {
                con.Close();
            }
            return firstName;
        }

        public int ManageAccount(Account account)
        {
            int count = 0;
            SqlCommand cmd = new SqlCommand("usp_AmendAccountDetails", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Email", account.Email);
            string password = Crypto.HashPassword(account.Password);
            cmd.Parameters.AddWithValue("@Password", password);
            cmd.Parameters.AddWithValue("@NewsletterSub", account.NewsletterSub);

            try
            {
                con.Open();
                count = cmd.ExecuteNonQuery();
            }
            catch (SystemException ex)
            {
                message = ex.Message;
            }
            finally
            {
                con.Close();
            }
            return count;
        }

        public List<Account> ShowAllAccounts()
        {
            List<Account> accountList = new List<Account>();

            SqlDataReader reader;
            SqlCommand cmd = new SqlCommand("usp_ShowAllAccounts", con);
            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                con.Open();

                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Account account = new Account();
                    account.Email = reader["Email"].ToString();
                    account.FirstName = reader["FirstName"].ToString();
                    account.LastName = reader["LastName"].ToString();
                    account.DOB = DateTime.Parse(reader["DOB"].ToString());
                    //public string dateString = string.Format("{0:dd/MM/yyyy}", account.DOB);

                    accountList.Add(account);
                }
            }
            catch (Exception ex)
            {
                message = ex.Message;
            }
            finally
            {
                con.Close();
            }

            return accountList;
        }

        #endregion

        #region Orders

        public int EnterOrder(Order order)
        {
            int? order_no = 0;
            SqlCommand cmd = new SqlCommand("usp_EnterOrderDetailsANDResults", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@OrderNo", order.OrderNo);
            cmd.Parameters.AddWithValue("@OrderDate", DateTime.Today.Date);

            cmd.Parameters.AddWithValue("@RaceId", order.RaceId);
            //cmd.Parameters.AddWithValue("@BibNo", order.BibNo);
            cmd.Parameters.AddWithValue("@TShirtSize", order.TshirtSize);
            cmd.Parameters.AddWithValue("@OrderMedalInsert", order.OrderMedalInsert);
            cmd.Parameters.AddWithValue("@StartGroup", order.StartGroup);
            cmd.Parameters.AddWithValue("@TotalAmount", order.TotalAmount);
                        
            cmd.Parameters.AddWithValue("@Address1", order.AddressLine1);
            cmd.Parameters.AddWithValue("@Address2", order.AddressLine2);
            cmd.Parameters.AddWithValue("@City", order.City);
            cmd.Parameters.AddWithValue("@PostalCode", order.PostCode);
            cmd.Parameters.AddWithValue("@Country", order.Country);
            cmd.Parameters.AddWithValue("@Mobile", order.Mobile);

            cmd.Parameters.AddWithValue("@EmergencyContactName", order.EmergencyContactName);
            cmd.Parameters.AddWithValue("@EmergencyContactNumber", order.EmergencyContactNumber);
            cmd.Parameters.AddWithValue("@MedicalDetails", order.MedicalDetails);
            cmd.Parameters.AddWithValue("@AgreeTermsAndConditions", order.AgreeTermsAndConditions);
            
            cmd.Parameters.AddWithValue("@Email", order.Email);

            try
            {
                con.Open();
                order_no = (int?)cmd.ExecuteScalar();
                order.OrderNo = order_no.GetValueOrDefault();
            }
            catch (SystemException ex)
            {
                message = ex.Message;
            }
            finally
            {
                con.Close();
            }
            return order_no.GetValueOrDefault();
        }

        
        public int AddOrderPayPalRef(Order order)
        {
            int count = 0;
            SqlCommand cmd = new SqlCommand("usp_AlterOrderPayPalRef", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@OrderNo", order.OrderNo);
            cmd.Parameters.AddWithValue("@PayPalReference", order.PayPalReference);
            
            try
            {
                con.Open();
                count = cmd.ExecuteNonQuery();
            }
            catch (SystemException ex)
            {
                message = ex.Message;
            }
            finally
            {
                con.Close();
            }
            return count;
        }


        public int GetOrderNoFromPayPalRef(string payPalRef)
        {
            int? order_no = 0;
            SqlCommand cmd = new SqlCommand("usp_GetOrderNoFromPayPalRef", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@PayPalReference", payPalRef);

            try
            {
                con.Open();
                order_no = (int?)cmd.ExecuteScalar();
            }
            catch (SystemException ex)
            {
                message = ex.Message;
            }
            finally
            {
                con.Close();
            }
            return order_no.GetValueOrDefault();
        }


        public int GetLastOrderNoFromEmail(string email)
        {
            int? order_no = 0;
            SqlCommand cmd = new SqlCommand("usp_GetLastOrderNoFromEmail", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@email", email);

            try
            {
                con.Open();
                order_no = (int?)cmd.ExecuteScalar();
            }
            catch (SystemException ex)
            {
                message = ex.Message;
            }
            finally
            {
                con.Close();
            }
            return order_no.GetValueOrDefault();
        }


        public int AlterOrder(Order order)
        {
            int count = 0;
            SqlCommand cmd = new SqlCommand("usp_AlterOrderDetails", con);  
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@OrderNo", order.OrderNo);
                        
            cmd.Parameters.AddWithValue("@Address1", order.AddressLine1);
            cmd.Parameters.AddWithValue("@Address2", order.AddressLine2);
            cmd.Parameters.AddWithValue("@City", order.City);
            cmd.Parameters.AddWithValue("@Country", order.Country);
            cmd.Parameters.AddWithValue("@PostalCode", order.PostCode);

            cmd.Parameters.AddWithValue("@TShirtSize", order.TshirtSize);
            cmd.Parameters.AddWithValue("@Mobile", order.Mobile);
            cmd.Parameters.AddWithValue("@EmergencyContactName", order.EmergencyContactName);
            cmd.Parameters.AddWithValue("@EmergencyContactNumber", order.EmergencyContactNumber);
            cmd.Parameters.AddWithValue("@MedicalDetails", order.MedicalDetails);
            cmd.Parameters.AddWithValue("@RaceId", order.RaceId);
            cmd.Parameters.AddWithValue("@StartGroup", order.StartGroup);

            try
            {
                con.Open();
                count = cmd.ExecuteNonQuery();
            }
            catch (SystemException ex)
            {
                message = ex.Message;
            }
            finally
            {
                con.Close();
            }
            return count;
        }


        public Order ShowLastOrder(string email)
        {
            Order lastOrder = new Order();

            SqlDataReader reader;
            SqlCommand cmd = new SqlCommand("usp_GetLastOrderFromEmail", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@email", email);

            try
            {
                con.Open();

                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    lastOrder.OrderNo = (int)reader[0];
                    lastOrder.OrderDate = (DateTime)reader[1];
                    lastOrder.TotalAmount = (decimal)reader[2];
                    lastOrder.RaceId = (RacesCurrentYearEnum)int.Parse(reader[3].ToString());
                    lastOrder.StartGroup = (StartGroupEnum)int.Parse(reader[4].ToString());
                    lastOrder.PayPalReference = reader[5].ToString();
                    lastOrder.Email = reader[6].ToString();
                }
            }
            catch (Exception ex)
            {
                message = ex.Message;
            }
            finally
            {
                con.Close();
            }
            return lastOrder;
        }

        public List<Order> ShowAllOrders()
        {
            List<Order> allOrdersList = new List<Order>();

            SqlDataReader reader;
            SqlCommand cmd = new SqlCommand("usp_ShowAllOrders", con);
            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                con.Open();

                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Order order = new Order();

                    order.OrderNo = Int32.Parse(reader["OrderNo"].ToString());
                    order.OrderDate = DateTime.Parse(reader["OrderDate"].ToString());
                    order.Email = reader["Email"].ToString();
                    order.RaceId = (RacesCurrentYearEnum)int.Parse(reader[13].ToString());
                    order.TotalAmount = decimal.Parse(reader["TotalAmount"].ToString());

                    allOrdersList.Add(order);
                }
            }
            catch (Exception ex)
            {
                message = ex.Message;
            }
            finally
            {
                con.Close();
            }

            return allOrdersList;
        }


        #endregion

        #region Race

        public int EnterRace(Race race)
        {
            int count = 0;
            SqlCommand cmd = new SqlCommand("usp_EnterRaceDetails", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@RaceId", race.RaceId);
            cmd.Parameters.AddWithValue("@RaceName", race.RaceName);
            cmd.Parameters.AddWithValue("@RaceDate", race.RaceDate);
            cmd.Parameters.AddWithValue("@RaceLimit", race.RaceLimit);
            cmd.Parameters.AddWithValue("@Price", race.Price);

            try
            {
                con.Open();
                count = cmd.ExecuteNonQuery();
            }
            catch (SystemException ex)
            {
                message = ex.Message;
            }
            finally
            {
                con.Close();
            }
            return count;
        }

        public List<Race> ShowAllRaces()
        {
            List<Race> raceList = new List<Race>();
            SqlDataReader reader;
            SqlCommand cmd;
            cmd = new SqlCommand("usp_ShowAllRaces", con);
            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                con.Open();
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Race race = new Race();
                    race.RaceId = reader["RaceId"].ToString();
                    race.RaceName = reader["RaceName"].ToString();
                    race.RaceDate = DateTime.Parse(reader["RaceDate"].ToString());
                    race.RaceLimit = Int32.Parse(reader["RaceLimit"].ToString());
                    race.Price = decimal.Parse(reader["Price"].ToString());
                    raceList.Add(race);
                }
            }
            catch (Exception ex)
            {
                message = ex.Message;
            }
            finally
            {
                con.Close();
            }
            return raceList;
        }

        #endregion

        #region Results

        public int EnterResult(Results results)
        {
            int count = 0;

            foreach (Result result in results.ResultList_IEnumerable)
            {
                //SqlCommand cmd = new SqlCommand("usp_EnterResultsDetails", con);      //This SP enters RaceId, BibNo, FinishPlace, FinishTime and ChipTime (does not require existing row with RaceId and BibNo)
                SqlCommand cmd = new SqlCommand("usp_UpdateResultsDetails", con);       //This SP updates existing db rows based in RaceId and BibNo with the FinishPlace, FinishTime and ChipTime
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@RaceId", result.RaceId);
                cmd.Parameters.AddWithValue("@BibNo", result.BibNo);
                cmd.Parameters.AddWithValue("@FinishPlace", result.FinishPlace);
                cmd.Parameters.AddWithValue("@FinishTime", result.FinishTime);
                cmd.Parameters.AddWithValue("@ChipTime", result.ChipTime);

                try
                {
                    con.Open();
                    count += cmd.ExecuteNonQuery();
                }
                catch (SystemException ex)
                {
                    message = ex.Message;
                }
                finally
                {
                    con.Close();
                }
            }

            return count;
        }


        public Results SearchResults(Result resultSearch)
        {
            Results resultsList = new Results();
            SqlDataReader reader;

            SqlCommand cmd = new SqlCommand("usp_FindResults", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@RaceId", resultSearch.RaceId);
            //cmd.Parameters.AddWithValue("@BibNo", resultSearch.BibNo);
            //cmd.Parameters.AddWithValue("@FinishPlace", resultSearch.FinishPlace);
            //cmd.Parameters.AddWithValue("@FinishTime", resultSearch.FinishTime);
            //cmd.Parameters.AddWithValue("@ChipTime", resultSearch.ChipTime);
            //cmd.Parameters.AddWithValue("@Email", resultSearch.Email);

            try
            {
                con.Open();
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Result result = new Result();
                    result.RaceId = reader["RaceId"].ToString();       //can use the index no. of the database table column or the name of the column
                    result.BibNo = int.Parse(reader["BibNo"].ToString());
                    result.FinishPlace = int.Parse(reader["FinishPlace"].ToString());
                    result.FinishTime = TimeSpan.Parse(reader["FinishTime"].ToString());
                    result.ChipTime = TimeSpan.Parse(reader["ChipTime"].ToString());
                    result.Email = reader["Email"].ToString();
                    resultsList.Add(result);
                }
            }
            catch (SystemException ex)
            {
                message = ex.Message;
            }
            finally
            {
                con.Close();
            }
            return resultsList;
        }
        #endregion
    }
}