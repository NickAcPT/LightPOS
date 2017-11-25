//
// Copyright (c) NickAc. All rights reserved.
// Licensed under the MIT License. See LICENSE file in the project root for full license information.
//
using NickAc.LightPOS.Backend.Data;
using System;
using System.Drawing;

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
            /*Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());*/
            DataManager.Initialize(new System.IO.FileInfo("POS.db"));
            DataManager.AddProduct(new Backend.Objects.Product
            {
                Name = "Test Product 2",
                Barcode = "12",
                Category = new Backend.Objects.Category
                {
                    Name = "Test",
                    Color = Color.Red
                },
                Price = 1.25f,
                Quantity = 1,
                UnitPrice = 1.25f
            });
        }
    }
}