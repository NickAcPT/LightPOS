using NickAc.LightPOS.Backend.Data;
using NickAc.LightPOS.Backend.Objects;
using NickAc.LightPOS.Backend.Translation;
using NickAc.LightPOS.Backend.Utils;
using NickAc.LightPOS.Frontend.Controls;
using NickAc.ModernUIDoneRight.Controls;
using NickAc.ModernUIDoneRight.Forms;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
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
        }

        private void InitEverything()
        {
            Program.InitializeDatabase();

            //Get the translated administrator account username
            string adminUserName = "";
            using (var helper = new TranslationHelper()) {
                adminUserName = helper.GetTranslation("create_user_admin");
            }

            int numberOfUsers = 0;
            numberOfUsers = DataManager.GetNumberOfUsers();
            if (numberOfUsers < 1) {
                //Create an administrator account
                Application.Run(new Forms.Users.ModifyUserForm().WithName(adminUserName).WithPermissions(UserPermission.All));
            }
            //The person might've not created a user
            //Check if it was created
            if (DataManager.GetNumberOfUsers() < 1) {
                //A new user wasn't created, so we'll exit the app.
                Close();
                return;
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            Recenter(label1);
            panel1.Hide();
            base.OnLoad(e);
            Thread th = new Thread(() => {
                InitEverything();

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
            });
            label1.InvokeIfRequired(label1.Hide);
        }

        private void UserTile_Click(object sender, EventArgs e)
        {
            if (sender is TilePanelReborn tile) {
                if (tile.Tag is User usr) {
                    const int formPadding = 8;
                    const float percentage = 0.25f;
                    const float userNamePercentage = 0.25f;
                    const float textBoxPercentage = 0.65f;
                    ModernForm form = new ModernForm
                    {
                        Sizable = false,
                        Size = new Size((int)(Width * percentage), (int)(Height * percentage)),
                        TitlebarVisible = false,
                        Text = Text,
                        Opacity = 0
                    };
                    KeyEventHandler escapeKey = (Object s, KeyEventArgs ee) => {
                        if (ee.KeyCode == Keys.Escape && !ee.Control && !ee.Alt && !ee.Shift) {
                            form.Close();
                        }
                    };
                    Label mainLabel = new Label
                    {
                        AutoSize = true,
                        BackColor = Color.Transparent,
                        Text = translationHelper1.GetTranslation("user_login_simple_title"),
                        Font = new Font(base.Font.FontFamily, 16),
                        Location = new Point(0, formPadding)
                    };

                    form.Controls.Add(mainLabel);
                    Recenter(mainLabel, vertical: false);


                    Label userNameLabel = new Label
                    {
                        AutoSize = true,
                        BackColor = Color.Transparent,
                        Text = usr.UserName,
                        Font = new Font(base.Font.FontFamily, 12),
                        Location = new Point(0, (int)(form.Height * userNamePercentage))
                    };

                    form.Controls.Add(userNameLabel);
                    Recenter(userNameLabel, vertical: false);

                    ModernButton btn = new ModernButton
                    {
                        Text = translationHelper1.GetTranslation("user_login_okbutton"),
                        Size = new Size((int)(form.Width * percentage), (int)(form.Height * percentage)),

                    };
                    btn.Location = new Point(0 /* Will be centered later */, form.Bottom - formPadding - btn.Height);

                    Point point = new Point(0, (int)(form.Height * textBoxPercentage));
                    point.Offset(0, -8);

                    TextBoxEx textBox = new TextBoxEx
                    {
                        Font = userNameLabel.Font,
                        UseSystemPasswordChar = true,
                        Size = new Size((int)(form.Width * textBoxPercentage), 0 /* The textbox sizes automatically */),
                    };
                    point.Offset(0, -textBox.Height);
                    textBox.Location = point;

                    form.Controls.Add(textBox);
                    Recenter(textBox, vertical: false);

                    //Now we can add the button click
                    btn.Click += (s, ee) => {
                        if (!string.IsNullOrWhiteSpace(textBox.Text)) {
                            if (usr.CheckPassword(textBox.Text)) {
                                //Close our smal login-form
                                form.Close();
                                Thread th = new Thread(() => {
                                    //Start a new application loop.
                                    Application.Run(new MainMenuForm());
                                    this.InvokeIfRequired(Show);
                                });
                                //Setting the apartment state is needed.
                                th.SetApartmentState(ApartmentState.STA);
                                //Then we can start the thread and and hide this form
                                Hide();
                                th.Start();
                            } else {
                                //Password doesn't work
                                //Clear the textbox
                                textBox.Clear();
                            }
                        }
                    };
                    form.Controls.Add(btn);
                    Recenter(btn, vertical: false);
                    form.AcceptButton = btn;
                    textBox.KeyUp += escapeKey;
                    form.KeyUp += escapeKey;
                    form.Load += (ss, ee) => {
                        var anim = new Animation().WithLimit(20).WithAction((a) => form.InvokeIfRequired(() => form.Opacity += 0.05f));
                        anim.Start();
                    };
                    bool canCloseForm = false;
                    MethodInvoker reduceOpacity = () => form.Opacity -= 0.05f;

                    form.FormClosing += (ss, ee) => {
                        ee.Cancel = !canCloseForm;
                        Debug.WriteLine(ee.CloseReason);
                        var anim = new Animation().WithLimit(20).WithAction((a) => {
                            form.InvokeIfRequired(reduceOpacity);
                            if (Math.Abs(form.Opacity) < float.Epsilon) {
                                canCloseForm = true;
                                form.InvokeIfRequired(form.Close);
                            }
                        });
                        anim.Start();
                    };
                    form.ShowDialog();
                }
            }

        }
    }
}
