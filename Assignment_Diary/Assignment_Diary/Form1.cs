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
    public partial class Form1 : Form
    {
        

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["OOP2[E]"].ConnectionString);
           connection.Open();
 
            string sql = "INSERT INTO Events(EventName,EventDate,EventImportance,EventDescription) VALUES('" + textBox1.Text + "','" + dateTimePicker1.Text + "','" + comboBox1.Text + "','" + textBox2.Text + "')";
            SqlCommand command = new SqlCommand(sql, connection);
           
            int result = command.ExecuteNonQuery();
            connection.Close();
            if (result > 0)
            {
                MessageBox.Show("Event added successfully.");
                textBox1.Text = dateTimePicker1.Text = comboBox1.Text = textBox2.Text  = string.Empty;
               
            }
            else
            {
                MessageBox.Show("Error in  adding.");
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {
            Important il = new Important();
            il.Show();
            this.Hide();
        }

       private void button2_Click(object sender, EventArgs e)
        {
           SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["OOP2[E]"].ConnectionString);
           connection.Open();
           string sql = "UPDATE Events SET EventName='"+ textBox1.Text + "'WHERE EventName='" + textBox1.Text + "'";
           SqlCommand command = new SqlCommand(sql, connection);
            int result = command.ExecuteNonQuery();
            connection.Close();
            MessageBox.Show("Update successfull.");
            textBox1.Text = string.Empty;
        }
       
        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["OOP2[E]"].ConnectionString);
            connection.Open();
            string sql = "DELETE FROM Events WHERE EventName='" + textBox1.Text + "'";
            SqlCommand command = new SqlCommand(sql, connection);
            int result = command.ExecuteNonQuery();
            connection.Close();
            MessageBox.Show("Deleted successfully.");
            textBox1.Text= string.Empty;
        }
    }
}
