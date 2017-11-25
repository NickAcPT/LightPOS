//
// Copyright (c) NickAc. All rights reserved.
// Licensed under the MIT License. See LICENSE file in the project root for full license information.
//
using NickAc.LightPOS.Backend.Objects;
using System.Collections.Generic;
using System.IO;

namespace NickAc.LightPOS.Backend.Data
{
    public static class DataManager
    {
        public static void Initialize(FileInfo file)
        {
            DataFactory = new DataFactory(file, false);
            DataFactory.Create(file);
        }

        public static DataFactory DataFactory { get; set; }

        public static void AddProduct(Product p)
        {
            using (var sf = DataFactory.CreateSessionFactory()) {
                using (var session = sf.OpenSession()) {
                    using (var trans = session.BeginTransaction()) {
                        session.SaveOrUpdate(p.Category);
                        session.SaveOrUpdate(p);
                        trans.Commit();
                    }
                }
            }
        }

        public static IList<Product> GetProducts()
        {
            IList<Product> list;
            using (var sf = DataFactory.CreateSessionFactory()) {
                using (var session = sf.OpenSession()) {
                    list = session.QueryOver<Product>().List();
                }
            }
            return list;
        }

        /// <summary>
        /// Never called! Exists just to tell Visual Studio to copy the assemblies to the build directory
        /// </summary>
        public static void InitStuff()
        {
            System.Data.SQLite.SQLiteCommand cmd = new System.Data.SQLite.SQLiteCommand();
            cmd.Dispose();
        }
    }
}