using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using NickAc.LightPOS.Backend.Data;
using NickAc.LightPOS.Backend.Objects;
using NickAc.LightPOS.Backend.Utils;
using NickAc.LightPOS.Frontend.Controls;
using NickAc.LightPOS.Frontend.Controls.DrawHandler;
using NickAc.LightPOS.Frontend.Utils;

namespace NickAc.LightPOS.Frontend.Forms.POS
{
    public partial class PointOfSaleForm : TemplateForm
    {
        public struct ProductListBoxItem
        {
            public static explicit operator ProductListBoxItem(Product prod)
            {
                prod.Quantity = 1;
                prod.RequiresQuantity = true;
                return new ProductListBoxItem(prod);
            }

            private ProductListBoxItem(Product product)
            {
                Product = product;
            }

            private Product Product { get; }

            public string TextValue => $"$pos_list_prodName {Product.Name}"
                .AppendLine($"$pos_list_prodCategory {Product.Category.Name}")
                .AppendLine($"$pos_list_prodQuantity {Product.Quantity}")
                .AppendLine("$pos_list_prodPrice //TODO")
                .AppendLine("$pos_list_prodUnitPrice //TODO");
        }

        public override Size MaximumSize
        {
            get => Size.Empty;
            set => base.MaximumSize = value;
        }


        public PointOfSaleForm()
        {
            InitializeComponent();
            var drawHandler = new ProductListBoxDrawHandler(listBox1);

            translationHelper1.Translate(this);
            WindowState = FormWindowState.Maximized;

            _nickCustomTabControl1.LoadProducts(ProductButton_Click);
            
        }

        private void ProductButton_Click(object sender, EventArgs e)
        {
            if (!(sender is ModernProductButton productButton)) return;

            listBox1.Items.Add((ProductListBoxItem)productButton.Product);
        }

        private void modernButton1_Click(object sender, EventArgs e)
        {

        }
    }
}