using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace NickAc.LightPOS.Backend.Objects
{
    public class Category
    {
        public virtual Int32 ID { get; set; }
        public virtual String Name { get; set; }
        public virtual Color Color { get; set; }
    }
}
