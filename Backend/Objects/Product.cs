using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NickAc.LightPOS.Backend.Objects
{
    public class Product
    {
        public virtual Int32 ID { get; set; }
        public virtual String Barcode { get; set; }
        public virtual String Name { get; set; }
        public virtual Category Category { get; set; }

        public virtual int Quantity { get; set; }
        public virtual float UnitPrice { get; set; }
        public virtual float Price { get; set; }
        
    }
}
