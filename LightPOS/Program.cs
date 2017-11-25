using NickAc.LightPOS.Backend.Data;
using System;
using System.Drawing;

namespace NickAc.LightPOS.Frontend
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            /*Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());*/
            DataManager.Initialize(new System.IO.FileInfo("POS.db"));
            DataManager.AddProduct(new Backend.Objects.Product
            {
                Name = "Test Product",
                Barcode = "1",
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
