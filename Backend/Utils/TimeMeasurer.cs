using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace NickAc.LightPOS.Backend.Utils
{
    public static class TimeMeasurer
    {
        public static void MeasureTime(Action a)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            a();
            sw.Stop();
            Console.WriteLine(string.Format("Action took {0}ms to execute.", sw.ElapsedMilliseconds));
        }
    }
}
