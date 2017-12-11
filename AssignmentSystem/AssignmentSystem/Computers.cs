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
    public class Computers
    {
        private const string Domain = "tand.local";
        private const string ComputerGroup = "Domain Computers";

        public string CompName { get; set; }

        public Computers(string compName)
        {
            CompName = compName;
        }
        [Obsolete("Doesn't work outside of developement environment", true)]
        public bool IsPcOnDomain()
        {
            PrincipalContext pc = new PrincipalContext(ContextType.Domain, Domain);

            ComputerPrincipal computer =  ComputerPrincipal.FindByIdentity(pc, CompName);

            foreach (Principal result in computer.GetGroups())
            {
                if (result.Name == ComputerGroup)
                {
                    return true;
                }
            }
            return false;
        }
    }
}