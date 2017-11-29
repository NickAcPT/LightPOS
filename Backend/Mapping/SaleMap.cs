using FluentNHibernate.Mapping;
using NHibernate;
using NickAc.LightPOS.Backend.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
