//
// Copyright (c) NickAc. All rights reserved.
// Licensed under the MIT License. See LICENSE file in the project root for full license information.
//
//
// Copyright (c) NickAc. All rights reserved.
// Licensed under the MIT License. See LICENSE file in the project root for full license information.
//
using NickAc.LightPOS.Backend.Data;
using NickAc.LightPOS.Backend.Utils;
using System;
using System.Linq;

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
                DataManager.GetProducts().All(p => {
                    Console.WriteLine(p);
                    return true;
                });
            });
        }
    }
}