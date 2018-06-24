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
        public new decimal Value
        {
            get => base.Value / 100;
            set => base.Value = value * 100;
        }
    }
}
