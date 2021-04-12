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
    public partial class Important : Form
    {
        public Important()
        {
            InitializeComponent();
        }

        private void Important_Load(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["OOP2[E]"].ConnectionString);
            connection.Open();
            string sql = "SELECT * FROM Events";
            SqlCommand command = new SqlCommand(sql, connection);
            SqlDataReader reader = command.ExecuteReader();
            List<User> list = new List<User>();
            while (reader.Read())
            {
                User user = new User();
                user.Id = (int)reader["Id"];
                user.EventName = reader["EventName"].ToString();
                user.EventDate = reader["EventDate"].ToString();
                user.EventImportance = reader["EventImportance"].ToString();
                user.EventDescription = reader["EventDescription"].ToString();
              
                list.Add(user);
            }

            dataGridView1.DataSource = list;
        }

        private void Important_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void Home_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            f1.Show();
            this.Hide();
        }
    }
}
