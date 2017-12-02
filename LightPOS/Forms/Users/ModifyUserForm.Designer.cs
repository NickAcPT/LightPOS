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
            this.metroButton1 = new NickAc.ModernUIDoneRight.Controls.ModernButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.translationHelper1 = new NickAc.LightPOS.Backend.Translation.TranslationHelper();
            this.textBoxEx1 = new NickAc.LightPOS.Frontend.Controls.TextBoxEx();
            this.textBox1 = new NickAc.LightPOS.Frontend.Controls.TextBoxEx();
            this.SuspendLayout();
            // 
            // appBar1
            // 
            this.appBar1.Size = new System.Drawing.Size(643, 50);
            this.appBar1.TabStop = false;
            this.translationHelper1.SetTranslationLocation(this.appBar1, "");
            // 
            // metroButton1
            // 
            this.metroButton1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.metroButton1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.metroButton1.Location = new System.Drawing.Point(224, 285);
            this.metroButton1.Name = "metroButton1";
            this.metroButton1.Size = new System.Drawing.Size(197, 47);
            this.metroButton1.TabIndex = 7;
            this.metroButton1.Text = "create_user_okbutton";
            this.translationHelper1.SetTranslationLocation(this.metroButton1, "create_user_okbutton");
            this.metroButton1.UseVisualStyleBackColor = true;
            this.metroButton1.Click += new System.EventHandler(this.MetroButton1_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.label1.Location = new System.Drawing.Point(13, 101);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 27);
            this.label1.TabIndex = 1;
            this.label1.Text = "edit_user_name";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.translationHelper1.SetTranslationLocation(this.label1, "edit_user_name");
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.label2.Location = new System.Drawing.Point(13, 167);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(117, 27);
            this.label2.TabIndex = 5;
            this.label2.Text = "edit_user_permissions";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.translationHelper1.SetTranslationLocation(this.label2, "edit_user_permissions");
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.HorizontalScrollbar = true;
            this.checkedListBox1.IntegralHeight = false;
            this.checkedListBox1.Location = new System.Drawing.Point(136, 165);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(496, 110);
            this.checkedListBox1.TabIndex = 6;
            this.translationHelper1.SetTranslationLocation(this.checkedListBox1, "");
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.label3.Location = new System.Drawing.Point(13, 132);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(117, 27);
            this.label3.TabIndex = 3;
            this.label3.Text = "edit_user_password";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.translationHelper1.SetTranslationLocation(this.label3, "edit_user_password");
            // 
            // textBoxEx1
            // 
            this.textBoxEx1.Location = new System.Drawing.Point(136, 134);
            this.textBoxEx1.Name = "textBoxEx1";
            this.textBoxEx1.Size = new System.Drawing.Size(496, 25);
            this.textBoxEx1.TabIndex = 4;
            this.translationHelper1.SetTranslationLocation(this.textBoxEx1, "");
            this.textBoxEx1.UseSystemPasswordChar = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(136, 103);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(496, 25);
            this.textBox1.TabIndex = 4;
            this.translationHelper1.SetTranslationLocation(this.textBox1, "");
            // 
            // ModifyUserForm
            // 
            this.AcceptButton = this.metroButton1;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(645, 345);
            this.ColorScheme.PrimaryColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(119)))), ((int)(((byte)(189)))));
            this.ColorScheme.SecondaryColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(75)))), ((int)(((byte)(120)))));
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.textBoxEx1);
            this.Controls.Add(this.checkedListBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.metroButton1);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.MinimumSize = new System.Drawing.Size(645, 345);
            this.Name = "ModifyUserForm";
            this.Text = "ModifyUserForm";
            this.translationHelper1.SetTranslationLocation(this, "edit_user_title");
            this.Controls.SetChildIndex(this.appBar1, 0);
            this.Controls.SetChildIndex(this.metroButton1, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.checkedListBox1, 0);
            this.Controls.SetChildIndex(this.textBoxEx1, 0);
            this.Controls.SetChildIndex(this.textBox1, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Backend.Translation.TranslationHelper translationHelper1;
        private ModernUIDoneRight.Controls.ModernButton metroButton1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckedListBox checkedListBox1;
        private System.Windows.Forms.Label label3;
        private Controls.TextBoxEx textBoxEx1;
        private Controls.TextBoxEx textBox1;
    }
}