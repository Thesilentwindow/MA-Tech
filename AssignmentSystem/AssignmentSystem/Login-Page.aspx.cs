using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.DirectoryServices;
using System.DirectoryServices.AccountManagement;


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
            string result;
            bool loginVal = ValidateCredentials(tb_Username.Text, tb_Password.Text);

            if (loginVal)
            {
                result = "Valid Credentials";
            }
            else
            {
                result = "Invalid Credentials";
            }

            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + result + "');", true);
        }

        public string LdapCheck(string uName, string pWord)
        {
            DirectoryEntry directoryEntry = new DirectoryEntry("LDAP://tand.local");

            try
            {
                PrincipalContext AD = new PrincipalContext(ContextType.Domain, "tand.local");

                UserPrincipal test = new UserPrincipal(AD);
                test.SamAccountName = uName;

                PrincipalSearcher searcher = new PrincipalSearcher(test);
                UserPrincipal resutPrincipal = (UserPrincipal)searcher.FindOne();
                searcher.Dispose();

                return resutPrincipal.GivenName;
                if (directoryEntry.Properties.Count > 0)
                {
                    return "yup";
                }
                else
                {
                    return "nope";
                }

            }
            catch (Exception e)
            {
                return e.ToString();
            }

        }

        public bool ValidateCredentials(string uName, string pWord)
        {   
            using (PrincipalContext pContext = new PrincipalContext(ContextType.Domain, "tand.local"))
            {
                bool isValid = pContext.ValidateCredentials(uName, pWord);
                return isValid;
            }
        }
    }
}