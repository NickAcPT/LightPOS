using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using NickAc.LightPOS.Backend.Objects;
using NickAc.LightPOS.Backend.Translation;
using NickAc.LightPOS.Frontend.Forms.POS;

namespace NickAc.LightPOS.Frontend.Controls.DrawHandler
{
    class ProductListBoxDrawHandler : ListBoxDrawHandler
    {
        private TranslationHelper translation;

        public ProductListBoxDrawHandler(ListBox control) : base(control)
        {
            translation = new TranslationHelper();
        }

        public override void DrawItem(DrawItemEventArgs e)
        {
            var item = Control.Items.Cast<PointOfSaleForm.ProductListBoxItem>().ElementAtOrDefault(e.Index);

            e.Graphics.SetClip(e.Bounds);
            using (var brush = new SolidBrush(e.BackColor))
            {
                e.Graphics.FillRectangle(brush, e.Bounds);
            }

            using (var sb = new SolidBrush(Control.ForeColor))
            {
                e.Graphics.DrawString(translation.TranslateMultilineResult(item.TextValue), Control.Font, sb, e.Bounds);
            }

            e.Graphics.SetClip(Rectangle.Empty);
        }

        private int? _itemHeight;

        public override void MeasureItem(MeasureItemEventArgs e)
        {
            e.ItemHeight = _itemHeight ??
                           (int) (_itemHeight = (int) (e.Graphics.MeasureString("ABC", Control.Font).Height * 5));
        }
    }
}