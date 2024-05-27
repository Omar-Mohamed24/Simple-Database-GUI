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
    public partial class Add_Book : Form
    {
        public Add_Book()
        {
            InitializeComponent();
        }

        static int ExecuteSql(SqlConnection conn, string sql)
        {
            using (SqlCommand command = new SqlCommand(sql, conn))
            {
                int rowsAffected = command.ExecuteNonQuery();
                return rowsAffected;
            }
        }

        private void btnAddBook_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection("Server=localhost; Database=University Library Management; Integrated Security=True;"))
            {
                try
                {
                    conn.Open();
                    long bookId = long.Parse(txtBookID.Text);
                    long isbn = long.Parse(txtISBN.Text);
                    string title = txtTitle.Text;
                    long pubYear = long.Parse(txtPublicationYear.Text);
                    long quantity = long.Parse(txtQuantityAvailable.Text);

                    string sql = $"INSERT INTO BOOK (BOOK_ID, ISBN, TITLE, PUBLICATION_YEAR, QUANTITY_AVAILABLE) VALUES ({bookId}, '{isbn}', '{title}', {pubYear}, {quantity})";
                    if (ExecuteSql(conn, sql) > 0)
                        MessageBox.Show("Book inserted successfully.");
                    else
                        MessageBox.Show("No book was inserted.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed to insert book: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        private void btnDeleteBook_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection("Server=localhost; Database=University Library Management; Integrated Security=True;"))
            {
                try
                {
                    conn.Open();
                    long bookId = long.Parse(txtBookID.Text);

                    string sql = $"DELETE FROM BOOK WHERE BOOK_ID = {bookId}";
                    if (ExecuteSql(conn, sql) > 0)
                        MessageBox.Show("Book deleted successfully.");
                    else
                        MessageBox.Show("No book was deleted.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed to delete book: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        private void btnUpdateBook_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection("Server=localhost; Database=University Library Management; Integrated Security=True;"))
            {
                try
                {
                    conn.Open();
                    long bookId = long.Parse(txtBookID.Text);
                    long isbn = long.Parse(txtISBN.Text);
                    string title = txtTitle.Text;
                    long pubYear = long.Parse(txtPublicationYear.Text);
                    long quantity = long.Parse(txtQuantityAvailable.Text);

                    string sql = $"UPDATE BOOK SET TITLE = '{title}', PUBLICATION_YEAR = {pubYear}, QUANTITY_AVAILABLE = {quantity} WHERE BOOK_ID = {bookId}";
                    if (ExecuteSql(conn, sql) > 0)
                        MessageBox.Show("Book updated successfully.");
                    else
                        MessageBox.Show("No book was updated.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed to update book: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
        }

    }
}