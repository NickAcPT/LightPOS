using NickAc.LightPOS.Backend.Data;
using NickAc.LightPOS.Backend.Objects;
using NickAc.LightPOS.Backend.Utils;
using NickAc.ModernUIDoneRight.Controls;
using NickAc.ModernUIDoneRight.Forms;
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
            Recenter(label1);
            panel1.Hide();
            base.OnLoad(e);
            Thread th = new Thread(() => {
                users = DataManager.GetUsers();
                SetupUsers(users);
            });
            th.Start();
        }


        public void Recenter(Control c, bool horizontal = true, bool vertical = true)
        {
            if (horizontal)
                c.Left = (c.Parent.ClientSize.Width - c.Width) / 2;
            if (vertical)
                c.Top = (c.Parent.ClientSize.Height - c.Height) / 2;
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
                    Tag = user,
                    Size = tileSz,
                    Text = user.UserName,
                    Image = Properties.Resources.ic_person_white_48dp_2x,

                    CanBeHovered = true,
                    BackColor = ColorScheme.PrimaryColor,
                    ForeColor = ColorScheme.ForegroundColor,
                    Flat = true
                };


                panel1.InvokeIfRequired(() => panel1.Controls.Add(rb));

                rb.InvokeIfRequired(() => {
                    rb.Click += UserTile_Click;
                });
            }
            panel1.InvokeIfRequired(() => {
                panel1.Show();
                Recenter(panel1);
                label1.Hide();
            });
        }

        private void UserTile_Click(object sender, EventArgs e)
        {
            if (sender is TilePanelReborn tile) {
                if (tile.Tag is User usr) {
                    var percentage = 0.25f;
                    ModernForm form = new ModernForm
                    {
                        Sizable = false,
                        Size = new Size((int)(Width * percentage), (int)(Height * percentage)),
                        TitlebarVisible = false,
                        Text = Text
                    };
                    form.KeyUp += (s, ee) => {
                        if (ee.KeyCode == Keys.Escape && !ee.Control && !ee.Alt && !ee.Shift) {
                            if (s is Form ss)
                                ss.Close();
                        }
                    };

                    Label mainLabel = new Label
                    {
                        AutoSize = true,
                        BackColor = Color.Transparent,
                        Text = translationHelper1.GetTranslation("user_login_simple_title"),
                        Font = new Font(Font.FontFamily, 12)
                    };

                    form.Controls.Add(mainLabel);
                    Recenter(mainLabel, vertical: false);

                    form.ShowDialog();
                }
            }

        }
    }
}
