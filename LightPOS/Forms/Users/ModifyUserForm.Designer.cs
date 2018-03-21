namespace NickAc.LightPOS.Frontend.Forms.Users
{
    partial class ModifyUserForm
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
            this.textBox1 = new NickAc.LightPOS.Frontend.Controls.TextBoxEx();
            this.textBoxEx1 = new NickAc.LightPOS.Frontend.Controls.TextBoxEx();
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.metroButton1 = new NickAc.ModernUIDoneRight.Controls.ModernButton();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // appBar1
            // 
            this.appBar1.Location = new System.Drawing.Point(1, 1);
            this.appBar1.Size = new System.Drawing.Size(956, 50);
            this.appBar1.TabIndex = 1;
            this.appBar1.TabStop = false;
            this.translationHelper1.SetTranslationLocation(this.appBar1, "");
            // 
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.textBoxEx1);
            this.panel1.Controls.Add(this.checkedListBox1);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.metroButton1);
            this.panel1.Location = new System.Drawing.Point(154, 79);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(651, 422);
            this.panel1.TabIndex = 0;
            this.translationHelper1.SetTranslationLocation(this.panel1, "");
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.textBox1.Location = new System.Drawing.Point(12, 27);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(629, 29);
            this.textBox1.TabIndex = 1;
            this.translationHelper1.SetTranslationLocation(this.textBox1, "");
            // 
            // textBoxEx1
            // 
            this.textBoxEx1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxEx1.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.textBoxEx1.Location = new System.Drawing.Point(12, 79);
            this.textBoxEx1.Name = "textBoxEx1";
            this.textBoxEx1.Size = new System.Drawing.Size(629, 29);
            this.textBoxEx1.TabIndex = 3;
            this.translationHelper1.SetTranslationLocation(this.textBoxEx1, "");
            this.textBoxEx1.UseSystemPasswordChar = true;
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.checkedListBox1.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.HorizontalScrollbar = true;
            this.checkedListBox1.IntegralHeight = false;
            this.checkedListBox1.Location = new System.Drawing.Point(12, 135);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(629, 228);
            this.checkedListBox1.TabIndex = 5;
            this.translationHelper1.SetTranslationLocation(this.checkedListBox1, "");
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label3.Location = new System.Drawing.Point(8, 55);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(147, 21);
            this.label3.TabIndex = 2;
            this.label3.Text = "edit_user_password";
            this.label3.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.translationHelper1.SetTranslationLocation(this.label3, "edit_user_password");
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label2.Location = new System.Drawing.Point(8, 111);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(164, 21);
            this.label2.TabIndex = 4;
            this.label2.Text = "edit_user_permissions";
            this.label2.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.translationHelper1.SetTranslationLocation(this.label2, "edit_user_permissions");
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label1.Location = new System.Drawing.Point(8, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "edit_user_name";
            this.label1.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.translationHelper1.SetTranslationLocation(this.label1, "edit_user_name");
            // 
            // metroButton1
            // 
            this.metroButton1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.metroButton1.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.metroButton1.Location = new System.Drawing.Point(224, 369);
            this.metroButton1.Name = "metroButton1";
            this.metroButton1.Size = new System.Drawing.Size(202, 47);
            this.metroButton1.TabIndex = 6;
            this.metroButton1.Text = "create_user_okbutton";
            this.translationHelper1.SetTranslationLocation(this.metroButton1, "create_user_okbutton");
            this.metroButton1.UseVisualStyleBackColor = true;
            this.metroButton1.Click += new System.EventHandler(this.MetroButton1_Click);
            // 
            // ModifyUserForm
            // 
            this.AcceptButton = this.metroButton1;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(958, 530);
            this.ColorScheme.PrimaryColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(119)))), ((int)(((byte)(189)))));
            this.ColorScheme.SecondaryColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(75)))), ((int)(((byte)(120)))));
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.MinimumSize = new System.Drawing.Size(645, 365);
            this.Name = "ModifyUserForm";
            this.Text = "ModifyUserForm";
            this.TitlebarVisible = false;
            this.translationHelper1.SetTranslationLocation(this, "edit_user_title");
            this.Controls.SetChildIndex(this.appBar1, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Backend.Translation.TranslationHelper translationHelper1;
        private System.Windows.Forms.Panel panel1;
        private Controls.TextBoxEx textBox1;
        private Controls.TextBoxEx textBoxEx1;
        private System.Windows.Forms.CheckedListBox checkedListBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private ModernUIDoneRight.Controls.ModernButton metroButton1;
    }
}