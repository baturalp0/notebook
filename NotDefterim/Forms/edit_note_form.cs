using NotDefterim.Context;
using NotDefterim.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NotDefterim.Forms
{
    public partial class edit_note_form : Form
    {
        private note tempNote;
        notes_form notes_Form; // notes_form örneğini burada tanımlayın
        db_connection dbConnection = new db_connection();

        public edit_note_form(note tempNote)
        {
            InitializeComponent();
            this.tempNote = tempNote;
            notes_Form = Application.OpenForms["notes_form"] as notes_form; // notes_form örneğini oluşturun.Notlarım ekranındaki datagridview'u refreshlemek için kullandım aşşağıda.
            //Application.OpenForms koleksiyonu uygulamanın şu anda açık olan tüm formlarına eerişmeyi sağlıyor.
            //Application.OpenForms["notes_form"] ifadesi, koleksiyon içinde notes_form adına sahip bir form arar ve bu formun örneğini döndürür. Eğer böyle bir form bulunamazsa, null değeri döner.
            //Sonra as notes_form ifadesi, döndürülen form örneğini notes_form sınıfına dönüştürmeye çalışır. Bu, tip güvenliği sağlamak ve hata almamak için yapılır. Eğer dönüşüm başarılı ise, notes_Form değişkenine notes_form örneğini atar. Eğer dönüşüm başarısız olursa, notes_Form değişkenine null atanır.
            //Bu satır, add_note_form içindeki notes_form örneğini elde etmeye ve böylece notes_form'un içindeki fonksiyonları ve özellikleri çağırmaya yardımcı olur.

        }

        private void edit_note_form_Load(object sender, EventArgs e)
        {
            //notlarım ekranından gelen veriyi not düzenle ekranına gösteriyorum.
            tbx_noteContent.Text = tempNote.noteContent.ToString();
            tbx_header.Text = tempNote.noteTitle.ToString();

        }

        private void tbx_noteContent_TextChanged(object sender, EventArgs e)
        {
            string content = tbx_noteContent.Text;

            int contentLength = content.Length;

            lbl_count.Text = contentLength + " /5000";
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            if (tbx_header.TextLength == 0)
            {
                //başlık boş mu kontrolu yapıyorum.
                MessageBox.Show("Başlık boş bırakılamaz");
            }
            else
            {
                //notu ekleme işlemi burada olacak.
                //not başlığı ve not içeriği bilgisini textboxtan alıyorum. 
                string noteTitle = tbx_header.Text.TrimStart();  //Başlığın solunda boşluk varsa temizliyoruz
                string noteContent = tbx_noteContent.Text;

                //id ve user id bilgisini notes classından aldığım tempNote nesnesinden alacağım
                int id = Convert.ToInt32(tempNote.id);
                int user_id = Convert.ToInt32(tempNote.user_id);


                //Büyük küçük harf duyarlılığından dolayı bu şekilde sorgu.
                string query = "UPDATE notes SET \"noteTitle\" = '" + noteTitle + "' , \"noteContent\" = '" + noteContent + "' WHERE id = '" + id + "' ;";
                dbConnection.add_npgsql(query);

                //Notu kaydettikten sonra notlarım ekranındaki dataGridView'u refreshleme işlemini yapıyorum. Bunun için notes_form classından fonksiyon çağırdım.
                if (notes_Form != null)
                {
                    notes_Form.refreshDataGridViewNotes();
                }

                //Kaydettikten sonra başarılı mesajı verip formu kapatıyoruz.
                MessageBox.Show("Kaydedildi");
                this.Hide();



            }
        }
    }
}
