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
using NickAc.LightPOS.Backend.Data;
using NickAc.LightPOS.Backend.Objects;
using NickAc.LightPOS.Backend.Utils;
using NickAc.LightPOS.Frontend.Controls;

namespace NickAc.LightPOS.Frontend.Forms.POS
{
    public partial class CurrencyPickerForm : TemplateForm
    {
        public List<Product> Products { get; }

        private readonly Size _currencyButtonSize = new Size(130, 130);

        public CurrencyPickerForm(List<Product> products)
        {
            Products = products;
            InitializeComponent();
            LoadCurrencies();
        }

        private void LoadCurrencies()
        {
            //Backend.Currency.CurrencyManager
            foreach (var cur in GlobalStorage.CurrencyManager.Currencies)
            {
                var btn = new CurrencyButton
                {
                    Currency = cur,
                    BackColor = Color.Transparent,
                    Size = _currencyButtonSize
                };
                btn.Click += (s, e) => CurrencyButton_Click((CurrencyButton)s, e);
                flowLayoutPanel1.Controls.Add(btn);
            }
        }

        private void CurrencyButton_Click(CurrencyButton sender, EventArgs e)
        {
            var state = new TransactionState
            {
                Products = Products,
                TotalPrice = DataManager.CalculateTotal(Products)
            };
            var result = sender.Currency?.RequestTransaction(ref state);
            if (result != TransactionResult.Completed) return;

            DataManager.AddSale(DataManager.CreateSale(GlobalStorage.DefaultCustomer, GlobalStorage.CurrentUser, state.PaidPrice, Products.ToArray()));
            Close();
        }

        public override Size MaximumSize { get; set; } = Size.Empty;
    }
}
