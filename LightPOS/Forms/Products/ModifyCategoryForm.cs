using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using JetBrains.Annotations;
using NickAc.LightPOS.Backend.Data;
using NickAc.LightPOS.Backend.Objects;
using NickAc.LightPOS.Backend.Utils;

namespace NickAc.LightPOS.Frontend.Forms.Products
{
    public partial class ModifyCategoryForm : TemplateForm
    {
        private readonly Category _toEdit;


        private IEnumerable<string> _categories;

        public ModifyCategoryForm(bool translate = true)
        {
            InitializeComponent();
            _categories = DataManager.GetCategories().Select(c => c.Name);
            metroButton1.Click += (s, e) =>
            {
                _categories = DataManager.GetCategories().Select(c => c.Name);
                errorImage.Hide();
            };
            simpleSelectionControl1.OptionEnum = typeof(PortugueseTax);
            simpleSelectionControl1.SelectedEnumValue = PortugueseTax.TwentyTree;
            simpleSelectionControl1.SelectionChanged += (s, e) =>
            {
                percentageUpDown1.InvokeIfRequired(() =>
                {
                    percentageUpDown1.Visible = Equals(e.NewEnumItem, PortugueseTax.Custom);
                });
            };

            textBox1.TextChanged += (s, e) =>
            {
                errorImage.Visible = _categories.Any(c => textBox1.Text == c) &&
                                     (_toEdit == null || _toEdit.Name != textBox1.Text);
            };
            if (translate)
                translationHelper1.Translate(this);
        }

        public ModifyCategoryForm(Category toEdit) : this(false)
        {
            _toEdit = toEdit;

            textBox1.Text = _toEdit.Name;
            percentageUpDown1.Value = _toEdit.Tax;

            translationHelper1.SetTranslationLocation(this, "edit_cat_title");
            translationHelper1.SetTranslationLocation(metroButton1, "edit_cat_okbutton");
            translationHelper1.Translate(this);
        }

        private void MetroButton1_Click(object sender, EventArgs e)
        {
            if (_toEdit != null)
            {
                var oldName = _toEdit.Name;
                _toEdit.Name = textBox1.Text;
                _toEdit.Tax = percentageUpDown1.Value;
                Extensions.RunInAnotherThread(() =>
                {
                    DataManager.AddCategory(_toEdit);
                    DataManager.LogAction(GlobalStorage.CurrentUser, UserAction.Action.EditCategory, oldName);
                });
            }
            else
            {
                if (string.IsNullOrEmpty(textBox1.Text.Trim()) || errorImage.Visible) return;
                var finalCategory = new Category
                {
                    Name = textBox1.Text,
                    Tax = !percentageUpDown1.Visible
                        ? int.Parse(string.Join("",
                              simpleSelectionControl1.SelectedEnumValue.GetDescription().Where(char.IsDigit))) / 100m
                        : percentageUpDown1.Value
                };
                Extensions.RunInAnotherThread(() =>
                {
                    DataManager.AddCategory(finalCategory);
                    DataManager.LogAction(GlobalStorage.CurrentUser, UserAction.Action.CreateCategory, textBox1.Text);
                });
            }

            simpleSelectionControl1.SelectedEnumValue = PortugueseTax.TwentyTree;
            textBox1.Clear();
        }

        private enum PortugueseTax
        {
            [UsedImplicitly] [Description("6%")] Six,
            [UsedImplicitly] [Description("13%")] Thirteen,
            [Description("23%")] TwentyTree,
            Custom
        }
    }
}