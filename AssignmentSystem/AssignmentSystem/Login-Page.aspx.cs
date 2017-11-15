using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.DirectoryServices;

namespace AssignmentSystem
{
    public partial class Login_Page : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public static void ValidateUser()
        {

        }

        protected void btn_Login_OnClick(object sender, EventArgs e)
        {
            //DirectoryEntry ldapConn = new DirectoryEntry("ldap://192.168.1.13");
            //ldapConn.AuthenticationType = AuthenticationTypes.Anonymous;
            //DirectorySearcher ds = new DirectorySearcher(ldapConn);
            //ds.Filter = ("objectClass=*");
        }

        public bool LdapConnCheck()
        {
            DirectoryEntry ldapConn = new DirectoryEntry("ldap://192.168.1.13");


        }
    }
}