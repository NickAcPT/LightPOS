namespace NickAc.LightPOS.Frontend.Forms
{
    partial class MainMenuForm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.tilePanelReborn2 = new NickAc.ModernUIDoneRight.Controls.TilePanelReborn();
            this.label2 = new System.Windows.Forms.Label();
            this.tilePanelReborn1 = new NickAc.ModernUIDoneRight.Controls.TilePanelReborn();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.tilePanelReborn2);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.tilePanelReborn1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(13, 101);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(852, 344);
            this.panel1.TabIndex = 1;
            this.translationHelper1.SetTranslationLocation(this.panel1, "");
            // 
            // tilePanelReborn2
            // 
            this.tilePanelReborn2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(108)))), ((int)(((byte)(0)))));
            this.tilePanelReborn2.BrandedTile = false;
            this.tilePanelReborn2.CanBeHovered = true;
            this.tilePanelReborn2.Checkable = false;
            this.tilePanelReborn2.Flat = false;
            this.tilePanelReborn2.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.tilePanelReborn2.ForeColor = System.Drawing.Color.White;
            this.tilePanelReborn2.Image = global::NickAc.LightPOS.Frontend.Properties.Resources.tilePanel3_Image;
            this.tilePanelReborn2.Location = new System.Drawing.Point(368, 68);
            this.tilePanelReborn2.Name = "tilePanelReborn2";
            this.tilePanelReborn2.Size = new System.Drawing.Size(222, 109);
            this.tilePanelReborn2.TabIndex = 1;
            this.tilePanelReborn2.Text = "posManagementTile";
            this.translationHelper1.SetTranslationLocation(this.tilePanelReborn2, "main_menu_pos_management");
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.label2.Location = new System.Drawing.Point(363, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(165, 25);
            this.label2.TabIndex = 0;
            this.label2.Text = "labelManagement";
            this.translationHelper1.SetTranslationLocation(this.label2, "main_menu_labelManagement");
            // 
            // tilePanelReborn1
            // 
            this.tilePanelReborn1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(119)))), ((int)(((byte)(189)))));
            this.tilePanelReborn1.BrandedTile = false;
            this.tilePanelReborn1.CanBeHovered = true;
            this.tilePanelReborn1.Checkable = false;
            this.tilePanelReborn1.Flat = false;
            this.tilePanelReborn1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.tilePanelReborn1.ForeColor = System.Drawing.Color.White;
            this.tilePanelReborn1.Image = global::NickAc.LightPOS.Frontend.Properties.Resources.lightpos;
            this.tilePanelReborn1.Location = new System.Drawing.Point(48, 68);
            this.tilePanelReborn1.Name = "tilePanelReborn1";
            this.tilePanelReborn1.Size = new System.Drawing.Size(222, 109);
            this.tilePanelReborn1.TabIndex = 1;
            this.tilePanelReborn1.Text = "openLightPOSTile";
            this.translationHelper1.SetTranslationLocation(this.tilePanelReborn1, "main_menu_openLightPOSTile");
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.label1.Location = new System.Drawing.Point(43, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "labelMain";
            this.translationHelper1.SetTranslationLocation(this.label1, "main_menu_labelMain");
            // 
            // MainMenuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(878, 458);
            this.ColorScheme.PrimaryColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(119)))), ((int)(((byte)(189)))));
            this.ColorScheme.SecondaryColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(75)))), ((int)(((byte)(120)))));
            this.Controls.Add(this.panel1);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "MainMenuForm";
            this.Text = "MainMenuForm";
            this.translationHelper1.SetTranslationLocation(this, "main_menu_title");
            this.Controls.SetChildIndex(this.panel1, 0);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Backend.Translation.TranslationHelper translationHelper1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private ModernUIDoneRight.Controls.TilePanelReborn tilePanelReborn1;
        private ModernUIDoneRight.Controls.TilePanelReborn tilePanelReborn2;
        private System.Windows.Forms.Label label2;
    }
}