//
// Copyright (c) NickAc. All rights reserved.
// Licensed under the MIT License. See LICENSE file in the project root for full license information.
//

using System;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using NickAc.LightPOS.Backend.Data;
using NickAc.LightPOS.Backend.Objects;
using NickAc.LightPOS.Backend.Utils;
using static NickAc.LightPOS.Backend.Utils.GlobalStorage;
using Animation = NickAc.ModernUIDoneRight.Utils.Animation;

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

            comboBox2.Items.AddRange(DataManager.GetCategories().ToArray<object>());
            comboBox2.DrawMode = DrawMode.OwnerDrawVariable;
            comboBox2.DrawItem += ComboBox2_DrawItem;

            var existingProducts = DataManager.GetProducts().Select(p => p.Barcode);
            textBoxEx1.TextChanged += (sender, args) =>
            {
                pictureBox1.Visible = existingProducts.Any(c => c == textBoxEx1.Text);
            };
            modernButton2.Click += (s, e) =>
            {
                pictureBox1.Hide();
                existingProducts = DataManager.GetProducts().Select(p => p.Barcode);
            };
            textBoxEx2.TextChanged += (sender, args) =>
            {
                pictureBox2.Visible = !float.TryParse(textBoxEx2.Text, NumberStyles.Currency, CultureInfo.InvariantCulture, out _);
            };
        }


        private void ComboBox2_DrawItem(object sender, DrawItemEventArgs e)
        {
            const int sideOffset = 8;
            int colorRectSize = e.Bounds.Height - 2;

            if (!(sender is ComboBox combo) || combo.Items.Count <= 0) return;
            if (!(combo.Items.Cast<object>().ElementAtOrDefault(e.Index) is Category category)) return;
            e.DrawBackground();
            using (var sb = new SolidBrush(combo.ForeColor))
            {
                using (var borderBrush = new SolidBrush(Color.FromArgb(95, 95, 95)))
                {
                    using (var colorBrush = new SolidBrush(category.Color))
                    {
                        var rect = new Rectangle(e.Bounds.X + 2, e.Bounds.Y + 2, colorRectSize - 2, colorRectSize - 2);
                        e.Graphics.FillRectangle(borderBrush, rect);
                        e.Graphics.FillRectangle(colorBrush, Rectangle.Inflate(rect, -1, -1));
                    }
                }

                var textRect = Rectangle.FromLTRB(e.Bounds.Left + colorRectSize + sideOffset, e.Bounds.Top,
                    e.Bounds.Right,
                    e.Bounds.Bottom);
                e.Graphics.DrawString(category.Name, combo.Font, sb,
                    textRect);
            }
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


        private void ModernButton2_Click(object sender, EventArgs e)
        {
            this.InvokeIfRequired(Hide);
            Extensions.RunInAnotherApplication<ModifyCategoryForm>(true);
            this.InvokeIfRequired(Show);
        }

        private void MetroButton1_Click(object sender, EventArgs e)
        {
            if (comboBox2.SelectedIndex < 0 || textBoxEx2.Text.Trim() == string.Empty) return;
            if (_toEdit != null)
            {
                var price = float.Parse(textBoxEx2.Text, NumberStyles.Currency, CultureInfo.InvariantCulture);
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
                var price = float.Parse(textBoxEx2.Text, NumberStyles.Currency, CultureInfo.InvariantCulture);
                var product = new Product
                {
                    Name = textBox1.Text,
                    Barcode = textBoxEx1.Text,
                    Price = price,
                    UnitPrice = price,
                    Category = comboBox2.SelectedItem as Category,
                    RequiresQuantity = false,
                };
                Extensions.RunInAnotherThread(() =>
                {
                    DataManager.AddProduct(product);
                    DataManager.LogAction(CurrentUser, UserAction.Action.CreateProduct, textBox1.Text);
                });
            }
        }
    }
}