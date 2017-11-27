using NickAc.LightPOS.Backend.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Security.Cryptography;
using System.Text;

namespace NickAc.LightPOS.Backend.Objects
{
    public class User
    {
        public virtual int UserID { get; set; }
        public virtual string UserName { get; set; }
        public virtual string HashedPassword { get; set; }
        [NotLazy]
        public virtual string Salt { get; set; }
        public virtual IList<UserAction> Actions { get; set; }

        public static void CreateUser(string userName, string password)
        {
            User u = new User
            {
                UserName = userName,
                Salt = Guid.NewGuid().ToString().Replace("-", "")
            };
            u.HashedPassword = HashWithSalt(password, u.Salt);
        }

        private static string HashWithSalt(string password, string salt)
        {
            return Sha256(salt + password);
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
