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
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System;

namespace NickAc.LightPOS.Backend.Data
{
    public class DataFactory
    {
        private const string fileConfig = "nh.config";
        private readonly FileInfo _dbFile;
        private readonly bool _overwriteExisting;

        public DataFactory(FileInfo file, bool overwriteExisting)
        {
            _dbFile = file;
            _overwriteExisting = overwriteExisting;
        }

        public void Create()
        {
            if (_dbFile.Exists) return;
            DataFactory df = new DataFactory(_dbFile, true);
            using (var sf = df.CreateSessionFactory()) {
                sf.Close();
            }
        }

        public ISessionFactory CreateSessionFactory()
        {
            return GetConfiguration()
                .BuildSessionFactory();
        }

        private FluentConfiguration GetConfiguration()
        {
            try {
                if (File.Exists(fileConfig)) {
                    using (var file = File.Open(fileConfig, FileMode.Open, FileAccess.Read)) {
                        var bf = new BinaryFormatter();
                        return Fluently.Configure(bf.Deserialize(file) as Configuration);
                    }
                }
            }
            catch (SerializationException ex) {
                Ignore(ex);
                //Ignore errors...
            }
            FluentConfiguration fluentConfiguration = Fluently.Configure()
                            .Database(
                                SQLiteConfiguration.Standard
                                    .UsingFile(_dbFile.FullName)
                            )
                            .Mappings(m => m.FluentMappings.AddFromAssemblyOf<DataFactory>()
                            .Conventions.Add(new ReferenceConvention()))
                            .ExposeConfiguration(BuildSchema);
            using (var file = File.Open(fileConfig, FileMode.Create)) {
                var bf = new BinaryFormatter();
                bf.Serialize(file, fluentConfiguration.BuildConfiguration());
            }
            return fluentConfiguration;
        }

        private void Ignore(SerializationException ex)
        {
            string exx = ex.GetType().GUID.ToString();
        }

        private void BuildSchema(Configuration config)
        {
            if (_overwriteExisting) {
                if (_dbFile.Exists) _dbFile.Delete();

                var se = new SchemaExport(config);
                se.Execute(false, true, false);
            }

        }
    }
}