//
// Copyright (c) NickAc. All rights reserved.
// Licensed under the MIT License. See LICENSE file in the project root for full license information.
//
using NickAc.LightPOS.Backend.Data;
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
            Application.Run(new Forms.FormMenu());
            /*
            TimeMeasurer.MeasureTime(() => {
                DataManager.Initialize(new System.IO.FileInfo("POS.db"));
            });

            TimeMeasurer.MeasureTime(() => {
                DataManager.GetProducts().All(p => {
                    Console.WriteLine(p);
                    return true;
                });
            });
            TimeMeasurer.MeasureTime(() => {
                DataManager.AddProduct(new Backend.Objects.Product
                {
                    Name = "Test Product",
                    Barcode = "1",
                    Category = new Backend.Objects.Category
                    {
                        Name = "Test Category",
                        Color = Color.Red
                    },
                    Price = 1.1f,
                    UnitPrice = 1.1f,
                    Quantity = 1,
                });
            });
            TimeMeasurer.MeasureTime(() => {
                DataManager.AddProduct(new Backend.Objects.Product
                {
                    Name = "Test Product 2",
                    Barcode = "2",
                    Category = new Backend.Objects.Category
                    {
                        Name = "Test Category 2",
                        Color = Color.Blue
                    },
                    Price = 1.2f,
                    UnitPrice = 1.2f,
                    Quantity = 1,
                });
            });

            TimeMeasurer.MeasureTime(() => {
                DataManager.RemoveProduct(1);
            });*/
        }
    }
}