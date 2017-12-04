using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace NickAc.LightPOS.Backend.Utils
{
    public static class Extensions
    {
        public static void RunInAnotherThread(MethodInvoker inv)
        {
            var th = new Thread(() => inv?.Invoke());
            th.Start();
        }

        //Code taken from StackOverflow (https://stackoverflow.com/questions/2367718/automating-the-invokerequired-code-pattern)
        //All credits go to Olivier Jacot-Descombes (https://stackoverflow.com/users/880990/olivier-jacot-descombes)
        public static void InvokeIfRequired(this Control control, MethodInvoker action)
        {
            if (control.InvokeRequired) {
                if (!control.IsDisposed && !control.Disposing) control.Invoke(action);
            } else {
                action();
            }
        }
    }
}
