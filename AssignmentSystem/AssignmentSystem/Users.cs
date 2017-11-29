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
            Authority = GetUserAuthLevel();
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
                UserPrincipal user = new UserPrincipal(pc);

                user.SamAccountName = Username;

                PrincipalSearcher searcher = new PrincipalSearcher(user);
                UserPrincipal resultPrincipal = (UserPrincipal)searcher.FindOne();
                searcher.Dispose();

                string resultToRturn = "Welcome: " + resultPrincipal.DisplayName + " !";
                return resultToRturn;
            }
            catch (Exception ex)
            {
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
                    return false;
                    //Todo add logging of exception
                }
            }
            return true;
        }

        private int GetUserAuthLevel() //Bruges i constructor der tager Username og Password
        {
            //domæne context
            PrincipalContext pContext = new PrincipalContext(ContextType.Domain, Domain);

            //her finder man gruppen som man leder efter
            GroupPrincipal userGroup = GroupPrincipal.FindByIdentity(pContext, "TestGroup");
            GroupPrincipal adminGroup = GroupPrincipal.FindByIdentity(pContext, "TestAdminGroup");

            //findes gruppen gå videre

            if (adminGroup != null)
            {
                foreach (Principal p2 in adminGroup.GetMembers())
                {
                    if (p2.SamAccountName == Username)
                    {
                        return 2;
                    }
                }
            }
            else if (userGroup != null)
            {
                foreach (Principal p in userGroup.GetMembers())
                {
                    if (p.SamAccountName == Username)
                    {
                        return 1;
                    }
                }
            }
            return 0;

        }
    }
}