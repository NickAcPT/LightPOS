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
        [Description("Do sale")]
        DoSale = 1,
        [Description("Print a receipt")]
        PrintReceipt = 2, //Later
        [Description("Create users")]
        CreateUser = 4,
        [Description("Remove users")]
        RemoveUser = 8,
        All = DoSale | PrintReceipt | CreateUser | RemoveUser
    }
}