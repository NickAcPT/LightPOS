// 
// Copyright (c) NickAc. All rights reserved.
// Licensed under the MIT License. See LICENSE file in the project root for full license information.

using System;
using System.Collections.Generic;
using NickAc.LightPOS.Backend.Objects;

namespace NickAc.LightPOS.Backend.Currency
{
    public struct TransactionState
    {
        private decimal _totalPrice;

        public List<Product> Products { get; set; }

        public decimal TotalPrice
        {
            get => _totalPrice;
            set
            {
                _totalPrice = value;
                if (PaidPrice == decimal.Zero)
                    PaidPrice = _totalPrice;
            }
        }

        public decimal PaidPrice { get; set; }
    }
}