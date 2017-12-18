using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NickAc.LightPOS.Backend.Objects
{
    public class StoredSetting
    {
        public virtual string ID { get; set; }
        public virtual byte[] Data { get; set; }

    }
}
