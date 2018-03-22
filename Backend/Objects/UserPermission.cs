//
// Copyright (c) NickAc. All rights reserved.
// Licensed under the MIT License. See LICENSE file in the project root for full license information.
//

using System;
using System.ComponentModel;
using static NickAc.LightPOS.Backend.Utils.EnumUtils;

namespace NickAc.LightPOS.Backend.Objects
{
    [Flags]
    public enum UserPermission
    {
        None = 0,

        [Description("permissions_do_sale")]
        DoSale = 1 << 0,

        [Description("permissions_print_receipt")]
        PrintReceipt = 1 << 1,

        [Description("permissions_create_user")]
        CreateUser = 1 << 2,

        [Description("permissions_remove_user")]
        RemoveUser = 1 << 3,

        [Description("permissions_modify_user")]
        ModifyUser = 1 << 4,

        [Description("permissions_apply_discounts")]
        ApplyDiscount = 1 << 5,
        
        [Description("permissions_create_product")]
        CreateProducts = 1 << 6,
        
        [Description("permissions_modify_product")]
        ModifyProducts = 1 << 7,

        [Description("permissions_remove_product")]
        RemoveProducts = 1 << 8,

        All = DoSale | PrintReceipt | CreateUser | RemoveUser | ModifyUser | ApplyDiscount | CreateProducts | ModifyProducts | RemoveProducts
    }
}