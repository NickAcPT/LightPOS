//
// Copyright (c) NickAc. All rights reserved.
// Licensed under the MIT License. See LICENSE file in the project root for full license information.
//

using FluentNHibernate.Mapping;
using NickAc.LightPOS.Backend.Objects;

namespace NickAc.LightPOS.Backend.Mapping
{
    public class ProductMap : ClassMap<Product>
    {
        public ProductMap()
        {
            Table("Products");
            Id(x => x.Id).GeneratedBy.Native();
            Map(x => x.Name);
            Map(x => x.Barcode).Unique();
            Map(x => x.Price);
            Map(x => x.UnitPrice);
            Map(x => x.Quantity);

            References(x => x.Category);
        }
    }
}