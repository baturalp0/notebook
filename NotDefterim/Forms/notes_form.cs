using NotDefterim.Context;
using NotDefterim.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NotDefterim.Forms
{
    public partial class notes_form : Form
    {
        private DataTable dataTable;
        db_connection dbConnection = new db_connection();
        login_form login_form = new login_form();
        DataTable user_dt = login_form.user_dt; // burada user_dt adında bir DataTable oluşturduk ve log_in ekranındaki user_dt'ı atadık. Yani Login ekranından gelen kullanıcının bilgileri burada olacak.

        public notes_form()
        {
            InitializeComponent();
            dataTable = new DataTable();
        }

        private void notes_form_Load(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(user_dt.Rows[0]["id"]);


            string query = "SELECT n.*,sn.\"readOnly\"\r\nFROM notes n\r\nLEFT JOIN \"sharedNotes\" sn ON n.id = sn.\"notId\"\r\nWHERE (n.user_id = '"+id+"' AND n.deleted = false)\r\n   OR (sn.\"userId\" = '"+id+"' AND n.id = sn.\"notId\")";


            dataTable = dbConnection.get_npgsql(query);

            dataGridViewNotes.DataSource = dataTable;

            foreach (DataGridViewColumn column in dataGridViewNotes.Columns) //Notlar sütunu hariç diğerlerini gizledim
            {
                if (column.Name != "noteTitle")
                {
                    column.Visible = false;
                }
            }

            //Paylaş butonu sütun ekleme işlemi
            DataGridViewButtonColumn buttonShareColumn = new DataGridViewButtonColumn();
            buttonShareColumn.HeaderText = ""; // Düğme sütununun başlığı
            buttonShareColumn.Text = "Paylaş"; // Düğme üzerindeki metin
            buttonShareColumn.UseColumnTextForButtonValue = true; // Düğme üzerindeki metni göster
            buttonShareColumn.Name = "buttonShareColumn";
            dataGridViewNotes.Columns.Add(buttonShareColumn);

            //Sil butonu sütun ekleme işlemi
            DataGridViewButtonColumn buttonDeleteColumn = new DataGridViewButtonColumn();
            buttonDeleteColumn.HeaderText = ""; // Düğme sütununun başlığı
            buttonDeleteColumn.Text = "Sil"; // Düğme üzerindeki metin
            buttonDeleteColumn.UseColumnTextForButtonValue = true; // Düğme üzerindeki metni göster
            buttonDeleteColumn.Name = "buttonDeleteColumn";
            dataGridViewNotes.Columns.Add(buttonDeleteColumn);

            //En baştaki tümünü seç sütununu kapattım
            dataGridViewNotes.RowHeadersVisible = false;

            //En alttaki boş satırı gizledim
            dataGridViewNotes.AllowUserToAddRows = false;

            //Sütun başlıklarını gizledim.
            dataGridViewNotes.ColumnHeadersVisible = false;

            //dataGridView'ı read-Only yapıyoruz
            dataGridViewNotes.ReadOnly = true;


            // Otomatik not sıralarını gösteren sütun
            DataGridViewTextBoxColumn rowNumberColumn = new DataGridViewTextBoxColumn();
            rowNumberColumn.HeaderText = ""; // Sütun başlığı
            dataGridViewNotes.Columns.Insert(0, rowNumberColumn); // Sütunu DataGridView'a ekle
            dataGridViewNotes.CellFormatting += DataGridView1_CellFormatting; // CellFormatting olayını bağlayın


            void DataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)  //en baştaki not sayılarını gösteren sütunu eklemek için kullandığım metod 
            {
                // "RowNumber" sütununu biçimlendirme
                if (e.ColumnIndex == 0 && e.RowIndex >= 0) // Sadece "RowNumber" sütunu için işlem yaptık
                {
                    e.Value = (e.RowIndex + 1).ToString();
                    e.FormattingApplied = true;
                }
            }
        }

        private void btn_addNotes_Click(object sender, EventArgs e)
        {
            add_note_form add_Note_Form = new add_note_form();
            add_Note_Form.ShowDialog();
        }


        //Not ekle ekranında kaydet butonuna tıklandığında dgvNotes'u yeniliyorum ki yeni eklenen not ekranda görünsün. Bu fonksiyonu not ekleme ekranında kaydet butonu click'i altında kullanacağım
        public void refreshDataGridViewNotes()
        {
            int id = Convert.ToInt32(user_dt.Rows[0]["id"]);

            string query = "SELECT n.*,sn.\"readOnly\"\r\nFROM notes n\r\nLEFT JOIN \"sharedNotes\" sn ON n.id = sn.\"notId\"\r\nWHERE (n.user_id = '" + id + "' AND n.deleted = false)\r\n   OR (sn.\"userId\" = '" + id + "' AND n.id = sn.\"notId\")";

            DataTable tempDataTable = dbConnection.get_npgsql(query);

            dataGridViewNotes.DataSource = tempDataTable;

            dataGridViewNotes.Refresh();
        }
        //Sil ve paylaş butonuna tıklandığımda yapılacak işlemler CellContentClick ile yapılıyor.
        //SİL BUTONU İŞLEMLERİ
        private void dataGridViewNotes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0) // Tıklanan hücre geçerli bir hücre mi?
            {
                DataGridViewColumn column = dataGridViewNotes.Columns[e.ColumnIndex]; // Tıklanan sütunu al
                if (column.Name == "buttonDeleteColumn")
                {
                    if (column is DataGridViewButtonColumn) // Sütun bir düğme sütunu mu?
                    {

                        bool readOnly = Convert.ToBoolean(dataTable.Rows[0]["readOnly"]);
                        if (readOnly == true) // note başkasından gelmiş ve sadece okunabilir
                        {
                            //not silme işlemini burada yapacağız.
                            //Silmek istediğine emin misin? uyarısı verip cevaba göre devam ediyoruz
                            DialogResult dialogResult = MessageBox.Show("Paylaşılan Notu silmek istediğinizden emin misiniz?", "Sil", MessageBoxButtons.YesNo);
                            if (dialogResult == DialogResult.Yes)
                            {
                                //tıkladığımız notun id'sini alıyoruz
                                DataGridViewRow row = dataGridViewNotes.Rows[e.RowIndex];
                                string id = row.Cells["id"].Value.ToString();
                                //o anda giriş yapmış kullanıcının id'sini alıyoruz (notu teslim alan kişinin id'si yani)
                                int user_id = Convert.ToInt32(user_dt.Rows[0]["id"]);

                                //notun deleted bool özelliği true olması için gerekli sorguyu yazıyoruz.
                                string query = "DELETE FROM \"sharedNotes\" WHERE \"notId\"= '"+id+"' and \"userId\"='"+user_id+"'";
                                dbConnection.add_npgsql(query);

                                //datagridview'u refreshliyoruz ki ekran kapanmasada silinen veri değişikliği ekrana yansısın
                                refreshDataGridViewNotes();

                            }
                            else if (dialogResult == DialogResult.No)
                            {
                                //form otomatik kapanıyor burada bir şey yapmaya gerek yok.
                            }
                        }
                        else if (readOnly == false) //not başkasından gelmiş ve hem okunabilir hem yazılabilir
                        {
                            //not silme işlemini burada yapacağız.
                            //Silmek istediğine emin misin? uyarısı verip cevaba göre devam ediyoruz
                            DialogResult dialogResult = MessageBox.Show("Paylaşılan Notu silmek istediğinizden emin misiniz?", "Sil", MessageBoxButtons.YesNo);
                            if (dialogResult == DialogResult.Yes)
                            {
                                //tıkladığımız notun id'sini alıyoruz
                                DataGridViewRow row = dataGridViewNotes.Rows[e.RowIndex];
                                string id = row.Cells["id"].Value.ToString();
                                //o anda giriş yapmış kullanıcının id'sini alıyoruz (notu teslim alan kişinin id'si yani)
                                int user_id = Convert.ToInt32(user_dt.Rows[0]["id"]);

                                //notun deleted bool özelliği true olması için gerekli sorguyu yazıyoruz.
                                string query = "DELETE FROM \"sharedNotes\" WHERE \"notId\"= '" + id + "' and \"userId\"='" + user_id + "'";
                                dbConnection.add_npgsql(query);

                                //datagridview'u refreshliyoruz ki ekran kapanmasada silinen veri değişikliği ekrana yansısın
                                refreshDataGridViewNotes();
                            }
                            else if (dialogResult == DialogResult.No)
                            {
                                //form otomatik kapanıyor burada bir şey yapmaya gerek yok.
                            }
                        }
                        else { //not başkasından gelmemiş. Oluşturulmuş

                               //not silme işlemini burada yapacağız.
                            //Silmek istediğine emin misin? uyarısı verip cevaba göre devam ediyoruz
                            DialogResult dialogResult = MessageBox.Show("Notu silmek istediğinizden emin misiniz?", "Sil", MessageBoxButtons.YesNo);
                            if (dialogResult == DialogResult.Yes)
                            {
                                //tıkladığımız notun id'sini alıyoruz
                                DataGridViewRow row = dataGridViewNotes.Rows[e.RowIndex];
                                string id = row.Cells["id"].Value.ToString();

                                //notun deleted bool özelliği true olması için gerekli sorguyu yazıyoruz.
                                string query = "UPDATE notes SET deleted=true WHERE id= '" + id + "'";
                                dbConnection.add_npgsql(query);

                                //datagridview'u refreshliyoruz ki ekran kapanmasada silinen veri değişikliği ekrana yansısın
                                refreshDataGridViewNotes();

                            }
                            else if (dialogResult == DialogResult.No)
                            {
                                //form otomatik kapanıyor burada bir şey yapmaya gerek yok.
                            }
                        }



                    }
                }
                //PAYLAŞ BUTONU İŞLEMLERİ
                else if(column.Name == "buttonShareColumn")
                {
                    if (column is DataGridViewButtonColumn) // Sütun bir düğme sütunu mu?
                    {

                        DataGridViewRow row = dataGridViewNotes.Rows[e.RowIndex];
                        int id = Convert.ToInt32(row.Cells["id"].Value);
                        int user_id = Convert.ToInt32(row.Cells["user_id"].Value);
                        string noteTitle = row.Cells["noteTitle"].Value.ToString();
                        string noteContent = row.Cells["noteContent"].Value.ToString();
                        bool deleted = Convert.ToBoolean(row.Cells["deleted"].Value);
                        DateTime createDate = Convert.ToDateTime(row.Cells["createDate"].Value);

                        //not bilgilerini nesneye aktarıyoruz.
                        note tempNoteShare = new note();
                        tempNoteShare = new note();
                        tempNoteShare.id = id;
                        tempNoteShare.user_id = user_id;
                        tempNoteShare.noteTitle = noteTitle;
                        tempNoteShare.noteContent = noteContent;
                        tempNoteShare.deleted = deleted;
                        tempNoteShare.createDate = createDate;

                        //aldığımız bilgileri açtığımız form ile gönderiyoruz. Paylaş ekranı classının constructorını düzenledim bunun için.
                        share_note_form share_Note_Form = new share_note_form(tempNoteShare);
                        share_Note_Form.ShowDialog();
                    
                    }

                }
            }
        }


        //CellDoubleClick ile notlarıma çift tıklama ile not düzenle ekranı açılacak ve veriler o forma gönderilecek.
        private void dataGridViewNotes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0) // Tıklanan hücre geçerli bir hücre mi?
            {
                DataGridViewColumn column = dataGridViewNotes.Columns[e.ColumnIndex]; // Tıklanan sütunu al
                //tıklanan hücrenin bulunduğu sütunun ismi noteTitle'mı kontrolü yapıyoruz.
                if (column.Name == "noteTitle")
                {
                    //Not düzenleme işlemlerinin hepsini burada yapacağız



                    //tıklanan sütundaki tüm bilgileri bir nesne içine atıyorum.
                    DataGridViewRow row = dataGridViewNotes.Rows[e.RowIndex];
                    int id = Convert.ToInt32(row.Cells["id"].Value);
                    int user_id = Convert.ToInt32(row.Cells["user_id"].Value);
                    string noteTitle = row.Cells["noteTitle"].Value.ToString();
                    string noteContent = row.Cells["noteContent"].Value.ToString();
                    bool deleted = Convert.ToBoolean(row.Cells["deleted"].Value);
                    DateTime createDate = Convert.ToDateTime(row.Cells["createDate"].Value);

                    //not bilgilerini nesneye aktarıyoruz.
                    note tempNote = new note();
                    tempNote = new note();
                    tempNote.id = id;
                    tempNote.user_id = user_id;
                    tempNote.noteTitle = noteTitle;
                    tempNote.noteContent = noteContent;
                    tempNote.deleted = deleted;
                    tempNote.createDate = createDate;


                    //aldığımız bilgileri açtığımız form ile gönderiyoruz. Not düzenle ekranı classının constructorını düzenledim bunun için.
                    edit_note_form edit_Note_Form = new edit_note_form(tempNote);
                    edit_Note_Form.ShowDialog();
                }
            }
        }
    }
}
