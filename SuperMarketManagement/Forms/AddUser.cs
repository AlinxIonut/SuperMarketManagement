using SuperMarketManagement.Models;
using SuperMarketManagement.Repository;
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

namespace SuperMarketManagement.Forms
{
    public partial class AddUser : Form
    {
        string userid;
        public AddUser()
        {
            InitializeComponent();
        }
        public bool DataAreEmpty()
        {
            if (string.IsNullOrEmpty(textBox_AddUsername.Text) || string.IsNullOrEmpty(textBox_Password.Text) || comboBox_UserType.SelectedIndex== -1)
                return true;
            return false;
             
        }
        public bool ExistUser()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["connection"].ConnectionString;
            var sql = $"select * from Users  where username='{textBox_AddUsername.Text}'";
            using (var connection = new SqlConnection(connectionString))
            {

                connection.Open();
                SqlCommand cmd = new SqlCommand(sql, connection);



                if (Convert.ToInt32(cmd.ExecuteScalar()) >= 1)
                {

                    return true;

                }
                else
                {

                    return false;
                }
            }
            }
        private void button_AddUser_Click(object sender, EventArgs e)
        {
            var userRepository = RepositoryFactory.CreateUserRepository();
            User user = new User();
            user.Username = textBox_AddUsername.Text;
            user.Password = textBox_Password.Text;
            
            if (DataAreEmpty() == false)
            {
                user.UserType = comboBox_UserType.SelectedItem.ToString();
                if (ExistUser() == false)
                {
                    userRepository.Create(user);
                    textBox_AddUsername.Clear();
                    textBox_Password.Clear();
                    comboBox_UserType.SelectedIndex = -1;
                    UpdateGrid();
                }

                else
                { MessageBox.Show("Users aleardy exists, choose another username!"); textBox_AddUsername.Focus(); }
            } else { MessageBox.Show("Please complete all data!"); }
        }
        private void StyleDGV()
        {
           dataGridView_Users.BorderStyle = BorderStyle.None;
           dataGridView_Users.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
           dataGridView_Users.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
           dataGridView_Users.DefaultCellStyle.SelectionBackColor = Color.DarkTurquoise;
           dataGridView_Users.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;
           dataGridView_Users.BackgroundColor = Color.FromArgb(128, 128, 128);

           dataGridView_Users.EnableHeadersVisualStyles = false;
           dataGridView_Users.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
           dataGridView_Users.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(20, 25, 72);
           dataGridView_Users.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
        }
        public void UpdateGrid()
        {
            DataGridViewButtonColumn edit = new DataGridViewButtonColumn();
            DataGridViewButtonColumn delete = new DataGridViewButtonColumn();
            delete.FlatStyle = FlatStyle.Flat;
            delete.HeaderText = "Delete";
            delete.Name = "Delete";
            delete.UseColumnTextForButtonValue = true;
            delete.Text = "Delete";
            delete.Width = 60;

            edit.FlatStyle = FlatStyle.Flat;
            edit.HeaderText = "Edit";
            edit.Name = "Edit";
            edit.UseColumnTextForButtonValue = true;
            edit.Text = "Edit";
            edit.Width = 60;

            if (dataGridView_Users.Columns.Contains(edit.Name = "Edit"))
            {
                dataGridView_Users.Columns.Remove("Edit");
                dataGridView_Users.Columns.Remove("Delete");
                
            }
            var userRepository = RepositoryFactory.CreateUserRepository();
            dataGridView_Users.DataSource = userRepository.GetAll();
            dataGridView_Users.Columns.Add(edit);
            dataGridView_Users.Columns.Add(delete);
            dataGridView_Users.Columns[0].Visible = false;
        }
        
        private void AddUser_Load(object sender, EventArgs e)
        {
            StyleDGV();
            UpdateGrid();
           
            button_Edit.Visible = false;
        }

        private void dataGridView_Users_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var Reviews = RepositoryFactory.CreateProductEvaluationRepository();
            var userRepository = RepositoryFactory.CreateUserRepository();
            var connectionString = ConfigurationManager.ConnectionStrings["connection"].ConnectionString;
          
            var sql2 = "select COUNT(usertype) from users where usertype='admin'";
            using (var connection = new SqlConnection(connectionString))
            {

                connection.Open();
             
                SqlCommand admin = new SqlCommand(sql2, connection);
                if (dataGridView_Users.Columns[e.ColumnIndex].HeaderText == "Delete")
                {

                    var result = MessageBox.Show("Are u sure u want delete? This category will be permanently deleted, will have to be added again if is necessary ", " ", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);

                    if (result == DialogResult.Yes)
                    {

                        if ((int)admin.ExecuteScalar() > 1)
                        {
                            Reviews.Delete((int)dataGridView_Users.Rows[e.RowIndex].Cells["Id"].Value);
                            userRepository.Delete((int)dataGridView_Users.Rows[e.RowIndex].Cells["Id"].Value);
                            UpdateGrid();


                        }
                        else if ((int)admin.ExecuteScalar() >= 1 && dataGridView_Users.Rows[e.RowIndex].Cells["UserType"].Value.ToString() == "user")
                        {
                            Reviews.Delete((int)dataGridView_Users.Rows[e.RowIndex].Cells["Id"].Value);
                            userRepository.Delete((int)dataGridView_Users.Rows[e.RowIndex].Cells["Id"].Value);
                            UpdateGrid();
                        }
                        else MessageBox.Show("You must to have one or more admin, you can t delete all admin.");

                    }
                }
                
                   
                   

                }
            if (dataGridView_Users.Columns[e.ColumnIndex].HeaderText == "Edit")
            {
                textBox_AddUsername.Text = dataGridView_Users.Rows[e.RowIndex].Cells[1].Value.ToString();
                textBox_Password.Text = dataGridView_Users.Rows[e.RowIndex].Cells[2].Value.ToString();
                comboBox_UserType.SelectedItem = dataGridView_Users.Rows[e.RowIndex].Cells[3].Value.ToString();
                userid = dataGridView_Users.Rows[e.RowIndex].Cells[0].Value.ToString();
                button_Edit.Visible = true;
            }



            }

        private void button_Edit_Click(object sender, EventArgs e)
        {
            var userRepository = RepositoryFactory.CreateUserRepository();
            User user = new User();
            user.Username = textBox_AddUsername.Text;
            user.Password = textBox_Password.Text;
            user.Id = int.Parse(userid);

            if (DataAreEmpty() == false)
            {
                user.UserType = comboBox_UserType.SelectedItem.ToString();
               
              
                    userRepository.Update(user);
                    textBox_AddUsername.Clear();
                    textBox_Password.Clear();
                    comboBox_UserType.SelectedIndex = -1;
                      UpdateGrid();
                button_Edit.Visible = false;
                
                
            }
            else { MessageBox.Show("Please complete all data!"); }
        }
    }
    }

