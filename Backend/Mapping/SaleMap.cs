//
// Copyright (c) NickAc. All rights reserved.
// Licensed under the MIT License. See LICENSE file in the project root for full license information.
//
using FluentNHibernate.Mapping;
using NickAc.LightPOS.Backend.Objects;

namespace NickAc.LightPOS.Backend.Mapping
{
    public class SaleMap : ClassMap<Sale>
    {
        public SaleMap()
        {
            Table("Sales");
            Id(x => x.ID).GeneratedBy.Native();
            HasMany(x => x.Products);
            Map(x => x.TotalPrice);
            Map(x => x.PaidPrice);
            Map(x => x.ChangePrice);

            References(x => x.Customer);
            References(x => x.User);
        }
    }
}