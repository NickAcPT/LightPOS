// 
// Copyright (c) NickAc. All rights reserved.
// Licensed under the MIT License. See LICENSE file in the project root for full license information.

using System;
using System.ComponentModel.Composition;
using System.Drawing;
using System.Threading.Tasks;

namespace NickAc.LightPOS.Backend.Currency
{
    [InheritedExport(typeof(AbstractCurrency))]
    public abstract class AbstractCurrency : IDisposable
    {
        public abstract string Name { get; }

        public abstract Image Image { get; }

        public abstract void Dispose();
        public abstract void Init();

        public abstract Task<TransactionResult> RequestTransaction(TransactionState state);
    }
}