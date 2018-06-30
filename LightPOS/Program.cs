//
// Copyright (c) NickAc. All rights reserved.
// Licensed under the MIT License. See LICENSE file in the project root for full license information.
//

using System;
using System.IO;
using System.Windows.Forms;
using NickAc.LightPOS.Backend.Data;
using NickAc.LightPOS.Backend.Utils;
using NickAc.LightPOS.Frontend.Forms.Users;

namespace NickAc.LightPOS.Frontend
{
    internal static class Program
    {
        /// <summary>
        ///     The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {

            //Load settings prematurely
            SettingsManager.Initialize();
            var settingsManager = new Settings.SettingsManager();
            settingsManager.LoadSettings();

            //Do winforms stuff
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new UserLoginForm());

            //Dispose every currency and save settings
            GlobalStorage.CurrencyManager?.Currencies?.ForEach(c => c.Dispose());
            settingsManager.SaveSettings();
        }

        public static void CreateGenericProducts()
        {
#if NDB
            var catgories = new[] {"Drink", "General"};
            var barcode = 0;
            foreach (var prodName in catgories)
            {
                var cat = new Category
                {
                    Name = prodName,
                    Tax = 0.23m
                };
                DataManager.AddCategory(cat);
                const decimal incrementPrice = 0.1m;
                var basePrice = 0.5m;
                for (var i = 1; i <= 5; i++)
                {
                    DataManager.AddProduct(new Product
                    {
                        Barcode = barcode.ToString(),
                        Category = cat,
                        Name = $"{prodName} #{i}",
                        Price = basePrice,
                        UnitPrice = basePrice
                    });

                    basePrice += incrementPrice;
                    barcode++;
                }
            }
#endif
        }

        public static void InitializeDatabase()
        {
            DataManager.Initialize(new FileInfo("POS.db"));
            CreateGenericProducts();
        }
    }
}