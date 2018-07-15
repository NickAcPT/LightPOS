// 
// Copyright (c) NickAc. All rights reserved.
// Licensed under the MIT License. See LICENSE file in the project root for full license information.

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using NickAc.ModernUIDoneRight.Forms;
using NickAc.ModernUIDoneRight.Objects;

namespace NickAc.LightPOS.Frontend.Controls
{
    public class PriceKeypadControl : Control
    {
        public PriceKeypadControl()
        {
            Font = new Font(SystemFonts.MessageBoxFont.FontFamily, 18);
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.DoubleBuffer | ControlStyles.UserMouse, true);
        }

        private readonly ColorScheme _colorScheme = DefaultColorSchemes.Blue;

        public ColorScheme ColorScheme => FindForm() is ModernForm frm ? frm.ColorScheme : _colorScheme;

        public event EventHandler<string> ButtonClicked;


        #region Rectangles

        public string GetRectangleText(Rectangle rect)
        {
            if (rect == OneButton)
                return "1";

            if (rect == TwoButton)
                return "2";

            if (rect == ThreeButton)
                return "3";

            if (rect == FourButton)
                return "4";

            if (rect == FiveButton)
                return "5";

            if (rect == SixButton)
                return "6";

            if (rect == SevenButton)
                return "7";

            if (rect == EightButton)
                return "8";

            if (rect == NineButton)
                return "9";

            if (rect == ZeroButton)
                return "0";

            if (rect == DotButtonButton)
                return ".";

            return "";
        }

        public Size ButtonSize { get; set; } = new Size(75, 75);

        public int ButtonWidth => ButtonSize.Width;

        public int ButtonHeight => ButtonSize.Height;

        [Browsable(false)]
        public Rectangle OneButton => new Rectangle(0, 0, ButtonWidth, ButtonHeight);

        [Browsable(false)]
        public Rectangle TwoButton => new Rectangle(ButtonWidth * 1, 0, ButtonWidth, ButtonHeight);

        [Browsable(false)]
        public Rectangle ThreeButton => new Rectangle(ButtonWidth * 2, 0, ButtonWidth, ButtonHeight);

        [Browsable(false)]
        public Rectangle FourButton => new Rectangle(0, ButtonHeight * 1, ButtonWidth, ButtonHeight);

        [Browsable(false)]
        public Rectangle FiveButton => new Rectangle(ButtonWidth * 1, ButtonHeight * 1, ButtonWidth, ButtonHeight);

        [Browsable(false)]
        public Rectangle SixButton => new Rectangle(ButtonWidth * 2, ButtonHeight * 1, ButtonWidth, ButtonHeight);

        [Browsable(false)]
        public Rectangle SevenButton => new Rectangle(0, ButtonHeight * 2, ButtonWidth, ButtonHeight);

        [Browsable(false)]
        public Rectangle EightButton => new Rectangle(ButtonWidth * 1, ButtonHeight * 2, ButtonWidth, ButtonHeight);

        [Browsable(false)]
        public Rectangle NineButton => new Rectangle(ButtonWidth * 2, ButtonHeight * 2, ButtonWidth, ButtonHeight);

        [Browsable(false)]
        public Rectangle ZeroButton => new Rectangle(0, ButtonHeight * 3, ButtonWidth * 2, ButtonHeight);

        [Browsable(false)]
        public Rectangle DotButtonButton => new Rectangle(ButtonWidth * 2, ButtonHeight * 3, ButtonWidth, ButtonHeight);

        #endregion

        private bool _mouseDown = false;

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            _mouseDown = true;
            Invalidate();
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            _mouseDown = false;
            Invalidate();
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            _mouseDown = false;
            Invalidate();
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            var curPos = PointToClient(Cursor.Position);

            var rects = ButtonRectangles;

            var colorScheme = ColorScheme;
            using (var sb = new SolidBrush(colorScheme.PrimaryColor))
            {
                using (var sb2 = new SolidBrush(colorScheme.MouseHoverColor))
                {
                    using (var sb3 = new SolidBrush(colorScheme.MouseDownColor))
                    {
                        foreach (var rect in rects)
                        {
                            var buttonRect = Rectangle.Inflate(rect, -2, -2);
                            e.Graphics.FillRectangle(buttonRect.Contains(curPos) ? _mouseDown ? sb3 : sb2 : sb, buttonRect);
                            using (var sF = new StringFormat
                            {
                                Alignment = StringAlignment.Center,
                                LineAlignment = StringAlignment.Center
                            })
                            {
                                using (var fc = new SolidBrush(colorScheme.ForegroundColor))
                                {
                                    e.Graphics.DrawString(GetRectangleText(rect), Font, fc, buttonRect, sF);
                                }
                            }
                        }
                    }
                }
            }
        }

        public Rectangle[] ButtonRectangles => new[]
        {
            OneButton, TwoButton, ThreeButton, FourButton, FiveButton, SixButton, SevenButton, EightButton,
            NineButton, ZeroButton, DotButtonButton
        };

        protected virtual void OnButtonClicked(string e)
        {
            ButtonClicked?.Invoke(this, e);
        }
    }
}