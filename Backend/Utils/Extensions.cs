//
// Copyright (c) NickAc. All rights reserved.
// Licensed under the MIT License. See LICENSE file in the project root for full license information.
//

using System;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using NickAc.LightPOS.Backend.Data;

namespace NickAc.LightPOS.Backend.Utils
{
    public static class Extensions
    {
        public static void LoadProducts(this TabControl tab)
        {
            Extensions.RunInAnotherThread(() =>
            {
                var allProds = DataManager.GetProducts();
                var splitProducts = allProds.GroupBy(c => c.Category);
                foreach (var prods in splitProducts)
                {
                    var page = new TabPage(prods.Key.Name) {Tag = prods.Key.Color};
                    var pnl = new FlowLayoutPanel
                    {
                        Dock = DockStyle.Fill,
                        FlowDirection = FlowDirection.LeftToRight
                    };
                    page.Controls.Add(pnl);

                    foreach (var product in prods)
                    {
                        var btn = new ModernProductButton(product)
                        {
                            Text = product.Name,
                            Size = ButtonSize,
                        };
                        btn.Click += ProductButton_Click;
                        pnl.Controls.Add(btn);
                    }

                    this.InvokeIfRequired(() => _nickCustomTabControl1.TabPages.Add(page));
                }
            });
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

        
        public static void RunInAnotherApplication<T>(bool join = true, params object[] constructorArgs) where T: Form
        {
            RunInAnotherThread(() => Application.Run((Form) Activator.CreateInstance(typeof(T), constructorArgs)), join);
        }
        public static void HideAndRunInAnotherApplication<T>(this Form form, bool join = true, params object[] constructorArgs) where T: Form
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