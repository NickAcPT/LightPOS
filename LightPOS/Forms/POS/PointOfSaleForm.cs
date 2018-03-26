using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NickAc.LightPOS.Frontend.Forms.POS
{
    public partial class PointOfSaleForm : TemplateForm
    {
        public override Size MaximumSize
        {
            get => Size.Empty;
            set => base.MaximumSize = value;
        }

        public PointOfSaleForm()
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;
        }

        private void modernButton1_Click(object sender, EventArgs e)
        {

        }
    }
}
