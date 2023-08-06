using NotDefterim.Context;
using NotDefterim.Entities;
using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace NotDefterim.Forms
{
    public partial class login_form : Form
    {
        db_connection dbConnection = new db_connection();
        NpgsqlConnection connection = new NpgsqlConnection("server=localhost; port=5432; Database=notebook;user Id=postgres; password=antalya");
        public static DataTable user_dt = new DataTable();

        public login_form()
        {
            InitializeComponent();
        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            string email = tbx_email.Text.Trim();
            string password = tbx_password.Text.Trim();

            //alanlar boş mu değil mi diye kontrol ediyorum
            if ((email.Length == 0) || (password.Length == 0))
            {
                MessageBox.Show("Lütfen tüm alanları doldurun");
            }

            else
            {
                //boş alan yoksa koda devam

                //e-mail db'de var mı yok mu kontrol ediyorum.
                if (isEmailExist(email) == 1)
                {
                    string query = "SELECT * FROM users WHERE email = '" + email + "' ";


                    user_dt = dbConnection.get_npgsql(query);

                    //filtreleme sonucu aldığım tablo burada. e-mailin varlığı zaten kontrol edildi. şimdi şifre doğruluğu kontrol edilecek ve duruma göre giriş yaptınız yapmadınız denilecek.

                    int id = Convert.ToInt32(user_dt.Rows[0]["id"]);
                    string dtName = user_dt.Rows[0]["name"].ToString();
                    string dtSurname = user_dt.Rows[0]["surname"].ToString();
                    string dtEmail = user_dt.Rows[0]["email"].ToString();
                    string dtPassword = user_dt.Rows[0]["password"].ToString();
                    bool dtActive = Convert.ToBoolean(user_dt.Rows[0]["active"]);
                    DateTime dtCreateDate = Convert.ToDateTime(user_dt.Rows[0]["createDate"]);

                    if (dtPassword == password)
                    {
                        MessageBox.Show("Giriş Başarılı");
                        goToNotes();
                    }
                    else
                    {
                        MessageBox.Show("Şifre Yanlış");
                    }


                }
                else if (isEmailExist(email) == 0)
                {
                    MessageBox.Show("Bu mail adresi ile kayıtlı bir kullanıcı bulunamadı.");
                }

            }

        }

        void goToNotes()
        {
            notes_form notes_Form = new notes_form();
            notes_Form.Show();
            this.Hide();
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

        private void lbl_signin_Click(object sender, EventArgs e)
        {
            signin_form signin_Form = new signin_form();
            signin_Form.Show();
            this.Hide();
        }

        private void tbx_email_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btn_login_Click(this, new EventArgs());
            }
        }

        private void tbx_password_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btn_login_Click(this, new EventArgs());
            }
        }


    }
}
