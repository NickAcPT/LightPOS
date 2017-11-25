//
// Copyright (c) NickAc. All rights reserved.
// Licensed under the MIT License. See LICENSE file in the project root for full license information.
//
//
// Copyright (c) NickAc. All rights reserved.
// Licensed under the MIT License. See LICENSE file in the project root for full license information.
//
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using NickAc.LightPOS.Backend.Mapping;
using System.IO;

namespace NickAc.LightPOS.Backend.Data
{
    public class DataFactory
    {
        private readonly FileInfo _dbFile;
        private readonly bool _overwriteExisting;
        private static ISessionFactory sessionFactory;

        public DataFactory(FileInfo file, bool overwriteExisting)
        {
            _dbFile = file;
            _overwriteExisting = overwriteExisting;
        }

        public void Create()
        {
            using (var sf = CreateSessionFactory()) {
                sf.Close();
            }
        }

        public ISessionFactory CreateSessionFactory()
        {
            return Fluently.Configure()
                .Database(
                    SQLiteConfiguration.Standard
                        .UsingFile(_dbFile.FullName)
                )
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<DataFactory>().Conventions.Add(new ReferenceConvention()))
                .ExposeConfiguration(BuildSchema)
                .BuildSessionFactory();
        }

        private void BuildSchema(Configuration config)
        {
            if (_overwriteExisting) {
                if (_dbFile.Exists) _dbFile.Delete();

                var se = new SchemaExport(config);
                se.Execute(true, true, false);
            }
        }
    }
}