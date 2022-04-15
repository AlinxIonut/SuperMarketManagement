using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SuperMarketManagement.Forms
{
    public partial class AddPhotos : Form
    {
        string filePath = string.Empty;
        public AddPhotos()
        {
            InitializeComponent();
        }

        private void button_Search_Click(object sender, EventArgs e)
        {
            var fileContent = string.Empty;

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "C:\\Desktop";
                openFileDialog.Filter = "Jpg files (*.jpg)|*.jpg|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Get the path of specified file
                    filePath = openFileDialog.FileName;

                    //Read the contents of the file into a stream
                    var fileStream = openFileDialog.OpenFile();

                    using (StreamReader reader = new StreamReader(fileStream))
                    {
                        fileContent = reader.ReadToEnd();
                    }
                }
            }
            pictureBox_Image.Image = Image.FromFile(filePath);
            pictureBox_Image.SizeMode = PictureBoxSizeMode.StretchImage;


        }

        private void button_AddPhoto_Click(object sender, EventArgs e)
        {
            Guid guid = Guid.NewGuid();
            string PicturesPath = ConfigurationManager.AppSettings["PicturesPath"];
            ImageList imgs=new  ImageList();

            AddProduct addProduct = new AddProduct();

            DirectoryInfo DIR = new DirectoryInfo($"{PicturesPath}\\{textBox_name.Text}");
            if(DIR.Exists)
            {
                Image imageref = Image.FromFile(filePath);
                imageref.Save($"{PicturesPath}\\{textBox_name.Text}\\{guid}.jpg");
                MessageBox.Show("Photo was added with succes, now you can add another one. ");

            }
            else
            {
                DIR.Create();
                Image imageref = Image.FromFile(filePath);
                imageref.Save($"{PicturesPath}\\{textBox_name.Text}\\{guid}.jpg");
                MessageBox.Show("Photo was added with succes, now you can add another one. ");
            }
        }
    }
}
