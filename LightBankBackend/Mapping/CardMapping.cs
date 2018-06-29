// 
// Copyright (c) NickAc. All rights reserved.
// Licensed under the MIT License. See LICENSE file in the project root for full license information.

using FluentNHibernate.Mapping;
using NickAc.LightBank.Backend.Objects;

namespace NickAc.LightBank.Backend.Mapping
{
    public class CardMapping : ClassMap<Card>
    {
        public CardMapping()
        {
            Table("LightCards");
            Id(x => x.Id);
            Map(x => x.Enabled);
            Map(x => x.CardSerialNumber);
            References(x => x.Owner);
        }
    }
}