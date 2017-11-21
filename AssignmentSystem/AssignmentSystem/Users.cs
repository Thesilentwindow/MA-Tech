using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.DirectoryServices;
using System.DirectoryServices.AccountManagement;

namespace AssignmentSystem
{
    public class Users
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Authority { get; set; }

        public Users(string username)
        {
            Username = username;
        }

        public Users(string username, string password)
        {
            Username = username;
            Password = password;
        }

        public Users()
        {
            
        }


        public string GetCredentials()
        {
            PrincipalContext pc = new PrincipalContext(ContextType.Domain, "tand.local");
            UserPrincipal userPrincipalTest = new UserPrincipal(pc);

            userPrincipalTest.SamAccountName = Username;

            return "Not implemented yet";
        }

        public string GetAccountDisplayInfo()
        {
            try
            {
                PrincipalContext pc = new PrincipalContext(ContextType.Domain, "tand.local");
                UserPrincipal userPrincipalTest = new UserPrincipal(pc);

                userPrincipalTest.SamAccountName = Username;


                PrincipalSearcher searcher = new PrincipalSearcher(userPrincipalTest);
                UserPrincipal resultPrincipal = (UserPrincipal)searcher.FindOne();
                searcher.Dispose();

                string resultToRturn = "Welcome: " + resultPrincipal.DisplayName + " --- " + resultPrincipal.EmailAddress;
                return resultToRturn;
            }
            catch (Exception ex)
            {
                return string.Empty;
            }
        }

        public bool ValidateUser()
        {
            using (PrincipalContext pContext = new PrincipalContext(ContextType.Domain, "tand.local"))
            {
                bool isValid = pContext.ValidateCredentials(Username, Password);
                return isValid;
            }
        }
    }
}