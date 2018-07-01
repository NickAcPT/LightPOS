using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;
using NickAc.LightPOS.Backend.Data;
using NickAc.LightPOS.Backend.Objects;
using NickAc.LightPOS.Backend.Utils;
using NickAc.LightPOS.Frontend.Controls;
using NickAc.LightPOS.Frontend.Forms;

namespace NickAc.LightPOS.Frontend.Utils
{
    public static class FrontendExtensions
    {
        private const int SrcCopy = 0xCC0020;
        private static readonly Size ButtonSize = new Size(100, 100);

        public static string ToCurrency(this decimal price)
        {
            return price.ToString("C", CultureInfo.CurrentCulture);
        }

        public static void LoadProducts(this NickCustomTabControl tab, Action<object, EventArgs> evt)
        {
            Extensions.RunInAnotherThread(() =>
            {
                tab.InvokeIfRequired(() => tab.DrawHandler = new ModernTabDrawHandler());
                var allProds = DataManager.GetProducts();
                var splitProducts = allProds.GroupBy(c => c.Category);
                foreach (var prods in splitProducts)
                {
                    var page = new TabPage(prods.Key.Name) {BackColor = Color.Transparent};
                    var pnl = new FlowLayoutPanel
                    {
                        Dock = DockStyle.Fill,
                        FlowDirection = FlowDirection.LeftToRight,
                        BackColor = Color.Transparent
                    };
                    page.Controls.Add(pnl);

                    foreach (var product in prods)
                    {
                        var btn = new ModernProductButton(product)
                        {
                            Text = GetButtonTextForProduct(product),
                            Size = ButtonSize
                        };
                        btn.Click += (s, e) => evt?.Invoke(s, e);
                        pnl.Controls.Add(btn);
                    }

                    tab.InvokeIfRequired(() => tab.TabPages.Add(page));
                }
            });
        }

        private static string GetButtonTextForProduct(Product product)
        {
            return product.Name.AppendLine($"({product.UnitPrice.ToCurrency()})");
        }


        public static Bitmap DrawToBitmapEx(this Form f)
        {
            var width = f.Width;
            var height = f.Height;
            /*using (*/
            var bitmap = new Bitmap(width, height);
            //)
            {
                using (var gb = Graphics.FromImage(bitmap))
                using (var gc = Graphics.FromHwnd(f.Handle))
                {
                    var hdcDest = IntPtr.Zero;
                    var hdcSrc = IntPtr.Zero;

                    try
                    {
                        hdcDest = gb.GetHdc();
                        hdcSrc = gc.GetHdc();

                        BitBlt(hdcDest, 0, 0, width, height, hdcSrc, 0, 0, SrcCopy);
                    }
                    finally
                    {
                        if (hdcDest != IntPtr.Zero) gb.ReleaseHdc(hdcDest);
                        if (hdcSrc != IntPtr.Zero) gc.ReleaseHdc(hdcSrc);
                    }
                }

                return bitmap;
            }
        }

        // Pinvoke declaration for ShowWindow
        private const int SwMaximize = 3;

        [DllImport("user32.dll")]
        private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);


        [DllImport("gdi32.dll", EntryPoint = "BitBlt")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool BitBlt(IntPtr hdc, int x, int y, int cx, int cy, IntPtr hdcSrc, int x1, int y1,
            uint rop);

        public static void ShowDialog<T>(this Form form, params object[] constructorArgs) where T : TemplateForm
        {
            void CloseDialog(object s, TemplateForm templateForm)
            {
                ((Control) s).Dispose();
                templateForm.Dispose();
            }

            var bmp = GetShadedFormBitmap(form);
            var dialogForm = (TemplateForm) Activator.CreateInstance(typeof(T), constructorArgs);
            dialogForm.TitlebarVisible = false;
            dialogForm.Location = Point.Empty;
            var p = new Panel
            {
                BackgroundImage = bmp,
                Size = bmp.Size,
                Location = Point.Empty,
                Anchor = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right | AnchorStyles.Bottom
            };
            form.Controls.Add(p);
            p.BringToFront();
            p.SizeChanged += (s, e) =>
            {
                p.Hide();
                p.BackgroundImage = GetShadedFormBitmap(form);
                p.Show();
            };

            p.MouseClick += (s, e) =>
            {
                if (e.Button == MouseButtons.Left && e.Clicks == 1) CloseDialog(s, dialogForm);
            };
            dialogForm.FormClosing += (s, e) => CloseDialog(s, dialogForm);
            form.FormClosing += (s, e) => CloseDialog(s, dialogForm);

            var dialogHolder = new Panel
            {
                Size = dialogForm.Size,
                Location = new Point(p.Width / 2 - dialogForm.Width / 2, p.Height / 2 - dialogForm.Height / 2),
                Anchor = AnchorStyles.None
            };


            p.Controls.Add(dialogHolder);
            dialogForm.Sizable = false;
            dialogForm.Opacity = 0f;
            dialogForm.Show();
            ShowWindow(dialogForm.Handle, SwMaximize);
            SetParent(dialogForm.Handle, dialogHolder.Handle);
            dialogForm.WindowState = FormWindowState.Maximized;
            dialogForm.Opacity = 1f;
        }

        [DllImport("user32.dll", SetLastError = true)]
        private static extern IntPtr SetParent(IntPtr hWndChild, IntPtr hWndNewParent);

        private static Bitmap StackBlurTiled(Bitmap bmp)
        {
            var bmps = new List<Bitmap>(2);
            var bmpsFinal = new List<Bitmap>(2);

            var rectFirst = new Rectangle(0, 0, bmp.Width / 2, bmp.Height / 2);
            var rectSecond = new Rectangle(bmp.Width / 2, 0, bmp.Width / 2, bmp.Height);
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
                                (bmps2, _, index) => { bmpsFinal[(int) index] = BlurAndShade(bmps2); });

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

        private static Bitmap GetShadedFormBitmap(Form form)
        {
            return StackBlurTiled(form.DrawToBitmapEx());
        }

        private static Bitmap BlurAndShade(Image bmp)
        {
            var finalBmp = new Bitmap(bmp);
            StackBlur.StackBlur.Process(finalBmp, 4);
            using (var g = Graphics.FromImage(finalBmp))
            {
                using (var sb = new SolidBrush(Color.FromArgb(100, Color.Black)))
                {
                    g.FillRectangle(sb, new Rectangle(Point.Empty, bmp.Size));
                }
            }

            return finalBmp;
        }
    }
}