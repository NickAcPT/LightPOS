// 
// Copyright (c) NickAc. All rights reserved.
// Licensed under the MIT License. See LICENSE file in the project root for full license information.

using NHibernate;
using NickAc.LightBank.Backend.Objects;
using NickAc.LightPOS.Backend.Data;

namespace NickAc.LightBank.Backend.Data
{
    public class LightBankDataManager
    {
        
        #region Properties

        public static ISessionFactory SessionFactory => DataManager.SessionFactory;

        #endregion

        #region Methods

        public static User CreateUser(string name)
        {
            using (SessionFactory.OpenSession(out var session))
            {
                var user = new User {Name = name};
                user.Cards.InitializeProxy();
                user.Transactions.InitializeProxy();

                session.SaveOrUpdate(user);
                return user;
            }
        }
        
        public static Card AddCardToUser(User user, string cardId)
        {
            using (SessionFactory.OpenSession(out var session))
            {
                user.Cards.InitializeProxy();
                user.Transactions.InitializeProxy();
                var card = new Card {CardSerialNumber = cardId, Enabled = true, Owner = user};
                user.Cards.Add(card);

                session.SaveOrUpdate(user);
                return card;
            }
        }

        #endregion

    }
}