using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Demo_Adonet_Project
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        //Data Source=DESKTOP-T0I7RRL;Initial Catalog=DbIstAkademi1;Integrated Security=True
        private void btnList_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection("Data Source=DESKTOP-T0I7RRL;Initial Catalog=DbIstAkademi1;Integrated Security=True");
             connection.Open();
            SqlCommand command = new SqlCommand("Select * from Category", connection);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            dataGridView1.DataSource= dataTable;
            connection.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection("Data Source=DESKTOP-T0I7RRL;Initial Catalog=DbIstAkademi1;Integrated Security=True");
            connection.Open();
            SqlCommand command = new SqlCommand("insert into Category (CategoryName) Values (@p1)", connection);
            command.Parameters.AddWithValue("@p1", txtCategoryName.Text);
            command.ExecuteNonQuery();
            connection.Close();
            MessageBox.Show("kategori başarılı bir şekilde eklendi");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection("Data Source=DESKTOP-T0I7RRL;Initial Catalog=DbIstAkademi1;Integrated Security=True");
            connection.Open();
            SqlCommand command = new SqlCommand("Delete from Category where categoryId=@p1", connection);
            command.Parameters.AddWithValue("@p1",txtCategoryId.Text);
            command.ExecuteNonQuery();


            connection.Close();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {

            SqlConnection connection = new SqlConnection("Data Source=DESKTOP-T0I7RRL;Initial Catalog=DbIstAkademi1;Integrated Security=True");
            connection.Open();
            SqlCommand command = new SqlCommand("Update Category Set CategoryName=@p1 where categoryId=@p2",connection);
            command.Parameters.AddWithValue("@p1", txtCategoryName.Text);
            command.Parameters.AddWithValue("@p2", txtCategoryId.Text);
            command.ExecuteNonQuery();
            connection.Close();
        }
    }
}
