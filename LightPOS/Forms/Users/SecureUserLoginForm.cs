//
// Copyright (c) NickAc. All rights reserved.
// Licensed under the MIT License. See LICENSE file in the project root for full license information.
//

using System;
using System.Drawing;
using System.Windows.Forms;
using NickAc.LightPOS.Backend.Objects;
using NickAc.LightPOS.Backend.Translation;
using NickAc.LightPOS.Backend.Utils;
using NickAc.LightPOS.Frontend.Controls;
using NickAc.ModernUIDoneRight.Controls;
using NickAc.ModernUIDoneRight.Forms;
using Transitions;
using static NickAc.LightPOS.Frontend.Controls.UserPanel;

namespace NickAc.LightPOS.Frontend.Forms.Users
{
    internal class SecureUserLoginForm : ModernForm
    {
        #region Constructors

        public SecureUserLoginForm()
        {
            AutoScaleMode = AutoScaleMode.None;
            Size = new Size(345, 192);
            Sizable = false;
            TitlebarVisible = false;
            Opacity = 0;
        }

        #endregion

        #region Properties

        public User User { get; set; }

        #endregion

        #region Events

        /// <summary>
        ///     Called to signal to subscribers that login succeded
        /// </summary>
        public event EventHandler<UserEventArgs> LoginSucceded;

        #endregion

        #region Fields

        private const int ControlPadding = 8;
        private const float SizePercentage = 0.65f;

        #endregion

        #region Methods

        public void Recenter(Control c, bool horizontal = true, bool vertical = true)
        {
            if (c == null) return;
            if (horizontal)
                c.Left = (c.Parent.ClientSize.Width - c.Width) / 2;
            if (vertical)
                c.Top = (c.Parent.ClientSize.Height - c.Height) / 2;
        }

        public void SecureRequest(User usr)
        {
            User = usr;
            AddControls(this);
            CenterToScreen();
            ShowDialog();
        }

        protected virtual void OnLoginSucceded(User e)
        {
            var eh = LoginSucceded;

            eh?.Invoke(this, new UserEventArgs(e));
        }

        private void AddControls(SecureUserLoginForm form)
        {
            var translationHelper = new TranslationHelper();
            var usr = User;

            void EscapeKeyHandler(object s, KeyEventArgs ee)
            {
                if (ee.KeyCode == Keys.Escape && !ee.Control && !ee.Alt && !ee.Shift)
                {
                    this.InvokeIfRequired(form.Close);
                    ee.Handled = ee.SuppressKeyPress = true;
                }
            }

            var mainLabel = new Label
            {
                AutoSize = true,
                BackColor = Color.Transparent,
                Text = translationHelper.GetTranslation("user_login_simple_title"),
                Font = new Font(Font.FontFamily, 16),
                Location = new Point(0, ControlPadding)
            };

            form.Controls.Add(mainLabel);
            Recenter(mainLabel, vertical: false);

            var userNameLabel = new Label
            {
                AutoSize = true,
                BackColor = Color.Transparent,
                Text = usr.UserName,
                Font = new Font(Font.FontFamily, 12),
                Location = new Point(0, 48)
            };

            form.Controls.Add(userNameLabel);
            Recenter(userNameLabel, vertical: false);

            var btn = new ModernButton
            {
                Text = translationHelper.GetTranslation("user_login_okbutton"),
                Size = new Size(86, 38)
            };
            btn.Location = new Point(0 /* Will be centered later */, 192 - ControlPadding - btn.Height);

            var point = new Point(0, 134);
            point.Offset(0, -8);

            var textBox = new TextBoxEx
            {
                Font = userNameLabel.Font,
                UseSystemPasswordChar = true,
                Size = new Size(241, 0 /* The textbox sizes automatically */)
            };
            point.Offset(0, -textBox.Height);
            textBox.Location = point;

            form.Controls.Add(textBox);
            Recenter(textBox, vertical: false);

            //Now we can add the button click
            btn.Click += (s, ee) =>
            {
                if (!string.IsNullOrWhiteSpace(textBox.Text))
                {
                    if (usr.CheckPassword(textBox.Text))
                    {
                        //Close our smal login-form
                        form.FormClosed += (sss, eee) => { OnLoginSucceded(usr); };
                        form.Close();
                    }
                    else
                    {
                        //Password doesn't work
                        //Clear the textbox
                        textBox.Clear();
                    }
                }
            };
            form.Controls.Add(btn);
            Recenter(btn, vertical: false);
            form.AcceptButton = btn;
            textBox.KeyUp += EscapeKeyHandler;
            form.KeyUp += EscapeKeyHandler;
            form.Load += (ss, ee) => Transition.run(form, "Opacity", 1d, new TransitionType_EaseInEaseOut(400));
            translationHelper.Dispose();
            form.TopMost = true;
        }

        #endregion
    }
}