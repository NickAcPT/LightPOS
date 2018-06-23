using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using NickAc.LightPOS.Backend.Data;
using NickAc.LightPOS.Backend.Utils;
using NickAc.LightPOS.Frontend.Controls;

namespace NickAc.LightPOS.Frontend.Utils
{
    public static class FrontendExtensions
    {
        private static readonly Size ButtonSize = new Size(100, 100);

        public static void LoadProducts(this NickCustomTabControl tab, Action<object, EventArgs> evt)
        {
            Extensions.RunInAnotherThread(() =>
            {
                tab.InvokeIfRequired(() => tab.DrawHandler = new ModernTabDrawHandler());
                var allProds = DataManager.GetProducts();
                var splitProducts = allProds.GroupBy(c => c.Category);
                foreach (var prods in splitProducts)
                {
                    var page = new TabPage(prods.Key.Name) {BackColor = Color.Transparent};
                    var pnl = new FlowLayoutPanel
                    {
                        Dock = DockStyle.Fill,
                        FlowDirection = FlowDirection.LeftToRight,
                        BackColor = Color.Transparent
                    };
                    page.Controls.Add(pnl);

                    foreach (var product in prods)
                    {
                        var btn = new ModernProductButton(product)
                        {
                            Text = product.Name,
                            Size = ButtonSize,
                        };
                        btn.Click += (s, e) => evt?.Invoke(s, e);
                        pnl.Controls.Add(btn);
                    }

                    tab.InvokeIfRequired(() => tab.TabPages.Add(page));
                }
            });
        }
    }
}