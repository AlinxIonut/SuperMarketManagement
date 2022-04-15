
namespace SuperMarketManagement.Forms
{
    partial class AddProduct
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddProduct));
            this.panel1 = new System.Windows.Forms.Panel();
            this.list_CategoryType = new System.Windows.Forms.ListBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.button_Edit = new System.Windows.Forms.Button();
            this.textBox_Brand = new System.Windows.Forms.TextBox();
            this.button_Product = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_Name = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.textBox_Price = new System.Windows.Forms.TextBox();
            this.Description = new System.Windows.Forms.RichTextBox();
            this.dataGridView_Product = new System.Windows.Forms.DataGridView();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button_ClearData = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.listView_Category = new System.Windows.Forms.ListBox();
            this.label8 = new System.Windows.Forms.Label();
            this.list_Brands = new System.Windows.Forms.ListBox();
            this.button_ExportJSON = new System.Windows.Forms.Button();
            this.button_ExportCSV = new System.Windows.Forms.Button();
            this.textBox_Min = new System.Windows.Forms.TextBox();
            this.textBox_Max = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.textBox_Search = new System.Windows.Forms.TextBox();
            this.Search = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Product)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.list_CategoryType);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.button_Edit);
            this.panel1.Controls.Add(this.textBox_Brand);
            this.panel1.Controls.Add(this.button_Product);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.textBox_Name);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.dateTimePicker1);
            this.panel1.Controls.Add(this.textBox_Price);
            this.panel1.Controls.Add(this.Description);
            this.panel1.Location = new System.Drawing.Point(3, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(355, 680);
            this.panel1.TabIndex = 0;
            // 
            // list_CategoryType
            // 
            this.list_CategoryType.FormattingEnabled = true;
            this.list_CategoryType.Location = new System.Drawing.Point(227, 68);
            this.list_CategoryType.Name = "list_CategoryType";
            this.list_CategoryType.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.list_CategoryType.Size = new System.Drawing.Size(115, 121);
            this.list_CategoryType.TabIndex = 12;
            // 
            // label6
            // 
            this.label6.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(211, 12);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(131, 52);
            this.label6.TabIndex = 11;
            this.label6.Text = "Category Type";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(71, 376);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(160, 52);
            this.label5.TabIndex = 9;
            this.label5.Text = "Description";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button_Edit
            // 
            this.button_Edit.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button_Edit.Location = new System.Drawing.Point(192, 612);
            this.button_Edit.Name = "button_Edit";
            this.button_Edit.Size = new System.Drawing.Size(127, 45);
            this.button_Edit.TabIndex = 8;
            this.button_Edit.Text = "Edit";
            this.button_Edit.UseVisualStyleBackColor = true;
            this.button_Edit.Click += new System.EventHandler(this.button_Edit_Click);
            // 
            // textBox_Brand
            // 
            this.textBox_Brand.Location = new System.Drawing.Point(88, 349);
            this.textBox_Brand.Name = "textBox_Brand";
            this.textBox_Brand.Size = new System.Drawing.Size(100, 20);
            this.textBox_Brand.TabIndex = 7;
            // 
            // button_Product
            // 
            this.button_Product.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button_Product.Location = new System.Drawing.Point(9, 612);
            this.button_Product.Name = "button_Product";
            this.button_Product.Size = new System.Drawing.Size(127, 45);
            this.button_Product.TabIndex = 2;
            this.button_Product.Text = "Add Product";
            this.button_Product.UseVisualStyleBackColor = true;
            this.button_Product.Click += new System.EventHandler(this.button_Product_Click);
            // 
            // label4
            // 
            this.label4.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Image = ((System.Drawing.Image)(resources.GetObject("label4.Image")));
            this.label4.Location = new System.Drawing.Point(109, 270);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 76);
            this.label4.TabIndex = 8;
            this.label4.Text = "Brand";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label3
            // 
            this.label3.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Image = ((System.Drawing.Image)(resources.GetObject("label3.Image")));
            this.label3.Location = new System.Drawing.Point(109, 191);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 53);
            this.label3.TabIndex = 6;
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label2
            // 
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Image = ((System.Drawing.Image)(resources.GetObject("label2.Image")));
            this.label2.Location = new System.Drawing.Point(109, 103);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 53);
            this.label2.TabIndex = 5;
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // textBox_Name
            // 
            this.textBox_Name.Location = new System.Drawing.Point(88, 80);
            this.textBox_Name.Name = "textBox_Name";
            this.textBox_Name.Size = new System.Drawing.Size(100, 20);
            this.textBox_Name.TabIndex = 0;
            this.textBox_Name.Leave += new System.EventHandler(this.textBox_Name_Leave);
            // 
            // label1
            // 
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Image = ((System.Drawing.Image)(resources.GetObject("label1.Image")));
            this.label1.Location = new System.Drawing.Point(99, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 109);
            this.label1.TabIndex = 4;
            this.label1.Text = "Product Name";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(88, 247);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(100, 20);
            this.dateTimePicker1.TabIndex = 3;
            // 
            // textBox_Price
            // 
            this.textBox_Price.Location = new System.Drawing.Point(88, 168);
            this.textBox_Price.Name = "textBox_Price";
            this.textBox_Price.Size = new System.Drawing.Size(100, 20);
            this.textBox_Price.TabIndex = 2;
            // 
            // Description
            // 
            this.Description.Location = new System.Drawing.Point(-3, 434);
            this.Description.Name = "Description";
            this.Description.Size = new System.Drawing.Size(355, 148);
            this.Description.TabIndex = 1;
            this.Description.Text = "";
            // 
            // dataGridView_Product
            // 
            this.dataGridView_Product.AllowUserToAddRows = false;
            this.dataGridView_Product.AllowUserToDeleteRows = false;
            this.dataGridView_Product.AllowUserToResizeColumns = false;
            this.dataGridView_Product.AllowUserToResizeRows = false;
            this.dataGridView_Product.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView_Product.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Product.Location = new System.Drawing.Point(364, 51);
            this.dataGridView_Product.Name = "dataGridView_Product";
            this.dataGridView_Product.ReadOnly = true;
            this.dataGridView_Product.Size = new System.Drawing.Size(768, 409);
            this.dataGridView_Product.TabIndex = 1;
            this.dataGridView_Product.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_Product_CellContentClick);
            this.dataGridView_Product.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_Product_CellContentDoubleClick);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(364, 574);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(19, 20);
            this.textBox1.TabIndex = 7;
            this.textBox1.Visible = false;
            // 
            // button_ClearData
            // 
            this.button_ClearData.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_ClearData.Location = new System.Drawing.Point(404, 466);
            this.button_ClearData.Name = "button_ClearData";
            this.button_ClearData.Size = new System.Drawing.Size(131, 44);
            this.button_ClearData.TabIndex = 9;
            this.button_ClearData.Text = "Clear Data/Filter";
            this.button_ClearData.UseVisualStyleBackColor = true;
            this.button_ClearData.Click += new System.EventHandler(this.button_ClearData_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(1202, 37);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(112, 23);
            this.label7.TabIndex = 10;
            this.label7.Text = "Categories";
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Location = new System.Drawing.Point(968, 466);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(127, 44);
            this.button1.TabIndex = 12;
            this.button1.Text = "Show Add/Edit Menu";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // listView_Category
            // 
            this.listView_Category.FormattingEnabled = true;
            this.listView_Category.Location = new System.Drawing.Point(1206, 63);
            this.listView_Category.Name = "listView_Category";
            this.listView_Category.Size = new System.Drawing.Size(121, 225);
            this.listView_Category.TabIndex = 13;
            this.listView_Category.Click += new System.EventHandler(this.listView_Category_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(1228, 291);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(64, 23);
            this.label8.TabIndex = 14;
            this.label8.Text = "Brand";
            // 
            // list_Brands
            // 
            this.list_Brands.FormattingEnabled = true;
            this.list_Brands.Location = new System.Drawing.Point(1206, 317);
            this.list_Brands.Name = "list_Brands";
            this.list_Brands.Size = new System.Drawing.Size(121, 212);
            this.list_Brands.TabIndex = 15;
            this.list_Brands.Click += new System.EventHandler(this.list_Brands_Click);
            // 
            // button_ExportJSON
            // 
            this.button_ExportJSON.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_ExportJSON.Location = new System.Drawing.Point(581, 466);
            this.button_ExportJSON.Name = "button_ExportJSON";
            this.button_ExportJSON.Size = new System.Drawing.Size(147, 43);
            this.button_ExportJSON.TabIndex = 16;
            this.button_ExportJSON.Text = "Export JSON";
            this.button_ExportJSON.UseVisualStyleBackColor = true;
            this.button_ExportJSON.Click += new System.EventHandler(this.button_ImportJSON_Click);
            // 
            // button_ExportCSV
            // 
            this.button_ExportCSV.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_ExportCSV.Location = new System.Drawing.Point(768, 466);
            this.button_ExportCSV.Name = "button_ExportCSV";
            this.button_ExportCSV.Size = new System.Drawing.Size(147, 43);
            this.button_ExportCSV.TabIndex = 17;
            this.button_ExportCSV.Text = "Export CSV";
            this.button_ExportCSV.UseVisualStyleBackColor = true;
            this.button_ExportCSV.Click += new System.EventHandler(this.button_ImportCSV_Click);
            // 
            // textBox_Min
            // 
            this.textBox_Min.Location = new System.Drawing.Point(668, 537);
            this.textBox_Min.Name = "textBox_Min";
            this.textBox_Min.Size = new System.Drawing.Size(60, 20);
            this.textBox_Min.TabIndex = 18;
            this.textBox_Min.TextChanged += new System.EventHandler(this.textBox_Min_TextChanged);
            // 
            // textBox_Max
            // 
            this.textBox_Max.Location = new System.Drawing.Point(768, 537);
            this.textBox_Max.Name = "textBox_Max";
            this.textBox_Max.Size = new System.Drawing.Size(60, 20);
            this.textBox_Max.TabIndex = 19;
            this.textBox_Max.TextChanged += new System.EventHandler(this.textBox_Max_TextChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(578, 539);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(49, 18);
            this.label9.TabIndex = 20;
            this.label9.Text = "Price:";
            // 
            // textBox_Search
            // 
            this.textBox_Search.Location = new System.Drawing.Point(599, 24);
            this.textBox_Search.Name = "textBox_Search";
            this.textBox_Search.Size = new System.Drawing.Size(271, 20);
            this.textBox_Search.TabIndex = 21;
            this.textBox_Search.TextChanged += new System.EventHandler(this.textBox_Search_TextChanged);
            // 
            // Search
            // 
            this.Search.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Search.Location = new System.Drawing.Point(885, 24);
            this.Search.Name = "Search";
            this.Search.Size = new System.Drawing.Size(82, 23);
            this.Search.TabIndex = 22;
            this.Search.Text = "Search";
            this.Search.UseVisualStyleBackColor = true;
            this.Search.Click += new System.EventHandler(this.Search_Click);
            // 
            // button2
            // 
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Location = new System.Drawing.Point(846, 535);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(81, 23);
            this.button2.TabIndex = 23;
            this.button2.Text = "Price Interval";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // AddProduct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1455, 693);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.Search);
            this.Controls.Add(this.textBox_Search);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.textBox_Max);
            this.Controls.Add(this.textBox_Min);
            this.Controls.Add(this.button_ExportCSV);
            this.Controls.Add(this.button_ExportJSON);
            this.Controls.Add(this.list_Brands);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.listView_Category);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.button_ClearData);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.dataGridView_Product);
            this.Controls.Add(this.panel1);
            this.Name = "AddProduct";
            this.Text = "Product";
            this.Load += new System.EventHandler(this.AddProduct_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Product)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.TextBox textBox_Name;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.TextBox textBox_Price;
        private System.Windows.Forms.RichTextBox Description;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox_Brand;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dataGridView_Product;
        private System.Windows.Forms.Button button_Product;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ListBox list_CategoryType;
        public System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button_Edit;
        private System.Windows.Forms.Button button_ClearData;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListBox listView_Category;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ListBox list_Brands;
        private System.Windows.Forms.Button button_ExportJSON;
        private System.Windows.Forms.Button button_ExportCSV;
        private System.Windows.Forms.TextBox textBox_Min;
        private System.Windows.Forms.TextBox textBox_Max;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBox_Search;
        private System.Windows.Forms.Button Search;
        private System.Windows.Forms.Button button2;
    }
}