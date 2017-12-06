using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.DirectoryServices;
using System.DirectoryServices.Protocols;
using System.DirectoryServices.AccountManagement;
using System.Net;
using System.Threading;


namespace AssignmentSystem
{
    public partial class Login_Page : System.Web.UI.Page
    {
        //Global Variables
        private Users _user;
        private Computers _computer;


        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Cache.SetNoStore(); //sørger for at en aspx side ikke bliver cached
        }


        protected void btn_Login_OnClick(object sender, EventArgs e)
        {
            _user = new Users(tb_Username.Text, tb_Password.Text);
            _computer = new Computers(Environment.MachineName);

            bool isPcValid = _computer.IsPcOnDomain();

            if (isPcValid)
            {
                if (_user.LoginValidation())
                {
                    //Setting Session Variables
                    Session["LoggedIn"] = 1;
                    Session["Account"] = _user.GetAccountDisplayInfo();
                    Session["User"] = _user.Username;
                    Session["Authority"] = _user.Authority;

                    Response.Redirect("Assignments.aspx");
                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "Prøv igen, hvis problemet fortsætter, så kontakt en administrator" + "');", true);
                }
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "Computeren er ikke en del af domænet, kontakt en administrator." + "');", true);
            }
        }
    }
}