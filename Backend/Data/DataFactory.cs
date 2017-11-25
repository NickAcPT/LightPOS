using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace NickAc.LightPOS.Backend.Data
{
    public class DataFactory
    {
        readonly FileInfo _dbFile;
        readonly bool _overwriteExisting;

        public DataFactory(FileInfo file, bool overwriteExisting)
        {
            _dbFile = file;
            _overwriteExisting = overwriteExisting;
        }

        public static void Create(FileInfo file)
        {
            DataFactory df = new DataFactory(file, true);
            using (var sf = df.CreateSessionFactory()) {
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
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<DataFactory>())
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
