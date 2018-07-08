//
// Copyright (c) NickAc. All rights reserved.
// Licensed under the MIT License. See LICENSE file in the project root for full license information.
//

using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;

namespace NickAc.LightPOS.Backend.Utils
{
    public static class Extensions
    {
        public static string GetEnumDescription(Enum value)
        {
            var fi = value.GetType().GetField(value.ToString());

            var attributes =
                (DescriptionAttribute[])fi.GetCustomAttributes(
                    typeof(DescriptionAttribute),
                    false);

            return attributes.Length > 0 ? attributes[0].Description : value.ToString();
        }

        public static string ToDescription<TEnum>(this TEnum enumValue) where TEnum : struct
        {
            return GetEnumDescription((Enum)(object)enumValue);
        }


        public static string AppendLine(this string original, string otherLine)
        {
            return original + Environment.NewLine + otherLine;
        }

        public static void HideAndStart<T>(this Form owner, params object[] constructor) where T : Form
        {
            owner.Hide();
            ((Form) Activator.CreateInstance(typeof(T), constructor)).ShowDialog(owner);
            owner.Show();
        }
        
        public static void RunInAnotherApplication(this Form form)
        {
            RunInAnotherThread(() => Application.Run(form));
        }
        public static void RunInAnotherApplicationAndJoin(this Form form)
        {
            RunInAnotherThread(() => Application.Run(form), true);
        }


        public static void RunInAnotherApplication<T>(bool join = true, params object[] constructorArgs) where T : Form
        {
            RunInAnotherThread(() => Application.Run((Form) Activator.CreateInstance(typeof(T), constructorArgs)),
                join);
        }
        
        public static void HideAndRunInAnotherApplication<T>(this Form form, bool join = true,
            params object[] constructorArgs) where T : Form
        {
            form.InvokeIfRequired(form.Hide);
            RunInAnotherThread(() =>
            {
                Application.Run((Form) Activator.CreateInstance(typeof(T), constructorArgs));
                form.InvokeIfRequired(form.Show);
            }, join);
        }

        public static void RunInAnotherThread(MethodInvoker inv, bool join = false)
        {
            var th = new Thread(() => inv?.Invoke());
            th.Start();
            if (join)
                th.Join();
        }

        /// <summary>  
        /// method for changing the opacity of an image  
        /// </summary>  
        /// <param name="image">image to set opacity on</param>  
        /// <param name="opacity">percentage of opacity</param>  
        /// <returns></returns>  
        public static Bitmap SetImageOpacity(this Bitmap image, float opacity)  
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
                return image;
            }  
        } 


        //Code taken and adapted from StackOverflow (https://stackoverflow.com/questions/2367718/automating-the-invokerequired-code-pattern)
        //All credits go to Olivier Jacot-Descombes (https://stackoverflow.com/users/880990/olivier-jacot-descombes)
        public static void InvokeIfRequired(this Control control, MethodInvoker action)
        {
            if (!control.IsDisposed && !control.Disposing && control.InvokeRequired)
                control.Invoke(action);
            else
                action();
        }
    }
}