// 
// Copyright (c) NickAc. All rights reserved.
// Licensed under the MIT License. See LICENSE file in the project root for full license information.

using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.ComponentModel.Composition.Primitives;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection;
using JetBrains.Annotations;
using NHibernate.Linq;
using NHibernate.Util;

namespace NickAc.LightPOS.Backend.Currency
{
    public class CurrencyManager {
        private AggregateCatalog Catalog { get; set; }
        private CompositionContainer Container { get; set; }

        [UsedImplicitly]
        [ImportMany(typeof(AbstractCurrency))]
        public List<AbstractCurrency> Currencies { get; set; }

        private void LoadCatalog()
        {
            Catalog = new AggregateCatalog(new AssemblyCatalog(typeof(CurrencyManager).Assembly), new DirectoryCatalog(Environment.CurrentDirectory));
            Container = new CompositionContainer(Catalog);
        }

        public void LoadCurrencies()
        {
            Container?.SatisfyImportsOnce(this);
            foreach (var currency in Currencies)
            {
                currency.Init();
            }
        }
        public CurrencyManager()
        {
            LoadCatalog();
        }
    }
}
