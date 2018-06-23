namespace NickAc.LightPOS.Frontend.Forms.POS
{
    partial class PointOfSaleForm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this._nickCustomTabControl1 = new NickAc.LightPOS.Frontend.Controls.NickCustomTabControl();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.listBox1 = new NickAc.LightPOS.Frontend.Controls.ListBoxNoFlicker();
            this.modernButton1 = new NickAc.ModernUIDoneRight.Controls.ModernButton();
            this.translationHelper1 = new NickAc.LightPOS.Backend.Translation.TranslationHelper();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // appBar1
            // 
            this.appBar1.ColorScheme = this.ColorScheme;
            this.appBar1.Location = new System.Drawing.Point(1, 1);
            this.appBar1.Size = new System.Drawing.Size(878, 50);
            this.appBar1.Text = "PointOfSaleForm";
            this.translationHelper1.SetTranslationLocation(this.appBar1, "");
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(1, 51);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(5, 10, 5, 5);
            this.panel1.Size = new System.Drawing.Size(878, 456);
            this.panel1.TabIndex = 1;
            this.translationHelper1.SetTranslationLocation(this.panel1, "");
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this._nickCustomTabControl1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(332, 10);
            this.panel3.Name = "panel3";
            this.panel3.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.panel3.Size = new System.Drawing.Size(541, 441);
            this.panel3.TabIndex = 3;
            this.translationHelper1.SetTranslationLocation(this.panel3, "");
            // 
            // _nickCustomTabControl1
            // 
            this._nickCustomTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this._nickCustomTabControl1.DrawHandler = null;
            this._nickCustomTabControl1.Location = new System.Drawing.Point(8, 0);
            this._nickCustomTabControl1.Name = "_nickCustomTabControl1";
            this._nickCustomTabControl1.SelectedIndex = 0;
            this._nickCustomTabControl1.Size = new System.Drawing.Size(533, 441);
            this._nickCustomTabControl1.TabIndex = 4;
            this.translationHelper1.SetTranslationLocation(this._nickCustomTabControl1, "");
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(5, 10);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(327, 441);
            this.panel2.TabIndex = 2;
            this.translationHelper1.SetTranslationLocation(this.panel2, "");
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.panel5);
            this.panel4.Controls.Add(this.modernButton1);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(327, 441);
            this.panel4.TabIndex = 0;
            this.translationHelper1.SetTranslationLocation(this.panel4, "");
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.listBox1);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Padding = new System.Windows.Forms.Padding(0, 0, 0, 8);
            this.panel5.Size = new System.Drawing.Size(327, 384);
            this.panel5.TabIndex = 1;
            this.translationHelper1.SetTranslationLocation(this.panel5, "");
            // 
            // listBox1
            // 
            this.listBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.IntegralHeight = false;
            this.listBox1.ItemHeight = 15;
            this.listBox1.Location = new System.Drawing.Point(0, 0);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(327, 376);
            this.listBox1.TabIndex = 1;
            this.translationHelper1.SetTranslationLocation(this.listBox1, "");
            // 
            // modernButton1
            // 
            this.modernButton1.ColorScheme = this.ColorScheme;
            this.modernButton1.CustomColorScheme = false;
            this.modernButton1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.modernButton1.Location = new System.Drawing.Point(0, 384);
            this.modernButton1.Name = "modernButton1";
            this.modernButton1.Size = new System.Drawing.Size(327, 57);
            this.modernButton1.TabIndex = 0;
            this.modernButton1.Text = "modernButton1";
            this.translationHelper1.SetTranslationLocation(this.modernButton1, "pos_screen_perform_sale");
            this.modernButton1.UseVisualStyleBackColor = true;
            this.modernButton1.Click += new System.EventHandler(this.modernButton1_Click);
            // 
            // PointOfSaleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(246)))));
            this.ClientSize = new System.Drawing.Size(880, 508);
            this.ColorScheme.MouseDownColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(64)))), ((int)(((byte)(101)))));
            this.ColorScheme.MouseHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(100)))), ((int)(((byte)(158)))));
            this.ColorScheme.PrimaryColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(119)))), ((int)(((byte)(189)))));
            this.ColorScheme.SecondaryColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(75)))), ((int)(((byte)(120)))));
            this.Controls.Add(this.panel1);
            this.Name = "PointOfSaleForm";
            this.Text = "PointOfSaleForm";
            this.TitlebarVisible = false;
            this.translationHelper1.SetTranslationLocation(this, "pos_screen_title");
            this.Controls.SetChildIndex(this.appBar1, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Backend.Translation.TranslationHelper translationHelper1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private Controls.NickCustomTabControl _nickCustomTabControl1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
        private NickAc.LightPOS.Frontend.Controls.ListBoxNoFlicker listBox1;
        private ModernUIDoneRight.Controls.ModernButton modernButton1;
    }
}