//
// Copyright (c) NickAc. All rights reserved.
// Licensed under the MIT License. See LICENSE file in the project root for full license information.
//
using NickAc.LightPOS.Backend.Mapping;
using System.Collections.Generic;

namespace NickAc.LightPOS.Backend.Objects
{
    public class Sale
    {
        public virtual int ID { get; set; }

        [NotLazy]
        public virtual IList<Product> Products { get; set; }

        public virtual float TotalPrice { get; set; }
        public virtual float PaidPrice { get; set; }
        public virtual float ChangePrice { get; set; }

        [NotLazy]
        public virtual Customer Customer { get; set; }

        [NotLazy]
        public virtual User User { get; set; }
    }
}