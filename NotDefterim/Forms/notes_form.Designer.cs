namespace NotDefterim.Forms
{
    partial class notes_form
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
            dataGridViewNotes = new DataGridView();
            lbl_myNotes = new Label();
            btn_addNotes = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridViewNotes).BeginInit();
            SuspendLayout();
            // 
            // dataGridViewNotes
            // 
            dataGridViewNotes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewNotes.Location = new Point(12, 43);
            dataGridViewNotes.Name = "dataGridViewNotes";
            dataGridViewNotes.RowTemplate.Height = 25;
            dataGridViewNotes.Size = new Size(412, 395);
            dataGridViewNotes.TabIndex = 0;
            dataGridViewNotes.CellContentClick += dataGridViewNotes_CellContentClick;
            dataGridViewNotes.CellDoubleClick += dataGridViewNotes_CellDoubleClick;
            // 
            // lbl_myNotes
            // 
            lbl_myNotes.AutoSize = true;
            lbl_myNotes.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point);
            lbl_myNotes.Location = new Point(124, 5);
            lbl_myNotes.Name = "lbl_myNotes";
            lbl_myNotes.Size = new Size(141, 32);
            lbl_myNotes.TabIndex = 1;
            lbl_myNotes.Text = "NOTLARIM";
            // 
            // btn_addNotes
            // 
            btn_addNotes.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btn_addNotes.Location = new Point(286, 5);
            btn_addNotes.Name = "btn_addNotes";
            btn_addNotes.Size = new Size(86, 32);
            btn_addNotes.TabIndex = 2;
            btn_addNotes.Text = "Ekle";
            btn_addNotes.UseVisualStyleBackColor = true;
            btn_addNotes.Click += btn_addNotes_Click;
            // 
            // notes_form
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(436, 450);
            Controls.Add(btn_addNotes);
            Controls.Add(lbl_myNotes);
            Controls.Add(dataGridViewNotes);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Name = "notes_form";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Notlarım";
            Load += notes_form_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewNotes).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridViewNotes;
        private Label lbl_myNotes;
        private Button btn_addNotes;
    }
}