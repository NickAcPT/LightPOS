using NickAc.LightPOS.Backend.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

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
