//
// Copyright (c) NickAc. All rights reserved.
// Licensed under the MIT License. See LICENSE file in the project root for full license information.
//

using System;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using NickAc.LightPOS.Backend.Data;
using NickAc.LightPOS.Backend.Objects;
using NickAc.LightPOS.Backend.Utils;
using static NickAc.LightPOS.Backend.Utils.GlobalStorage;

namespace NickAc.LightPOS.Frontend.Forms.Products
{
    public partial class ModifyProductForm : TemplateForm
    {
        private readonly Product _toEdit;

        public ModifyProductForm(bool translate = true)
        {
            InitializeComponent();
            CenterToScreen();
            TitlebarVisible = true;
            //WindowState = FormWindowState.Maximized;

            AdaptToErrorImage(textBoxEx1, pictureBox1);
            AdaptToErrorImage(textBoxEx2, pictureBox2);

            if (translate) translationHelper1.Translate(this);

            LoadCategories();

            var existingProducts = DataManager.GetProducts().Select(p => p.Barcode);
            textBoxEx1.TextChanged += (sender, args) =>
            {
                pictureBox1.Visible = existingProducts.Any(c => c == textBoxEx1.Text);
                AdaptToErrorImage((Control) sender, pictureBox1);
            };
            metroButton1.Click += (s, e) =>
            {
                pictureBox1.Hide();
                existingProducts = DataManager.GetProducts().Select(p => p.Barcode);
            };
            modernButton2.Click += (s, e) => { existingProducts = DataManager.GetProducts().Select(p => p.Barcode); };
            textBoxEx2.TextChanged += (sender, args) =>
            {
                pictureBox2.Visible =
                    !float.TryParse(textBoxEx2.Text.Replace(',', '.'), NumberStyles.Currency, CultureInfo.InvariantCulture, out _) &&
                    textBoxEx2
                        .Text != "";
                AdaptToErrorImage((Control) sender, pictureBox2);
            };
        }


        public ModifyProductForm(Product toEdit) : this(false)
        {
            _toEdit = toEdit;
            textBox1.Text = toEdit.Name;
            textBoxEx1.Text = toEdit.Barcode;
            textBoxEx2.Text = toEdit.UnitPrice.ToString(CultureInfo.InvariantCulture);
            translationHelper1.SetTranslationLocation(metroButton1, "edit_prod_okbutton");
            translationHelper1.SetTranslationLocation(this, "edit_prod_title");
            translationHelper1.Translate(this);
        }

        public override Size MaximumSize
        {
            get => Size.Empty;
            set => base.MaximumSize = value;
        }

        private void LoadCategories()
        {
            comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox2.Items.Clear();
            comboBox2.Items.AddRange(DataManager.GetCategories().ToArray<object>());
            comboBox2.DisplayMember = nameof(Category.Name);
        }

        private static void AdaptToErrorImage(Control target, Control errorImage)
        {
            target.Width = (errorImage.Visible ? errorImage.Left - 8 : errorImage.Right) - target.Left;
        }

        private void ModernButton2_Click(object sender, EventArgs e)
        {
            this.InvokeIfRequired(Hide);
            Extensions.RunInAnotherApplication<ModifyCategoryForm>(constructorArgs: true);
            this.InvokeIfRequired(Show);
            LoadCategories();
        }

        private void MetroButton1_Click(object sender, EventArgs e)
        {
            if (comboBox2.SelectedIndex < 0 || textBoxEx2.Text.Trim() == string.Empty) return;
            if (_toEdit != null)
            {
                var price = decimal.Parse(textBoxEx2.Text, NumberStyles.Currency, CultureInfo.InvariantCulture);
                var oldName = _toEdit.Name;
                _toEdit.Name = textBox1.Text;
                _toEdit.Barcode = textBoxEx1.Text;
                _toEdit.Price = _toEdit.UnitPrice = price;
                _toEdit.Category = comboBox2.SelectedItem as Category;

                Extensions.RunInAnotherThread(() =>
                {
                    DataManager.AddProduct(_toEdit);
                    DataManager.LogAction(CurrentUser, UserAction.Action.EditProduct, oldName);
                });
            }
            else
            {
                var price = decimal.Parse(textBoxEx2.Text, NumberStyles.Currency, CultureInfo.InvariantCulture);
                var product = new Product
                {
                    Name = textBox1.Text,
                    Barcode = textBoxEx1.Text,
                    Price = price,
                    UnitPrice = price,
                    Category = comboBox2.SelectedItem as Category,
                    RequiresQuantity = false
                };
                Extensions.RunInAnotherThread(() =>
                {
                    DataManager.AddProduct(product);
                    DataManager.LogAction(CurrentUser, UserAction.Action.CreateProduct, textBox1.Text);
                });
            }

            textBox1.Text = textBoxEx1.Text = textBoxEx2.Text = string.Empty;
            comboBox2.SelectedIndex = -1;
        }
    }
}