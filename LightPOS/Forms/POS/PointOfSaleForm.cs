using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using NickAc.LightPOS.Backend.Data;
using NickAc.LightPOS.Backend.Objects;
using NickAc.LightPOS.Backend.Utils;
using NickAc.LightPOS.Frontend.Controls;

namespace NickAc.LightPOS.Frontend.Forms.POS
{
    public partial class PointOfSaleForm : TemplateForm
    {
        struct ProductListBoxItem
        {

            public static explicit operator ProductListBoxItem(Product prod)
            {
                return new ProductListBoxItem(prod);
            }

            private ProductListBoxItem(Product product)
            {
                Product = product;
            }

            private Product Product { get; }

            public string TextValue => $"$pos_list_prodName {Product.Name}"
                .AppendLine("$pos_list_prodCategory {Product.Category}")
                .AppendLine("$pos_list_prodQuantity {Product.Quantity}")
                .AppendLine("$pos_list_prodPrice //TODO")
                .AppendLine("$pos_list_prodUnitPrice //TODO");
        }

        public override Size MaximumSize
        {
            get => Size.Empty;
            set => base.MaximumSize = value;
        }

        private static readonly Size ButtonSize = new Size(100, 100);

        public PointOfSaleForm()
        {
            InitializeComponent();
            translationHelper1.Translate(this);
            _nickCustomTabControl1.DrawHandler = new ModernTabDrawHandler();
            WindowState = FormWindowState.Maximized;
            Extensions.RunInAnotherThread(() =>
            {
                var allProds = DataManager.GetProducts();
                var splitProducts = allProds.GroupBy(c => c.Category);
                foreach (var prods in splitProducts)
                {
                    var page = new TabPage(prods.Key.Name) {Tag = prods.Key.Color};
                    var pnl = new FlowLayoutPanel
                    {
                        Dock = DockStyle.Fill,
                        FlowDirection = FlowDirection.LeftToRight
                    };
                    page.Controls.Add(pnl);

                    foreach (var product in prods)
                    {
                        var btn = new ModernProductButton(product)
                        {
                            Text = product.Name,
                            Size = ButtonSize,
                        };
                        btn.Click += ProductButton_Click;
                        pnl.Controls.Add(btn);
                    }

                    this.InvokeIfRequired(() => _nickCustomTabControl1.TabPages.Add(page));
                }
            });
        }

        private void ProductButton_Click(object sender, EventArgs e)
        {
            if (!(sender is ModernProductButton productButton)) return;

            listBox1.Items.Add((ProductListBoxItem)productButton.Product);
        }
    }
}