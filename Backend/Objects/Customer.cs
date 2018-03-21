//
// Copyright (c) NickAc. All rights reserved.
// Licensed under the MIT License. See LICENSE file in the project root for full license information.
//

using System.Collections.Generic;
using NickAc.LightPOS.Backend.Mapping;

namespace NickAc.LightPOS.Backend.Objects
{
    public class Customer
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual string Street { get; set; }
        public virtual string PhoneNumber { get; set; }

        [NotLazy] public virtual IList<Sale> Sales { get; set; }
    }
}