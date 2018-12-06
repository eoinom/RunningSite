using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Web.Configuration;

namespace MarathonFestival3.Models
{
    
    public class DAO
    {
        SqlConnection con;
        public string message = "";

        public DAO()
        {
            con = new SqlConnection(WebConfigurationManager.ConnectionStrings["conString"].ConnectionString);
        }

        public int EnterVisitor(Visitor visitor)
        {
            int count = 0;
            SqlCommand cmd = new SqlCommand("usp_EnterVisitorDetails", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@EmailAddress", visitor.EmailAddress);
            cmd.Parameters.AddWithValue("@Password", visitor.Password);
            cmd.Parameters.AddWithValue("@FirstName", visitor.FirstName);
            cmd.Parameters.AddWithValue("@LastName", visitor.LastName);
            cmd.Parameters.AddWithValue("@DateOfBirth", visitor.DateOfBirth);
            cmd.Parameters.AddWithValue("@Address1", visitor.Address1);
            cmd.Parameters.AddWithValue("@Address2", visitor.Address2);
            cmd.Parameters.AddWithValue("@Town_City", visitor.Town_City);

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
       
        public int EnterOrder(Order order)
        {
            int count = 0;
            SqlCommand cmd = new SqlCommand("usp_EnterOrderDetails", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@OrderDate", order.OrderDate);
            cmd.Parameters.AddWithValue("@TShirtSize", order.TShirtSize);
            cmd.Parameters.AddWithValue("@TotalAmount", order.TShirtSize);
            cmd.Parameters.AddWithValue("@EmailAddress", order.EmailAddress);
            cmd.Parameters.AddWithValue("@RaceId", order.RaceId);

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

       

        public int EnterRace(Race race)
        {
            int count = 0;
            SqlCommand cmd = new SqlCommand("usp_EnterRaceDetails", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@RaceId", race.RaceId);
            cmd.Parameters.AddWithValue("@RaceDate", race.RaceDate);
            cmd.Parameters.AddWithValue("@RaceLimit", race.RaceLimit);
            cmd.Parameters.AddWithValue("@Prce", race.Price);
            

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


        public int EnterRunner(Runner runner)
        {
            int count = 0;
            SqlCommand cmd = new SqlCommand("usp_EnterRunnerDetails", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@BibId", runner.BibNo);
            cmd.Parameters.AddWithValue("@FinishTime", runner.FinishTime);
            cmd.Parameters.AddWithValue("@RaceId", runner.RaceId);
            
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
    }
}