using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using NickAc.LightPOS.Backend.Objects;
using NickAc.LightPOS.Backend.Translation;
using NickAc.LightPOS.Frontend.Forms.POS;
using NickAc.ModernUIDoneRight.Forms;
using NickAc.ModernUIDoneRight.Objects;
using NickAc.ModernUIDoneRight.Utils;

namespace NickAc.LightPOS.Frontend.Controls.DrawHandler
{
    public class ProductListBoxDrawHandler : ListBoxDrawHandler
    {
        private readonly TranslationHelper _translation;
        private readonly ColorScheme _colorScheme = DefaultColorSchemes.Blue;

        public ColorScheme ColorScheme => Control?.FindForm() is ModernForm frm ? frm.ColorScheme : _colorScheme; 

        public ProductListBoxDrawHandler(ListBox control) : base(control)
        {
            _translation = new TranslationHelper();
        }

        private readonly StringFormat _centerVerticalStringFormat = new StringFormat
        {
            LineAlignment = StringAlignment.Center
        };
        public override void DrawItem(DrawItemEventArgs e)
        {
            var item = Control.Items.Cast<PointOfSaleForm.ProductListBoxItem>().ElementAtOrDefault(e.Index);

            if (item == null) return;

            e.Graphics.SetClip(e.Bounds);
            var backColor = e.State.HasFlag(DrawItemState.Selected) ? ControlPaint.Light(ColorScheme.PrimaryColor, 0.05f) : e.BackColor;
            using (var brush =
                new SolidBrush(backColor))
            {
                e.Graphics.FillRectangle(brush, e.Bounds);
            }

            using (var sb = new SolidBrush(GraphicUtils.ForegroundColorForBackground(backColor)))
            {
                e.Graphics.DrawString(_translation.TranslateMultilineResult(item.TextValue), Control.Font, sb, e.Bounds.OffsetAndReturn(5, 0), _centerVerticalStringFormat);
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