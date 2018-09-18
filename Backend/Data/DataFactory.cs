//  
// Copyright (c) NickAc. All rights reserved.
// Licensed under the GNU LGPLv3 License. See LICENSE file in the project root for full license information.
//  

using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;

namespace NickAc.LightPOS.Backend.Data
{
    public class DataFactory
    {
        private const string FileConfig = "nh.config";
        private readonly FileInfo _dbFile;
        private readonly bool _overwriteExisting;

        public DataFactory(FileInfo file, bool overwriteExisting)
        {
            _dbFile = file;
            _overwriteExisting = overwriteExisting;
        }

        public ISessionFactory CreateSessionFactory()
        {
            var config = GetConfiguration();
            return config
                .BuildSessionFactory();
        }

        public void Create()
        {
            if (_dbFile.Exists) return;
            var df = new DataFactory(_dbFile, true);
            using (var sf = df.CreateSessionFactory())
            {
                sf.Close();
            }
        }

        private FluentConfiguration GetConfiguration()
        {
            try
            {
                if (File.Exists(FileConfig))
                    using (var file = File.Open(FileConfig, FileMode.Open, FileAccess.Read))
                    {
                        var bf = new BinaryFormatter();
                        return Fluently.Configure(bf.Deserialize(file) as Configuration);
                    }
            }
            catch (SerializationException)
            {
                //Ignore errors deserialization errors and delete the existing file
                File.Delete(FileConfig);
            }

            var fluentConfiguration = Fluently.Configure()
                .Database(
                    SQLiteConfiguration.Standard
                        .UsingFile(_dbFile.FullName)
                )
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<DataFactory>())
                .ExposeConfiguration(BuildSchema);
            using (var file = File.Open(FileConfig, FileMode.Create))
            {
                var bf = new BinaryFormatter();
                bf.Serialize(file, fluentConfiguration.BuildConfiguration());
            }

            return fluentConfiguration;
        }

        private static void BuildSchema(Configuration config)
        {
            var se = new SchemaUpdate(config);
            se.Execute(false, true);
        }
    }
}