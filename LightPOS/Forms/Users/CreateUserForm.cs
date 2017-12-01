using NickAc.LightPOS.Backend.Objects;
using NickAc.LightPOS.Backend.Utils;
using NickAc.ModernUIDoneRight.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NickAc.LightPOS.Frontend.Forms.Users
{
    public partial class CreateUserForm : TemplateForm
    {
        public CreateUserForm()
        {
            InitializeComponent();
            translationHelper1.Translate(this);
            InitializePermissions(checkedListBox1);
            checkedListBox1.CheckOnClick = true;
        }

        private void InitializePermissions(ListBox listBox)
        {
            listBox.Format += (s, e) => {
                dynamic obj = e.ListItem;
                e.Value = obj.Description;
            };

            foreach (Enum e in Enum.GetValues(typeof(UserPermission))) {
                if (e.HasDescription()) {
                    dynamic obj = new ExpandoObject();
                    obj.EnumValue = e;
                    obj.Description = e.GetDescription();
                    listBox.Items.Add(obj);
                }

            }
        }


        private void MetroButton1_Click(object sender, EventArgs e)
        {
            UserPermission perm = GetPermissions(checkedListBox1.CheckedItems.OfType<object>());
            if (!string.IsNullOrWhiteSpace(textBox1.Text) && !string.IsNullOrWhiteSpace(textBox2.Text)) {
                User user = User.CreateUser(textBox1.Text.Trim(), textBox2.Text.Trim(), perm);
            }
        }

        private UserPermission GetPermissions(IEnumerable<object> enumerable)
        {
            Enum final = UserPermission.None;
            foreach (var i in enumerable) {
                dynamic expandoObject = i as ExpandoObject;
                if (expandoObject != null) {
                    if ((expandoObject.EnumValue is UserPermission value)) {
                        final = final.Or(value);
                    }
                }
            }
            return (UserPermission)final;
        }
    }
}
