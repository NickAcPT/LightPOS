//
// Copyright (c) NickAc. All rights reserved.
// Licensed under the MIT License. See LICENSE file in the project root for full license information.
//
using NickAc.LightPOS.Backend.Mapping;
using System;
using System.Collections.Generic;

namespace NickAc.LightPOS.Backend.Objects
{
    public class Customer
    {
        public virtual int ID { get; set; }
        public virtual String Name { get; set; }
        public virtual String Street { get; set; }
        public virtual String PhoneNumber { get; set; }

        [NotLazy]
        public virtual IList<Sale> Sales { get; set; }
    }
}