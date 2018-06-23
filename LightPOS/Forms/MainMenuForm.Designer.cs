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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainMenuForm));
            this.translationHelper1 = new NickAc.LightPOS.Backend.Translation.TranslationHelper();
            this.tilePanelReborn1 = new NickAc.ModernUIDoneRight.Controls.TilePanelReborn();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tilePanelReborn2 = new NickAc.ModernUIDoneRight.Controls.TilePanelReborn();
            this.label2 = new System.Windows.Forms.Label();
            this.shadedPanel1 = new NickAc.LightPOS.Frontend.Controls.OuterShadowPanel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            this.shadedPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // appBar1
            // 
            this.appBar1.Location = new System.Drawing.Point(1, 1);
            this.appBar1.Size = new System.Drawing.Size(784, 50);
            this.appBar1.Text = "MainMenuForm";
            this.translationHelper1.SetTranslationLocation(this.appBar1, "");
            // 
            // tilePanelReborn1
            // 
            this.tilePanelReborn1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(193)))));
            this.tilePanelReborn1.BrandedTile = false;
            this.tilePanelReborn1.CanBeHovered = true;
            this.tilePanelReborn1.Checkable = false;
            this.tilePanelReborn1.Flat = true;
            this.tilePanelReborn1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.tilePanelReborn1.ForeColor = System.Drawing.Color.White;
            this.tilePanelReborn1.Image = ((System.Drawing.Image)(resources.GetObject("tilePanelReborn1.Image")));
            this.tilePanelReborn1.Location = new System.Drawing.Point(7, 36);
            this.tilePanelReborn1.Name = "tilePanelReborn1";
            this.tilePanelReborn1.Size = new System.Drawing.Size(298, 145);
            this.tilePanelReborn1.TabIndex = 1;
            this.tilePanelReborn1.Text = "openLightPOSTile";
            this.translationHelper1.SetTranslationLocation(this.tilePanelReborn1, "main_menu_openLightPOSTile");
            this.tilePanelReborn1.Click += new System.EventHandler(this.tilePanelReborn1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI Light", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(1, 1);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "labelMain";
            this.translationHelper1.SetTranslationLocation(this.label1, "main_menu_labelMain");
            // 
            // panel2
            // 
            this.panel2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel2.Controls.Add(this.tilePanelReborn2);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.tilePanelReborn1);
            this.panel2.Location = new System.Drawing.Point(24, 156);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(739, 190);
            this.panel2.TabIndex = 2;
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
            this.tilePanelReborn2.Image = global::NickAc.LightPOS.Frontend.Properties.Resources.ic_person_white_48dp_2x;
            this.tilePanelReborn2.Location = new System.Drawing.Point(432, 36);
            this.tilePanelReborn2.Name = "tilePanelReborn2";
            this.tilePanelReborn2.Size = new System.Drawing.Size(298, 145);
            this.tilePanelReborn2.TabIndex = 5;
            this.tilePanelReborn2.Text = "posManagementTile";
            this.translationHelper1.SetTranslationLocation(this.tilePanelReborn2, "main_menu_pos_management");
            this.tilePanelReborn2.Click += new System.EventHandler(this.TilePanelReborn2_Click_1);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Segoe UI Light", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(426, 1);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(196, 32);
            this.label2.TabIndex = 4;
            this.label2.Text = "labelManagement";
            this.translationHelper1.SetTranslationLocation(this.label2, "main_menu_labelManagement");
            // 
            // shadedPanel1
            // 
            this.shadedPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.shadedPanel1.Controls.Add(this.pictureBox1);
            this.shadedPanel1.Controls.Add(this.label3);
            this.shadedPanel1.Location = new System.Drawing.Point(558, 67);
            this.shadedPanel1.Name = "shadedPanel1";
            this.shadedPanel1.OldEngine = false;
            this.shadedPanel1.Size = new System.Drawing.Size(215, 50);
            this.shadedPanel1.TabIndex = 3;
            this.translationHelper1.SetTranslationLocation(this.shadedPanel1, "");
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::NickAc.LightPOS.Frontend.Properties.Resources.alert_circle;
            this.pictureBox1.Location = new System.Drawing.Point(11, 13);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(25, 25);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            this.translationHelper1.SetTranslationLocation(this.pictureBox1, "");
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(38, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(165, 15);
            this.label3.TabIndex = 0;
            this.label3.Text = "Beta version. Use with caution";
            this.translationHelper1.SetTranslationLocation(this.label3, "main_menu_warning");
            // 
            // MainMenuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(246)))));
            this.ClientSize = new System.Drawing.Size(786, 478);
            this.ColorScheme.MouseDownColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(64)))), ((int)(((byte)(101)))));
            this.ColorScheme.MouseHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(100)))), ((int)(((byte)(158)))));
            this.ColorScheme.PrimaryColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(119)))), ((int)(((byte)(189)))));
            this.ColorScheme.SecondaryColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(75)))), ((int)(((byte)(120)))));
            this.Controls.Add(this.shadedPanel1);
            this.Controls.Add(this.panel2);
            this.Name = "MainMenuForm";
            this.Text = "MainMenuForm";
            this.TitlebarVisible = false;
            this.translationHelper1.SetTranslationLocation(this, "main_menu_title");
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MainMenuForm_Load);
            this.Controls.SetChildIndex(this.appBar1, 0);
            this.Controls.SetChildIndex(this.panel2, 0);
            this.Controls.SetChildIndex(this.shadedPanel1, 0);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.shadedPanel1.ResumeLayout(false);
            this.shadedPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Backend.Translation.TranslationHelper translationHelper1;
        private System.Windows.Forms.Label label1;
        private ModernUIDoneRight.Controls.TilePanelReborn tilePanelReborn1;
        private System.Windows.Forms.Panel panel2;
        private ModernUIDoneRight.Controls.TilePanelReborn tilePanelReborn2;
        private System.Windows.Forms.Label label2;
        private Controls.OuterShadowPanel shadedPanel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}