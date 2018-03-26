using System.ComponentModel;
using System.Windows.Forms;
using NickAc.LightPOS.Backend.Translation;
using NickAc.LightPOS.Frontend.Controls;
using NickAc.ModernUIDoneRight.Controls;

namespace NickAc.LightPOS.Frontend.Forms.Products
{
    partial class ModifyProductForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

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
            this.textBox1 = new NickAc.LightPOS.Frontend.Controls.TextBoxEx();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.metroButton1 = new NickAc.ModernUIDoneRight.Controls.ModernButton();
            this.translationHelper1 = new NickAc.LightPOS.Backend.Translation.TranslationHelper();
            this.modernButton2 = new NickAc.ModernUIDoneRight.Controls.ModernButton();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.textBoxEx1 = new NickAc.LightPOS.Frontend.Controls.TextBoxEx();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxEx2 = new NickAc.LightPOS.Frontend.Controls.TextBoxEx();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // appBar1
            // 
            this.appBar1.Location = new System.Drawing.Point(1, 1);
            this.appBar1.Size = new System.Drawing.Size(755, 50);
            this.appBar1.TabStop = false;
            this.translationHelper1.SetTranslationLocation(this.appBar1, "");
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.textBox1.Location = new System.Drawing.Point(10, 31);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(542, 29);
            this.textBox1.TabIndex = 1;
            this.translationHelper1.SetTranslationLocation(this.textBox1, "");
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label3.Location = new System.Drawing.Point(7, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(139, 21);
            this.label3.TabIndex = 2;
            this.label3.Text = "edit_prod_barcode";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.translationHelper1.SetTranslationLocation(this.label3, "edit_prod_barcode");
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label1.Location = new System.Drawing.Point(7, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(122, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "edit_prod_name";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.translationHelper1.SetTranslationLocation(this.label1, "edit_prod_name");
            // 
            // metroButton1
            // 
            this.metroButton1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.metroButton1.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.metroButton1.Location = new System.Drawing.Point(177, 192);
            this.metroButton1.Name = "metroButton1";
            this.metroButton1.Size = new System.Drawing.Size(210, 42);
            this.metroButton1.TabIndex = 9;
            this.metroButton1.Text = "add_prod_okbutton";
            this.translationHelper1.SetTranslationLocation(this.metroButton1, "edit_prod_okbutton");
            this.metroButton1.UseVisualStyleBackColor = true;
            this.metroButton1.Click += new System.EventHandler(this.MetroButton1_Click);
            // 
            // modernButton2
            // 
            this.modernButton2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.modernButton2.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.modernButton2.Location = new System.Drawing.Point(524, 150);
            this.modernButton2.Name = "modernButton2";
            this.modernButton2.Size = new System.Drawing.Size(28, 29);
            this.modernButton2.TabIndex = 8;
            this.modernButton2.Text = "+";
            this.translationHelper1.SetTranslationLocation(this.modernButton2, "");
            this.modernButton2.UseVisualStyleBackColor = true;
            this.modernButton2.Click += new System.EventHandler(this.ModernButton2_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label2.Location = new System.Drawing.Point(7, 128);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(143, 21);
            this.label2.TabIndex = 6;
            this.label2.Text = "edit_prod_category";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.translationHelper1.SetTranslationLocation(this.label2, "edit_prod_category");
            // 
            // comboBox2
            // 
            this.comboBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox2.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(10, 150);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(508, 29);
            this.comboBox2.TabIndex = 7;
            this.translationHelper1.SetTranslationLocation(this.comboBox2, "");
            // 
            // textBoxEx1
            // 
            this.textBoxEx1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxEx1.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.textBoxEx1.Location = new System.Drawing.Point(10, 89);
            this.textBoxEx1.Name = "textBoxEx1";
            this.textBoxEx1.Size = new System.Drawing.Size(269, 29);
            this.textBoxEx1.TabIndex = 3;
            this.translationHelper1.SetTranslationLocation(this.textBoxEx1, "");
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label4.Location = new System.Drawing.Point(314, 67);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(144, 21);
            this.label4.TabIndex = 4;
            this.label4.Text = "edit_prod_unitprice";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.translationHelper1.SetTranslationLocation(this.label4, "edit_prod_unitprice");
            // 
            // textBoxEx2
            // 
            this.textBoxEx2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxEx2.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.textBoxEx2.Location = new System.Drawing.Point(317, 89);
            this.textBoxEx2.Name = "textBoxEx2";
            this.textBoxEx2.Size = new System.Drawing.Size(202, 29);
            this.textBoxEx2.TabIndex = 5;
            this.translationHelper1.SetTranslationLocation(this.textBoxEx2, "");
            // 
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.metroButton1);
            this.panel1.Controls.Add(this.modernButton2);
            this.panel1.Controls.Add(this.comboBox2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.textBoxEx2);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.textBoxEx1);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.panel1.Location = new System.Drawing.Point(96, 121);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(565, 242);
            this.panel1.TabIndex = 1;
            this.translationHelper1.SetTranslationLocation(this.panel1, "");
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::NickAc.LightPOS.Frontend.Properties.Resources.alert_circle;
            this.pictureBox1.Location = new System.Drawing.Point(281, 89);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(29, 29);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 10;
            this.pictureBox1.TabStop = false;
            this.translationHelper1.SetTranslationLocation(this.pictureBox1, "");
            this.pictureBox1.Visible = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::NickAc.LightPOS.Frontend.Properties.Resources.alert_circle;
            this.pictureBox2.Location = new System.Drawing.Point(523, 89);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(29, 29);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 11;
            this.pictureBox2.TabStop = false;
            this.translationHelper1.SetTranslationLocation(this.pictureBox2, "");
            this.pictureBox2.Visible = false;
            // 
            // ModifyProductForm
            // 
            this.AcceptButton = this.metroButton1;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(757, 451);
            this.ColorScheme.PrimaryColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(119)))), ((int)(((byte)(189)))));
            this.ColorScheme.SecondaryColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(75)))), ((int)(((byte)(120)))));
            this.Controls.Add(this.panel1);
            this.Name = "ModifyProductForm";
            this.Text = "FormModifyProduct";
            this.TitlebarVisible = false;
            this.translationHelper1.SetTranslationLocation(this, "add_prod_title");
            this.Controls.SetChildIndex(this.appBar1, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private TranslationHelper translationHelper1;
        private TextBoxEx textBox1;
        private Label label3;
        private Label label1;
        private ModernButton metroButton1;
        private ModernButton modernButton2;
        private Label label2;
        private ComboBox comboBox2;
        private TextBoxEx textBoxEx1;
        private Label label4;
        private TextBoxEx textBoxEx2;
        private Panel panel1;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
    }
}