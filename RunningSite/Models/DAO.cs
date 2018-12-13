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

        #endregion

        #region Orders

        public int EnterOrder(AccountOrder acc_order)
        {
            int count = 0;
            SqlCommand cmd = new SqlCommand("usp_EnterOrderDetails", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@OrderNo", acc_order.order_model.OrderNo);
            cmd.Parameters.AddWithValue("@OrderDate", DateTime.Today.Date);

            cmd.Parameters.AddWithValue("@RaceId", acc_order.order_model.RaceId);
            cmd.Parameters.AddWithValue("@BibNo", acc_order.order_model.BibNo);
            cmd.Parameters.AddWithValue("@TShirtSize", acc_order.order_model.TshirtSize);
            cmd.Parameters.AddWithValue("@OrderMedalInsert", acc_order.order_model.OrderMedalInsert);
            cmd.Parameters.AddWithValue("@StartGroup", acc_order.order_model.StartGroup);
            cmd.Parameters.AddWithValue("@TotalAmount", acc_order.order_model.TotalAmount);

            cmd.Parameters.AddWithValue("@AgreeRaceDisclaimer", acc_order.order_model.AgreeRaceDisclaimer);
            cmd.Parameters.AddWithValue("@AgreeTermsAndConditions", acc_order.order_model.AgreeTermsAndConditions);

            cmd.Parameters.AddWithValue("@Address1", acc_order.order_model.AddressLine1);
            cmd.Parameters.AddWithValue("@Address2", acc_order.order_model.AddressLine2);
            cmd.Parameters.AddWithValue("@City", acc_order.order_model.City);
            cmd.Parameters.AddWithValue("@PostalCode", acc_order.order_model.PostCode);
            cmd.Parameters.AddWithValue("@Country", acc_order.order_model.Country);

            cmd.Parameters.AddWithValue("@EmergencyContactName", acc_order.order_model.EmergencyContactName);
            cmd.Parameters.AddWithValue("@EmergencyContactNo", acc_order.order_model.EmergencyContactNo);
            cmd.Parameters.AddWithValue("@MedicalDetails", acc_order.order_model.MedicalDetails);
            cmd.Parameters.AddWithValue("@Mobile", acc_order.order_model.Mobile);
            cmd.Parameters.AddWithValue("@Email", acc_order.account_model.Email);  

            cmd.Parameters.AddWithValue("@CC_Type", acc_order.order_model.CC_Type);
            cmd.Parameters.AddWithValue("@CC_Holder_FirstName", acc_order.order_model.CC_Holder_FirstName);
            cmd.Parameters.AddWithValue("@CC_Holder_LastName", acc_order.order_model.CC_Holder_LastName);
            cmd.Parameters.AddWithValue("@CC_Number", acc_order.order_model.CC_Number);
            cmd.Parameters.AddWithValue("@CC_ExpDate_Month", acc_order.order_model.CC_ExpDate_Month);
            cmd.Parameters.AddWithValue("@CC_ExpDate_Year", acc_order.order_model.CC_ExpDate_Year);
            cmd.Parameters.AddWithValue("@CC_SecCode", acc_order.order_model.CC_SecCode);

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


        public int AlterOrder(AccountOrder acc_order)
        {
            int count = 0;
            SqlCommand cmd = new SqlCommand("usp_AlterOrderDetails", con);  //need to create this SP
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@OrderNo", acc_order.order_model.OrderNo);
            //cmd.Parameters.AddWithValue("@OrderNo", acc_order.order_model.OrderName);

            cmd.Parameters.AddWithValue("@RaceId", acc_order.order_model.RaceId);
            cmd.Parameters.AddWithValue("@BibNo", acc_order.order_model.BibNo);
            cmd.Parameters.AddWithValue("@TShirtSize", acc_order.order_model.TshirtSize);
            //cmd.Parameters.AddWithValue("@OrderMedalInsert", acc_order.order_model.OrderMedalInsert);
            cmd.Parameters.AddWithValue("@StartGroup", acc_order.order_model.StartGroup);
            //cmd.Parameters.AddWithValue("@TotalAmount", acc_order.order_model.TotalAmount);

            cmd.Parameters.AddWithValue("@AgreeRaceDisclaimer", acc_order.order_model.AgreeRaceDisclaimer);
            cmd.Parameters.AddWithValue("@AgreeTermsAndConditions", acc_order.order_model.AgreeTermsAndConditions);

            cmd.Parameters.AddWithValue("@Address1", acc_order.order_model.AddressLine1);
            cmd.Parameters.AddWithValue("@Address2", acc_order.order_model.AddressLine2);
            cmd.Parameters.AddWithValue("@City", acc_order.order_model.City);
            cmd.Parameters.AddWithValue("@PostalCode", acc_order.order_model.PostCode);
            cmd.Parameters.AddWithValue("@Country", acc_order.order_model.Country);

            cmd.Parameters.AddWithValue("@EmergencyContactName", acc_order.order_model.EmergencyContactName);
            cmd.Parameters.AddWithValue("@EmergencyContactNo", acc_order.order_model.EmergencyContactNo);
            cmd.Parameters.AddWithValue("@MedicalDetails", acc_order.order_model.MedicalDetails);
            cmd.Parameters.AddWithValue("@Mobile", acc_order.order_model.Mobile);
            //cmd.Parameters.AddWithValue("@Email", acc_order.account_model.Email);

            //cmd.Parameters.AddWithValue("@CC_Type", acc_order.order_model.CC_Type);
            //cmd.Parameters.AddWithValue("@CC_Holder_FirstName", acc_order.order_model.CC_Holder_FirstName);
            //cmd.Parameters.AddWithValue("@CC_Holder_LastName", acc_order.order_model.CC_Holder_LastName);
            //cmd.Parameters.AddWithValue("@CC_Number", acc_order.order_model.CC_Number);
            //cmd.Parameters.AddWithValue("@CC_ExpDate_Month", acc_order.order_model.CC_ExpDate_Month);
            //cmd.Parameters.AddWithValue("@CC_ExpDate_Year", acc_order.order_model.CC_ExpDate_Year);
            //cmd.Parameters.AddWithValue("@CC_SecCode", acc_order.order_model.CC_SecCode);

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

        public int EnterResult(Result runner)
        {
            int count = 0;
            SqlCommand cmd = new SqlCommand("usp_EnterRunnerDetails", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@RaceId", runner.RaceId);
            cmd.Parameters.AddWithValue("@BibId", runner.BibNo);
            cmd.Parameters.AddWithValue("@FinishPlace", runner.FinishPlace);
            cmd.Parameters.AddWithValue("@FinishTime", runner.FinishTime);
            cmd.Parameters.AddWithValue("@ChipTime", runner.ChipTime);

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