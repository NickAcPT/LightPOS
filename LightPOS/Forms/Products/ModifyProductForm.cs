//
// Copyright (c) NickAc. All rights reserved.
// Licensed under the MIT License. See LICENSE file in the project root for full license information.
//

using System.Drawing;
using System.Windows.Forms;

namespace NickAc.LightPOS.Frontend.Forms.Products
{
    public partial class ModifyProductForm : TemplateForm
    {
        public override Size MaximumSize
        {
            get => Size.Empty;
            set => base.MaximumSize = value;
        }

        public bool CreateNewItem { get; }

        public ModifyProductForm(bool createNewItem)
        {
            CreateNewItem = createNewItem;
            InitializeComponent();
            WindowState = FormWindowState.Maximized;
            if (createNewItem) translationHelper1.SetTranslationLocation(metroButton1, "add_prod_okbutton");
            translationHelper1.Translate(this);
        }
    }
}