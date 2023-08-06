namespace NotDefterim.Forms
{
    partial class share_note_form
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
            tbx_shareEmail = new TextBox();
            cbx_share = new CheckBox();
            btn_share = new Button();
            SuspendLayout();
            // 
            // tbx_shareEmail
            // 
            tbx_shareEmail.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            tbx_shareEmail.Location = new Point(77, 66);
            tbx_shareEmail.Name = "tbx_shareEmail";
            tbx_shareEmail.PlaceholderText = "Paylaşılacak E-mail Adresi";
            tbx_shareEmail.Size = new Size(237, 29);
            tbx_shareEmail.TabIndex = 0;
            tbx_shareEmail.TabStop = false;
            // 
            // cbx_share
            // 
            cbx_share.AutoSize = true;
            cbx_share.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            cbx_share.Location = new Point(77, 144);
            cbx_share.Name = "cbx_share";
            cbx_share.Size = new Size(242, 25);
            cbx_share.TabIndex = 1;
            cbx_share.Text = "Sadece görüntülemeye izin ver";
            cbx_share.UseVisualStyleBackColor = true;
            // 
            // btn_share
            // 
            btn_share.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btn_share.Location = new Point(138, 199);
            btn_share.Name = "btn_share";
            btn_share.Size = new Size(104, 43);
            btn_share.TabIndex = 2;
            btn_share.Text = "Paylaş";
            btn_share.UseVisualStyleBackColor = true;
            btn_share.Click += btn_share_Click;
            // 
            // share_note_form
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(385, 304);
            Controls.Add(btn_share);
            Controls.Add(cbx_share);
            Controls.Add(tbx_shareEmail);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "share_note_form";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Paylaş";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox tbx_shareEmail;
        private CheckBox cbx_share;
        private Button btn_share;
    }
}