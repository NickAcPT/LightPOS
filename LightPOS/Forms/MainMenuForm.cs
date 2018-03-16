//
// Copyright (c) NickAc. All rights reserved.
// Licensed under the MIT License. See LICENSE file in the project root for full license information.
//
using NickAc.LightPOS.Backend.Objects;
using NickAc.LightPOS.Backend.Utils;
using NickAc.LightPOS.Frontend.Properties;
using NickAc.ModernUIDoneRight.Controls;
using NickAc.ModernUIDoneRight.Forms;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace NickAc.LightPOS.Frontend.Forms
{
    public partial class MainMenuForm : TemplateForm
    {
        private const int FormPadding = 8;

        #region Constructors

        public MainMenuForm()
        {
            InitializeComponent();
            translationHelper1.Translate(this);

        }
        #endregion

        #region Properties

        public override Size MaximumSize { get => Size.Empty; set => base.MaximumSize = value; }

        #endregion

        private void tilePanelReborn2_Click_1(object sender, EventArgs e)
        {
            if (GlobalStorage.CurrentUser.CanOpenManagement())
            this.HideAndStart<ManagementForm>();
        }
    }
}