using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Cryptography;
using System.Text;
using static System.Security.Cryptography.SHA256Managed;
using static System.Security.Cryptography.SHA512Managed;

namespace AssignmentSystem
{
    public class Encrypt
    {
        private static readonly List<string> AuthVals = new List<string>(new string[] { "´x2c3v4b55gouhi4g7fkfh", "mzmzka39tgfriueh693nspgi", "akakiqyugbng49sdgrhry4s", "m009385ngodu58yhnws0fgbg05ugbso0"});

        public string GenerateSha256String(string inputString)
        {
            SHA256 sha256 = SHA256.Create();
            byte[] bytes = Encoding.UTF8.GetBytes(inputString);
            byte[] hash = sha256.ComputeHash(bytes);
            return GetStringFromHash(hash);
        }


        public string GenerateSha512String(string inputString)
        {
            SHA512 sha512 = SHA512.Create();
            byte[] bytes = Encoding.UTF8.GetBytes(inputString);
            byte[] hash = sha512.ComputeHash(bytes);
            return GetStringFromHash(hash);
        }

        private string GetStringFromHash(byte[] hash)
        {
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                result.Append(hash[i].ToString("X2"));
            }
            return result.ToString();
        }

        public string GetAuthVal()
        {
            Random rand = new Random();

            int random = rand.Next(0, 3);

            return GenerateSha512String(AuthVals[random]);
        }

        public bool CheckAuth(string authVal)
        {
            foreach (string val in AuthVals)
            {
                var shaVal = GenerateSha512String(val);
                if (shaVal == authVal)
                {
                    return true;
                }                
            }
            return false;
        }
    }
}