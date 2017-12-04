using NickAc.LightPOS.Backend.Data;
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
    public partial class ModifyUserForm : TemplateForm
    {
        public UserAction.Action UserAction { get; set; } = Backend.Objects.UserAction.Action.CreateUser;

        public ModifyUserForm()
        {
            InitializeComponent();
            switch (UserAction) {
                case Backend.Objects.UserAction.Action.ModifyUser:
                    translationHelper1.SetTranslationLocation(metroButton1, "edit_user_okbutton");
                    break;
            }
            translationHelper1.Translate(this);
            InitializePermissions(checkedListBox1);
            checkedListBox1.CheckOnClick = true;
            Focus();
        }

        public ModifyUserForm WithAction(UserAction.Action action)
        {
            UserAction = action;
            return this;
        }

        public ModifyUserForm WithName(string name)
        {
            textBox1.Text = name;
            return this;
        }

        public ModifyUserForm WithPermissions(UserPermission perms)
        {
            var flags = perms.SplitFlags<UserPermission>();
            for (int i = 0; i < checkedListBox1.Items.Count; i++) {
                dynamic item = checkedListBox1.Items[i];
                if (item is ExpandoObject) {
                    if (flags.Contains(item.EnumValue)) {
                        checkedListBox1.SetItemChecked(i, true);
                    }
                }
            }
            return this;
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
                    obj.Description = translationHelper1.GetTranslation(e.GetDescription());
                    listBox.Items.Add(obj);
                }

            }
        }


        private void MetroButton1_Click(object sender, EventArgs e)
        {
            UserPermission perm = GetPermissions(checkedListBox1.CheckedItems.OfType<object>());
            if (!string.IsNullOrWhiteSpace(textBox1.Text) && !string.IsNullOrWhiteSpace(textBoxEx1.Text)) {
                User user = User.CreateUser(textBox1.Text.Trim(), textBoxEx1.Text.Trim(), perm);
                switch (UserAction) {
                    case Backend.Objects.UserAction.Action.CreateUser:
                    case Backend.Objects.UserAction.Action.ModifyUser:
                        DataManager.AddUser(user);
                        break;
                }

                Close();
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
