using System;
using System.Configuration;
using System.Data.SqlClient;

namespace AssignmentSystem
{


    public class Assignment
    {
        private SqlConnection con =
            new SqlConnection(ConfigurationManager.ConnectionStrings["ProductionConString"].ConnectionString);

        public string Title { get; set; }
        public string Description { get; set; }
        public string Responsible { get; set; }
        public DateTime Date { get; set; }

        private Logger _log;

        public Assignment(string title, string description, string responsible, DateTime date)
        {
            Title = title;
            Description = description;
            Responsible = responsible;
            Date = date;
        }

        public bool InsertToTable()
        {
            string AddAssignment = "insert into Opgaver (AktivitetTitel, AktivitetBeskrivelse, AktivitetDato, AktivitetAnsvarlig) Values(@Title, @Description, @Date, @Responsible)";

            using (con)
            using (SqlCommand cmd = new SqlCommand(AddAssignment, con))
            {
                try
                {
                    if (Title != string.Empty && Description != string.Empty && Responsible != string.Empty)
                    {
                        cmd.Parameters.AddWithValue("@Title", Title);
                        cmd.Parameters.AddWithValue("@Description", Description);
                        cmd.Parameters.AddWithValue("@Date", Date);
                        cmd.Parameters.AddWithValue("@Responsible", Responsible);
                    }

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();

                    return true;
                }
                catch (Exception e)
                {
                    _log = new Logger("0101", e.Message, "Insert Attempt");
                    _log.Log();
                    return false;
                }
            }
        }



    }

}
