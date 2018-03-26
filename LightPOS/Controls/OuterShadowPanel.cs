using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using NickAc.LightPOS.Backend.Utils;
using NickAc.ModernUIDoneRight.Utils;

namespace NickAc.LightPOS.Frontend.Controls
{
    public class OuterShadowPanel : Panel
    {
        private bool _oldEngine;

        public bool OldEngine
        {
            get => _oldEngine;
            set
            {
                _oldEngine = value;
                if (OldEngine)
                    this.CreateDropShadow();
            }
        }

        private Bitmap FrozenImage { get; set; }

        public OuterShadowPanel() : this(false)
        {
        }

        public OuterShadowPanel(bool oldEngine)
        {
            OldEngine = oldEngine;
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            ParentChanged += (sender, args) => Parent.Paint += (o, eventArgs) =>
            {
                if (FrozenImage != null)
                {
                    eventArgs.Graphics.DrawImageUnscaled(FrozenImage,
                        Bounds.OffsetAndReturn(-(Bounds.Width / 2), -(Bounds.Height / 2)));
                }
            };
        }

        public void Freeze()
        {
            FrozenImage = new Bitmap(Size.Width * 2, Size.Height * 2);
            using (var g = Graphics.FromImage(FrozenImage))
            {
                DrawControlShadow(DisplayRectangle, Bounds, g);
            }

            Refresh();
        }

        public void UnFreeze()
        {
            FrozenImage = null;
            Refresh();
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            if (FrozenImage != null)
                Freeze();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            var targetGraphics = Parent?.CreateGraphics();
            if (targetGraphics == null) return;
            if (FrozenImage != null)
            {
                return;
            }

            Extensions.RunInAnotherThread(() =>
            {
                DrawControlShadow(DisplayRectangle, Bounds, targetGraphics);
                targetGraphics.Dispose();
            }, false);
        }

        private const int SHADOW_OFFSET = 3;
        private const int HALF_SHADOW_OFFSET = SHADOW_OFFSET / 2;
        private const int HALF_HALF_SHADOW_OFFSET = HALF_SHADOW_OFFSET / 2;

        private void DrawControlShadow(Rectangle rect, Rectangle bounds, Graphics g)
        {
            if (OldEngine)
            {
                return;
            }

            using (var brush = new SolidBrush(Color.FromArgb(150, Color.Black)))
            {
                using (var img = new Bitmap(Width * 2, Height * 2))
                {
                    using (var gp = Graphics.FromImage(img))
                    {
                        var graphicsUnit = GraphicsUnit.Pixel;
                        gp.FillRectangle(brush,
                            Rectangle.Inflate(rect.OffsetAndReturn(SHADOW_OFFSET, SHADOW_OFFSET)
                                    .Center(Rectangle.Round(img.GetBounds(ref graphicsUnit))),
                                HALF_SHADOW_OFFSET, HALF_SHADOW_OFFSET));
                    }

                    var gaussian = new GaussianBlur(img);
                    var result = gaussian.Process(SHADOW_OFFSET);
                    g.DrawImageUnscaled(result, bounds.OffsetAndReturn(-(bounds.Width / 2), -(bounds.Height / 2)));
                    FrozenImage = result;
                    Parent?.Invalidate(Rectangle.Inflate(Bounds, SHADOW_OFFSET * 2, SHADOW_OFFSET * 2));
                }
            }
        }
    }
}