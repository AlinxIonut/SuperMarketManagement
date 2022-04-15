
namespace SuperMarketManagement.Forms
{
    partial class AddCategory
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
            this.dataGridView_Category = new System.Windows.Forms.DataGridView();
            this.textBox_CategoryName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button_EditCateg = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Category)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView_Category
            // 
            this.dataGridView_Category.AllowUserToAddRows = false;
            this.dataGridView_Category.AllowUserToDeleteRows = false;
            this.dataGridView_Category.AllowUserToResizeColumns = false;
            this.dataGridView_Category.AllowUserToResizeRows = false;
            this.dataGridView_Category.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView_Category.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Category.Location = new System.Drawing.Point(167, 3);
            this.dataGridView_Category.Name = "dataGridView_Category";
            this.dataGridView_Category.ReadOnly = true;
            this.dataGridView_Category.Size = new System.Drawing.Size(324, 255);
            this.dataGridView_Category.TabIndex = 0;
            this.dataGridView_Category.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_Category_CellContentClick);
            // 
            // textBox_CategoryName
            // 
            this.textBox_CategoryName.Location = new System.Drawing.Point(12, 56);
            this.textBox_CategoryName.Name = "textBox_CategoryName";
            this.textBox_CategoryName.Size = new System.Drawing.Size(149, 20);
            this.textBox_CategoryName.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(21, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(127, 18);
            this.label1.TabIndex = 2;
            this.label1.Text = "Category Name";
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(4, 135);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(157, 32);
            this.button1.TabIndex = 3;
            this.button1.Text = "Add Category";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button_EditCateg
            // 
            this.button_EditCateg.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_EditCateg.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_EditCateg.Location = new System.Drawing.Point(4, 135);
            this.button_EditCateg.Name = "button_EditCateg";
            this.button_EditCateg.Size = new System.Drawing.Size(157, 32);
            this.button_EditCateg.TabIndex = 4;
            this.button_EditCateg.Text = "Edit Category";
            this.button_EditCateg.UseVisualStyleBackColor = true;
            this.button_EditCateg.Click += new System.EventHandler(this.button_EditCateg_Click);
            // 
            // AddCategory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(482, 258);
            this.Controls.Add(this.button_EditCateg);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox_CategoryName);
            this.Controls.Add(this.dataGridView_Category);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "AddCategory";
            this.Text = "AddCategory";
            this.Load += new System.EventHandler(this.AddCategory_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Category)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView_Category;
        private System.Windows.Forms.TextBox textBox_CategoryName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button_EditCateg;
    }
}