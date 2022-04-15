using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SuperMarketManagement.Forms
{
    public partial class Main : Form
    {
        public string username;
        public Main()
        {
            InitializeComponent();
        }

        private void button_Category_Click(object sender, EventArgs e)
        {
            AddCategory addCategory = new AddCategory();
            this.Hide();
            addCategory.ShowDialog();
            this.Show();
        }

        private void Main_FormClosed(object sender, FormClosedEventArgs e)
        {
            Login login = new Login();
            login.Show();
        }

        private void button_Add_Click(object sender, EventArgs e)
        {
            AddUser addUser = new AddUser();
            this.Hide();
            addUser.ShowDialog();
            this.Show();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
         
        }

        private void button_Product_Click(object sender, EventArgs e)
        {
            AddProduct addProduct = new AddProduct();
            this.Hide();
            addProduct.username = username;
            addProduct.textBox1.Text = textBox1.Text;
            addProduct.ShowDialog();
            this.Show();
        }

        private void Main_Load(object sender, EventArgs e)
        {
           
        }
    }
}
