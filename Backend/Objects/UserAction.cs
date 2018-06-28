//
// Copyright (c) NickAc. All rights reserved.
// Licensed under the MIT License. See LICENSE file in the project root for full license information.
//

using System;
using System.ComponentModel;

namespace NickAc.LightPOS.Backend.Objects
{
    public class UserAction
    {
        public enum Action
        {
            [Description("Login")] Login,
            [Description("Log Out")] LogOut,
            [Description("Perform Sale")] UserSale,
            [Description("Create User")] CreateUser,
            [Description("Modify User")] ModifyUser,
            [Description("Delete User")] DeleteUser,
            [Description("Create Category")] CreateCategory,
            [Description("Edit Category")] EditCategory,
            [Description("Remove Category")] RemoveCategory,
            [Description("Create Product")] CreateProduct,
            [Description("Edit Product")] EditProduct,
            [Description("Remove Product")] RemoveProduct
        }

        public virtual int Id { get; set; }

        public virtual Action Event { get; set; }

        public virtual string Description { get; set; }

        public virtual DateTime Time { get; set; }
    }
}