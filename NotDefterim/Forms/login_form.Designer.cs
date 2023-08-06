namespace NotDefterim.Forms
{
    partial class login_form
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
            if (disposing && (components != null))
            {
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
            tbx_email = new TextBox();
            tbx_password = new TextBox();
            btn_login = new Button();
            groupBox1 = new GroupBox();
            lbl_signin = new Label();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // tbx_email
            // 
            tbx_email.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            tbx_email.Location = new Point(6, 22);
            tbx_email.Name = "tbx_email";
            tbx_email.PlaceholderText = "E-mail";
            tbx_email.Size = new Size(207, 29);
            tbx_email.TabIndex = 0;
            tbx_email.KeyDown += tbx_email_KeyDown;
            // 
            // tbx_password
            // 
            tbx_password.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            tbx_password.Location = new Point(6, 64);
            tbx_password.Name = "tbx_password";
            tbx_password.PasswordChar = '*';
            tbx_password.PlaceholderText = "Password";
            tbx_password.Size = new Size(207, 29);
            tbx_password.TabIndex = 1;
            tbx_password.KeyDown += tbx_password_KeyDown;
            // 
            // btn_login
            // 
            btn_login.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btn_login.Location = new Point(186, 222);
            btn_login.Name = "btn_login";
            btn_login.Size = new Size(94, 48);
            btn_login.TabIndex = 2;
            btn_login.Text = "Giriş Yap";
            btn_login.UseVisualStyleBackColor = true;
            btn_login.Click += btn_login_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(tbx_email);
            groupBox1.Controls.Add(tbx_password);
            groupBox1.FlatStyle = FlatStyle.Flat;
            groupBox1.ForeColor = Color.Transparent;
            groupBox1.Location = new Point(118, 92);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(232, 100);
            groupBox1.TabIndex = 4;
            groupBox1.TabStop = false;
            // 
            // lbl_signin
            // 
            lbl_signin.AutoSize = true;
            lbl_signin.Location = new Point(124, 305);
            lbl_signin.Name = "lbl_signin";
            lbl_signin.Size = new Size(229, 15);
            lbl_signin.TabIndex = 5;
            lbl_signin.Text = "Hesabın yok mu?  Hemen bir tane oluştur!";
            lbl_signin.Click += lbl_signin_Click;
            // 
            // login_form
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(473, 441);
            Controls.Add(lbl_signin);
            Controls.Add(groupBox1);
            Controls.Add(btn_login);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "login_form";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Giriş Yap";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox tbx_email;
        private TextBox tbx_password;
        private Button btn_login;
        private GroupBox groupBox1;
        private Label lbl_signin;
    }
}