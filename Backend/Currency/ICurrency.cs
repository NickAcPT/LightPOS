// 
// Copyright (c) NickAc. All rights reserved.
// Licensed under the MIT License. See LICENSE file in the project root for full license information.

using System.ComponentModel.Composition;
using System.Drawing;

namespace NickAc.LightPOS.Backend.Currency
{
    [InheritedExport(typeof(ICurrency))]
    public interface ICurrency
    {
        string Name { get; set; }

        Image Image { get; set; }

        TransactionResult RequestTransaction(TransactionState state);
    }
}