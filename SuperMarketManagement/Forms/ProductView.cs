using SuperMarketManagement.Models;
using SuperMarketManagement.Properties;
using SuperMarketManagement.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SuperMarketManagement.Forms
{
 
    public partial class ProductView : Form
    {
        public string username;
        public string nameFolder;
        int count = 0;
        int counts = 0;
        ImageList imgs = new ImageList();
        public ProductView()
        {
            InitializeComponent();
        }
        public void ImageList()
        {
            imgs.ImageSize = new Size(230, 230);

            String[] paths = { };




            string PicturesPath = ConfigurationManager.AppSettings["PicturesPath"];
            if (Directory.Exists($"{PicturesPath}\\{nameFolder}"))
            {
                paths = Directory.GetFiles($"{PicturesPath}\\{nameFolder}");

                foreach (String path in paths)
                {
                    imgs.Images.Add(Image.FromFile(path));
                    count++;
                }


            }
        }
        private void PhotoLoad()
        {

            if (count == 1)
            {
                Prev.Enabled = false;
                Next.Enabled = false;

            }
            try
            {
                pictureBox_Image.Image = imgs.Images[0];


            }
            catch
            {
                pictureBox_Image.Image = Image.FromFile("D:\\Proiecte c#\\SuperMarketManagement\\nophoto.jpg");
                Prev.Visible = false;
                Next.Visible = false;
            };

        }
        private void ProductView_Load(object sender, EventArgs e)
        {
            imgs.ImageSize = new Size(230, 230);
            PhotoLoad();
            pictureBox_Image.SizeMode = PictureBoxSizeMode.StretchImage;
          if(UserRate()==true)
            {
                panel1.Visible = false;
                panel2.Visible = false;
            }
            Prev.Enabled = false;
            panel1.Visible = false;
            panel3.Visible = false;
            StyleDGV();

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

        private void Prev_Click(object sender, EventArgs e)
        {
            imgs.ImageSize = new Size(230, 230);

            if (counts == 1)
            {
                pictureBox_Image.Image = imgs.Images[--counts];
                Prev.Enabled = false;
            }
            if (counts > 1)
            {
                Next.Enabled = true;
                Prev.Enabled = true;
                pictureBox_Image.Image = imgs.Images[--counts];


            }
            else
            {
                Prev.Enabled = false;
                Next.Enabled = true;
            }
            pictureBox_Image.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void Next_Click(object sender, EventArgs e)
        {
            imgs.ImageSize = new Size(230, 230);

            if (counts < count - 1)
            {
                Prev.Enabled = true;
                Next.Enabled = true;
                counts++;
                pictureBox_Image.Image = imgs.Images[counts];


            }
            if (counts == count - 1)
            {

                Next.Enabled = false;
                Prev.Enabled = true;
            }
            pictureBox_Image.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void star5_Click(object sender, EventArgs e)
        {
            star1.Image = Resources.star;
            star2.Image = Resources.star;
            star3.Image = Resources.star;
            star4.Image = Resources.star;
            star5.Image = Resources.star;
            label8.Text = "5";
        }

        private void star4_Click(object sender, EventArgs e)
        {
            star5.Image = Resources.starz;
            star1.Image = Resources.star;
            star2.Image = Resources.star;
            star3.Image = Resources.star;
            star4.Image = Resources.star;
            label8.Text = "4";
        }

        private void star3_Click(object sender, EventArgs e)
        {
            star5.Image = Resources.starz;
            star1.Image = Resources.star;
            star2.Image = Resources.star;
            star3.Image = Resources.star;
            star4.Image = Resources.starz;
            label8.Text = "3";
        }

        private void star2_Click(object sender, EventArgs e)
        {
            star5.Image = Resources.starz;
            star1.Image = Resources.star;
            star2.Image = Resources.star;
            star3.Image = Resources.starz;
            star4.Image = Resources.starz;
            label8.Text = "2";
        }

        private void star1_Click(object sender, EventArgs e)
        {
            star5.Image = Resources.starz;
            star1.Image = Resources.star;
            star2.Image = Resources.starz;
            star3.Image = Resources.starz;
            star4.Image = Resources.starz;
            label8.Text = "1";
        }
        private bool UserRate()
        {
            ProductEvaluation productEvaluation = new ProductEvaluation();
            var sql = "select * from ProductEvaluation where UserId=@uId and ProductId=@pId";
            var sql1 = "select ID from Users where Username=@name";
           var connectionString = ConfigurationManager.ConnectionStrings["connection"].ConnectionString;
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(sql1, connection);
                cmd.Parameters.Add("@name", SqlDbType.NVarChar).Value = username;
                productEvaluation.UserId = (int)cmd.ExecuteScalar();
                 

            }
         
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(sql, connection);
                cmd.Parameters.Add("@uId", SqlDbType.NVarChar).Value = productEvaluation.UserId;
                cmd.Parameters.Add("@pId",SqlDbType.BigInt).Value = int.Parse(label9.Text);
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

        public void UpdateRating()
        {
            var sql = "select AVG(Rating) from ProductEvaluation where ProductId=@pId";
            var connectionString = ConfigurationManager.ConnectionStrings["connection"].ConnectionString;
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(sql, connection);
                cmd.Parameters.Add("@pId", SqlDbType.NVarChar).Value = label9.Text;
                try
                {
                    if (Convert.ToInt32(cmd.ExecuteScalar()) >= 1)
                    {
                        int Rating = (int)cmd.ExecuteScalar();

                        if (Rating == 1)
                        {
                            starz.Image = Resources.star;
                            starz1.Image = Resources.starz;
                            starz2.Image = Resources.starz;
                            starz3.Image = Resources.starz;
                            starz4.Image = Resources.starz;
                        }
                        if (Rating == 2)
                        {
                            starz.Image = Resources.star;
                            starz1.Image = Resources.star;
                            starz2.Image = Resources.starz;
                            starz3.Image = Resources.starz;
                            starz4.Image = Resources.starz;
                        }
                        if (Rating == 3)
                        {
                            starz.Image = Resources.star;
                            starz1.Image = Resources.star;
                            starz2.Image = Resources.star;
                            starz3.Image = Resources.starz;
                            starz4.Image = Resources.starz;
                        }
                        if (Rating == 4)
                        {
                            starz.Image = Resources.star;
                            starz1.Image = Resources.star;
                            starz2.Image = Resources.star;
                            starz3.Image = Resources.star;
                            starz4.Image = Resources.starz;
                        }
                        if (Rating == 5)
                        {
                            starz.Image = Resources.star;
                            starz1.Image = Resources.star;
                            starz2.Image = Resources.star;
                            starz3.Image = Resources.star;
                            starz4.Image = Resources.star;
                                 
            }
                    }
                }
                catch {  }
                }
        }
        private void button_Add_Click(object sender, EventArgs e)
        {
            if (UserRate() == false)
            {
                if (!(string.IsNullOrEmpty(label8.Text) || string.IsNullOrEmpty(richTextBox.Text)))
                {
                    var productEvaluationRepository = RepositoryFactory.CreateProductEvaluationRepository();
                    ProductEvaluation productEvaluation = new ProductEvaluation();

                    productEvaluation.Description = richTextBox.Text;
                    productEvaluation.ProductId = int.Parse(label9.Text);
                    productEvaluation.Rating = int.Parse(label8.Text);
                    var sql = "select ID from Users where Username=@name";
                    var connectionString = ConfigurationManager.ConnectionStrings["connection"].ConnectionString;
                    using (var connection = new SqlConnection(connectionString))
                    {
                        connection.Open();
                        SqlCommand cmd = new SqlCommand(sql, connection);
                        cmd.Parameters.Add("@name", SqlDbType.NVarChar).Value = username;
                        productEvaluation.UserId = (int)cmd.ExecuteScalar();

                    }
                    productEvaluationRepository.Create(productEvaluation);
                    MessageBox.Show("Review Added");
                    panel1.Visible = false;

                    panel2.Visible = false;
                    UpdateRating();
                }
                else MessageBox.Show("Complete data if u want to add a review");
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Click(object sender, EventArgs e)
        {
            if(panel1.Visible == false)
            {
                panel1.Visible = true;
            }
        }
        private Reviews GetProductFromMultiples(SqlDataReader row)
        {
            return new Reviews()
            {
                Username = (string)row["username"],
                Description = (string)row["Review"],
                Rating = (int)row["Rating"],
                NameOfProduct = (string)row["NameOfProduct"]
            };
        }

        private void UpdateGrid()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["connection"].ConnectionString;

            var sql = " Select Users.username,Product.Name as NameOfProduct,ProductEvaluation.Description as Review,Rating from ProductEvaluation inner join Users on Users.Id=ProductEvaluation.UserId inner join Product on Product.Id = ProductEvaluation.ProductId where ProductId=@pId";
            using (var connection = new SqlConnection(connectionString))
            {
                var result = new List<Reviews>();
                connection.Open();

                //vom crea un obiect de tip reader pentru executarea unui select
                using (var reader = new SqlCommand(sql, connection))
                {
                    reader.Parameters.Add("@pId", SqlDbType.BigInt).Value = int.Parse(label9.Text); 
                    var queryResult = reader.ExecuteReader();
                    while (queryResult.Read())
                    {
                      
                        var user = GetProductFromMultiples(queryResult);
                        result.Add(user);
                    }
                    var bindigList = new BindingList<Reviews>(result) ;
                dataGridView_Product.DataSource = new BindingSource(bindigList, null); 
                }


              
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {
            if (panel1.Visible == false)
            {
                panel1.Visible = true;
            }
            else
            {
                panel1.Visible = false;
            }
        }

        private void label11_Click(object sender, EventArgs e)
        {
            if (panel3.Visible == false)
            {
                panel3.Visible = true;
            }
            else
            {
                panel3.Visible = false;
            }
            UpdateGrid();
           
        }
    }
}
