//
// Copyright (c) NickAc. All rights reserved.
// Licensed under the MIT License. See LICENSE file in the project root for full license information.
//

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using NickAc.LightPOS.Backend.Data;
using NickAc.LightPOS.Backend.Objects;
using NickAc.LightPOS.Backend.Translation;
using NickAc.LightPOS.Backend.Utils;
using NickAc.LightPOS.Frontend.Controls;

namespace NickAc.LightPOS.Frontend.Forms.Users
{
    public partial class UserLoginForm : TemplateForm
    {
        #region Constructors

        public UserLoginForm()
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;
            translationHelper1.Translate(this);
        }

        #endregion

        #region Properties

        public override Size MaximumSize
        {
            get => Size.Empty;
            set => base.MaximumSize = value;
        }

        #endregion

        #region Fields

        private const int MaxTilesPerRow = 3;
        private const int TileSize = 145;
        private IList<User> users;
        private const int ControlPadding = 8;

        #endregion

        #region Methods

        public void Recenter(Control c, bool horizontal = true, bool vertical = true)
        {
            if (c?.Parent == null) return;
            if (horizontal)
                c.Left = (c.Parent.ClientSize.Width - c.Width) / 2;
            if (vertical)
                c.Top = (c.Parent.ClientSize.Height - c.Height) / 2;
        }

        protected override void OnLoad(EventArgs e)
        {
            label1.Show();
            foreach (Control control in panel1.Controls) control.Dispose();
            panel1.Controls.Clear();
            Recenter(label1);
            panel1.Hide();
            base.OnLoad(e);
            var th = new Thread(() =>
            {
                InitEverything();

                users = DataManager.GetUsers();
                panel1.SetupUsers(users);
            });
            th.Start();
            panel1.UserClick += Panel1_UserClick;
            panel1.UserTilesCreated += Panel1_UserTilesCreated;
        }

        private void Panel1_UserTilesCreated(object sender, EventArgs e)
        {
            panel1.InvokeIfRequired(() =>
            {
                panel1.Show();
                Recenter(panel1);
            });
            label1.InvokeIfRequired(label1.Hide);
        }

        private void Panel1_UserClick(object sender, UserPanel.UserEventArgs e)
        {
            //Ignore "ghost" click if user is logged in
            if (GlobalStorage.CurrentUser != null) return;
            //A user was selected. We can now show a form and ask for a password
            var usr = e.User;
            const float percentage = 0.25f;

            var form = new SecureUserLoginForm
            {
                Size = new Size((int) (Width * percentage), (int) (Height * percentage)),
                Text = Text
            };
            form.LoginSucceded += Form_LoginSucceded;
            form.SecureRequest(usr);
        }

        private void Form_LoginSucceded(object sender, UserPanel.UserEventArgs e)
        {
            ((IDisposable) sender).Dispose();
            var usr = e.User;
            var th = new Thread(() =>
            {
                //Start a new application loop.
                GlobalStorage.CurrentUser = usr;
                //Log user login
                Extensions.RunInAnotherThread(() => DataManager.LogAction(usr, UserAction.Action.Login, ""));
                this.InvokeIfRequired(Hide);
                //Run main form
                var mainForm = new MainMenuForm();
                Application.Run(mainForm);
                //Log user logout
                Extensions.RunInAnotherThread(() => DataManager.LogAction(usr, UserAction.Action.LogOut, ""));
                GlobalStorage.CurrentUser = null;
                this.InvokeIfRequired(Show);
                this.InvokeIfRequired(Activate);
                if (ModifierKeys.HasFlag(Keys.Shift))
                    this.InvokeIfRequired(() => OnLoad(EventArgs.Empty));
            });
            //Setting the apartment state is needed.
            th.SetApartmentState(ApartmentState.STA);
            //Then we can start the thread and and hide this form
            Hide();
            th.Start();
        }

        private void InitEverything()
        {
            Program.InitializeDatabase();

            //Get the translated administrator account username
            var adminUserName = "";
            using (var helper = new TranslationHelper())
            {
                adminUserName = helper.GetTranslation("create_user_admin");
            }

            var numberOfUsers = 0;
            numberOfUsers = DataManager.GetNumberOfUsers();
            if (numberOfUsers < 1)
                Application.Run(new ModifyUserForm().WithName(adminUserName).WithPermissions(UserPermission.All)
                    .WithReadOnlyPermissions());
            //The person might've not created a user
            //Check if it was created
            if (DataManager.GetNumberOfUsers() < 1) this.InvokeIfRequired(Close);
        }

        #endregion
    }
}