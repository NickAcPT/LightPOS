// 
// Copyright (c) NickAc. All rights reserved.
// Licensed under the MIT License. See LICENSE file in the project root for full license information.

using System;
using System.Drawing;
using System.Threading.Tasks;

namespace NickAc.LightPOS.Backend.Currency.Impl
{
    public class MoneyCurrencyImpl : AbstractCurrency
    {
        public override void Init()
        {
            Console.WriteLine(@"Loaded Money Currency!");
        }

        public override string Name => "Money";
        public override Image Image => CurrencyResources.cash_usd;
        public override async Task<TransactionResult> RequestTransaction(TransactionState state)
        {
            return await Task.FromResult(TransactionResult.Canceled);
        }

        public override void Dispose()
        {

        }
    }
}