//
// Copyright (c) NickAc. All rights reserved.
// Licensed under the MIT License. See LICENSE file in the project root for full license information.
//
using System;
using System.Threading;
using System.Windows.Forms;

namespace NickAc.LightPOS.Backend.Utils
{
    public static class Extensions
    {
        public static void RunInAnotherApplication(this Form form)
        {
            RunInAnotherThread(() => Application.Run(form));
        }

        public static void RunInAnotherThread(MethodInvoker inv)
        {
            var th = new Thread(() => inv?.Invoke());
            th.Start();
        }

        //Code taken and adapted from StackOverflow (https://stackoverflow.com/questions/2367718/automating-the-invokerequired-code-pattern)
        //All credits go to Olivier Jacot-Descombes (https://stackoverflow.com/users/880990/olivier-jacot-descombes)
        public static void InvokeIfRequired(this Control control, MethodInvoker action)
        {
            if (!control.IsDisposed && !control.Disposing && control.InvokeRequired) {
                control.Invoke(action);
            } else {
                action();
            }
        }
    }
}