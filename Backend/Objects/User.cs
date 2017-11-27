using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Security.Cryptography;
using System.Text;

namespace NickAc.LightPOS.Backend.Objects
{
    class User
    {
        public virtual int UserID { get; set; }
        public virtual string UserName { get; set; }
        public virtual string HashedPassword { get; set; }
        public virtual string Salt { get; set; }
        
        public static void CreateUser(string userName, string password)
        {
            User u = new User();
            u.UserName = userName;
            u.Salt = Guid.NewGuid().ToString().Replace("-", "");
            u.HashedPassword = Sha256(u.Salt + password);

        }

        private static string Sha256(string randomString)
        {
            SHA256Managed crypt = new SHA256Managed();
            string hash = String.Empty;
            byte[] crypto = crypt.ComputeHash(Encoding.UTF8.GetBytes(randomString), 0, Encoding.ASCII.GetByteCount(randomString));
            foreach (byte theByte in crypto) {
                hash += theByte.ToString("x2");
            }
            return hash;
        }
    }
}
