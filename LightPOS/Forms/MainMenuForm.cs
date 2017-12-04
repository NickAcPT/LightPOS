//
// Copyright (c) NickAc. All rights reserved.
// Licensed under the MIT License. See LICENSE file in the project root for full license information.
//
using NickAc.LightPOS.Backend.Utils;
using NickAc.ModernUIDoneRight.Forms;
using System.Drawing;

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
                MinimumSize = new Size(3, 3),
                Size = new Size(0, tilePanelReborn2.Size.Height + FormPadding * 2),
                TitlebarVisible = false,
            };
            form.Location = tilePanelReborn2.PointToScreen(new Point(-FormPadding, -FormPadding));

            int wIncrement = finalWidth % 2 == 0 ? 6 : 9;
            form.Load += (s, ee) => {
                var anim = new Animation().WithAction((a) => {
                    form.InvokeIfRequired(() => {
                        if (form.Width < finalWidth) {
                            form.Width += wIncrement;
                            return;
                        }
                        a.Stop();
                    });
                    
                });
                anim.Start();
            };

            form.ShowDialog();
        }
    }
}