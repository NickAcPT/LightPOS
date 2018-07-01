using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NickAc.LightPOS.Backend.Currency;
using NickAc.LightPOS.Frontend.Forms;

namespace NickAc.LightPOS.Frontend.CurrencyImpl
{
    public partial class MoneyCurrencyForm : TemplateForm
    {
        public MoneyCurrencyForm(ref TransactionState state)
        {
            TransactionState = state;
            InitializeComponent();
            WindowState = FormWindowState.Maximized;
            translationHelper1.Translate(this);
        }

        public TransactionState TransactionState { get; set; }

        public override Size MaximumSize
        {
            get => Size.Empty;
            set => base.MaximumSize = value;
        }
    }
}
