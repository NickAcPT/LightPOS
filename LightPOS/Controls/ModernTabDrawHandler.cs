using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using NickAc.ModernUIDoneRight.Objects;
using NickAc.ModernUIDoneRight.Utils;

namespace NickAc.LightPOS.Frontend.Controls
{
    public class ModernTabDrawHandler : NickCustomTabControl.CustomTabDrawHandler
    {
        public override void DrawCustomTabBackground(int id, Graphics g, Rectangle rect, bool isHot, bool isSelected)
        {
        }

        public override void DrawTabContent(int id, Graphics g, Rectangle rect, bool isHot, bool isSelected)
        {
            using (var sb = new SolidBrush(Parent.ColorScheme.ForegroundColor))
            {
                using (var sF = new StringFormat {Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center})
                {
                    g.DrawString(Parent.TabPages[id].Text, this.Parent.Font, sb, rect,
                        sF);
                }
            }

        }

        public override bool HandleTabClick(int id, Rectangle rect)
        {
            return false;
        }
    }
}
