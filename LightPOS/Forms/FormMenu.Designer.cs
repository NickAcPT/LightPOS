namespace NickAc.LightPOS.Frontend.Forms
{
    partial class FormMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMenu));
            this.appBar1 = new NickAc.ModernUIDoneRight.Controls.AppBar();
            this.translationHelper1 = new NickAc.LightPOS.Backend.Translation.TranslationHelper();
            this.SuspendLayout();
            // 
            // appBar1
            // 
            this.appBar1.Dock = System.Windows.Forms.DockStyle.Top;
            this.appBar1.IconVisible = true;
            this.appBar1.Location = new System.Drawing.Point(1, 33);
            this.appBar1.Name = "appBar1";
            this.appBar1.Size = new System.Drawing.Size(679, 50);
            this.appBar1.TabIndex = 0;
            this.appBar1.Text = "appBar1";
            this.appBar1.TextFont = new System.Drawing.Font("Segoe UI", 14F);
            this.translationHelper1.SetTranslationLocation(this.appBar1, "");
            // 
            // FormMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(681, 459);
            this.ColorScheme.PrimaryColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(158)))), ((int)(((byte)(158)))));
            this.ColorScheme.SecondaryColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(112)))), ((int)(((byte)(112)))));
            this.Controls.Add(this.appBar1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Location = new System.Drawing.Point(0, 0);
            this.MinimumSize = new System.Drawing.Size(96, 39);
            this.Name = "FormMenu";
            this.Text = "LightPOS - Menu";
            this.translationHelper1.SetTranslationLocation(this, "main_menu");
            this.ResumeLayout(false);

        }

        #endregion

        private ModernUIDoneRight.Controls.AppBar appBar1;
        private Backend.Translation.TranslationHelper translationHelper1;
    }
}