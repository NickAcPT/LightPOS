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
        [Description("Do sales")]
        DoSale = 1,
        [Description("Print receipts")]
        PrintReceipt = 2,
        [Description("Create users")]
        CreateUser = 4,
        [Description("Remove users")]
        RemoveUser = 8,
        [Description("Apply Discounts")]
        ApplyDiscount = 16,
        All = DoSale | PrintReceipt | CreateUser | RemoveUser | ApplyDiscount
    }
}