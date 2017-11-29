using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
