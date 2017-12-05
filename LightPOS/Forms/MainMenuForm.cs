//
// Copyright (c) NickAc. All rights reserved.
// Licensed under the MIT License. See LICENSE file in the project root for full license information.
//
using NickAc.LightPOS.Backend.Utils;
using NickAc.ModernUIDoneRight.Controls;
using NickAc.ModernUIDoneRight.Forms;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace NickAc.LightPOS.Frontend.Forms
{
    public partial class MainMenuForm : TemplateForm
    {
        private const int FormPadding = 8;
        #region Constructors

        public MainMenuForm()
        {
            InitializeComponent();
            translationHelper1.Translate(this);

        }
        #endregion

        #region Properties

        public override Size MaximumSize { get => Size.Empty; set => base.MaximumSize = value; }

        #endregion

        private void TilePanelReborn2_Click(object sender, System.EventArgs e)
        {
            //POS Management tile

            int finalWidth = tilePanelReborn2.Size.Width + FormPadding * 2;
            ModernForm form = new ModernForm
            {
                Sizable = false,
                MinimumSize = new Size(3, 3),
                Size = new Size(0, tilePanelReborn2.Size.Height + FormPadding * 2),
                TitlebarVisible = false,
            };
            var layoutPanel = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                Padding = new Padding(FormPadding / 2)
            };

            var tileWidth = (tilePanelReborn2.Width / 2) - FormPadding;
            var tileHeight = tilePanelReborn2.Height;
            TilePanelReborn addUserTile = GenerateActionTile(tileWidth, tileHeight, translationHelper1.GetTranslation("main_menu_add_user"), () => {
                Extensions.RunInAnotherThread(() => Application.Run(new Forms.Users.ModifyUserForm().WithAction(Backend.Objects.UserAction.Action.CreateUser)));
            });

            layoutPanel.Controls.Add(addUserTile);

            form.Location = tilePanelReborn2.PointToScreen(new Point(-FormPadding, -FormPadding));

            int wIncrement = finalWidth % 2 == 0 ? 8 : 15;
            form.Load += (s, ee) => {
                var anim = new Animation().WithAction((a) => {
                    form.InvokeIfRequired(() => {
                        if (form.Width < finalWidth) {
                            form.Width += wIncrement;
                            return;
                        }
                        a.Stop();
                        form.Controls.Add(layoutPanel);
                    });

                }).WithDisposal(form);
                anim.Start();
            };

            form.Deactivate += (s, ee) => {
                form.Dispose();
            };
            form.Show();
        }

        private TilePanelReborn GenerateActionTile(int tileWidth, int tileHeight, string text, Action clickAction, Image img = null)
        {
            TilePanelReborn tile = new TilePanelReborn
            {
                Text = text,
                Size = new Size(tileWidth, tileHeight),
                Image = img,
                BackColor = ColorScheme.PrimaryColor,
                ForeColor = ColorScheme.ForegroundColor,
            };
            tile.Click += (s, e) => tile.InvokeIfRequired(() => clickAction?.Invoke());
            return tile;

        }
    }
}