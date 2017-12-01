//
// Copyright (c) NickAc. All rights reserved.
// Licensed under the MIT License. See LICENSE file in the project root for full license information.
//
using System;

namespace NickAc.LightPOS.Backend.Objects
{
    [Flags]
    public enum UserPermission
    {
        DoSale = 1,
        PrintReceipt = 2, //Later
        CreateUser = 4,
        RemoveUser = 8,
        All = DoSale | PrintReceipt | CreateUser | RemoveUser
    }
}