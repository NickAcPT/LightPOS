namespace NickAc.LightPOS.Frontend.Forms
{
    partial class ManagementForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.translationHelper1 = new NickAc.LightPOS.Backend.Translation.TranslationHelper();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tilePanelReborn2 = new NickAc.ModernUIDoneRight.Controls.TilePanelReborn();
            this.label2 = new System.Windows.Forms.Label();
            this.tilePanelReborn3 = new NickAc.ModernUIDoneRight.Controls.TilePanelReborn();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // appBar1
            // 
            this.appBar1.Location = new System.Drawing.Point(1, 1);
            this.appBar1.Size = new System.Drawing.Size(774, 50);
            this.translationHelper1.SetTranslationLocation(this.appBar1, "");
            // 
            // panel2
            // 
            this.panel2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel2.Controls.Add(this.tilePanelReborn3);
            this.panel2.Controls.Add(this.tilePanelReborn2);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Location = new System.Drawing.Point(246, 73);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(280, 302);
            this.panel2.TabIndex = 3;
            this.translationHelper1.SetTranslationLocation(this.panel2, "");
            // 
            // tilePanelReborn2
            // 
            this.tilePanelReborn2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(108)))), ((int)(((byte)(0)))));
            this.tilePanelReborn2.BrandedTile = false;
            this.tilePanelReborn2.CanBeHovered = true;
            this.tilePanelReborn2.Checkable = false;
            this.tilePanelReborn2.Flat = true;
            this.tilePanelReborn2.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.tilePanelReborn2.ForeColor = System.Drawing.Color.White;
            this.tilePanelReborn2.Image = global::NickAc.LightPOS.Frontend.Properties.Resources.account_plus;
            this.tilePanelReborn2.Location = new System.Drawing.Point(144, 36);
            this.tilePanelReborn2.Name = "tilePanelReborn2";
            this.tilePanelReborn2.Size = new System.Drawing.Size(129, 122);
            this.tilePanelReborn2.TabIndex = 5;
            this.tilePanelReborn2.Text = "main_menu_edit_user";
            this.translationHelper1.SetTranslationLocation(this.tilePanelReborn2, "main_menu_edit_user");
            this.tilePanelReborn2.Click += new System.EventHandler(this.tilePanelReborn2_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Segoe UI Light", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 1);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(196, 32);
            this.label2.TabIndex = 4;
            this.label2.Text = "labelManagement";
            this.translationHelper1.SetTranslationLocation(this.label2, "main_menu_labelManagement");
            // 
            // tilePanelReborn3
            // 
            this.tilePanelReborn3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(193)))));
            this.tilePanelReborn3.BrandedTile = false;
            this.tilePanelReborn3.CanBeHovered = true;
            this.tilePanelReborn3.Checkable = false;
            this.tilePanelReborn3.Flat = true;
            this.tilePanelReborn3.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.tilePanelReborn3.ForeColor = System.Drawing.Color.White;
            this.tilePanelReborn3.Image = global::NickAc.LightPOS.Frontend.Properties.Resources.account_plus;
            this.tilePanelReborn3.Location = new System.Drawing.Point(9, 36);
            this.tilePanelReborn3.Name = "tilePanelReborn3";
            this.tilePanelReborn3.Size = new System.Drawing.Size(129, 122);
            this.tilePanelReborn3.TabIndex = 5;
            this.tilePanelReborn3.Text = "main_menu_add_user";
            this.translationHelper1.SetTranslationLocation(this.tilePanelReborn3, "");
            this.tilePanelReborn3.Click += new System.EventHandler(this.tilePanelReborn3_Click);
            // 
            // ManagementForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(776, 448);
            this.ColorScheme.PrimaryColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(119)))), ((int)(((byte)(189)))));
            this.ColorScheme.SecondaryColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(75)))), ((int)(((byte)(120)))));
            this.Controls.Add(this.panel2);
            this.Name = "ManagementForm";
            this.Text = "ManagementForm";
            this.TitlebarVisible = false;
            this.translationHelper1.SetTranslationLocation(this, "");
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Controls.SetChildIndex(this.appBar1, 0);
            this.Controls.SetChildIndex(this.panel2, 0);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Backend.Translation.TranslationHelper translationHelper1;
        private System.Windows.Forms.Panel panel2;
        private ModernUIDoneRight.Controls.TilePanelReborn tilePanelReborn2;
        private System.Windows.Forms.Label label2;
        private ModernUIDoneRight.Controls.TilePanelReborn tilePanelReborn3;
    }
}