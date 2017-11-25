using FluentNHibernate.Mapping;
using NickAc.LightPOS.Backend.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NickAc.LightPOS.Backend.Mapping
{
    public class ProductMap : ClassMap<Product>
    {
        public ProductMap()
        {
            Table("Products");
            Id(x => x.ID).GeneratedBy.Native();
            Map(x => x.Name);
            Map(x => x.Barcode);
            Map(x => x.Price);
            Map(x => x.UnitPrice);
            Map(x => x.Quantity);

            References(x => x.Category);
        }
    }
}
