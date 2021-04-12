using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assignment_Diary
{
    public partial class Login_ : Form
    {
        public Login_()
        {
            InitializeComponent();
        }

        private void Login__Load(object sender, EventArgs e)
        {
          
                SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["OOP2[E]"].ConnectionString);
                connection.Open();
                string sql = "SELECT * FROM Login WHERE UserName='' and Password=''";
                SqlCommand command = new SqlCommand(sql, connection);
                SqlDataReader reader = command.ExecuteReader();
        }

        private void Login__FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text ==""|| textBox2.Text =="")
            {
                MessageBox.Show("username or password can not be empty");
            }
            else
            {
                Form1 f2 = new Form1();
                f2.Show();
                this.Hide();
            }
        }
    }
}
