using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;
using NickAc.ModernUIDoneRight.Controls;
using NickAc.ModernUIDoneRight.Forms;
using NickAc.ModernUIDoneRight.Objects;
using NickAc.ModernUIDoneRight.Utils;

namespace NickAc.LightPOS.Frontend.Controls
{
    public class NickCustomTabControl : TabControl
    {
        public abstract class CustomTabDrawHandler
        {
            public NickCustomTabControl Parent { get; set; }

            public abstract void DrawCustomTabBackground(int id, Graphics g, Rectangle rect, bool isHot,
                bool isSelected);

            public abstract void DrawTabContent(int id, Graphics g, Rectangle rect, bool isHot, bool isSelected);
            public abstract bool HandleTabClick(int id, Rectangle rect);
        }

        private int _hotTabIndex = -1;
        private CustomTabDrawHandler _drawHandler;

        public NickCustomTabControl()
        {
            SetStyle(
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

        private int HotTabIndex
        {
            get => _hotTabIndex;
            set
            {
                if (_hotTabIndex != value)
                {
                    _hotTabIndex = value;
                    Invalidate();
                }
            }
        }

        #endregion

        #region Overridden Methods

        protected override void OnCreateControl()
        {
            base.OnCreateControl();
            OnFontChanged(EventArgs.Empty);
        }

        protected override void OnFontChanged(EventArgs e)
        {
            base.OnFontChanged(e);
            var hFont = Font.ToHfont();
            SendMessage(Handle, WmSetfont, hFont, new IntPtr(-1));
            SendMessage(Handle, WmFontchange, IntPtr.Zero, IntPtr.Zero);
            UpdateStyles();
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            var hti = new Tchittestinfo(e.X, e.Y);
            HotTabIndex = SendMessage(Handle, TcmHittest, IntPtr.Zero, ref hti);
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            HotTabIndex = -1;
        }

        #region Shadow
        
        private const int ShadowOffset = 3;

        private void DrawControlShadow(Graphics g, Rectangle rect)
        {/*
            using (var brush = new SolidBrush(Color.FromArgb(150, Color.Black)))
            {
                var img = new Bitmap(Width, Height);
                {
                    using (var gp = Graphics.FromImage(img)) {
                            gp.FillRectangle(brush, rect);
                    }

                    StackBlur.StackBlur.Process(img, ShadowOffset * 2);
                    var result = _topBarShadow = img;
                    g?.DrawImageUnscaled(result, Point.Empty);
                }
            }*/
            ShadowUtils.DrawShadow(g, Color.Black, rect, 7, DockStyle.Top);
        }

        #endregion

        public Color BackgroundColor { get; set; } = SystemColors.Control;

        protected override void OnPaintBackground(PaintEventArgs pevent)
        {
            base.OnPaintBackground(pevent);
            using (var sb = new SolidBrush(BackgroundColor))
            {
                pevent.Graphics.FillRectangle(sb, new Rectangle(Point.Empty, Size));
            }
            var tabHeight = TabCount > 0 ? GetTabRect(0).Height : Height;
            var tabRect = TabCount > 0 ? GetTabRect(0) : new Rectangle(Point.Empty, Size);
            if (TabCount > 0)
            {
                DrawControlShadow(pevent.Graphics,
                    Rectangle.FromLTRB(0, tabRect.Top, Width, tabRect.Bottom - 2));
            
                using (var sb = new SolidBrush(ColorScheme.PrimaryColor))
                {
                    pevent.Graphics.FillRectangle(sb, new Rectangle(Point.Empty, new Size(Width, tabHeight)));
                }
            }

            for (var id = 0; id < TabCount; id++)
                DrawTabBackground(pevent.Graphics, id);
            
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            for (var id = 0; id < TabCount; id++)
                DrawTabContent(e.Graphics, id);
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == TcmSetpadding)
                m.LParam = Makelparam(Padding.X + 10, Padding.Y + 16);

            if (m.Msg == WmMousedown && !DesignMode)
            {
                var pt = PointToClient(Cursor.Position);
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

        private ColorScheme _scheme;
        private Rectangle _hotRectangle = Rectangle.Empty;

        public Rectangle HotRectangle
        {
            get => _hotRectangle.IsEmpty ? HotRectangleFromTabRect(GetTabRect(0)) : _hotRectangle;
            set => _hotRectangle = value;
        }

        public int HotRectangleHeight { get; set; } = 7;


        private Rectangle HotRectangleFromTabRect(Rectangle rect)
        {
            return Rectangle.FromLTRB(rect.Left, rect.Bottom - HotRectangleHeight, rect.Right, rect.Bottom - 2);
        }

        public ColorScheme ColorScheme =>
            _scheme ?? (_scheme = FindForm() is ModernForm mdrF ? mdrF.ColorScheme : DefaultColorSchemes.Blue);

        protected new Rectangle GetTabRect(int id)
        {
            var tabRect = base.GetTabRect(id);
            tabRect.Height -= 2;
            return tabRect;
        }

        private void DrawTabBackground(Graphics graphics, int id)
        {
            DrawHandler?.DrawCustomTabBackground(id, graphics, GetTabRect(id), id == HotTabIndex, id == SelectedIndex);
            using (var cSchemeFore = new SolidBrush(ColorScheme.ForegroundColor))
            {
                graphics.FillRectangle(cSchemeFore, HotRectangle);
            }

            /*
            else if (id == HotTabIndex)
            {
                var rc = GetTabRect(id);
                rc.Width--;
                rc.Height--;
                graphics.DrawRectangle(Pens.DarkGray, rc);
            }*/
        }

        private void DrawTabContent(Graphics graphics, int id)
        {
            /*
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
            DrawHandler?.DrawTabContent(id, graphics, GetTabRect(id), id == HotTabIndex, id == SelectedIndex);
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
            private readonly Point pt;
            private readonly Tchittestflags flags;

            public Tchittestinfo(int x, int y)
            {
                pt = new Point(x, y);
                flags = Tchittestflags.TchtNowhere;
            }
        }

        [Flags]
        private enum Tchittestflags
        {
            TchtNowhere = 1
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