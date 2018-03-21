//
// Copyright (c) NickAc. All rights reserved.
// Licensed under the MIT License. See LICENSE file in the project root for full license information.
//

using System.Drawing;
using System.Windows.Forms;
using NickAc.LightPOS.Backend.Objects;
using NickAc.LightPOS.Backend.Utils;

namespace NickAc.LightPOS.Frontend.Forms.Products
{
    public partial class ModifyProductForm : TemplateForm
    {
        private readonly Product _toEdit;

        private enum ProductModifyState
        {
            Create,
            Delete,
            Modify
        }

        public override Size MaximumSize
        {
            get => Size.Empty;
            set => base.MaximumSize = value;
        }
        
        public ModifyProductForm(bool translate = true)
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;
            if (translate) translationHelper1.Translate(this);
        }

        public ModifyProductForm(Product toEdit) : this(false)
        {
            _toEdit = toEdit;
            textBox1.Text = toEdit.Name;
            textBoxEx1.Text = toEdit.Barcode;
            textBox1.Text = toEdit.Name;
            translationHelper1.SetTranslationLocation(metroButton1, "edit_prod_okbutton");
            translationHelper1.SetTranslationLocation(this, "edit_prod_title");

            translationHelper1.Translate(this);
        }


        private void modernButton2_Click(object sender, System.EventArgs e)
        {
            this.InvokeIfRequired(Hide);
            Extensions.RunInAnotherApplication<Products.ModifyCategoryForm>(true);
            this.InvokeIfRequired(Show);
        }
    }
}