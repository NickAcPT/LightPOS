// 
// Copyright (c) NickAc. All rights reserved.
// Licensed under the MIT License. See LICENSE file in the project root for full license information.

using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Reflection;

namespace NickAc.LightPOS.Backend.Currency
{
    public class CurrencyManager {
        private AggregateCatalog Catalog { get; set; }
        private CompositionContainer Container { get; set; }

        [ImportMany(typeof(ICurrency))] public List<ICurrency> Currencies { get; }

        private void LoadCatalog()
        {
            Catalog = new AggregateCatalog(new AssemblyCatalog(Assembly.GetExecutingAssembly()), new DirectoryCatalog(Environment.CurrentDirectory));
            Container = new CompositionContainer(Catalog);
        }

        public void LoadCurrencies()
        {
            Container?.SatisfyImportsOnce(this);
        }
        public CurrencyManager()
        {
            LoadCatalog();
        }
    }
}
