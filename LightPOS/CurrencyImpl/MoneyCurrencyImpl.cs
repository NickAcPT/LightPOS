// 
// Copyright (c) NickAc. All rights reserved.
// Licensed under the MIT License. See LICENSE file in the project root for full license information.

using System;
using System.Drawing;
using System.Threading.Tasks;
using NickAc.LightPOS.Backend;
using NickAc.LightPOS.Backend.Currency;

namespace NickAc.LightPOS.Frontend.CurrencyImpl
{
    public class MoneyCurrencyImpl : AbstractCurrency
    {
        public override string Name => "curr_money";

        public override Image Image => CurrencyResources.cash_usd;

        public override void Init()
        {
            Console.WriteLine(@"Loaded Money Currency!");
        }

        
        public override TransactionResult RequestTransaction(ref TransactionState state)
        {

            return TransactionResult.Canceled;
        }


        public override void Dispose()
        {
        }
    }
}