// 
// Copyright (c) NickAc. All rights reserved.
// Licensed under the MIT License. See LICENSE file in the project root for full license information.

using System;
using NHibernate;

namespace NickAc.LightPOS.Backend.Data
{
    public class SessionTransactionWrapper : IDisposable
    {
        public void Dispose()
        {
            if (!OpenTransaction?.WasRolledBack ?? false)
            {
                OpenTransaction?.Commit();
            }
            OpenTransaction?.Dispose();
            OpenSession?.Dispose();
            SessionFactory?.Dispose();
        }

        public ISessionFactory SessionFactory { get; }
        public ISession OpenSession { get; }
        public ITransaction OpenTransaction { get; }

        public SessionTransactionWrapper(ISessionFactory sessionFactory, bool beginTransaction)
        {
            SessionFactory = sessionFactory;
            OpenSession = sessionFactory.OpenSession();
            if (beginTransaction)
                OpenTransaction = OpenSession.BeginTransaction();
        }
    }
}