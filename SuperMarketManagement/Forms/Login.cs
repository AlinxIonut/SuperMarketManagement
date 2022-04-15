using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;
using SuperMarketManagement.Forms;

namespace SuperMarketManagement
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
        public bool DataAreEmpty()
        {
            if (string.IsNullOrEmpty(textBox_Username.Text) || string.IsNullOrEmpty(textBox_Password.Text) || comboBox_AccountType.SelectedIndex == -1)
                return true;
            return false;
        }
        private void button_LogIn_Click(object sender, EventArgs e)
        {
            
            int UserExist=0;
            var connectionString =  ConfigurationManager.ConnectionStrings["connection"].ConnectionString;
              if (DataAreEmpty() == false)
                {
            var sql = $"Select * from Users where Username= '{textBox_Username.Text}' and password='{textBox_Password.Text}' and usertype= '{comboBox_AccountType.SelectedItem.ToString()}' ";
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open(); 
               
                SqlCommand cmd = new SqlCommand(sql, connection);
               
                    if (cmd.ExecuteScalar() != null)
                    {
                        UserExist = (int)cmd.ExecuteScalar();
                    }
                    if (UserExist > 0 && comboBox_AccountType.SelectedItem.ToString() == "admin")
                    {
                        this.Hide();
                      
                        Main main = new Main();
                       
                        main.label1.Text = $"Welcome,{textBox_Username.Text}";
                        main.label2.Text = $"You are logged as {comboBox_AccountType.SelectedItem}";
                        main.username = $"{textBox_Username.Text}";
                        main.textBox1.Text = $"{ comboBox_AccountType.SelectedItem}";
                        
                        main.ShowDialog();

                    }
                    else if (UserExist > 0 && comboBox_AccountType.SelectedItem.ToString() == "user")
                    {

                        this.Hide();
                     
                        Main main = new Main();
                   
                        main.label1.Text = $"Welcome,{textBox_Username.Text}";
                        main.label2.Text = $"You are logged as {comboBox_AccountType.SelectedItem} ";
                        main.textBox1.Text = $"{ comboBox_AccountType.SelectedItem}";
                        main.username = $"{textBox_Username.Text}";
                        main.button_Category.Visible = false;
                        main.button_Add.Visible = false;
                        main.button_Product.Location = new Point(308, 3);
                        main.ShowDialog();

                    }
                    else MessageBox.Show("You write a wrong data, please try again.");
                }
            }
                else MessageBox.Show("Please complete all data!");
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
