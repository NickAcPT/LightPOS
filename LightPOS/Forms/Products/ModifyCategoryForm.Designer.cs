namespace NickAc.LightPOS.Frontend.Forms.Products
{
    partial class ModifyCategoryForm
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
            this.metroButton1 = new NickAc.ModernUIDoneRight.Controls.ModernButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.simpleSelectionControl1 = new NickAc.LightPOS.Frontend.Controls.SimpleSelectionControl();
            this.percentageUpDown1 = new NickAc.LightPOS.Frontend.Controls.PercentageUpDown();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new NickAc.LightPOS.Frontend.Controls.TextBoxEx();
            this.translationHelper1 = new NickAc.LightPOS.Backend.Translation.TranslationHelper();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.percentageUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // appBar1
            // 
            this.appBar1.Location = new System.Drawing.Point(1, 1);
            this.appBar1.Size = new System.Drawing.Size(759, 50);
            this.translationHelper1.SetTranslationLocation(this.appBar1, "");
            // 
            // metroButton1
            // 
            this.metroButton1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.metroButton1.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.metroButton1.Location = new System.Drawing.Point(177, 192);
            this.metroButton1.Name = "metroButton1";
            this.metroButton1.Size = new System.Drawing.Size(210, 42);
            this.metroButton1.TabIndex = 17;
            this.metroButton1.Text = "add_cat_okbutton";
            this.translationHelper1.SetTranslationLocation(this.metroButton1, "add_cat_okbutton");
            this.metroButton1.UseVisualStyleBackColor = true;
            this.metroButton1.Click += new System.EventHandler(this.MetroButton1_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel1.Controls.Add(this.simpleSelectionControl1);
            this.panel1.Controls.Add(this.metroButton1);
            this.panel1.Controls.Add(this.percentageUpDown1);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.panel1.Location = new System.Drawing.Point(98, 124);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(565, 236);
            this.panel1.TabIndex = 18;
            this.translationHelper1.SetTranslationLocation(this.panel1, "");
            // 
            // simpleSelectionControl1
            // 
            this.simpleSelectionControl1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.simpleSelectionControl1.Location = new System.Drawing.Point(9, 93);
            this.simpleSelectionControl1.Name = "simpleSelectionControl1";
            this.simpleSelectionControl1.OptionEnum = null;
            this.simpleSelectionControl1.SelectedEnumValue = null;
            this.simpleSelectionControl1.SelectedItemBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.simpleSelectionControl1.Size = new System.Drawing.Size(267, 34);
            this.simpleSelectionControl1.TabIndex = 19;
            this.simpleSelectionControl1.Text = "simpleSelectionControl1";
            this.translationHelper1.SetTranslationLocation(this.simpleSelectionControl1, "");
            // 
            // percentageUpDown1
            // 
            this.percentageUpDown1.Location = new System.Drawing.Point(11, 136);
            this.percentageUpDown1.Name = "percentageUpDown1";
            this.percentageUpDown1.Size = new System.Drawing.Size(265, 29);
            this.percentageUpDown1.TabIndex = 18;
            this.translationHelper1.SetTranslationLocation(this.percentageUpDown1, "");
            this.percentageUpDown1.Value = 0.23D;
            this.percentageUpDown1.Visible = false;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Location = new System.Drawing.Point(358, 96);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(29, 29);
            this.panel2.TabIndex = 17;
            this.translationHelper1.SetTranslationLocation(this.panel2, "");
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label4.Location = new System.Drawing.Point(354, 72);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(105, 21);
            this.label4.TabIndex = 8;
            this.label4.Text = "edit_cat_color";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.translationHelper1.SetTranslationLocation(this.label4, "edit_cat_color");
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label3.Location = new System.Drawing.Point(7, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 21);
            this.label3.TabIndex = 8;
            this.label3.Text = "edit_cat_tax";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.translationHelper1.SetTranslationLocation(this.label3, "edit_cat_tax");
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label1.Location = new System.Drawing.Point(7, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 21);
            this.label1.TabIndex = 8;
            this.label1.Text = "edit_cat_name";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.translationHelper1.SetTranslationLocation(this.label1, "edit_cat_name");
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.textBox1.Location = new System.Drawing.Point(10, 31);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(542, 29);
            this.textBox1.TabIndex = 10;
            this.translationHelper1.SetTranslationLocation(this.textBox1, "");
            // 
            // ModifyCategoryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(761, 441);
            this.ColorScheme.PrimaryColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(119)))), ((int)(((byte)(189)))));
            this.ColorScheme.SecondaryColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(75)))), ((int)(((byte)(120)))));
            this.Controls.Add(this.panel1);
            this.Name = "ModifyCategoryForm";
            this.Text = "add_cat_title";
            this.TitlebarVisible = false;
            this.translationHelper1.SetTranslationLocation(this, "add_cat_title");
            this.Controls.SetChildIndex(this.appBar1, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.percentageUpDown1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ModernUIDoneRight.Controls.ModernButton metroButton1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private Controls.TextBoxEx textBox1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private Controls.PercentageUpDown percentageUpDown1;
        private Backend.Translation.TranslationHelper translationHelper1;
        private Controls.SimpleSelectionControl simpleSelectionControl1;
    }
}