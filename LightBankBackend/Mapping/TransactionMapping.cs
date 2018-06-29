// 
// Copyright (c) NickAc. All rights reserved.
// Licensed under the MIT License. See LICENSE file in the project root for full license information.

using FluentNHibernate.Mapping;
using NickAc.LightBank.Backend.Objects;

namespace NickAc.LightBank.Backend.Mapping
{
    public class TransactionMapping : ClassMap<Transaction>
    {
        public TransactionMapping()
        {
            Table("LightTransactions");
            Id(x => x.Id);

            Map(x => x.Value);
            
            References(x => x.UserFrom);
            Map(x => x.UserTo);

            Map(x => x.Value);
        }
    }
}