using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Threading.Tasks;
using System.Windows.Forms;
using NickAc.LightPOS.Backend.Utils;
using NickAc.ModernUIDoneRight.Utils;

namespace NickAc.LightPOS.Frontend.Controls
{
    public class OuterShadowPanel : Panel
    {
        private const int SHADOW_OFFSET = 3;
        private const int HALF_SHADOW_OFFSET = SHADOW_OFFSET / 2;
        private const int HALF_HALF_SHADOW_OFFSET = HALF_SHADOW_OFFSET / 2;


        private bool _oldEngine;

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
                    eventArgs.Graphics.DrawImageUnscaled(FrozenImage,
                        Bounds.OffsetAndReturn(-(Bounds.Width / 2), -(Bounds.Height / 2)));
            };
        }

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

        public Bitmap SetImageOpacity(Image image, float opacity)
        {
            try
            {
                //create a Bitmap the size of the image provided  
                var bmp = new Bitmap(image.Width, image.Height);

                //create a graphics object from the image  
                using (var gfx = Graphics.FromImage(bmp))
                {
                    //create a color matrix object  
                    var matrix = new ColorMatrix {Matrix33 = opacity};

                    //create image attributes  
                    var attributes = new ImageAttributes();

                    //set the color(opacity) of the image  
                    attributes.SetColorMatrix(matrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);

                    //now draw the image  
                    gfx.DrawImage(image, new Rectangle(0, 0, bmp.Width, bmp.Height), 0, 0, image.Width, image.Height,
                        GraphicsUnit.Pixel, attributes);
                }

                return bmp;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
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
            if (FrozenImage != null) return;

            Extensions.RunInAnotherThread(() =>
            {
                DrawControlShadow(DisplayRectangle, Bounds, targetGraphics);
                targetGraphics.Dispose();
            }, false);
        }

        
        private Bitmap StackBlurTiled(Bitmap bmp)
        {
            var bmps = new List<Bitmap>(2);
            var bmpsFinal = new List<Bitmap>(2);

            var rectFirst = new Rectangle(0, 0, bmp.Width / 2, bmp.Height / 2);
            var rectSecond = new Rectangle(bmp.Width / 2, 0, bmp.Width / 2, bmp.Height / 2);
            var rectThird = new Rectangle(0, bmp.Height / 2, bmp.Width / 2, bmp.Height / 2);
            var rectForth = new Rectangle(bmp.Width / 2, bmp.Height / 2, bmp.Width / 2, bmp.Height / 2);


            Bitmap finalBmp;
            using (var firstHalf = bmp.Clone(rectFirst, bmp.PixelFormat))
            {
                using (var secondHalf = bmp.Clone(rectSecond, bmp.PixelFormat))
                {
                    using (var thirdHalf = bmp.Clone(rectThird, bmp.PixelFormat))
                    {
                        using (var forthHalf = bmp.Clone(rectForth, bmp.PixelFormat))
                        {
                            bmps.Add(firstHalf);
                            bmps.Add(secondHalf);
                            bmps.Add(thirdHalf);
                            bmps.Add(forthHalf);
                            bmpsFinal.Add(null);
                            bmpsFinal.Add(null);
                            bmpsFinal.Add(null);
                            bmpsFinal.Add(null);

                            Parallel.ForEach(bmps,
                                (bmps2, _, index) =>
                                {
                                    StackBlur.StackBlur.Process(bmps2, SHADOW_OFFSET * 2);
                                    bmpsFinal[(int) index] = bmps2;
                                });

                            finalBmp = new Bitmap(bmp);
                            using (var g = Graphics.FromImage(finalBmp))
                            {
                                g.DrawImage(bmpsFinal[0], rectFirst);
                                g.DrawImage(bmpsFinal[1], rectSecond);
                                g.DrawImage(bmpsFinal[2], rectThird);
                                g.DrawImage(bmpsFinal[3], rectForth);
                            }
                        }
                    }
                }
            }

            bmpsFinal[0].Dispose();
            bmpsFinal[1].Dispose();
            bmpsFinal[2].Dispose();
            bmpsFinal[3].Dispose();
            bmpsFinal.Clear();
            return finalBmp;
        }

        private void DrawControlShadow(Rectangle rect, Rectangle bounds, Graphics g)
        {
            if (OldEngine) return;

            using (var brush = new SolidBrush(Color.FromArgb(150, Color.Black)))
            {
                using (var img = new Bitmap(Width * 2, Height * 2))
                {
                    var finalImg = img;
                    using (var gp = Graphics.FromImage(img))
                    {
                        var graphicsUnit = GraphicsUnit.Pixel;
                        gp.FillRectangle(brush,
                            rect.OffsetAndReturn(SHADOW_OFFSET, SHADOW_OFFSET)
                                .Center(Rectangle.Round(img.GetBounds(ref graphicsUnit))));
                    }

                    finalImg = StackBlurTiled(finalImg);
                    var result = SetImageOpacity(finalImg, 0.65f);

                    g.DrawImageUnscaled(result, bounds.OffsetAndReturn(-(bounds.Width / 2), -(bounds.Height / 2)));
                    FrozenImage = result;
                    Parent?.Invalidate(Rectangle.Inflate(Bounds, SHADOW_OFFSET * 2, SHADOW_OFFSET * 2));
                }
            }
        }
    }
}