namespace NotDefterim.Forms
{
    partial class edit_note_form
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
            lbl_count = new Label();
            lbl_header = new Label();
            tbx_header = new TextBox();
            btn_save = new Button();
            tbx_noteContent = new TextBox();
            SuspendLayout();
            // 
            // lbl_count
            // 
            lbl_count.AutoSize = true;
            lbl_count.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lbl_count.Location = new Point(703, 404);
            lbl_count.Name = "lbl_count";
            lbl_count.Size = new Size(61, 21);
            lbl_count.TabIndex = 9;
            lbl_count.Text = "0/5000";
            // 
            // lbl_header
            // 
            lbl_header.AutoSize = true;
            lbl_header.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lbl_header.Location = new Point(240, 17);
            lbl_header.Name = "lbl_header";
            lbl_header.Size = new Size(55, 21);
            lbl_header.TabIndex = 8;
            lbl_header.Text = "Başlık";
            // 
            // tbx_header
            // 
            tbx_header.Location = new Point(313, 17);
            tbx_header.Name = "tbx_header";
            tbx_header.Size = new Size(240, 23);
            tbx_header.TabIndex = 7;
            // 
            // btn_save
            // 
            btn_save.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btn_save.Location = new Point(369, 395);
            btn_save.Name = "btn_save";
            btn_save.Size = new Size(94, 39);
            btn_save.TabIndex = 6;
            btn_save.Text = "KAYDET";
            btn_save.UseVisualStyleBackColor = true;
            btn_save.Click += btn_save_Click;
            // 
            // tbx_noteContent
            // 
            tbx_noteContent.Location = new Point(12, 63);
            tbx_noteContent.MaxLength = 5000;
            tbx_noteContent.Multiline = true;
            tbx_noteContent.Name = "tbx_noteContent";
            tbx_noteContent.ScrollBars = ScrollBars.Vertical;
            tbx_noteContent.Size = new Size(776, 317);
            tbx_noteContent.TabIndex = 5;
            tbx_noteContent.TextChanged += tbx_noteContent_TextChanged;
            // 
            // edit_note_form
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(lbl_count);
            Controls.Add(lbl_header);
            Controls.Add(tbx_header);
            Controls.Add(btn_save);
            Controls.Add(tbx_noteContent);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Name = "edit_note_form";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Not Düzenle";
            Load += edit_note_form_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lbl_count;
        private Label lbl_header;
        private TextBox tbx_header;
        private Button btn_save;
        private TextBox tbx_noteContent;
    }
}