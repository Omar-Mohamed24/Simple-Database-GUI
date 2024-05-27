using System;
using System.Collections;
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
    public partial class Search_Book : Form
    {
        public Search_Book()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection("Server=localhost; Database=University Library Management; Integrated Security=True;"))
            {
                conn.Open();


                string title = textBox1.Text;
                string sql = "SELECT BOOK_ID, ISBN, TITLE, PUBLICATION_YEAR, QUANTITY_AVAILABLE FROM BOOK WHERE TITLE LIKE @title";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@title", $"%{title}%");

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            MessageBox.Show($"Book ID: {reader["BOOK_ID"]}, ISBN: {reader["ISBN"]}, Title: {reader["TITLE"]}, Year: {reader["PUBLICATION_YEAR"]}, Quantity: {reader["QUANTITY_AVAILABLE"]}");
                        }
                    }
                    else
                    {
                        MessageBox.Show("No books found with that title.");
                    }
                }

                conn.Close();
            }

        }
    }
}



