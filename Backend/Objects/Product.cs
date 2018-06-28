//
// Copyright (c) NickAc. All rights reserved.
// Licensed under the MIT License. See LICENSE file in the project root for full license information.
//

namespace NickAc.LightPOS.Backend.Objects
{
    public class Product
    {
        public virtual int Id { get; set; }

        public virtual string Barcode { get; set; }

        public virtual string Name { get; set; }

        public virtual Category Category { get; set; }

        public virtual bool RequiresQuantity { get; set; }

        public virtual int Quantity { get; set; }

        public virtual decimal UnitPrice { get; set; }

        public virtual decimal Price { get; set; }

        public virtual decimal CalculatePrice()
        {
            return UnitPrice * Quantity * (1 + Category?.Tax) ?? 1m;
        }

        public virtual decimal CalculateUnitPrice()
        {
            return UnitPrice * (1 + Category?.Tax) ?? 1m;
        }

        public override string ToString()
        {
            return
                $"Product[ID={Id}, Barcode={Barcode}, Name={Name}, Category={Category}, RequiresQuantity={RequiresQuantity}, Quantity={Quantity}, Price={Price}]";
        }
    }
}