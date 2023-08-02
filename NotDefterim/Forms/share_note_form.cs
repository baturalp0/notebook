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
    public partial class share_note_form : Form
    {
        db_connection dbConnection = new db_connection();
        private note tempNoteShare;
        public share_note_form(note tempNoteShare)
        {
            InitializeComponent();
            this.tempNoteShare = tempNoteShare;
        }

        private void btn_share_Click(object sender, EventArgs e)
        {
            //Burada insert işlemi ile notu paylaşacağım.
            string shareEmail = tbx_shareEmail.Text;
            bool readOnly = cbx_share.Checked;

            //aldığım email bilgisi ile sorgu oluşturup o email adresindeki kullanıcının bilgileri ile DataTable oluşturacağım. Bu dt'den user_id yi çekebilirim.
            string query = "SELECT * FROM users WHERE email = '" + shareEmail + "'";
            DataTable dtSharedUser = dbConnection.get_npgsql(query); //not kiminle paylaşıldıysa onun bilgilerini bu dt'a attık.
            int user_id = Convert.ToInt32(dtSharedUser.Rows[0]["id"]); //user_id içerisine notun paylaşıldığı user'ın user_id'sini atamış olduk.

            //Paylaşılan notun bilgileri tempNoteShare nesnesinin içerisinde. (buradan not id ye ulaşabilirim.)
            int not_id = Convert.ToInt32(tempNoteShare.id);

            //Elimde user_id, paylaşılacak notun nesnesi , readonly durumu var. Eklemeyi yapabilirim
            string addQuery = "INSERT INTO \"sharedNotes\" (\"notId\",\"userId\",\"readOnly\") values ('"+not_id+"','"+user_id+"','"+readOnly+"') ";
            dbConnection.add_npgsql(addQuery); //sorguyu çalıştırıyoruz.





        }
    }
}
