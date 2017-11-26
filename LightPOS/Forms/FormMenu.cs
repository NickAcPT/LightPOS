using NickAc.ModernUIDoneRight.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NickAc.LightPOS.Frontend.Forms
{
    public partial class FormMenu : ModernForm
    {
        public FormMenu()
        {
            InitializeComponent();
            translationHelper1.Translate(this);
        }
    }
}
