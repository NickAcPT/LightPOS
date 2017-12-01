namespace NickAc.LightPOS.Frontend.Forms.Users
{
    partial class CreateUserForm
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
            this.metroButton1 = new NickAc.ModernUIDoneRight.Controls.MetroButton();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // appBar1
            // 
            this.appBar1.Size = new System.Drawing.Size(663, 50);
            this.translationHelper1.SetTranslationLocation(this.appBar1, "");
            // 
            // metroButton1
            // 
            this.metroButton1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.metroButton1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.metroButton1.Location = new System.Drawing.Point(234, 312);
            this.metroButton1.Name = "metroButton1";
            this.metroButton1.Size = new System.Drawing.Size(197, 47);
            this.metroButton1.TabIndex = 1;
            this.metroButton1.Text = "create_user_okbutton";
            this.translationHelper1.SetTranslationLocation(this.metroButton1, "create_user_okbutton");
            this.metroButton1.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.label1.Location = new System.Drawing.Point(13, 100);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 28);
            this.label1.TabIndex = 2;
            this.label1.Text = "create_user_name";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.translationHelper1.SetTranslationLocation(this.label1, "create_user_name");
            // 
            // CreateUserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(665, 372);
            this.ColorScheme.PrimaryColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(119)))), ((int)(((byte)(189)))));
            this.ColorScheme.SecondaryColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(75)))), ((int)(((byte)(120)))));
            this.Controls.Add(this.label1);
            this.Controls.Add(this.metroButton1);
            this.Name = "CreateUserForm";
            this.Text = "CreateUserForm";
            this.translationHelper1.SetTranslationLocation(this, "create_user_title");
            this.Controls.SetChildIndex(this.appBar1, 0);
            this.Controls.SetChildIndex(this.metroButton1, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.ResumeLayout(false);

        }

        #endregion

        private Backend.Translation.TranslationHelper translationHelper1;
        private ModernUIDoneRight.Controls.MetroButton metroButton1;
        private System.Windows.Forms.Label label1;
    }
}