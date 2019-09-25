using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Project
{
    public partial class Form1 : Form
    {
        String login;
        String senha;
        private string conn;
        private MySqlConnection connect;

        private void db_connection()
        {
            try
            {
                conn = "Server=localhost;Database=prd_aplication;Uid=root;Pwd=;";
                connect = new MySqlConnection(conn);
                connect.Open();
            }
            catch (MySqlException e)
            {
                throw;
            }
        }

        private bool validate_login(string login, string senha)
        {
            db_connection();
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = "Select * from user_login where login=@user and senha=@pass";
            cmd.Parameters.AddWithValue("@user", login);
            cmd.Parameters.AddWithValue("@pass", senha);
            cmd.Connection = connect;
            MySqlDataReader user = cmd.ExecuteReader();
            if (user.Read())
            {
                connect.Close();
                return true;
            }
            else
            {
                connect.Close();
                return false;
            }
        }


        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            login = loginText.Text;
        }

        private void senhaText_TextChanged(object sender, EventArgs e)
        {
            senha = senhaText.Text;
        }


        private void button1_Click(object sender, EventArgs e)
        {
                       
            bool r = validate_login(login, senha);
            if (r)
            {
                
                Form2 newForm2 = new Form2();
                newForm2.ShowDialog();
                
            }
            else
            {
                MessageBox.Show("Credencias incorretas");
            }
        }
    } 
    
}
