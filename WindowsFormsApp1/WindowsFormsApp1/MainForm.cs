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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }


        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Add_Book ADD = new Add_Book();
            this.Hide();
            ADD.ShowDialog();
            this.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Add_User ADDU = new Add_User();
            this.Hide();
            ADDU.ShowDialog();
            this.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DisplayBooks D = new DisplayBooks();
            this.Hide();
            D.ShowDialog();
            this.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            DisplayUser DU = new DisplayUser();
            this.Hide();
            DU.ShowDialog();
            this.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Search_Book Search = new Search_Book();
            this.Hide();
            Search.ShowDialog();
            this.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
