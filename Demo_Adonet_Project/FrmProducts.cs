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
    public partial class FrmProducts : Form
    {
        public FrmProducts()
        {
            InitializeComponent();
        }

        

        private void btnList_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection("Data Source=DESKTOP-T0I7RRL;Initial Catalog=DbIstAkademi1;Integrated Security=True");
            connection.Open();
            SqlCommand command = new SqlCommand("Select * from Product", connection);
            SqlDataAdapter adapter = new SqlDataAdapter(command); 
            DataTable dataTable = new DataTable(); 
            adapter.Fill(dataTable);    
            dataGridView1.DataSource= dataTable;
            connection.Close();
           
        }
    }
}
