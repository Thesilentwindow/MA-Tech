using System;
using System.Configuration;
using System.Data.SqlClient;

public class Assignment
{

    public string Title { get; set; }
    public string Description { get; set; }
    public string Responsible { get; set; }
    public DateTime Date { get; set; }

    private readonly SqlConnection _con = new SqlConnection(ConfigurationManager.ConnectionStrings["TandConString"].ConnectionString);



    public Assignment(string title, string description, string responsible, DateTime date)
    {
        Title = title;
        Description = description;
        Responsible = responsible;
        Date = date;
    }

    public string InsertToTable()
    {
        string AddAssignment = "insert into Opgaver (AktivitetTitel, AktivitetBeskrivelse, AktivitetDato, AktivitetAnsvarlig) Values(@Title, @Description, @Date, @Responsible)";
        SqlCommand cmd = new SqlCommand(AddAssignment, _con);

        if (Title != string.Empty && Description != string.Empty && Responsible != string.Empty)
        {
            cmd.Parameters.AddWithValue("@Title", Title);
            cmd.Parameters.AddWithValue("@Description", Description);
            cmd.Parameters.AddWithValue("@Date", Date);
            cmd.Parameters.AddWithValue("@Responsible", Responsible);
        }


        using (_con)
        {
            try
            {
                _con.Open();
                cmd.ExecuteNonQuery();
                _con.Close();
                return "success";
            }
            catch (Exception e)
            {
                return "Failed";
                //TODO add logging of errors
            }
        }
    }



}
