using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NickAc.LightPOS.Backend.Objects
{
    public class Customer
    {
        public virtual int ID { get; set; }
        public virtual String Name { get; set; }
        public virtual IList<Sale> Sales { get; set; }
    }
}
