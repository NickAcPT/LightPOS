//
// Copyright (c) NickAc. All rights reserved.
// Licensed under the MIT License. See LICENSE file in the project root for full license information.
//
using NickAc.LightPOS.Backend.Data;
using NickAc.LightPOS.Backend.Objects;
using NickAc.LightPOS.Backend.Utils;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace NickAc.LightPOS.Frontend
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Forms.MainMenuForm());
            /*
            TimeMeasurer.MeasureTime(() => {
                DataManager.Initialize(new System.IO.FileInfo("POS.db"));
            });
            
            Customer customer = new Customer
            {
                Name = "Default",
                PhoneNumber = "+XXX 9XX XXX XXX",
                Street = "Street 1234"
            };
            Customer customer = DataManager.GetCustomer(1);
            TimeMeasurer.MeasureTime(() => {
                DataManager.GetProducts().All(p => {
                    Console.WriteLine(p);
                    return true;
                });
            });
            Product p1 = new Product
            {
                Name = "Test Product",
                Barcode = "1",
                Category = new Category
                {
                    Name = "Test Category",
                    Color = Color.Red
                },
                Price = 1.1f,
                UnitPrice = 1.1f,
                Quantity = 1,
            };
            TimeMeasurer.MeasureTime(() => {
                DataManager.AddProduct(p1);
            });
            TimeMeasurer.MeasureTime(() => {
                DataManager.AddSale(DataManager.CreateSale(customer, 1.2f, p1));
            });
            TimeMeasurer.MeasureTime(() => {
                Customer c = DataManager.GetCustomer(1);
            });*/
        }
    }
}