using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace NickAc.LightPOS.Frontend.Controls
{
    public class NickCustomTabControl : System.Windows.Forms.TabControl
    {
        

        public abstract class CustomTabDrawHandler
        {
            public NickCustomTabControl Parent { get; set; }
            public abstract void DrawCustomTabBackground(int id, Graphics g, Rectangle rect, bool isHot, bool isSelected);
            public abstract void DrawTabContent(int id, Graphics g, Rectangle rect, bool isHot, bool isSelected);
            public abstract bool HandleTabClick(int id, Rectangle rect);
        }

        private int _hotTabIndex = -1;
        private CustomTabDrawHandler _drawHandler;

        public NickCustomTabControl()
            : base()
        {
            this.SetStyle(
                ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw |
                ControlStyles.UserPaint, true);
        }

        #region Properties

        public CustomTabDrawHandler DrawHandler
        {
            get => _drawHandler;
            set
            {
                _drawHandler = value;
                if (_drawHandler != null) _drawHandler.Parent = this;
            }
        }

        private int CloseButtonHeight
        {
            get { return FontHeight; }
        }

        private int HotTabIndex
        {
            get { return _hotTabIndex; }
            set
            {
                if (_hotTabIndex != value)
                {
                    _hotTabIndex = value;
                    this.Invalidate();
                }
            }
        }

        #endregion

        #region Overridden Methods

        protected override void OnCreateControl()
        {
            base.OnCreateControl();
            this.OnFontChanged(EventArgs.Empty);
        }

        protected override void OnFontChanged(EventArgs e)
        {
            base.OnFontChanged(e);
            var hFont = this.Font.ToHfont();
            SendMessage(this.Handle, WmSetfont, hFont, new IntPtr(-1));
            SendMessage(this.Handle, WmFontchange, IntPtr.Zero, IntPtr.Zero);
            this.UpdateStyles();
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            var hti = new Tchittestinfo(e.X, e.Y);
            HotTabIndex = SendMessage(this.Handle, TcmHittest, IntPtr.Zero, ref hti);
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            HotTabIndex = -1;
        }

        protected override void OnPaintBackground(PaintEventArgs pevent)
        {
            base.OnPaintBackground(pevent);

            for (var id = 0; id < this.TabCount; id++)
                DrawTabBackground(pevent.Graphics, id);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            for (var id = 0; id < this.TabCount; id++)
                DrawTabContent(e.Graphics, id);
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == TcmSetpadding)
                m.LParam = Makelparam(this.Padding.X + 10, this.Padding.Y + 10);

            if (m.Msg == WmMousedown && !this.DesignMode)
            {
                var pt = this.PointToClient(Cursor.Position);
                var tabRect = Rectangle.Empty;
                var tabId = 0;
                for (var i = 0; i < TabCount; i++)
                {
                    var rect = GetTabRect(i);
                    if (rect.Contains(pt))
                    {
                        tabId = i;
                        tabRect = rect;
                    }
                }
                if (DrawHandler?.HandleTabClick(tabId, tabRect) ?? false)
                    m.Msg = WmNull;
            }

            base.WndProc(ref m);
        }

        #endregion

        #region Private Methods

        private static IntPtr Makelparam(int lo, int hi)
        {
            return new IntPtr((hi << 16) | (lo & 0xFFFF));
        }

        private void DrawTabBackground(Graphics graphics, int id)
        {
            DrawHandler?.DrawCustomTabBackground(id, graphics, GetTabRect(id), id == HotTabIndex, id == SelectedIndex);
            /*if (id == SelectedIndex)
                graphics.FillRectangle(Brushes.DarkGray, GetTabRect(id));
            else if (id == HotTabIndex)
            {
                var rc = GetTabRect(id);
                rc.Width--;
                rc.Height--;
                graphics.DrawRectangle(Pens.DarkGray, rc);
            }*/
        }

        private void DrawTabContent(Graphics graphics, int id)
        {/*
            var selectedOrHot = id == this.SelectedIndex || id == this.HotTabIndex;
            var vertical = this.Alignment >= TabAlignment.Left;

            Image tabImage = null;

            if (this.ImageList != null)
            {
                var page = this.TabPages[id];
                if (page.ImageIndex > -1 && page.ImageIndex < this.ImageList.Images.Count)
                    tabImage = this.ImageList.Images[page.ImageIndex];

                if (page.ImageKey.Length > 0 && this.ImageList.Images.ContainsKey(page.ImageKey))
                    tabImage = this.ImageList.Images[page.ImageKey];
            }

            var tabRect = GetTabRect(id);
            var contentRect = vertical
                ? new Rectangle(0, 0, tabRect.Height, tabRect.Width)
                : new Rectangle(Point.Empty, tabRect.Size);
            var textrect = contentRect;
            textrect.Width -= FontHeight;

            if (tabImage != null)
            {
                textrect.Width -= tabImage.Width;
                textrect.X += tabImage.Width;
            }

            var frColor = id == SelectedIndex ? Color.White : this.ForeColor;
            var bkColor = id == SelectedIndex ? Color.DarkGray : this.BackColor;

            using (var bm = new Bitmap(contentRect.Width, contentRect.Height))
            {
                using (var bmGraphics = Graphics.FromImage(bm))
                {
                    TextRenderer.DrawText(bmGraphics, this.TabPages[id].Text, this.Font, textrect, frColor, bkColor);
                    if (selectedOrHot)
                    {
                        var closeRect = new Rectangle(contentRect.Right - CloseButtonHeight, 0, CloseButtonHeight,
                            CloseButtonHeight);
                        closeRect.Offset(-2, (contentRect.Height - closeRect.Height) / 2);
                        DrawCloseButton(bmGraphics, closeRect);
                    }

                    if (tabImage != null)
                    {
                        var imageRect = new Rectangle(Padding.X, 0, tabImage.Width, tabImage.Height);
                        imageRect.Offset(0, (contentRect.Height - imageRect.Height) / 2);
                        bmGraphics.DrawImage(tabImage, imageRect);
                    }
                }

                if (vertical)
                {
                    if (this.Alignment == TabAlignment.Left)
                        bm.RotateFlip(RotateFlipType.Rotate270FlipNone);
                    else
                        bm.RotateFlip(RotateFlipType.Rotate90FlipNone);
                }

                graphics.DrawImage(bm, tabRect);
            }*/
            DrawHandler?.DrawTabContent(id, graphics, GetTabRect(id), id == this.HotTabIndex, id == this.SelectedIndex);
        }        

        #endregion

        #region Interop

        [DllImport("user32.dll")]
        private static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wParam, IntPtr lParam);

        [DllImport("user32.dll")]
        private static extern int SendMessage(IntPtr hwnd, int msg, IntPtr wParam, ref Tchittestinfo lParam);

        [StructLayout(LayoutKind.Sequential)]
        private struct Tchittestinfo
        {
            public Point pt;
            public Tchittestflags flags;

            public Tchittestinfo(int x, int y)
            {
                pt = new Point(x, y);
                flags = Tchittestflags.TchtNowhere;
            }
        }

        [Flags()]
        private enum Tchittestflags
        {
            TchtNowhere = 1,
            TchtOnitemicon = 2,
            TchtOnitemlabel = 4,
            TchtOnitem = TchtOnitemicon | TchtOnitemlabel
        }

        private const int WmNull = 0x0;
        private const int WmSetfont = 0x30;
        private const int WmFontchange = 0x1D;
        private const int WmMousedown = 0x201;

        private const int TcmFirst = 0x1300;
        private const int TcmHittest = TcmFirst + 13;
        private const int TcmSetpadding = TcmFirst + 43;

        #endregion
    }
}