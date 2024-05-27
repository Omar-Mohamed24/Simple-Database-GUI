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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace WindowsFormsApp1
{
    public partial class Add_User : Form
    {
        public Add_User()
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

        private void btnAdduser_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection("Server=localhost; Database=University Library Management; Integrated Security=True;"))
            {
                try
                {
                    conn.Open();
                    long userId = long.Parse(textuserID.Text);
                    string fname = textuserfname.Text;
                    string lname = textuserLname.Text;
                    string gender = textuserGender.Text;
                    string user_name = textusername.Text;
                    string Email = textuseremail.Text;
                    string Pass = textuserpassword.Text;
                    string type = textusertype.Text;


                    string sql = $"INSERT INTO \"USER\" (USER_ID, FNAME, LNAME, GENDER, USER_NAME, EMAIL, PASSWORD, USER_TYPE) VALUES ({userId}, '{fname}', '{lname}', '{gender}', '{user_name}', '{Email}', '{Pass}', '{type}')";
                    if (ExecuteSql(conn, sql) > 0)
                        MessageBox.Show("User inserted successfully.");
                    else
                        MessageBox.Show("No User was inserted.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed to insert User: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        private void btnEditUser_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection("Server=localhost; Database=University Library Management; Integrated Security=True;"))
            {
                try
                {
                    conn.Open();
                    long userId = long.Parse(textuserID.Text);
                    string fname = textuserfname.Text;
                    string lname = textuserLname.Text;
                    string gender = textuserGender.Text;
                    string user_name = textusername.Text;
                    string Email = textuseremail.Text;
                    string Pass = textuserpassword.Text;
                    string type = textusertype.Text;


                    string sql = $"UPDATE \"USER\" SET FNAME = '{fname}', LNAME = '{lname}', GENDER = '{gender}', USER_NAME = '{user_name}', EMAIL = '{Email}', PASSWORD = '{Pass}', USER_TYPE = '{type}' WHERE USER_ID = {userId}";
                    if (ExecuteSql(conn, sql) > 0)
                        MessageBox.Show("User Updated successfully.");
                    else
                        MessageBox.Show("No User was Updated.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed to insert User: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        private void btnDeleteuser_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection("Server=localhost; Database=University Library Management; Integrated Security=True;"))
            {
                try
                {
                    conn.Open();
                    long userId = long.Parse(textuserID.Text);

                    string sql = $"DELETE FROM \"USER\" WHERE USER_ID = {userId}";
                    if (ExecuteSql(conn, sql) > 0)
                        MessageBox.Show("User deleted successfully.");
                    else
                        MessageBox.Show("No User was deleted.");
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
    }
}
