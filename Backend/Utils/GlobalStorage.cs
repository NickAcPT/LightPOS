using NickAc.LightPOS.Backend.Objects;
using NickAc.ModernUIDoneRight.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NickAc.LightPOS.Backend.Utils
{
    public static class GlobalStorage
    {
        public static User CurrentUser { get; set; }
    }
}
