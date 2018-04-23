//
// Copyright (c) NickAc. All rights reserved.
// Licensed under the MIT License. See LICENSE file in the project root for full license information.
//

using System;
using System.Windows.Forms;

namespace NickAc.LightPOS.Frontend.Controls
{
    public class ListBoxNoFlicker : ListBox
    {
        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            Capture = false;
        }

        public ListBoxNoFlicker()
        {
            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);

            SetStyle(ControlStyles.EnableNotifyMessage, true);
        }

        protected override void OnNotifyMessage(Message m)
        {
            if (m.Msg != 0x14)
                base.OnNotifyMessage(m);
        }
    }
}