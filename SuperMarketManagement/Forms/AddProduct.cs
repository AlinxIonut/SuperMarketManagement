using SuperMarketManagement.Models;
using SuperMarketManagement.Properties;
using SuperMarketManagement.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.Odbc;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using CsvHelper;
using System.Globalization;

namespace SuperMarketManagement.Forms
{

    public partial class AddProduct : Form
    {
        public string s;
        public string username;
        int Id = 0;
        public List<Product> product = new List<Product>();
        public AddProduct()
        {
            InitializeComponent();
        }

        public bool DataEmpty()
        {
            if (string.IsNullOrEmpty(textBox_Name.Text) || string.IsNullOrEmpty(textBox_Price.Text) || string.IsNullOrEmpty(textBox_Brand.Text) || string.IsNullOrEmpty(Description.Text) || list_CategoryType.SelectedIndex == -1)

                return true;
            return false;

        }

        private void UpdateComboBoxCategory()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["connection"].ConnectionString;
            var sql = "select Id,Name from Category  ";
            using (var connection = new SqlConnection(connectionString))
            {

                connection.Open();
                SqlCommand cmd = new SqlCommand(sql, connection);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    list_CategoryType.Items.Add(reader["Name"].ToString());
                    listView_Category.Items.Add(reader["Name"].ToString());

                }
            }




        }

        private void UpdateListBrand()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["connection"].ConnectionString;
            var sql = "select distinct(Brand) from Product ";
            using (var connection = new SqlConnection(connectionString))
            {

                connection.Open();
                SqlCommand cmd = new SqlCommand(sql, connection);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    list_Brands.Items.Add(reader["Brand"].ToString());
                 

                }
            }




        }









        private void StyleDGV()
        {
            dataGridView_Product.BorderStyle = BorderStyle.None;
            dataGridView_Product.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
            dataGridView_Product.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridView_Product.DefaultCellStyle.SelectionBackColor = Color.DarkTurquoise;
            dataGridView_Product.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;
            dataGridView_Product.BackgroundColor = Color.FromArgb(128, 128, 128);

            dataGridView_Product.EnableHeadersVisualStyles = false;
            dataGridView_Product.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridView_Product.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(20, 25, 72);
            dataGridView_Product.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
        }

   

        private void button_Product_Click(object sender, EventArgs e)
        {

            if (DataEmpty() == false)
            {
                var productRepository = RepositoryFactory.CreateProductRepository();
                Product product = new Product();
                product.Name = textBox_Name.Text;
                product.Description = Description.Text;
                product.Price = int.Parse(textBox_Price.Text);
                product.FabricationDate = dateTimePicker1.Value;
                product.Brand = textBox_Brand.Text;

                productRepository.Create(product);
                var sql = "select ID from Product where Name=@name";
                var connectionString = ConfigurationManager.ConnectionStrings["connection"].ConnectionString;
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand(sql, connection);
                    cmd.Parameters.Add("@name", SqlDbType.NVarChar).Value = product.Name;
                    product.Id = (int)cmd.ExecuteScalar();

                }

                var categorytypeRepository = RepositoryFactory.CreateCategoryTypeRepository();
                CategoryType categoryType = new CategoryType();
                

                categoryType.ProductId = int.Parse(product.Id.ToString());




                foreach (object category in list_CategoryType.SelectedItems)
                {
                    var sql1 = "select ID from Category where Name=@name";

                    using (var connection = new SqlConnection(connectionString))
                    {
                        connection.Open();
                        SqlCommand cmd = new SqlCommand(sql1, connection);
                        cmd.Parameters.Add("@name", SqlDbType.NVarChar).Value = category.ToString();
                        categoryType.CategoryId = (int)cmd.ExecuteScalar();

                        categorytypeRepository.Create(categoryType);
                    }

                }
                var result = MessageBox.Show("Do you want add photo for this proudct ", "Photo", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                if(result == DialogResult.Yes)
                {
                    AddPhotos addPhotos = new AddPhotos();

                    addPhotos.textBox_name.Text = textBox_Name.Text;
                    addPhotos.ShowDialog();
                }
                UpdateGrids();
                list_Brands.Items.Clear();
                UpdateListBrand();
            }
            else MessageBox.Show("You need to complete all data");
        }

        public void UpdateGrids()
        {
            DataGridViewButtonColumn edit = new DataGridViewButtonColumn();
            DataGridViewButtonColumn delete = new DataGridViewButtonColumn();
            DataGridViewButtonColumn disable = new DataGridViewButtonColumn();
            DataGridViewButtonColumn enable = new DataGridViewButtonColumn();
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


            disable.FlatStyle = FlatStyle.Flat;
            disable.HeaderText = "Disable Product";
            disable.Name = "Disable";
            disable.UseColumnTextForButtonValue = true;
            disable.Text = "Disable";
            disable.Width = 60;

            enable.FlatStyle = FlatStyle.Flat;
            enable.HeaderText = "Enable Product";
            enable.Name = "Enable";
            enable.UseColumnTextForButtonValue = true;
            enable.Text = "Enable";
            enable.Width = 60;



            if (textBox1.Text == "admin")
            {

                if (dataGridView_Product.Columns.Contains(edit.Name = "Edit"))
                {
                    dataGridView_Product.Columns.Remove("Edit");
                    dataGridView_Product.Columns.Remove("Delete");
                    dataGridView_Product.Columns.Remove("Enable");
                    dataGridView_Product.Columns.Remove("Disable");
                }
                var productRepository = RepositoryFactory.CreateProductRepository();


                var bindigList = new BindingList<Product>(productRepository.GetAll());
                dataGridView_Product.DataSource = new BindingSource(bindigList, null);
                dataGridView_Product.Columns.Add(edit);
                dataGridView_Product.Columns.Add(delete);
                dataGridView_Product.Columns.Add(disable);
                dataGridView_Product.Columns.Add(enable);
               dataGridView_Product.Columns[7].Visible = false;
                
            }
            else
            {

                if (dataGridView_Product.Columns.Contains(edit.Name = "Edit"))
                {
                    dataGridView_Product.Columns.Remove("Edit");
                    dataGridView_Product.Columns.Remove("Delete");
                    dataGridView_Product.Columns.Remove("Enable");
                    dataGridView_Product.Columns.Remove("Disable");
                }


                var productRepository = RepositoryFactory.CreateProductRepository();


                var bindigList = new BindingList<Product>(productRepository.GetActiveProduct());
                dataGridView_Product.DataSource = new BindingSource(bindigList, null);

                dataGridView_Product.Columns.Add(edit);
                dataGridView_Product.Columns.Add(delete);
                dataGridView_Product.Columns.Add(disable);
                dataGridView_Product.Columns.Add(enable);
                dataGridView_Product.Columns[7].Visible = false;
                dataGridView_Product.Columns[11].Visible = false;
            }

        
            
          
           

        }

        private void AddProduct_Load(object sender, EventArgs e)
        {   
            UpdateGrids();
            UpdateComboBoxCategory();
            UpdateListBrand();
            StyleDGV();
            button_ExportJSON.Visible = false;
            button_ExportCSV.Visible = false;
         
            

            dataGridView_Product.Columns[0].Visible = false;
        dataGridView_Product.Columns[7].Visible = false;


          //  if (textBox1.Text == "user")
           // {
           //     dataGridView_Product.Columns[10].Visible = false;
           // }
            button_Edit.Enabled = false;
          
        }

        private void dataGridView_Product_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView_Product.Columns[e.ColumnIndex].HeaderText == "Edit")
            {
              
                textBox_Name.Text = dataGridView_Product.Rows[e.RowIndex].Cells[1].Value.ToString();
                Description.Text = dataGridView_Product.Rows[e.RowIndex].Cells[2].Value.ToString();
                textBox_Price.Text = dataGridView_Product.Rows[e.RowIndex].Cells[3].Value.ToString();
                dateTimePicker1.Value = (DateTime)dataGridView_Product.Rows[e.RowIndex].Cells[4].Value;
                textBox_Brand.Text = dataGridView_Product.Rows[e.RowIndex].Cells[5].Value.ToString();
                s = dataGridView_Product.Rows[e.RowIndex].Cells[6].Value.ToString();
                Id = (int)dataGridView_Product.Rows[e.RowIndex].Cells[0].Value;
                button_Edit.Enabled = true;
                button_Product.Enabled = false;
               // UpdateGrids();

            }
            if (dataGridView_Product.Columns[e.ColumnIndex].HeaderText == "Delete")
            {
              
                    var PicturesPath = ConfigurationManager.AppSettings["PicturesPath"];
                    var categoryTypeRepository = RepositoryFactory.CreateCategoryTypeRepository();
                    var productRepository = RepositoryFactory.CreateProductRepository();
                    var dialogresult = MessageBox.Show("Are u sure? This action  is irreversibile", "Attention!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (dialogresult == DialogResult.Yes)
                    {
                        DirectoryInfo DIR = new DirectoryInfo($"{PicturesPath}\\{dataGridView_Product.Rows[e.RowIndex].Cells[1].Value}");
                        if (DIR.Exists)
                        {
                        GC.Collect();
                        

                            DIR.Delete(true);
                        }
                        categoryTypeRepository.Delete((int)dataGridView_Product.Rows[e.RowIndex].Cells[0].Value);
                        productRepository.Delete((int)dataGridView_Product.Rows[e.RowIndex].Cells[0].Value);



                    }
                    list_Brands.Items.Clear();
                    UpdateListBrand();
                if (string.IsNullOrEmpty(search) && string.IsNullOrEmpty(max) && string.IsNullOrEmpty(min))
                {
                    UpdateGrids();
                }
                else if (!string.IsNullOrEmpty(search)) UpdateSearchGrid();
                else if (!string.IsNullOrEmpty(max) && !string.IsNullOrEmpty(min)) UpdateSearchPrice();
            }
            if (dataGridView_Product.Columns[e.ColumnIndex].HeaderText == "Disable Product")
            {



                if (textBox1.Text == "admin")
                {
                    var connectionString = ConfigurationManager.ConnectionStrings["connection"].ConnectionString;
                    var selectUser = $"Update Product set  ProductStatus='disable' where Id='{dataGridView_Product.Rows[e.RowIndex].Cells[0].Value}'";
                    using (var connection = new SqlConnection(connectionString))
                    {
                        connection.Open();
                        SqlCommand cmd = new SqlCommand(selectUser, connection);
                        if (dataGridView_Product.Rows[e.RowIndex].Cells[6].Value.ToString() == "disable")
                        {
                            MessageBox.Show("This item is already disable");

                        }

                        else cmd.ExecuteNonQuery();
                    }
                }
                else if (textBox1.Text == "user")
                {
                    var dialogresult = MessageBox.Show("Are u sure? If you deactivate this product you will only be able to see it if an admin activates it again", "Attention!", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                    if (dialogresult == DialogResult.Yes)
                    {
                        var connectionString = ConfigurationManager.ConnectionStrings["connection"].ConnectionString;
                        var selectUser = $"Update Product set  ProductStatus='disable' where Id='{dataGridView_Product.Rows[e.RowIndex].Cells[0].Value}'";
                        using (var connection = new SqlConnection(connectionString))
                        {
                            connection.Open();
                            SqlCommand cmd = new SqlCommand(selectUser, connection);
                            if (dataGridView_Product.Rows[e.RowIndex].Cells[6].Value.ToString() == "disable")
                            {
                                MessageBox.Show("This item is already disable");

                            }

                            else cmd.ExecuteNonQuery();
                        }
                    }
                }


                if (string.IsNullOrEmpty(search))
                {
                    UpdateGrids();
                }
                else UpdateSearchGrid();

            }
            if (dataGridView_Product.Columns[e.ColumnIndex].HeaderText == "Enable Product")
            {
               // UpdateGrids();
                if (textBox1.Text == "admin")
                {
                    var connectionString = ConfigurationManager.ConnectionStrings["connection"].ConnectionString;
                    var selectUser = $"Update Product set  ProductStatus='active' where Id='{dataGridView_Product.Rows[e.RowIndex].Cells[0].Value}'";
                    using (var connection = new SqlConnection(connectionString))
                    {
                        connection.Open();
                        SqlCommand cmd = new SqlCommand(selectUser, connection);
                        if (dataGridView_Product.Rows[e.RowIndex].Cells[6].Value.ToString() == "active")
                        {
                            MessageBox.Show("This item is already active");

                        }

                        else cmd.ExecuteNonQuery();
                        UpdateGrids();
                    }


                }

            }
        }

        private void button_Edit_Click(object sender, EventArgs e)
        {
            if (DataEmpty() == false)
            {
                var productRepository = RepositoryFactory.CreateProductRepository();
                Product product = new Product();
                product.Name = textBox_Name.Text;
                product.Description = Description.Text;
                product.Price = int.Parse(textBox_Price.Text);
                product.FabricationDate = dateTimePicker1.Value;
                product.Brand = textBox_Brand.Text;
                product.ProductStatus = s;
                product.Id = Id;
                productRepository.Update(product);
                var sql = "select ID from Product where Name=@name";
                var connectionString = ConfigurationManager.ConnectionStrings["connection"].ConnectionString;
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand(sql, connection);
                    cmd.Parameters.Add("@name", SqlDbType.NVarChar).Value = product.Name;
                    product.Id = (int)cmd.ExecuteScalar();

                }

                var categorytypeRepository = RepositoryFactory.CreateCategoryTypeRepository();
                CategoryType categoryType = new CategoryType();
                

                categoryType.ProductId = int.Parse(product.Id.ToString());

                categorytypeRepository.Delete(categoryType.ProductId);


                foreach (object category in list_CategoryType.SelectedItems)
                {
                    var sql1 = "select ID from Category where Name=@name";

                    using (var connection = new SqlConnection(connectionString))
                    {
                        connection.Open();
                        SqlCommand cmd = new SqlCommand(sql1, connection);
                        cmd.Parameters.Add("@name", SqlDbType.NVarChar).Value = category.ToString();
                        categoryType.CategoryId = (int)cmd.ExecuteScalar();
                        
                        categorytypeRepository.Create(categoryType);
                    }

                }
                var result = MessageBox.Show("Do you want add photo for this proudct ", "Photo", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                if (result == DialogResult.Yes)
                {
                    AddPhotos addPhotos = new AddPhotos();

                    addPhotos.textBox_name.Text = textBox_Name.Text;
                    addPhotos.ShowDialog();
                }
                UpdateGrids();
                button_Edit.Enabled = false;
                button_Product.Enabled = true;
            }
            else MessageBox.Show("You need to complete all data!");
        }

        private void button_ClearData_Click(object sender, EventArgs e)
        {
            listView_Category.SelectedIndex = -1;
            list_Brands.SelectedIndex = -1;
            list_CategoryType.SelectedIndex = -1;
            textBox_Name.Clear();
            Description.Clear();
            dateTimePicker1.Value = DateTime.Now;
            textBox_Brand.Clear();
            textBox_Price.Clear();
            button_Product.Enabled = true;
            button_Edit.Enabled = false;
            button_ExportJSON.Visible = false;
            button_ExportCSV.Visible = false;
            textBox_Search.Clear();
            textBox_Max.Clear();
            textBox_Min.Clear();
            search = string.Empty;
            max = string.Empty;
            min = string.Empty;
            UpdateGrids();

        }

        private void button_AddPhoto_Click(object sender, EventArgs e)
        {
           
        }

        private void textBox_Name_Leave(object sender, EventArgs e)
        {


        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (panel1.Visible == true)
            {
                panel1.Visible = false;
            }
            else panel1.Visible = true;
        }

        private void listView_Category_Click(object sender, EventArgs e)
        {
           UpdateGrids();
            dataGridView_Product.Columns[7].Visible = true;
                dataGridView_Product.Columns[8].Visible = false;
                dataGridView_Product.Columns[9].Visible = false;
               dataGridView_Product.Columns[10].Visible = false;
              dataGridView_Product.Columns[11].Visible = false;
            button_ExportJSON.Visible = true;
            button_ExportCSV.Visible = true;
            var productRepository = RepositoryFactory.CreateProductRepository();
            foreach (object category in listView_Category.SelectedItems)
            {  
                
                dataGridView_Product.DataSource = productRepository.GettFromMultiple().Where(product => product.Category == category.ToString()).ToList();
               

         

            }
        }

        private void list_Brands_Click(object sender, EventArgs e)
        {
            UpdateGrids();
            dataGridView_Product.Columns[7].Visible = false;
            dataGridView_Product.Columns[8].Visible = false;
            dataGridView_Product.Columns[9].Visible = false;
            dataGridView_Product.Columns[10].Visible = false;
            dataGridView_Product.Columns[11].Visible = false;

            var productRepository = RepositoryFactory.CreateProductRepository();
           
            foreach (object brand in list_Brands.SelectedItems)
            {
                
                dataGridView_Product.DataSource = productRepository.GetAll().Where(product => product.Brand == brand.ToString() && product.ProductStatus=="active").ToList();

            }
        }

        private void dataGridView_Product_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if ((listView_Category.SelectedIndex == -1 && list_Brands.SelectedIndex == -1))
            {
                ProductView productView = new ProductView();
                productView.nameFolder = dataGridView_Product.Rows[e.RowIndex].Cells[1].Value.ToString();
                productView.label1.Text = "Name: " + dataGridView_Product.Rows[e.RowIndex].Cells[1].Value.ToString();
                productView.label2.Text = "Description: " + dataGridView_Product.Rows[e.RowIndex].Cells[2].Value.ToString();
                productView.label3.Text = "Price: " + dataGridView_Product.Rows[e.RowIndex].Cells[3].Value.ToString();
                productView.label4.Text = "FabricationDate: " + dataGridView_Product.Rows[e.RowIndex].Cells[4].Value.ToString();
                productView.label5.Text = "Brand: " + dataGridView_Product.Rows[e.RowIndex].Cells[5].Value.ToString();
                productView.label9.Text = dataGridView_Product.Rows[e.RowIndex].Cells[0].Value.ToString();
                productView.ImageList();
                productView.username = username;
                var sql = "select AVG(Rating) from ProductEvaluation where ProductId=@pId";
                var connectionString = ConfigurationManager.ConnectionStrings["connection"].ConnectionString;
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand(sql, connection);
                    cmd.Parameters.Add("@pId", SqlDbType.NVarChar).Value = dataGridView_Product.Rows[e.RowIndex].Cells[0].Value.ToString();
                    try
                    {
                        if (Convert.ToInt32(cmd.ExecuteScalar()) >= 1)
                        {
                            int Rating = (int)cmd.ExecuteScalar();

                            if (Rating == 1)
                            {
                                productView.starz.Image = Resources.star;
                            }
                            if (Rating == 2)
                            {
                                productView.starz.Image = Resources.star;
                                productView.starz1.Image = Resources.star;
                            }
                            if (Rating == 3)
                            {
                                productView.starz.Image = Resources.star;
                                productView.starz1.Image = Resources.star;
                                productView.starz2.Image = Resources.star;
                            }
                            if (Rating == 4)
                            {
                                productView.starz.Image = Resources.star;
                                productView.starz1.Image = Resources.star;
                                productView.starz2.Image = Resources.star;
                                productView.starz3.Image = Resources.star;
                            }
                            if (Rating == 5)
                            {
                                productView.starz.Image = Resources.star;
                                productView.starz1.Image = Resources.star;
                                productView.starz2.Image = Resources.star;
                                productView.starz3.Image = Resources.star;
                                productView.starz4.Image = Resources.star;
                            }
                        }
                        productView.ShowDialog();
                    }
                    catch { productView.ShowDialog(); }
                }
            }

        }

        private void button_ImportJSON_Click(object sender, EventArgs e)
        {
            var configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            var settings = configFile.AppSettings.Settings;
            
           
            
                settings["repType"].Value = "2";
           
            configFile.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection(configFile.AppSettings.SectionInformation.Name);
          
            foreach (object category in listView_Category.SelectedItems)
            {

        
  var productRepository = RepositoryFactory.CreateProductRepository();
           
          
            var filePath = ConfigurationManager.AppSettings["ProductPath"];

            if (!Directory.Exists(filePath))
            {
                Directory.CreateDirectory(filePath);
            }
            
         
           File.WriteAllText(Path.Combine(filePath, $"{category}.json"), JsonConvert.SerializeObject(productRepository.GettFromMultiple().Where(product => product.Category == category.ToString()).ToList()));
                MessageBox.Show($"Your data was exported at {Path.Combine(filePath, $"{category}.json")} ");
                button_ExportJSON.Visible = false;

            }

          



            settings["repType"].Value = "1";

            configFile.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection(configFile.AppSettings.SectionInformation.Name);
        }

        private void button_ImportCSV_Click(object sender, EventArgs e)
        {
            var productRepository = RepositoryFactory.CreateProductRepository();
            var filePath = ConfigurationManager.AppSettings["ProductPath"];   
            foreach (object category in listView_Category.SelectedItems)
            {


                using (var writer = new StreamWriter($"{filePath}\\{category}.csv"))
                using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))

                {
                    csv.WriteRecords(productRepository.GettFromMultiple().Where(product => product.Category == category.ToString()).ToList());
                    MessageBox.Show($"Your csv data was exported at {Path.Combine(filePath, $"{category}.csv")} ");
                }
            }
 button_ExportCSV.Visible = false;
        }

        private void textBox_Min_TextChanged(object sender, EventArgs e)
        {
           
        
           
        }

        private void textBox_Max_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void textBox_Search_TextChanged(object sender, EventArgs e)
        {
           
         
        }
        private void UpdateSearchGrid()
        {
            DataGridViewButtonColumn edit = new DataGridViewButtonColumn();
            DataGridViewButtonColumn delete = new DataGridViewButtonColumn();
            DataGridViewButtonColumn disable = new DataGridViewButtonColumn();
            DataGridViewButtonColumn enable = new DataGridViewButtonColumn();
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


            disable.FlatStyle = FlatStyle.Flat;
            disable.HeaderText = "Disable Product";
            disable.Name = "Disable";
            disable.UseColumnTextForButtonValue = true;
            disable.Text = "Disable";
            disable.Width = 60;

            enable.FlatStyle = FlatStyle.Flat;
            enable.HeaderText = "Enable Product";
            enable.Name = "Enable";
            enable.UseColumnTextForButtonValue = true;
            enable.Text = "Enable";
            enable.Width = 60;

            if (dataGridView_Product.Columns.Contains(edit.Name = "Edit"))
            {
                dataGridView_Product.Columns.Remove("Edit");
                dataGridView_Product.Columns.Remove("Delete");
                dataGridView_Product.Columns.Remove("Enable");
                dataGridView_Product.Columns.Remove("Disable");
            }
           
                var productRepository = RepositoryFactory.CreateProductRepository();
            var bindigList = new BindingList<Product>(productRepository.GetActiveProduct().Where(product => product.Name.Contains(textBox_Search.Text)).ToList());
            dataGridView_Product.DataSource = new BindingSource(bindigList, null);
            dataGridView_Product.Columns.Add(edit);
            dataGridView_Product.Columns.Add(delete);
            dataGridView_Product.Columns.Add(disable);
            dataGridView_Product.Columns.Add(enable); 
            if (textBox1.Text == "user")
            {
                dataGridView_Product.Columns[11].Visible = false;
            }

        }
        string max = string.Empty;
        string min = string.Empty;
        private void UpdateSearchPrice()
        {
            DataGridViewButtonColumn edit = new DataGridViewButtonColumn();
            DataGridViewButtonColumn delete = new DataGridViewButtonColumn();
            DataGridViewButtonColumn disable = new DataGridViewButtonColumn();
            DataGridViewButtonColumn enable = new DataGridViewButtonColumn();
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


            disable.FlatStyle = FlatStyle.Flat;
            disable.HeaderText = "Disable Product";
            disable.Name = "Disable";
            disable.UseColumnTextForButtonValue = true;
            disable.Text = "Disable";
            disable.Width = 60;

            enable.FlatStyle = FlatStyle.Flat;
            enable.HeaderText = "Enable Product";
            enable.Name = "Enable";
            enable.UseColumnTextForButtonValue = true;
            enable.Text = "Enable";
            enable.Width = 60;

            if (string.IsNullOrEmpty(textBox_Max.Text) && string.IsNullOrEmpty(textBox_Min.Text))
            {
                MessageBox.Show("You need to write all data");
                return;
            }
            else if(!string.IsNullOrEmpty(textBox_Max.Text) && !string.IsNullOrEmpty(textBox_Min.Text))
            {
            
                if (dataGridView_Product.Columns.Contains(edit.Name = "Edit"))
            {
                dataGridView_Product.Columns.Remove("Edit");
                dataGridView_Product.Columns.Remove("Delete");
                dataGridView_Product.Columns.Remove("Enable");
                dataGridView_Product.Columns.Remove("Disable");
            }
                var productRepository = RepositoryFactory.CreateProductRepository();
                var bindigList = new BindingList<Product>(productRepository.GetActiveProduct().Where(product => (product.Price >= int.Parse(textBox_Min.Text) && product.Price <= int.Parse(textBox_Max.Text))).ToList());
                dataGridView_Product.DataSource = new BindingSource(bindigList, null);      
                dataGridView_Product.Columns.Add(edit);
                dataGridView_Product.Columns.Add(delete);
                dataGridView_Product.Columns.Add(disable);
                dataGridView_Product.Columns.Add(enable);
                if (textBox1.Text == "user")
                {
                    dataGridView_Product.Columns[11].Visible = false;
                }
            }
                
            
      

        }
        string search = string.Empty;
        private void Search_Click(object sender, EventArgs e)
        {

            search = textBox_Search.Text;

            UpdateSearchGrid();
         
        }

        private void button2_Click(object sender, EventArgs e)
        {
            max = textBox_Max.Text;
            min = textBox_Min.Text;
            UpdateSearchPrice();
         
           
        }
    }
}

    

