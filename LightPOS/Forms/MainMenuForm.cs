//
// Copyright (c) NickAc. All rights reserved.
// Licensed under the MIT License. See LICENSE file in the project root for full license information.
//
using System.Drawing;

namespace NickAc.LightPOS.Frontend.Forms
{
    public partial class MainMenuForm : TemplateForm
    {
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
    }
}