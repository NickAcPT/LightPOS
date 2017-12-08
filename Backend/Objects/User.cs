//
// Copyright (c) NickAc. All rights reserved.
// Licensed under the MIT License. See LICENSE file in the project root for full license information.
//
using NickAc.LightPOS.Backend.Mapping;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace NickAc.LightPOS.Backend.Objects
{
    public class User
    {
        public virtual int UserID { get; set; }
        public virtual string UserName { get; set; }
        public virtual string HashedPassword { get; set; }
        public virtual string Salt { get; set; }

        public virtual IList<UserAction> Actions { get; set; }

        public virtual UserPermission Permissions { get; set; }

        public virtual IList<Sale> Sales { get; set; }

        public virtual bool HasPermission(UserPermission perm)
        {
            return Permissions.HasFlag(perm) || Permissions.HasFlag(UserPermission.All);
        }

        public static User CreateUser(string userName, string password, UserPermission permissions)
        {
            User u = new User
            {
                UserName = userName,
                Salt = Guid.NewGuid().ToString().Replace("-", "")
            };
            u.HashedPassword = HashWithSalt(password, u.Salt);
            u.Permissions = permissions;
            u.Actions = new List<UserAction>();
            u.Sales = new List<Sale>();
            return u;
        }

        public virtual bool CheckPassword(string password)
        {
            return string.Equals(HashWithSalt(password, Salt), HashedPassword);
        }

        private static string HashWithSalt(string password, string salt)
        {
            return Sha256(salt + password);
        }

        public virtual void ChangePassword(string newPassword)
        {
            HashedPassword = HashWithSalt(newPassword, Salt);
        }

        private static string Sha256(string randomString)
        {
            SHA256Managed crypt = new SHA256Managed();
            string hash = String.Empty;
            byte[] crypto = crypt.ComputeHash(Encoding.UTF8.GetBytes(randomString), 0, Encoding.UTF8.GetByteCount(randomString));
            foreach (byte theByte in crypto) {
                hash += theByte.ToString("x2");
            }
            return hash;
        }

        public virtual bool CanDoSale() => Permissions.HasFlag(UserPermission.DoSale);

        public virtual bool CanCreateUsers() => Permissions.HasFlag(UserPermission.CreateUser);

        public virtual bool CanRemoveUsers() => Permissions.HasFlag(UserPermission.RemoveUser);

        public virtual bool CanApplyDiscounts() => Permissions.HasFlag(UserPermission.ApplyDiscount);

        public virtual bool CanPrintReceipts() => Permissions.HasFlag(UserPermission.PrintReceipt);

    }
}