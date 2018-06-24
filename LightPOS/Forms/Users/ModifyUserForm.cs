//
// Copyright (c) NickAc. All rights reserved.
// Licensed under the MIT License. See LICENSE file in the project root for full license information.
//
using NickAc.LightPOS.Backend.Data;
using NickAc.LightPOS.Backend.Objects;
using NickAc.LightPOS.Backend.Utils;
using NickAc.ModernUIDoneRight.Objects.MenuItems;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Dynamic;
using System.Linq;
using System.Windows.Forms;

namespace NickAc.LightPOS.Frontend.Forms.Users
{
    public partial class ModifyUserForm : TemplateForm
    {
        #region Constructors

        public ModifyUserForm(UserAction.Action action = Backend.Objects.UserAction.Action.CreateUser)
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;

            UserAction = action;
            switch (action) {
                case Backend.Objects.UserAction.Action.ModifyUser:
                    if (GlobalStorage.CurrentUser.CanRemoveUsers() && BaseUser != null && BaseUser.UserId != GlobalStorage.CurrentUser.UserId) {
                        //Remove user menu item
                        var removeUserItem = new AppBarMenuTextItem(translationHelper1.GetTranslation("edit_user_delete"));
                        removeUserItem.Click += (s, e) => {
                            if (BaseUser != null)
                                Extensions.RunInAnotherThread(() => {
                                    DataManager.RemoveUser(BaseUser.UserId);
                                    this.InvokeIfRequired(Close);
                                });
                        };
                        appBar1.MenuItems.Add(removeUserItem);
                    }
                    translationHelper1.SetTranslationLocation(metroButton1, "edit_user_okbutton");
                    break;
            }
            translationHelper1.Translate(this);
            InitializePermissions(checkedListBox1);
            checkedListBox1.CheckOnClick = true;
        }

        #endregion

        #region Properties
        public bool IsCurrentUser => BaseUser != null && BaseUser.UserId == GlobalStorage.CurrentUser.UserId;
        public User BaseUser { get; set; }
        public UserAction.Action UserAction { get; set; }
        public override Size MaximumSize { get => Size.Empty; set => base.MaximumSize = value; }
        #endregion

        #region Methods
        
        public ModifyUserForm WithAction(UserAction.Action action)
        {
            UserAction = action;
            return this;
        }
        public ModifyUserForm WithReadOnlyPermissions()
        {
            checkedListBox1.Enabled = false;
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
            for (var i = 0; i < checkedListBox1.Items.Count; i++) {
                dynamic item = checkedListBox1.Items[i];
                if (item is ExpandoObject) {
                    if (flags.Contains(item.EnumValue)) {
                        checkedListBox1.SetItemChecked(i, true);
                    }
                }
            }
            return this;
        }

        public ModifyUserForm WithUser(User usr)
        {
            BaseUser = usr;
            return WithName(usr.UserName).WithPermissions(usr.Permissions);
        }
        private static UserPermission GetPermissions(IEnumerable<object> enumerable)
        {
            Enum final = UserPermission.None;
            foreach (var i in enumerable) {
                dynamic expandoObject = i as ExpandoObject;
                if (expandoObject == null) continue;
                if ((expandoObject.EnumValue is UserPermission value)) {
                    final = final.Or(value);
                }
            }
            return (UserPermission)final;
        }

        private void InitializePermissions(ListBox listBox)
        {
            listBox.Format += (s, e) => {
                dynamic obj = e.ListItem;
                e.Value = obj.Description;
            };

            foreach (Enum e in Enum.GetValues(typeof(UserPermission))) {
                if (!e.HasDescription()) continue;
                dynamic obj = new ExpandoObject();
                obj.EnumValue = e;
                obj.Description = translationHelper1.GetTranslation(e.GetDescription());
                listBox.Items.Add(obj);
            }
        }

        private void MetroButton1_Click(object sender, EventArgs e)
        {
            var perm = GetPermissions(checkedListBox1.CheckedItems.OfType<object>());
            if (!string.IsNullOrWhiteSpace(textBox1.Text) && (UserAction == Backend.Objects.UserAction.Action.ModifyUser || !string.IsNullOrWhiteSpace(textBoxEx1.Text))) {
                var user = BaseUser != null ? ModifyUser(BaseUser, perm) : User.CreateUser(textBox1.Text.Trim(), textBoxEx1.Text.Trim(), perm);
                switch (UserAction) {
                    case Backend.Objects.UserAction.Action.CreateUser:
                    case Backend.Objects.UserAction.Action.ModifyUser:
                        DataManager.AddUser(user);
                        break;
                }

                Close();
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (GlobalStorage.CurrentUser == null) return;
            textBox1.Enabled = GlobalStorage.CurrentUser.CanModifyUsers();
            textBoxEx1.Enabled = GlobalStorage.CurrentUser.CanModifyUsers();
            checkedListBox1.Enabled = GlobalStorage.CurrentUser.CanModifyUsers() && !IsCurrentUser;
            metroButton1.Enabled = GlobalStorage.CurrentUser.CanModifyUsers();
        }

        private User ModifyUser(User baseUser, UserPermission perm)
        {
            baseUser.UserName = textBox1.Text;
            baseUser.Permissions = perm;
            if (!string.IsNullOrWhiteSpace(textBoxEx1.Text)) {
                var loginForm = new SecureUserLoginForm();
                loginForm.LoginSucceded += (s, e) => {
                    baseUser.ChangePassword(textBoxEx1.Text);
                };
                loginForm.SecureRequest(baseUser);
            }

            if (baseUser.UserId == GlobalStorage.CurrentUser.UserId)
                GlobalStorage.CurrentUser = baseUser;
            return baseUser;
        }

        #endregion
    }
}