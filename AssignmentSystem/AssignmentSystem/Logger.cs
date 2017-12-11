using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace AssignmentSystem
{
    public class Logger
    {


        public string Code { get; set; }
        public string Message { get; set; }
        public string Action { get; set; }
        public DateTime Timestamp { get; set; }

        public Logger(string code, string message, string action)
        {
            Code = code;
            Message = message;
            Action = action;
            Timestamp = Convert.ToDateTime(DateTime.Now.ToShortTimeString());
        }

        /// <summary>
        /// This method logs actions and errors. They are inserted into the related DB.
        /// Code summary: 0(Regular actions), 0101(Exceptions that don't provide error codes), 0202(Other things of note)
        /// </summary>
        public void Log()
        {
            string query = "insert into ActionLogging (Code, Message, Action, Timestamp) Values(@Code, @Message, @Action, @Timestamp)";


            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ProductionConString"].ConnectionString))
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                try
                {
                    cmd.Parameters.AddWithValue("@Code", Code);
                    cmd.Parameters.AddWithValue("@Message", Message);
                    cmd.Parameters.AddWithValue("@Action", Action);
                    cmd.Parameters.AddWithValue("@Timestamp", Timestamp);


                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                catch (SqlException e)
                {
                    //You're basically fucked                   
                }

            }
        }

    }
}