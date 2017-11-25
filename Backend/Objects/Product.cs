//
// Copyright (c) NickAc. All rights reserved.
// Licensed under the MIT License. See LICENSE file in the project root for full license information.
//
using NickAc.LightPOS.Backend.Mapping;
using System;

namespace NickAc.LightPOS.Backend.Objects
{
    public class Product
    {
        public virtual Int32 ID { get; set; }
        public virtual String Barcode { get; set; }
        public virtual String Name { get; set; }
        [NotLazy]
        public virtual Category Category { get; set; }

        public virtual int Quantity { get; set; }
        public virtual float UnitPrice { get; set; }
        public virtual float Price { get; set; }

        public override string ToString()
        {
            return string.Format("Product[ID={0}, Barcode={1}, Name={2}, Category={3}, Quantity={4}, Price={5}]", ID, Barcode, Name, Category, Quantity, Price);
        }
    }
}