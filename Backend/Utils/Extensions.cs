using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NickAc.LightPOS.Backend.Utils
{
    public static class Extensions
    {
        //Code taken from StackOverflow (https://stackoverflow.com/questions/2367718/automating-the-invokerequired-code-pattern)
        //All credits go to Olivier Jacot-Descombes (https://stackoverflow.com/users/880990/olivier-jacot-descombes)
        public static void InvokeIfRequired(this Control control, MethodInvoker action)
        {
            if (control.InvokeRequired) {
                control.Invoke(action);
            }
            else {
                action();
            }
        }
    }
}
