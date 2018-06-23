// Copyright (c) 2018 Victorique Ko
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in all
// copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
// SOFTWARE.

using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace StackBlur
{
    internal class BlurStack
    {
        internal byte R { get; set; }

        internal byte G { get; set; }

        internal byte B { get; set; }

        internal byte A { get; set; }

        internal BlurStack Next { get; set; }
    }

    /// <summary> 
    /// Provides method for process stack blur.
    /// </summary>
    public static class StackBlur
    {
        private static readonly int[] MulTable =
        {
            512, 512, 456, 512, 328, 456, 335, 512, 405, 328, 271, 456, 388, 335, 292, 512,
            454, 405, 364, 328, 298, 271, 496, 456, 420, 388, 360, 335, 312, 292, 273, 512,
            482, 454, 428, 405, 383, 364, 345, 328, 312, 298, 284, 271, 259, 496, 475, 456,
            437, 420, 404, 388, 374, 360, 347, 335, 323, 312, 302, 292, 282, 273, 265, 512,
            497, 482, 468, 454, 441, 428, 417, 405, 394, 383, 373, 364, 354, 345, 337, 328,
            320, 312, 305, 298, 291, 284, 278, 271, 265, 259, 507, 496, 485, 475, 465, 456,
            446, 437, 428, 420, 412, 404, 396, 388, 381, 374, 367, 360, 354, 347, 341, 335,
            329, 323, 318, 312, 307, 302, 297, 292, 287, 282, 278, 273, 269, 265, 261, 512,
            505, 497, 489, 482, 475, 468, 461, 454, 447, 441, 435, 428, 422, 417, 411, 405,
            399, 394, 389, 383, 378, 373, 368, 364, 359, 354, 350, 345, 341, 337, 332, 328,
            324, 320, 316, 312, 309, 305, 301, 298, 294, 291, 287, 284, 281, 278, 274, 271,
            268, 265, 262, 259, 257, 507, 501, 496, 491, 485, 480, 475, 470, 465, 460, 456,
            451, 446, 442, 437, 433, 428, 424, 420, 416, 412, 408, 404, 400, 396, 392, 388,
            385, 381, 377, 374, 370, 367, 363, 360, 357, 354, 350, 347, 344, 341, 338, 335,
            332, 329, 326, 323, 320, 318, 315, 312, 310, 307, 304, 302, 299, 297, 294, 292,
            289, 287, 285, 282, 280, 278, 275, 273, 271, 269, 267, 265, 263, 261, 259
        };

        private static readonly int[] ShgTable =
        {
            9, 11, 12, 13, 13, 14, 14, 15, 15, 15, 15, 16, 16, 16, 16, 17,
            17, 17, 17, 17, 17, 17, 18, 18, 18, 18, 18, 18, 18, 18, 18, 19,
            19, 19, 19, 19, 19, 19, 19, 19, 19, 19, 19, 19, 19, 20, 20, 20,
            20, 20, 20, 20, 20, 20, 20, 20, 20, 20, 20, 20, 20, 20, 20, 21,
            21, 21, 21, 21, 21, 21, 21, 21, 21, 21, 21, 21, 21, 21, 21, 21,
            21, 21, 21, 21, 21, 21, 21, 21, 21, 21, 22, 22, 22, 22, 22, 22,
            22, 22, 22, 22, 22, 22, 22, 22, 22, 22, 22, 22, 22, 22, 22, 22,
            22, 22, 22, 22, 22, 22, 22, 22, 22, 22, 22, 22, 22, 22, 22, 23,
            23, 23, 23, 23, 23, 23, 23, 23, 23, 23, 23, 23, 23, 23, 23, 23,
            23, 23, 23, 23, 23, 23, 23, 23, 23, 23, 23, 23, 23, 23, 23, 23,
            23, 23, 23, 23, 23, 23, 23, 23, 23, 23, 23, 23, 23, 23, 23, 23,
            23, 23, 23, 23, 23, 24, 24, 24, 24, 24, 24, 24, 24, 24, 24, 24,
            24, 24, 24, 24, 24, 24, 24, 24, 24, 24, 24, 24, 24, 24, 24, 24,
            24, 24, 24, 24, 24, 24, 24, 24, 24, 24, 24, 24, 24, 24, 24, 24,
            24, 24, 24, 24, 24, 24, 24, 24, 24, 24, 24, 24, 24, 24, 24, 24,
            24, 24, 24, 24, 24, 24, 24, 24, 24, 24, 24, 24, 24, 24, 24
        };

        /// <summary>
        /// Process stack blur.
        /// </summary>
        /// <param name="bitmap">The bitmap to process.</param>
        /// <param name="radius">Gaussian blur radius.</param>
        public static void Process(Bitmap bitmap, int radius)
        {
            var width = bitmap.Width;
            var height = bitmap.Height;

            var div = radius + radius + 1;
            var widthMinus1 = width - 1;
            var heightMinus1 = height - 1;
            var radiusPlus1 = radius + 1;
            var sumFactor = radiusPlus1 * (radiusPlus1 + 1) / 2;

            var stack = new BlurStack();
            var stackStart = stack;
            var stackEnd = stack;

            for (var i = 1; i < div; i++)
            {
                stack = stack.Next = new BlurStack();
                if (i == radiusPlus1)
                {
                    stackEnd = stack;
                }
            }

            stack.Next = stackStart;
            
            Debug.Assert(stackEnd != null);

            var yw = 0;
            var yi = 0;

            var mulSum = MulTable[radius];
            var shgSum = ShgTable[radius];

            var rect = new Rectangle(Point.Empty, bitmap.Size);
            var data = bitmap.LockBits(rect, ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
            var pixels = new byte[Math.Abs(data.Stride) * data.Height];
            Marshal.Copy(data.Scan0, pixels, 0, pixels.Length);

            try
            {
                for (var y = 0; y < height; y++)
                {
                    var rInSum = 0;
                    var gInSum = 0;
                    var bInSum = 0;
                    var aInSum = 0;

                    var rSum = 0;
                    var gSum = 0;
                    var bSum = 0;
                    var aSum = 0;

                    var pr = pixels[yi];
                    var pg = pixels[yi + 1];
                    var pb = pixels[yi + 2];
                    var pa = pixels[yi + 3];

                    var rOutSum = radiusPlus1 * pr;
                    var gOutSum = radiusPlus1 * pg;
                    var bOutSum = radiusPlus1 * pb;
                    var aOutSum = radiusPlus1 * pa;

                    rSum += sumFactor * pr;
                    gSum += sumFactor * pg;
                    bSum += sumFactor * pb;
                    aSum += sumFactor * pa;

                    stack = stackStart;

                    for (var i = 0; i < radiusPlus1; i++)
                    {
                        stack.R = pr;
                        stack.G = pg;
                        stack.B = pb;
                        stack.A = pa;
                        stack = stack.Next;
                    }

                    for (var i = 1; i < radiusPlus1; i++)
                    {
                        var p = yi + ((widthMinus1 < i ? widthMinus1 : i) << 2);
                        var rbs = radiusPlus1 - i;
                        rSum += (stack.R = pr = pixels[p]) * rbs;
                        gSum += (stack.G = pg = pixels[p + 1]) * rbs;
                        bSum += (stack.B = pb = pixels[p + 2]) * rbs;
                        aSum += (stack.A = pa = pixels[p + 3]) * rbs;

                        rInSum += pr;
                        gInSum += pg;
                        bInSum += pb;
                        aInSum += pa;

                        stack = stack.Next;
                    }
                    
                    var stackIn = stackStart;
                    var stackOut = stackEnd;

                    for (var x = 0; x < width; x++)
                    {
                        pa = (byte) ((aSum * mulSum) >> shgSum);
                        pixels[yi + 3] = pa;
                        if (pa != 0)
                        {
                            pa = (byte) (255 / pa);
                            pixels[yi] = (byte) (((rSum * mulSum) >> shgSum) * pa);
                            pixels[yi + 1] = (byte) (((gSum * mulSum) >> shgSum) * pa);
                            pixels[yi + 2] = (byte) (((bSum * mulSum) >> shgSum) * pa);
                        }
                        else
                        {
                            pixels[yi] = pixels[yi + 1] = pixels[yi + 2] = 0;
                        }

                        rSum -= rOutSum;
                        gSum -= gOutSum;
                        bSum -= bOutSum;
                        aSum -= aOutSum;

                        rOutSum -= stackIn.R;
                        gOutSum -= stackIn.G;
                        bOutSum -= stackIn.B;
                        aOutSum -= stackIn.A;

                        var p = x + radius + 1;
                        p = (yw + (p < widthMinus1 ? p : widthMinus1)) << 2;

                        rInSum += stackIn.R = pixels[p];
                        gInSum += stackIn.G = pixels[p + 1];
                        bInSum += stackIn.B = pixels[p + 2];
                        aInSum += stackIn.A = pixels[p + 3];

                        rSum += rInSum;
                        gSum += gInSum;
                        bSum += bInSum;
                        aSum += aInSum;

                        stackIn = stackIn.Next;

                        rOutSum += pr = stackOut.R;
                        gOutSum += pg = stackOut.G;
                        bOutSum += pb = stackOut.B;
                        aOutSum += pa = stackOut.A;

                        rInSum -= pr;
                        gInSum -= pg;
                        bInSum -= pb;
                        aInSum -= pa;

                        stackOut = stackOut.Next;

                        yi += 4;
                    }

                    yw += width;
                }
                
                for (var x = 0; x < width; x++)
                {
                    var rInSum = 0;
                    var gInSum = 0;
                    var bInSum = 0;
                    var aInSum = 0;

                    var rSum = 0;
                    var gSum = 0;
                    var bSum = 0;
                    var aSum = 0;

                    yi = x << 2;
                    var pr = pixels[yi];
                    var pg = pixels[yi + 1];
                    var pb = pixels[yi + 2];
                    var pa = pixels[yi + 3];

                    var rOutSum = radiusPlus1 * pr;
                    var gOutSum = radiusPlus1 * pg;
                    var bOutSum = radiusPlus1 * pb;
                    var aOutSum = radiusPlus1 * pa;

                    rSum += sumFactor * pr;
                    gSum += sumFactor * pg;
                    bSum += sumFactor * pb;
                    aSum += sumFactor * pa;

                    stack = stackStart;

                    for (var i = 0; i < radiusPlus1; i++)
                    {
                        stack.R = pr;
                        stack.G = pg;
                        stack.B = pb;
                        stack.A = pa;
                        stack = stack.Next;
                    }

                    var yp = width;

                    for (var i = 1; i <= radius; i++)
                    {
                        yi = (yp + x) << 2;

                        var rbs = radiusPlus1 - i;
                        rSum += (stack.R = pr = pixels[yi]) * rbs;
                        gSum += (stack.G = pg = pixels[yi + 1]) * rbs;
                        bSum += (stack.B = pb = pixels[yi + 2]) * rbs;
                        aSum += (stack.A = pa = pixels[yi + 3]) * rbs;

                        rInSum += pr;
                        gInSum += pg;
                        bInSum += pb;
                        aInSum += pa;

                        stack = stack.Next;

                        if (i < heightMinus1) yp += width;
                    }

                    yi = x;
                    var stackIn = stackStart;
                    var stackOut = stackEnd;

                    for (var y = 0; y < height; y++)
                    {
                        var p = yi << 2;
                        pa = (byte) ((aSum * mulSum) >> shgSum);
                        pixels[p + 3] = pa;
                        if (pa > 0)
                        {
                            pa = (byte) (255 / pa);
                            pixels[p] = (byte) (((rSum * mulSum) >> shgSum) * pa);
                            pixels[p + 1] = (byte) (((gSum * mulSum) >> shgSum) * pa);
                            pixels[p + 2] = (byte) (((bSum * mulSum) >> shgSum) * pa);
                        }
                        else
                        {
                            pixels[p] = pixels[p + 1] = pixels[p + 2] = 0;
                        }

                        rSum -= rOutSum;
                        gSum -= gOutSum;
                        bSum -= bOutSum;
                        aSum -= aOutSum;

                        rOutSum -= stackIn.R;
                        gOutSum -= stackIn.G;
                        bOutSum -= stackIn.B;
                        aOutSum -= stackIn.A;

                        p = (x + ((p = y + radiusPlus1) < heightMinus1 ? p : heightMinus1) * width) << 2;

                        rSum += rInSum += stackIn.R = pixels[p];
                        gSum += gInSum += stackIn.G = pixels[p + 1];
                        bSum += bInSum += stackIn.B = pixels[p + 2];
                        aSum += aInSum += stackIn.A = pixels[p + 3];

                        stackIn = stackIn.Next;

                        rOutSum += pr = stackOut.R;
                        gOutSum += pg = stackOut.G;
                        bOutSum += pb = stackOut.B;
                        aOutSum += pa = stackOut.A;

                        rInSum -= pr;
                        gInSum -= pg;
                        bInSum -= pb;
                        aInSum -= pa;

                        stackOut = stackOut.Next;

                        yi += width;
                    }
                }

                Marshal.Copy(pixels, 0, data.Scan0, pixels.Length);
            }
            finally
            {
                bitmap.UnlockBits(data);
            }
        }
    }
}