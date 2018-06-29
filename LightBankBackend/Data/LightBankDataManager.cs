// 
// Copyright (c) NickAc. All rights reserved.
// Licensed under the MIT License. See LICENSE file in the project root for full license information.

using NHibernate;
using NickAc.LightPOS.Backend.Data;

namespace NickAc.LightBank.Backend.Data
{
    public class LightBankDataManager
    {
        
        #region Properties

        public static DataFactory DataFactory => DataManager.DataFactory;

        public static ISessionFactory SessionFactory => DataManager.SessionFactory;

        #endregion

        #region Methods



        #endregion

    }
}