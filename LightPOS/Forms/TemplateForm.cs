//
// Copyright (c) NickAc. All rights reserved.
// Licensed under the MIT License. See LICENSE file in the project root for full license information.
//

using System;
using System.Windows.Forms;
using NickAc.ModernUIDoneRight.Forms;
using NickAc.ModernUIDoneRight.Objects;

namespace NickAc.LightPOS.Frontend.Forms
{
    public partial class TemplateForm : ModernForm
    {
        public new void CenterToParent()
        {
            base.CenterToParent();
        }
        public new void CenterToScreen()
        {
            base.CenterToScreen();
        }

        public TemplateForm()
        {
            InitializeComponent();
            appBar1.MouseClick += (s, e) =>
            {
                if (appBar1.TextRectangle.Contains(e.Location) && Owner != null)
                    Close();
            };
            AutoScaleMode = AutoScaleMode.None;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            ColorScheme = DefaultColorSchemes.Blue;
        }

        protected override void WndProc(ref Message m) {
            // Suppress the WM_UPDATEUISTATE message
            if (m.Msg == 0x128) return;
            base.WndProc(ref m);
        }
    }
}