using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.DirectoryServices;
using System.DirectoryServices.AccountManagement;
using System.DirectoryServices.Protocols;
using System.Net;

namespace AssignmentSystem
{
    public class Users
    {
        private const string Domain = "tand.local";
        private Logger _log;


        public string Username { get; set; }
        public string Password { get; set; }
        public int Authority { get; set; }

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

        [Obsolete("This method was just a test method", true)]
        private string GetCredentials()
        {
            PrincipalContext pc = new PrincipalContext(ContextType.Domain, Domain);
            UserPrincipal userPrincipalTest = new UserPrincipal(pc);

            if (userPrincipalTest.SamAccountName == Username)
            {
                return userPrincipalTest.SamAccountName;
            }
            else
            {
                return "No such account was found";
            }
        }




        [Obsolete("Replaced by LoginValidation due to more safe validation", true)]
        private bool ValidateUser() //Denne metode er ikke i brug længere.
        {
            using (PrincipalContext pContext = new PrincipalContext(ContextType.Domain, Domain))
            {
                bool isValid = pContext.ValidateCredentials(Username, Password);
                return isValid;
            }
        }


        public string GetAccountDisplayInfo()
        {
            try
            {
                PrincipalContext pc = new PrincipalContext(ContextType.Domain, Domain);
                UserPrincipal user = new UserPrincipal(pc) {SamAccountName = Username};


                PrincipalSearcher searcher = new PrincipalSearcher(user);
                UserPrincipal resultPrincipal = (UserPrincipal)searcher.FindOne();
                searcher.Dispose();

                string resultToRturn = "Welcome: " + resultPrincipal.DisplayName + " !";
                return resultToRturn;
            }
            catch (ArgumentException e)
            {
                _log = new Logger("0101", e.Message, "Fetch User Info");
                _log.Log();
                return string.Empty;
            }
        }

        public bool LoginValidation()
        {
            NetworkCredential credentials = new NetworkCredential(Username, Password, Domain);


            LdapDirectoryIdentifier id = new LdapDirectoryIdentifier(Domain);

            using (LdapConnection connection = new LdapConnection(id, credentials, AuthType.Kerberos))
            {

                try
                {
                    connection.Bind();
                }
                catch (LdapException e)
                {
                    _log = new Logger(e.ErrorCode.ToString(), e.Message, "LoginValidation");
                    _log.Log();
                    return false;
                    //Todo add logging of exception
                }
            }
            return true;
        }

        public void SetUserAuthLvl() //Bruges i constructor der tager Username og Password
        {
            try
            {
                //domæne context
                PrincipalContext pContext = new PrincipalContext(ContextType.Domain, Domain);

                //her finder man gruppen som man leder efter
                GroupPrincipal guestGroup = GroupPrincipal.FindByIdentity(pContext, "WebGuests");
                GroupPrincipal userGroup = GroupPrincipal.FindByIdentity(pContext, "WebUsers");
                GroupPrincipal adminGroup = GroupPrincipal.FindByIdentity(pContext, "WebAdmins");

                //findes gruppen gå videre
                if (adminGroup != null)
                {
                    foreach (Principal adminPrincipal in adminGroup.GetMembers())
                    {
                        if (adminPrincipal.SamAccountName == Username)
                        {
                            Authority = 3;
                        }
                    }
                }

                if (userGroup != null)
                {
                    foreach (Principal userPrincipal in userGroup.GetMembers())
                    {
                        if (userPrincipal.SamAccountName == Username)
                        {
                            Authority = 2;
                        }
                    }
                }

                if (guestGroup != null)
                {
                    foreach (Principal guestPrincipal in guestGroup.GetMembers())
                    {
                        if (guestPrincipal.SamAccountName == Username)
                        {
                            Authority = 1;
                        }
                    }
                }

            }
            catch (ArgumentException e)
            {
                _log = new Logger("0101", e.Message, "LoginValidation");
                _log.Log();
            }

        }

        //public bool CreateUser()
        //{
        //    PrincipalContext p = new PrincipalContext(ContextType.Domain, Domain);

        //    UserPrincipal creationPrincipal = new UserPrincipal(p, Username, Password, true);




        //}



    }
}