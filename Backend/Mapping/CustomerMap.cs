using FluentNHibernate.Mapping;
using NickAc.LightPOS.Backend.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NickAc.LightPOS.Backend.Mapping
{
    public class CustomerMap : ClassMap<Customer>
    {
        public CustomerMap()
        {
            Table("Customers");
            Id(x => x.ID).GeneratedBy.Native();
            Map(x => x.Name);
            Map(x => x.PhoneNumber);
            Map(x => x.Street);

            HasManyToMany(x => x.Sales).Not.LazyLoad();
        }
    }
}
