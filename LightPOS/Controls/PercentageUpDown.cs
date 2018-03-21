using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NickAc.LightPOS.Frontend.Controls
{
    public class PercentageUpDown : NumericUpDown
    {
        public override string Text
        {
            get => base.Text.TrimEnd('%');
            set => base.Text = $@"{value}%";
        }
        public new double Value
        {
            get => (double) (base.Value / 100);
            set => base.Value = (decimal) (value * 100);
        }
    }
}
