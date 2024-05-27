using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class DisplayUser : Form
    {
        public DisplayUser()
        {
            InitializeComponent();
            LoadUsersIntoDataGridView();
        }

        private void LoadUsersIntoDataGridView()
        {
            using (SqlConnection conn = new SqlConnection("Server=localhost; Database=University Library Management; Integrated Security=True;"))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT * FROM [USER]";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    dataGridView1.DataSource = table;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed to load user info: " + ex.Message);
                }
            }
        }

        private void Load_Click(object sender, EventArgs e)
        {
            LoadUsersIntoDataGridView();
        }
    }
}
