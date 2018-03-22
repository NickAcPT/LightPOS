using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using NickAc.LightPOS.Backend.Data;
using NickAc.LightPOS.Backend.Objects;
using NickAc.LightPOS.Backend.Utils;

namespace NickAc.LightPOS.Frontend.Forms.Products
{
    public partial class ModifyCategoryForm : TemplateForm
    {
        enum PortugueseTax
        {
            [Description("6%")] Six,
            [Description("13%")] Thirteen,
            [Description("23%")] TwentyTree,
            Custom
        }

        private readonly Category _toEdit;

        public override Size MaximumSize
        {
            get => Size.Empty;
            set => base.MaximumSize = value;
        }

        public ModifyCategoryForm(bool translate = true)
        {
            InitializeComponent();

            simpleSelectionControl1.OptionEnum = typeof(PortugueseTax);
            simpleSelectionControl1.SelectedEnumValue = PortugueseTax.TwentyTree;
            simpleSelectionControl1.SelectionChanged += (s, e) =>
            {
                percentageUpDown1.InvokeIfRequired(() =>
                {
                    percentageUpDown1.Visible = Equals(e.NewEnumItem, PortugueseTax.Custom);
                });
            };


            WindowState = FormWindowState.Maximized;
            panel2.BackColor = Color.Transparent;
            panel2.Click += (s, e) =>
            {
                using (var dlg = new Cyotek.Windows.Forms.ColorPickerDialog())
                {
                    var result = dlg.ShowDialog();
                    if (result == DialogResult.OK)
                    {
                        panel2.BackColor = dlg.Color;
                    }
                }
            };
            if (translate)
                translationHelper1.Translate(this);
        }

        public ModifyCategoryForm(Category toEdit) : this(false)
        {
            _toEdit = toEdit;

            textBox1.Text = _toEdit.Name;
            percentageUpDown1.Value = _toEdit.Tax;
            panel2.BackColor = _toEdit.Color;

            translationHelper1.SetTranslationLocation(this, "edit_cat_title");
            translationHelper1.SetTranslationLocation(metroButton1, "edit_cat_okbutton");
            translationHelper1.Translate(this);
        }

        private void MetroButton1_Click(object sender, EventArgs e)
        {
            if (_toEdit != null)
            {
                _toEdit.Name = textBox1.Text;
                _toEdit.Tax = (float) percentageUpDown1.Value;
                _toEdit.Color = panel2.BackColor;
                DataManager.AddCategory(_toEdit);
            }
            else
            {
                if (string.IsNullOrEmpty(textBox1.Text.Trim())) return;
                var finalCategory = new Category
                {
                    Color = panel2.BackColor,
                    Name = textBox1.Text,
                    Tax = !percentageUpDown1.Visible ? int.Parse(string.Join("", simpleSelectionControl1.SelectedEnumValue.GetDescription().Where(char.IsDigit))) / 100d : percentageUpDown1.Value
                };
                DataManager.AddCategory(finalCategory);
            }
        }
    }
}