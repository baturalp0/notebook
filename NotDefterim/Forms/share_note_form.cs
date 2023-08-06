using NotDefterim.Context;
using NotDefterim.Entities;
using Npgsql;
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
        NpgsqlConnection connection = new NpgsqlConnection("server=localhost; port=5432; Database=notebook;user Id=postgres; password=antalya");
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

            //Yazdığım metodlarla paylaşan kullanıcı, paylaşılan kullanıcı ve not nesnelerini alıp bunları değişkene aktarıyorum:
            note note = returnNote();
            user userSender = returnSenderUser();
            user userShared = returnSharedUser();


            //kullanıcının girdiği mail ve checkBox durumunu değişkenlere aktarıyorum.
            string shareEmail = tbx_shareEmail.Text;
            bool readOnly = cbx_share.Checked;


            //Sırasıyla yapacağım kontroller: 1-Email boş olamaz 2-Email db de var mı 3-e-mail db de varsa bile hesap aktif mi? 4- e_mail kişinin kendisinin mi?
            if (shareEmail.Length == 0)
            {
                MessageBox.Show("Mail adresi boş olamaz");
            }
            else
            {
                //email boş değilmiş. email DB'de var mı kontrol etmem gerekiyor.
                if (isEmailExist(shareEmail) == 0)
                {
                    MessageBox.Show("Mail adresi geçersiz. Lütfen kontrol edin.");
                }
                else
                {
                    //email DB'de varmış. Şimdi DB'de varsa bile hesap aktif mi kontrolü yapacağım.
                    if (userShared.active) //hesap aktif demektir
                    {

                        //Şimdi email kendisinin mi değil mi kontrolü yapıyoruz
                        if (userSender.email.ToString() == shareEmail)
                        {
                            MessageBox.Show("Bu not kullanıcıda zaten mecvut");
                        }
                        else
                        {
                            //Kendisinin değilmiş.

                            //Şimdi not önceden paylaşılmış mı onu kontrol edeceğiz.

                            if (isSharedNoteExist(note.id, userShared.id))
                            {
                                MessageBox.Show("Bu not zaten paylaşılmış");
                            }
                            else
                            {
                                //Tüm kontroller tamam. şimdi sorgumu yazıp insert işlemi yapacağım.

                                string addQuery = "INSERT INTO \"sharedNotes\" (\"notId\",\"userId\",\"readOnly\") values ('" + note.id + "','" + userShared.id + "','" + readOnly + "') ";
                                dbConnection.add_npgsql(addQuery); //sorguyu çalıştırıyoruz.


                                MessageBox.Show("Başarıyla paylaşıldı!");

                                this.Hide();

                            }


                        }

                    }
                    else
                    { //Hesap aktif değil demektir.
                        MessageBox.Show("Bu hesap aktif değildir");
                    }



                }

            }

        }

        private long isEmailExist(string email)
        {
            connection.Open();
            string query = "SELECT COUNT(*) FROM users WHERE email = '" + email + "' ";
            NpgsqlCommand cmd = new NpgsqlCommand(query, connection); //cmd isminde NpgsqlCommand nesnesi oluşturduk. Bu nesne sorguyu ve bağlantıyı temsil ediyor.
            long count = (long)cmd.ExecuteScalar();
            connection.Close();
            return count;
        }

        private user returnSharedUser() //Girilen e-mail ile sorgu çalıştırıp tablo oluşturuyorum. Tablo bilgilerini user nesnesine aktarıp bu nesneyi döndürüyorum.
        {
            string shareEmail = tbx_shareEmail.Text;
            if (shareEmail.Length == 0) //boş mail olamaz kontrolü
            {
                return null;
            }
            else
            {
                if (isEmailExist(shareEmail) == 0) //db kontrolü
                {
                    return null;
                }
                else
                {
                    string query = "SELECT * FROM users WHERE email = '" + shareEmail + "'";
                    DataTable dt = dbConnection.get_npgsql(query); //not kiminle paylaşıldıysa onun bilgilerini bu dt'a attık.
                    int id = Convert.ToInt32(dt.Rows[0]["id"]);
                    string name = dt.Rows[0]["name"].ToString();
                    string surname = dt.Rows[0]["surname"].ToString();
                    string email = dt.Rows[0]["email"].ToString();
                    string password = dt.Rows[0]["password"].ToString();
                    bool active = Convert.ToBoolean(dt.Rows[0]["active"]);
                    DateTime createDate = Convert.ToDateTime(dt.Rows[0]["createDate"]);

                    user user = new user();
                    user.id = id;
                    user.name = name;
                    user.surname = surname;
                    user.email = email;
                    user.password = password;
                    user.active = active;
                    user.createDate = createDate;

                    return user;

                }

            }






        }

        private note returnNote() //Tıklanan notu nesne oalrak dönen metod.
        {
            return tempNoteShare;
        }

        private user returnSenderUser() //elimizdeki not nesnesinden user_id ye ulaşıp notun sahibi yani currentUsera ulaşabiliriz. Ulaştıktan sonra onu nesne olarak döndüreceğiz.
        {
            note note = new note();
            note = returnNote();

            int id = note.user_id;

            string query = "SELECT * FROM users Where id= '" + id + "'";
            DataTable dt = dbConnection.get_npgsql(query);

            if (dt.Rows.Count > 0) // Eğer sonuç varsa devam et
            {
                DataRow row = dt.Rows[0]; // İlk satırı al

                user user = new user
                {
                    id = Convert.ToInt32(row["id"]),
                    name = row["name"].ToString(),
                    surname = row["surname"].ToString(),
                    email = row["email"].ToString(),
                    password = row["password"].ToString(),
                    active = Convert.ToBoolean(row["active"]),
                    createDate = Convert.ToDateTime(row["createDate"])
                };

                return user;
            }
            else
            {
                // Kullanıcı bulunamadı veya hata durumu için uygun işlem yapılabilir.
                return null; // Veya başka bir değer döndürülebilir.
            }



        }

        private bool isSharedNoteExist(int not_id, int user_id)
        {
            string query = "SELECT * FROM \"sharedNotes\" WHERE \"notId\" = '" + not_id + "' AND \"userId\"= '" + user_id + "'";
            DataTable dt = dbConnection.get_npgsql(query);

            if (dt.Rows.Count == 0) //Dönen dt'nin satırı yok yani boş demektir
            {
                return false;
            }
            else
            {
                return true;
            }


        }




    }
}
