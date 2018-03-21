using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NickAc.LightPOS.Frontend.Controls
{
    public class SimpleSelectionControl  : Control
    {
        public Color BorderColor { get; set; }
        public Type OptionEnum { get; set; } 
        public Enum SelectedEnumValue { get; set; } 

        public SimpleSelectionControl()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.DoubleBuffer | ControlStyles.UserPaint, true);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            if (OptionEnum != null && OptionEnum.IsEnum)
            {
                //Split them within the size of the control.
                //But first, draw a rectangle

            }
        }
    }
}
