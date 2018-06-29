// 
// Copyright (c) NickAc. All rights reserved.
// Licensed under the MIT License. See LICENSE file in the project root for full license information.

using NHibernate;

namespace NickAc.LightPOS.Backend.Data
{
    public static class SessionExtensions
    {
        public static void InitializeProxy(this object proxy)
        {
            try
            {
                if (!NHibernateUtil.IsInitialized(proxy))
                    NHibernateUtil.Initialize(proxy);
            }
            catch (HibernateException)
            {
            }
        }

        public static SessionTransactionWrapper OpenSession(this ISessionFactory sf, out ISession session)
        {
            var wrapper = new SessionTransactionWrapper(sf, false);
            session = wrapper.OpenSession;
            return wrapper;
        }
        public static SessionTransactionWrapper OpenSessionWithTransaction(this ISessionFactory sf, out ISession session, out ITransaction transaction)
        {
            var wrapper = new SessionTransactionWrapper(sf, true);
            session = wrapper.OpenSession;
            transaction = wrapper.OpenTransaction;
            return wrapper;
        }
        public static SessionTransactionWrapper OpenSessionWithTransaction(this ISessionFactory sf, out ISession session)
        {
            return OpenSessionWithTransaction(sf, out session, out _);
        }
    }
}