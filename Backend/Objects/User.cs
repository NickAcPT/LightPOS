//
// Copyright (c) NickAc. All rights reserved.
// Licensed under the MIT License. See LICENSE file in the project root for full license information.
//

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace NickAc.LightPOS.Backend.Objects
{
    public class User
    {
        public virtual int UserId { get; set; }
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
            var u = new User
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
            return true;
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
            var crypt = new SHA256Managed();
            var hash = string.Empty;
            var crypto = crypt.ComputeHash(Encoding.UTF8.GetBytes(randomString), 0,
                Encoding.UTF8.GetByteCount(randomString));
            return crypto.Aggregate(hash, (current, theByte) => current + theByte.ToString("x2"));
        }

        public virtual bool CanDoSale() => Permissions.HasFlag(UserPermission.DoSale);

        public virtual bool CanCreateUsers() => Permissions.HasFlag(UserPermission.CreateUser);

        public virtual bool CanRemoveUsers() => Permissions.HasFlag(UserPermission.RemoveUser);

        public virtual bool CanModifyUsers() => Permissions.HasFlag(UserPermission.ModifyUser);

        public virtual bool CanApplyDiscounts() => Permissions.HasFlag(UserPermission.ApplyDiscount);

        public virtual bool CanPrintReceipts() => Permissions.HasFlag(UserPermission.PrintReceipt);

        public virtual bool CanManageProducts() => Permissions.HasFlag(UserPermission.CreateProducts);

        public virtual bool CanOpenManagement() => CanCreateUsers() || CanRemoveUsers() || CanModifyUsers() || CanManageProducts();

    }
}