//
// Copyright (c) NickAc. All rights reserved.
// Licensed under the MIT License. See LICENSE file in the project root for full license information.
//
using System;
using NickAc.ModernUIDoneRight.Forms;
using NickAc.ModernUIDoneRight.Objects;

namespace NickAc.LightPOS.Frontend.Forms
{
    public partial class TemplateForm : ModernForm
    {
        public TemplateForm()
        {
            InitializeComponent();
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            ColorScheme = DefaultColorSchemes.Blue;
        }
    }
}