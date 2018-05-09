using System;
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
        public Bitmap SetImageOpacity(Image image, float opacity)  
        {  
            try  
            {  
                //create a Bitmap the size of the image provided  
                var bmp = new Bitmap(image.Width, image.Height);  

                //create a graphics object from the image  
                using (var gfx = Graphics.FromImage(bmp)) {  

                    //create a color matrix object  
                    var matrix = new ColorMatrix {Matrix33 = opacity};

                    //create image attributes  
                    var attributes = new ImageAttributes();      

                    //set the color(opacity) of the image  
                    attributes.SetColorMatrix(matrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);    

                    //now draw the image  
                    gfx.DrawImage(image, new Rectangle(0, 0, bmp.Width, bmp.Height), 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, attributes);
                }
                return bmp;
            }  
            catch (Exception ex)  
            { 
                MessageBox.Show(ex.Message);  
                return null;  
            }
        } 


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
                    var result = SetImageOpacity(gaussian.Process(SHADOW_OFFSET), 0.65f);
                    
                    g.DrawImageUnscaled(result, bounds.OffsetAndReturn(-(bounds.Width / 2), -(bounds.Height / 2)));
                    FrozenImage = result;
                    Parent?.Invalidate(Rectangle.Inflate(Bounds, SHADOW_OFFSET * 2, SHADOW_OFFSET * 2));
                }
            }
        }
    }
}