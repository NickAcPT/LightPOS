// 
// Copyright (c) NickAc. All rights reserved.
// Licensed under the MIT License. See LICENSE file in the project root for full license information.

using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using NickAc.LightPOS.Backend.Currency;
using NickAc.LightPOS.Backend.Translation;
using NickAc.LightPOS.Backend.Utils;
using NickAc.LightPOS.Frontend.Utils;
using NickAc.ModernUIDoneRight.Utils;

namespace NickAc.LightPOS.Frontend.Controls
{
    public class CurrencyButton : Control
    {
        private const int ShadowOffset = 3;
        private const int HalfShadowOffset = ShadowOffset / 2;
        private readonly TranslationHelper _translationHelper = new TranslationHelper();
        private int _cornerRadius = 4;

        private Image _frozenShadowImage;

        private bool _isInsideRect;

        private bool _isMouseDown;

        public CurrencyButton()
        {
            SetStyle(
                ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer |
                ControlStyles.SupportsTransparentBackColor | ControlStyles.ResizeRedraw, true);
        }

        public AbstractCurrency Currency { get; set; }

        public Color ButtonColor { get; set; } = SystemColors.ControlLight;

        public int CornerRadius
        {
            get => _cornerRadius;
            set
            {
                _cornerRadius = value;
                InvalidateCachedShadow();
            }
        }

        public int BorderPadding { get; set; } = 16;

        public Rectangle ButtonRectangle =>
            Rectangle.FromLTRB(BorderPadding, BorderPadding, Right - BorderPadding, Bottom - BorderPadding);

        public Rectangle ImageRectangle =>
            Rectangle.FromLTRB(ButtonRectangle.Left, ButtonRectangle.Top + BorderPadding, ButtonRectangle.Right,
                (int) (ButtonRectangle.Bottom * 0.65f));


        public Rectangle TextRectangle =>
            Rectangle.FromLTRB(ButtonRectangle.Left, BorderPadding + (int) (ButtonRectangle.Bottom * 0.65f),
                ButtonRectangle.Right, ButtonRectangle.Bottom - BorderPadding / 2);

        public void ResetButtonColor()
        {
            ButtonColor = Color.White;
        }

        protected override void OnPaintBackground(PaintEventArgs pevent)
        {
            base.OnPaintBackground(pevent);
            DrawButtonBackground(pevent);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            DrawButtonForeground(e);
        }

        private void DrawButtonForeground(PaintEventArgs e)
        {
            var color = ControlPaint.Dark(ButtonColor);
            if (Currency?.Name != null)
                using (var sf = new StringFormat
                {
                    LineAlignment = StringAlignment.Center,
                    Alignment = StringAlignment.Center
                })
                {
                    using (var sb = new SolidBrush(color))
                    {
                        e.Graphics.DrawString(_translationHelper.GetTranslation(Currency.Name), Font, sb, TextRectangle,
                            sf);
                    }
                }

            if (Currency?.Image != null) ZoomDrawImage(e.Graphics, Currency.Image.ChangeToColor(color), ImageRectangle);
        }

        protected override void OnClick(EventArgs e)
        {
            if (!(e is MouseEventArgs mArgs)) return;
            if (ButtonRectangle.Contains(mArgs.Location))
                base.OnClick(e);
        }

        public static void ZoomDrawImage(Graphics g, Image img, Rectangle bounds)
        {
            var oldMode = g.InterpolationMode;
            g.InterpolationMode = InterpolationMode.High;
            g.DrawImage(img,
                ControlPaintWrapper.CalculateBackgroundImageRectangle(bounds, img, ImageLayout.Zoom).Center(bounds));
            g.InterpolationMode = oldMode;
        }

        public void DrawShadow(Graphics g, Rectangle rect)
        {
            if (_frozenShadowImage == null)
                using (var brush = new SolidBrush(Color.FromArgb(175, Color.Black)))
                {
                    var img = new Bitmap(Width, Height);
                    {
                        using (var gp = Graphics.FromImage(img))
                        {
                            gp.FillRoundedRectangle(brush,
                                Rectangle.Inflate(rect,
                                    HalfShadowOffset, HalfShadowOffset).OffsetAndReturn(HalfShadowOffset, HalfShadowOffset), CornerRadius);
                        }

                        StackBlur.StackBlur.Process(img, 2);
                        img = img.SetImageOpacity(0.45f);
                        _frozenShadowImage = img;
                        g.DrawImageUnscaled(img, Point.Empty);
                    }
                }
            else
                g.DrawImageUnscaled(_frozenShadowImage, Point.Empty);
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            InvalidateCachedShadow();
        }

        private void InvalidateCachedShadow()
        {
            _frozenShadowImage = null;
            Invalidate();
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            _isInsideRect = ButtonRectangle.Contains(e.Location);
            Invalidate();
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            _isMouseDown = false;
            Invalidate();
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            _isMouseDown = true;
            Invalidate();
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            _isInsideRect = false;
            Invalidate();
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            _isInsideRect = false;
            Invalidate();
        }

        private void DrawButtonBackground(PaintEventArgs e)
        {
            DrawShadow(e.Graphics, ButtonRectangle);
            using (var sb =
                new SolidBrush(_isInsideRect
                    ? _isMouseDown ? Darken2(ButtonColor) : ButtonColor
                    : Lighten(ButtonColor)))
            {
                e.Graphics.FillRoundedRectangle(sb, ButtonRectangle, CornerRadius);
            }
        }

        private static Color Darken2(Color buttonColor)
        {
            return ControlPaint.Dark(buttonColor, 0.001f);
        }

        private static Color Lighten(Color buttonColor)
        {
            return ControlPaint.LightLight(buttonColor);
        }
    }
}