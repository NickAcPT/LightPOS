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
        public PointOfSaleForm()
        {
            InitializeComponent();
            var drawHandler = new ProductListBoxDrawHandler(listBox1);

            translationHelper1.Translate(this);
            UpdateSaleButton();
            WindowState = FormWindowState.Maximized;

            _nickCustomTabControl1.LoadProducts(ProductButton_Click);
            listBox1.LostFocus += (s, e) => listBox1.SelectedIndex = -1;

            listBox1.MouseDoubleClick += (s, e) =>
            {
                var index = listBox1.IndexFromPoint(e.Location);
                if (index == -1) return;
                var item = listBox1.Items.OfType<ProductListBoxItem>().ElementAtOrDefault(index);
                if (item == null) return;
                listBox1.BeginUpdate();
                item.Product.Quantity -= 1;
                if (item.Product.Quantity < 1)
                    listBox1.Items.RemoveAt(index);
                listBox1.EndUpdate();
                UpdateSaleButton();
            };
        }

        public override Size MaximumSize
        {
            get => Size.Empty;
            set => base.MaximumSize = value;
        }

        private void ProductButton_Click(object sender, EventArgs e)
        {
            if (!(sender is ModernProductButton productButton)) return;
            var prod = productButton.Product;

            var existingItem = listBox1.Items.OfType<ProductListBoxItem>()
                .FirstOrDefault(c => c.Product.Name == prod.Name && c.Product.Barcode == prod.Barcode);
            listBox1.BeginUpdate();
            if (existingItem == null)
            {
                listBox1.Items.Add((ProductListBoxItem) prod);
            }
            else
            {
                existingItem.Product.Quantity += 1;
            }
            listBox1.Refresh();
            listBox1.EndUpdate();
            UpdateSaleButton();
        }

        private void UpdateSaleButton()
        {
            var loc = translationHelper1.GetTranslationLocation(modernButton1);
            modernButton1.Text = translationHelper1.GetTranslation(loc).AppendLine($@"({
                    DataManager.CalculateTotal(listBox1.Items.OfType<ProductListBoxItem>()
                            .Select(c => c.Product))
                        .ToCurrency()
                })");
        }

        private void modernButton1_Click(object sender, EventArgs e)
        {/*
            Hide();
            Extensions.RunInAnotherApplication<CurrencyPickerForm>(constructorArgs: listBox1.Items.OfType<ProductListBoxItem>()
                .Select(c => c.Product).ToList());
            Show();*/
            this.ShowBlurryDialog(new CurrencyPickerForm(listBox1.Items.OfType<ProductListBoxItem>()
                .Select(c => c.Product).ToList()));
        }

        public class ProductListBoxItem
        {
            private ProductListBoxItem(Product product)
            {
                Product = product;
            }


            public Product Product { get; }

            public string TextValue => Product == null
                ? ""
                : $"$pos_list_prodName {Product.Name}"
                    .AppendLine($"$pos_list_prodCategory {Product.Category.Name}")
                    .AppendLine($"$pos_list_prodQuantity {Product.Quantity}")
                    .AppendLine($"$pos_list_prodPrice {Product.CalculatePrice().ToCurrency()}")
                    .AppendLine($"$pos_list_prodUnitPrice {Product.CalculateUnitPrice().ToCurrency()}");

            public static explicit operator ProductListBoxItem(Product prod)
            {
                prod.Quantity = 1;
                prod.RequiresQuantity = true;
                return new ProductListBoxItem(prod);
            }
        }
    }
}