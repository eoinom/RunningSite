using System;
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
            //test
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
            SqlCommand cmd = new SqlCommand("usp_AmendAccountDetails", con);    //Need to create this Stored Procedure
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Email", account.Email);
            string password = Crypto.HashPassword(account.Password);
            cmd.Parameters.AddWithValue("@Pass", password);
            cmd.Parameters.AddWithValue("@Country", account.Country);
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

        #endregion

        #region Orders

        public int EnterOrder(Order order)
        {
            int count = 0;
            SqlCommand cmd = new SqlCommand("usp_EnterOrderDetails1", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@OrderNo", order.OrderNo);
            cmd.Parameters.AddWithValue("@OrderDate", DateTime.Today.Date);

            cmd.Parameters.AddWithValue("@RaceId", order.RaceId);
            //cmd.Parameters.AddWithValue("@BibNo", order.BibNo);
            cmd.Parameters.AddWithValue("@TShirtSize", order.TshirtSize);
            cmd.Parameters.AddWithValue("@OrderMedalInsert", order.OrderMedalInsert);
            cmd.Parameters.AddWithValue("@StartGroup", order.StartGroup);
            cmd.Parameters.AddWithValue("@TotalAmount", order.TotalAmount);

            cmd.Parameters.AddWithValue("@AgreeRaceDisclaimer", order.AgreeRaceDisclaimer);
            cmd.Parameters.AddWithValue("@AgreeTermsAndConditions", order.AgreeTermsAndConditions);

            cmd.Parameters.AddWithValue("@Address1", order.AddressLine1);
            cmd.Parameters.AddWithValue("@Address2", order.AddressLine2);
            cmd.Parameters.AddWithValue("@City", order.City);
            cmd.Parameters.AddWithValue("@PostalCode", order.PostCode);
            cmd.Parameters.AddWithValue("@Country", order.Country);

            cmd.Parameters.AddWithValue("@EmergencyContactName", order.EmergencyContactName);
            cmd.Parameters.AddWithValue("@EmergencyContactNumber", order.EmergencyContactNumber);
            cmd.Parameters.AddWithValue("@MedicalDetails", order.MedicalDetails);
            cmd.Parameters.AddWithValue("@Mobile", order.Mobile);
            cmd.Parameters.AddWithValue("@Email", order.Email);  

            cmd.Parameters.AddWithValue("@CC_Type", order.CC_Type);
            cmd.Parameters.AddWithValue("@CC_Holder_FirstName", order.CC_Holder_FirstName);
            cmd.Parameters.AddWithValue("@CC_Holder_LastName", order.CC_Holder_LastName);
            cmd.Parameters.AddWithValue("@CC_Number", order.CC_Number);
            cmd.Parameters.AddWithValue("@CC_ExpDate_Month", order.CC_ExpDate_Month);
            cmd.Parameters.AddWithValue("@CC_ExpDate_Year", order.CC_ExpDate_Year);
            cmd.Parameters.AddWithValue("@CC_SecCode", order.CC_SecCode);

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


        public int AlterOrder(Order order)
        {
            int count = 0;
            SqlCommand cmd = new SqlCommand("usp_AlterOrderDetails", con);  //need to create this SP
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@OrderNo", order.OrderNo);
            //cmd.Parameters.AddWithValue("@OrderNo", order.OrderName);

            cmd.Parameters.AddWithValue("@RaceId", order.RaceId);
            //cmd.Parameters.AddWithValue("@BibNo", order.BibNo);
            cmd.Parameters.AddWithValue("@TShirtSize", order.TshirtSize);
            //cmd.Parameters.AddWithValue("@OrderMedalInsert", order.OrderMedalInsert);
            cmd.Parameters.AddWithValue("@StartGroup", order.StartGroup);
            //cmd.Parameters.AddWithValue("@TotalAmount", order.TotalAmount);

            //cmd.Parameters.AddWithValue("@AgreeRaceDisclaimer", order.AgreeRaceDisclaimer);
            //cmd.Parameters.AddWithValue("@AgreeTermsAndConditions", order.AgreeTermsAndConditions);

            cmd.Parameters.AddWithValue("@Address1", order.AddressLine1);
            cmd.Parameters.AddWithValue("@Address2", order.AddressLine2);
            cmd.Parameters.AddWithValue("@City", order.City);
            cmd.Parameters.AddWithValue("@PostalCode", order.PostCode);
            cmd.Parameters.AddWithValue("@Country", order.Country);

            cmd.Parameters.AddWithValue("@EmergencyContactName", order.EmergencyContactName);
            cmd.Parameters.AddWithValue("@EmergencyContactNumber", order.EmergencyContactNumber);
            cmd.Parameters.AddWithValue("@MedicalDetails", order.MedicalDetails);
            cmd.Parameters.AddWithValue("@Mobile", order.Mobile);
            cmd.Parameters.AddWithValue("@Email", order.Email);

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

        public int EnterResult(Result result)
        {
            int count = 0;
            SqlCommand cmd = new SqlCommand("usp_EnterResultsDetails", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@RaceId", result.RaceId);
            cmd.Parameters.AddWithValue("@BibId", result.BibNo);
            cmd.Parameters.AddWithValue("@FinishPlace", result.FinishPlace);
            cmd.Parameters.AddWithValue("@FinishTime", result.FinishTime);
            cmd.Parameters.AddWithValue("@ChipTime", result.ChipTime);
            //cmd.Parameters.AddWithValue("@Email", result.);

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
        #endregion
    }
}