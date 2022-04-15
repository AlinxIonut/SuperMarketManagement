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
    public partial class AddCategory : Form
    {
        string categoryId;
        public AddCategory()
        {
            InitializeComponent();
        }
        public void Buttons()
        {
            
        }
        private void StyleDGV()
        {
            dataGridView_Category.BorderStyle = BorderStyle.None;
             dataGridView_Category.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
             dataGridView_Category.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
             dataGridView_Category.DefaultCellStyle.SelectionBackColor = Color.DarkTurquoise;
             dataGridView_Category.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;
             dataGridView_Category.BackgroundColor = Color.FromArgb(128, 128, 128);

             dataGridView_Category.EnableHeadersVisualStyles = false;
             dataGridView_Category.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
             dataGridView_Category.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(20, 25, 72);
             dataGridView_Category.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
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

            if (dataGridView_Category.Columns.Contains(edit.Name = "Edit"))
            {
                dataGridView_Category.Columns.Remove("Edit");
                dataGridView_Category.Columns.Remove("Delete");

            }
            var categoryRepository = RepositoryFactory.CreateCategoryRepository();
            dataGridView_Category.DataSource = categoryRepository.GetAll();
            dataGridView_Category.Columns.Add(edit);
            dataGridView_Category.Columns.Add(delete);
            dataGridView_Category.Columns[0].Visible = false;
        }
        private void AddCategory_Load(object sender, EventArgs e)
        {
            UpdateGrid();
            StyleDGV();
            Buttons();
            button_EditCateg.Visible = false;
        }
        public bool CategoryExist()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["connection"].ConnectionString;
            var sql = $"select * from Category  where Name='{textBox_CategoryName.Text}'";
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
        public bool CategoryNull()
        {
            if (string.IsNullOrEmpty(textBox_CategoryName.Text))
                return true;
            return false;
        }
        private void button1_Click(object sender, EventArgs e)
        {

            var categoryRepository = RepositoryFactory.CreateCategoryRepository();
            Category category = new Category();
            category.Name = textBox_CategoryName.Text;
            if (CategoryNull() == false)
            {
                if (CategoryExist() == false)
                {
                    categoryRepository.Create(category);
                    UpdateGrid();
                    textBox_CategoryName.Clear();
                }
                else
                {
                    MessageBox.Show("Category already exists");
                    textBox_CategoryName.Focus();
                }
            }
            else { MessageBox.Show("Complete name of category"); textBox_CategoryName.Focus(); }
        }

        private void dataGridView_Category_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var categoryRepository = RepositoryFactory.CreateCategoryRepository();
            if(dataGridView_Category.Columns[e.ColumnIndex].HeaderText=="Delete")
            {
                var result = MessageBox.Show("Are u sure u want delete? This category will be permanently deleted, will have to be added again if is necessary ", " ", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                if (result == DialogResult.Yes)
                {
                    
                        categoryRepository.Delete((int)dataGridView_Category.Rows[e.RowIndex].Cells["Id"].Value);
                    UpdateGrid();
                   
                   
                }
              
            }  if (dataGridView_Category.Columns[e.ColumnIndex].HeaderText == "Edit")
                {
                    textBox_CategoryName.Text = dataGridView_Category.Rows[e.RowIndex].Cells[1].Value.ToString();
                    categoryId = dataGridView_Category.Rows[e.RowIndex].Cells[0].Value.ToString();
                button_EditCateg.Visible = true;
                }
        }

        private void button_EditCateg_Click(object sender, EventArgs e)
        {
            var categoryReps = RepositoryFactory.CreateCategoryRepository();
            Category category = new Category();
            category.Name = textBox_CategoryName.Text;
            category.Id = int.Parse(categoryId);
            categoryReps.Update(category);
            UpdateGrid();
            button_EditCateg.Visible = false;
        }
    }
}
