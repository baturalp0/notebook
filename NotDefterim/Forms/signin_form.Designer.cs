namespace NotDefterim
{
    partial class signin_form
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
            btn_signin = new Button();
            tbx_name = new TextBox();
            tbx_password = new TextBox();
            tbx_surname = new TextBox();
            tbx_email = new TextBox();
            groupBox1 = new GroupBox();
            lbl_login = new Label();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // btn_signin
            // 
            btn_signin.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btn_signin.Location = new Point(176, 309);
            btn_signin.Name = "btn_signin";
            btn_signin.Size = new Size(124, 61);
            btn_signin.TabIndex = 0;
            btn_signin.Text = "Kayıt Ol";
            btn_signin.UseVisualStyleBackColor = true;
            btn_signin.Click += btn_signin_Click;
            // 
            // tbx_name
            // 
            tbx_name.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            tbx_name.Location = new Point(6, 22);
            tbx_name.Name = "tbx_name";
            tbx_name.PlaceholderText = "Ad";
            tbx_name.Size = new Size(234, 29);
            tbx_name.TabIndex = 1;
            tbx_name.KeyDown += tbx_name_KeyDown;
            // 
            // tbx_password
            // 
            tbx_password.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            tbx_password.Location = new Point(6, 174);
            tbx_password.Name = "tbx_password";
            tbx_password.PasswordChar = '*';
            tbx_password.PlaceholderText = "Şifre";
            tbx_password.Size = new Size(234, 29);
            tbx_password.TabIndex = 4;
            tbx_password.KeyDown += tbx_password_KeyDown;
            // 
            // tbx_surname
            // 
            tbx_surname.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            tbx_surname.Location = new Point(6, 74);
            tbx_surname.Name = "tbx_surname";
            tbx_surname.PlaceholderText = "Soyad";
            tbx_surname.Size = new Size(234, 29);
            tbx_surname.TabIndex = 2;
            tbx_surname.KeyDown += tbx_surname_KeyDown;
            // 
            // tbx_email
            // 
            tbx_email.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            tbx_email.Location = new Point(6, 124);
            tbx_email.Name = "tbx_email";
            tbx_email.PlaceholderText = "E-mail";
            tbx_email.Size = new Size(234, 29);
            tbx_email.TabIndex = 3;
            tbx_email.KeyDown += tbx_email_KeyDown;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(tbx_name);
            groupBox1.Controls.Add(tbx_email);
            groupBox1.Controls.Add(tbx_password);
            groupBox1.Controls.Add(tbx_surname);
            groupBox1.ForeColor = SystemColors.ActiveBorder;
            groupBox1.Location = new Point(108, 70);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(254, 233);
            groupBox1.TabIndex = 5;
            groupBox1.TabStop = false;
            // 
            // lbl_login
            // 
            lbl_login.AutoSize = true;
            lbl_login.Location = new Point(142, 400);
            lbl_login.Name = "lbl_login";
            lbl_login.Size = new Size(183, 15);
            lbl_login.TabIndex = 6;
            lbl_login.Text = "Hesabın var mı? Hemen giriş yap!";
            lbl_login.Click += lbl_login_Click;
            // 
            // signin_form
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(473, 441);
            Controls.Add(lbl_login);
            Controls.Add(groupBox1);
            Controls.Add(btn_signin);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Name = "signin_form";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Kayıt Ol";
            Load += register_form_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btn_signin;
        private TextBox tbx_name;
        private TextBox tbx_password;
        private TextBox tbx_surname;
        private TextBox tbx_email;
        private GroupBox groupBox1;
        private Label lbl_login;
    }
}