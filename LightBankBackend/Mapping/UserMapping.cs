// 
// Copyright (c) NickAc. All rights reserved.
// Licensed under the MIT License. See LICENSE file in the project root for full license information.

using FluentNHibernate.Mapping;
using NickAc.LightBank.Backend.Objects;

namespace NickAc.LightBank.Backend.Mapping
{
    public class UserMapping : ClassMap<User>
    {
        public UserMapping()
        {
            Table("LightUsers");
            Id(x => x.Id);

            Map(x => x.Name);

            HasMany(x => x.Cards);

            HasMany(x => x.Transactions);
        }
    }
}