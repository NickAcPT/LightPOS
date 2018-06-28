// 
// Copyright (c) NickAc. All rights reserved.
// Licensed under the MIT License. See LICENSE file in the project root for full license information.

using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Reflection;
using JetBrains.Annotations;

namespace NickAc.LightPOS.Backend.Currency
{
    public class CurrencyManager
    {
        public CurrencyManager()
        {
            LoadCatalog();
        }

        private AggregateCatalog Catalog { get; set; }

        private CompositionContainer Container { get; set; }

        [UsedImplicitly]
        [ImportMany(typeof(AbstractCurrency))]
        public List<AbstractCurrency> Currencies { get; set; }

        private void LoadCatalog()
        {
            Catalog = new AggregateCatalog(new AssemblyCatalog(typeof(CurrencyManager).Assembly),
                new DirectoryCatalog(Environment.CurrentDirectory),
                new AssemblyCatalog(Assembly.GetExecutingAssembly()));
            Container = new CompositionContainer(Catalog);
        }

        public void LoadCurrencies()
        {
            Container?.SatisfyImportsOnce(this);
            foreach (var currency in Currencies) currency.Init();
        }
    }
}