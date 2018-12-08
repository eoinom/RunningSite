using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Web.Configuration;

namespace RunningSite.Models
{
    
    public class DAO
    {
        SqlConnection con;
        public string message = "";

        #region constructor
        public DAO()
        {
            con = new SqlConnection(WebConfigurationManager.ConnectionStrings["conString"].ConnectionString);
        }
        #endregion

        #region Accounts
        //public int EnterVisitor(Account visitor)
        public int EnterAccount(Account account)
        {
            int count = 0;
            SqlCommand cmd = new SqlCommand("usp_EnterAccountDetails", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Email", account.Email);
            cmd.Parameters.AddWithValue("@Pass", account.Password);
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
            catch(SystemException ex)
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
            SqlCommand cmd = new SqlCommand("usp_EnterOrderDetails", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@RaceId", order.OrderNo);        //Change parameterName
            cmd.Parameters.AddWithValue("@OrderDate", order.OrderDate);
            
            cmd.Parameters.AddWithValue("@RaceId", order.RaceId);
            cmd.Parameters.AddWithValue("@RaceId", order.BibNo);        //Change parameterName
            cmd.Parameters.AddWithValue("@TShirtSize", order.TshirtSize);
            cmd.Parameters.AddWithValue("@RaceId", order.OrderMedalInsert);        //Change parameterName
            cmd.Parameters.AddWithValue("@RaceId", order.StartGroup);        //Change parameterName
            cmd.Parameters.AddWithValue("@TotalAmount", order.TotalAmount);

            cmd.Parameters.AddWithValue("@RaceId", order.AgreeRaceDisclaimer);        //Change parameterName
            cmd.Parameters.AddWithValue("@RaceId", order.AgreeTermsAndConditions);        //Change parameterName

            cmd.Parameters.AddWithValue("@RaceId", order.AddressLine1);        //Change parameterName
            cmd.Parameters.AddWithValue("@RaceId", order.AddressLine2);        //Change parameterName
            cmd.Parameters.AddWithValue("@RaceId", order.City);        //Change parameterName
            cmd.Parameters.AddWithValue("@RaceId", order.PostCode);        //Change parameterName
            cmd.Parameters.AddWithValue("@RaceId", order.Country);        //Change parameterName

            cmd.Parameters.AddWithValue("@RaceId", order.EmergencyContactName);        //Change parameterName
            cmd.Parameters.AddWithValue("@RaceId", order.EmergencyContactNo);        //Change parameterName
            cmd.Parameters.AddWithValue("@RaceId", order.MedicalDetails);        //Change parameterName
            cmd.Parameters.AddWithValue("@RaceId", order.Mobile);        //Change parameterName
            //cmd.Parameters.AddWithValue("@EmailAddress", order.EmailAddress);  

            cmd.Parameters.AddWithValue("@RaceId", order.CC_Type);        //Change parameterName
            cmd.Parameters.AddWithValue("@RaceId", order.CC_Holder_FirstName);        //Change parameterName
            cmd.Parameters.AddWithValue("@RaceId", order.CC_Holder_LastName);        //Change parameterName
            cmd.Parameters.AddWithValue("@RaceId", order.CC_Number);        //Change parameterName
            cmd.Parameters.AddWithValue("@RaceId", order.CC_ExpDate_Month);        //Change parameterName
            cmd.Parameters.AddWithValue("@RaceId", order.CC_ExpDate_Year);        //Change parameterName
            cmd.Parameters.AddWithValue("@RaceId", order.CC_SecCode);        //Change parameterName
            
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

        #endregion

        #region Results

        //public int EnterRunner(Runner runner)
        public int EnterResult(Result runner)
        {
            int count = 0;
            SqlCommand cmd = new SqlCommand("usp_EnterRunnerDetails", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@RaceId", runner.RaceId);
            cmd.Parameters.AddWithValue("@BibId", runner.BibNo);
            cmd.Parameters.AddWithValue("@FinishTime", runner.FinishPlace);    //Change parameterName
            cmd.Parameters.AddWithValue("@FinishTime", runner.Name);    //Change parameterName
            cmd.Parameters.AddWithValue("@FinishTime", runner.FinishTime);
            cmd.Parameters.AddWithValue("@FinishTime", runner.ChipTime);    //Change parameterName
            
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