using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

namespace AssignmentSystem
{
    public partial class Assignments1 : System.Web.UI.Page
    {
        private SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["TandDbConString"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Account"] == null)
            {
                Response.Redirect("Login-Page.aspx"); // Hvis sessionen er null, så bliver man smidt tilbage til login siden
            }
            else
            {
                lbl_Account.Text = Session["Account"].ToString(); // Viser brugerens information(display name & Email adresse)
            }
        }

        protected void btn_Logout_OnClick(object sender, EventArgs e)
        {
            Session.Clear(); // fjerner alle keys og session values fra den nuværrende session
            Session.Abandon(); // Anullere den nuværende session
            Response.Redirect("Login-Page.aspx"); // sender brugeren tilbage til login siden
        }

        private void dummy()
        {
            
        }
        
    }
}