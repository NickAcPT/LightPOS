using NickAc.LightPOS.Backend.Data;
using NickAc.LightPOS.Backend.Objects;
using NickAc.LightPOS.Backend.Utils;
using NickAc.ModernUIDoneRight.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace NickAc.LightPOS.Frontend.Forms.Users
{
    public partial class UserLoginForm : TemplateForm
    {
        public override Size MaximumSize { get => Size.Empty; set => base.MaximumSize = value; }

        private const int TileSize = 145;
        IList<User> users;

        public UserLoginForm()
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;
            translationHelper1.Translate(this);
            // users = DataManager.GetUsers();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Recenter(label1);
            panel1.Hide();
            Thread th = new Thread(() => {
                users = DataManager.GetUsers();
                SetupUsers(users);
            });
            th.Start();
        }


        public void Recenter(Control c)
        {
            c.Left = (ClientSize.Width - c.Width) / 2;
            c.Top = (ClientSize.Height - c.Height) / 2;
        }

        private void SetupUsers(IList<User> usr)
        {
            panel1.InvokeIfRequired(() => {
                panel1.AutoSize = true;
                panel1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            });

            Size tileSz = new Size(TileSize, TileSize);
            foreach (var user in usr) {
                TilePanelReborn rb = new TilePanelReborn
                {
                    Size = tileSz,
                    Text = user.UserName,
                    Image = Properties.Resources.ic_person_white_48dp_2x,

                    CanBeHovered = true,
                    BackColor = ColorScheme.PrimaryColor,
                    ForeColor = ColorScheme.ForegroundColor,
                    Flat = true
                };

                panel1.InvokeIfRequired(() => panel1.Controls.Add(rb));
            }
            panel1.InvokeIfRequired(() => {
                panel1.Show();
                Recenter(panel1);
                label1.Hide();
            });
        }
    }
}
