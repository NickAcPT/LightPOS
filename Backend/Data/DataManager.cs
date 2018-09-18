//  
// Copyright (c) NickAc. All rights reserved.
// Licensed under the GNU LGPLv3 License. See LICENSE file in the project root for full license information.
//  

using System.Collections.Generic;
using System.IO;
using NHibernate;
using NickAc.LightPOS.Backend.Utils;

namespace NickAc.LightPOS.Backend.Data
{
    public static class DataManager
    {
        #region Properties

        public static DataFactory DataFactory { get; set; }

        public static ISessionFactory SessionFactory { get; set; }

        #endregion

        #region Methods

        public static void Initialize(FileInfo file)
        {
            TimeMeasurer.MeasureTime("new DataFactory();", () =>
            {
                if (DataFactory == null) DataFactory = new DataFactory(file, false);
            });
            TimeMeasurer.MeasureTime("DataFactory.Create();", () =>
            {
                DataFactory?.Create();
            });

            if (SessionFactory == null) SessionFactory = DataFactory.CreateSessionFactory();
        }


        public static IList<T> GetAll<T>(bool includeRemoved = false) where T : BaseDbItem
        {
            using (SessionFactory.OpenSession(out var session))
            {
                var queryOver = session.QueryOver<T>();
                if (!includeRemoved)
                    queryOver = queryOver.Where(c => !c.Deleted);
                return queryOver.List();
            }
        }

        #endregion
    }
}