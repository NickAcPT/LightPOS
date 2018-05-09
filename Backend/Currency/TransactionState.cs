// 
// Copyright (c) NickAc. All rights reserved.
// Licensed under the MIT License. See LICENSE file in the project root for full license information.

using System.Collections.Generic;
using NickAc.LightPOS.Backend.Objects;

namespace NickAc.LightPOS.Backend.Currency
{
    public struct TransactionState
    {
        public List<Product> Products { get; set; }
        public float TotalPrice { get; set; }
    }
}