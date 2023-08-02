using NotDefterim.Context;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;
using System.Collections;
using NotDefterim.Forms;

namespace NotDefterim
{
    public partial class signin_form : Form
    {
        NpgsqlConnection connection = new NpgsqlConnection("server=localhost; port=5432; Database=notebook;user Id=postgres; password=antalya");

        public signin_form()
        {
            InitializeComponent();
        }

        private void register_form_Load(object sender, EventArgs e)
        {

        }

        private void btn_signin_Click(object sender, EventArgs e)
        {
            string name = tbx_name.Text.Trim();
            string surname = tbx_surname.Text.Trim();
            string email = tbx_email.Text.Trim();
            string password = tbx_password.Text.Trim();

            if (name.Length == 0 || surname.Length == 0 || email.Length == 0 || password.Length == 0)
            {
                MessageBox.Show("Lütfen tüm alanları doldurun");
            }
            else
            {
                //boş alan yoksa işlemlere devam

                //e-mail db'de var mı yok mu kontrolü
                if (isEmailExist(email) == 1)
                {
                    MessageBox.Show("Bu e-mail kullanımda.");
                }
                else if (isEmailExist(email) == 0)
                {
                    connection.Open();
                    string query = "insert into users (name,surname,email,password) values ('" + name + "' , '" + surname + "' , '" + email + "' , '" + password + "') ";
                    NpgsqlCommand cmd = new NpgsqlCommand(query, connection);
                    cmd.ExecuteNonQuery();
                    connection.Close();
                    MessageBox.Show("Başarıyla kayıt oluşturuldu.");
                }
            }



        }


        private long isEmailExist(string email)  //databasede girilen email mevcut mu değil mi onun kontrolünü yapıyoruz.
        {
            connection.Open();
            string query = "SELECT COUNT(*) FROM users WHERE email = '" + email + "' ";
            NpgsqlCommand cmd = new NpgsqlCommand(query, connection); //cmd isminde NpgsqlCommand nesnesi oluşturduk. Bu nesne sorguyu ve bağlantıyı temsil ediyor.
            long count = (long)cmd.ExecuteScalar();
            connection.Close();
            return count;
        }

        private void lbl_login_Click(object sender, EventArgs e) //kayıt ol ekranından giriş yap ekranına geçiş.
        {
            login_form login_Form = new login_form();
            login_Form.Show();
            this.Hide();
        }

        //isim girerken enter'a basılırsa kayıt ol butonuna tıklanmış varsaysın işlemi
        private void tbx_name_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btn_signin_Click(this, new EventArgs());
            }
        }

        private void tbx_surname_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btn_signin_Click(this, new EventArgs());
            }
        }

        private void tbx_email_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btn_signin_Click(this, new EventArgs());
            }
        }

        private void tbx_password_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btn_signin_Click(this, new EventArgs());
            }
        }
    }
}
