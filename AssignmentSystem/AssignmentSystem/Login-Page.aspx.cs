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
        private Users user;
        private const string _domain = "tand.local";
        private const int ERROR_LOGON_FAILURE = 0x31;




        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Cache.SetNoStore(); //sørger for at en aspx side ikke bliver cached
        }


        protected void btn_Login_OnClick(object sender, EventArgs e)
        {
                user = new Users(tb_Username.Text, tb_Password.Text);

            if (user.LoginValidation())
            {
                Session["Account"] = user.GetAccountDisplayInfo();
                Response.Redirect("Assignments.aspx");
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "Invalid Credentials" + "');", true);
            }


        }

        public bool ValidateCredentials(string uName, string pWord)
        {
            this.user = new Users(uName, pWord);

            if (user.ValidateUser())
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}