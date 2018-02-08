//
// Copyright (c) NickAc. All rights reserved.
// Licensed under the MIT License. See LICENSE file in the project root for full license information.
//
using NickAc.LightPOS.Backend.Utils;
using System;
using static NickAc.LightPOS.Backend.Utils.EnumUtils;

namespace NickAc.LightPOS.Backend.Objects
{
    [Flags]
    public enum UserPermission
    {
        None = 0,
        [Description("permissions_do_sale")]
        DoSale = 1,
        [Description("permissions_print_receipt")]
        PrintReceipt = 2,
        [Description("permissions_create_user")]
        CreateUser = 4,
        [Description("permissions_remove_user")]
        RemoveUser = 8,
        [Description("permissions_modify_user")]
        ModifyUser = 16,
        [Description("permissions_apply_discounts")]
        ApplyDiscount = 32,
        [Description("permissions_create_product")]
        CreateProducts = 64,
        All = DoSale | PrintReceipt | CreateUser | RemoveUser | ModifyUser | ApplyDiscount | CreateProducts
    }
}