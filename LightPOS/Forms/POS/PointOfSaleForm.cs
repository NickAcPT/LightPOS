using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using NickAc.LightPOS.Backend.Data;
using NickAc.LightPOS.Backend.Utils;
using NickAc.LightPOS.Frontend.Controls;

namespace NickAc.LightPOS.Frontend.Forms.POS
{
    public partial class PointOfSaleForm : TemplateForm
    {
        public override Size MaximumSize
        {
            get => Size.Empty;
            set => base.MaximumSize = value;
        }

        private static readonly Size ButtonSize = new Size(100, 100);

        public PointOfSaleForm()
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;
            Extensions.RunInAnotherThread(() =>
            {
                var allProds = DataManager.GetProducts();
                var splitProducts = allProds.GroupBy(c => c.Category);
                foreach (var prods in splitProducts)
                {
                    var page = new TabPage(prods.Key.Name);
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
                            Size = ButtonSize
                        };
                        pnl.Controls.Add(btn);
                    }


                    this.InvokeIfRequired(() => headerlessTabControl1.TabPages.Add(page));
                }
            });
        }
    }
}