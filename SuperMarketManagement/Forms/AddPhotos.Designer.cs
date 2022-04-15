
namespace SuperMarketManagement.Forms
{
    partial class AddPhotos
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
            this.pictureBox_Image = new System.Windows.Forms.PictureBox();
            this.button_Search = new System.Windows.Forms.Button();
            this.button_AddPhoto = new System.Windows.Forms.Button();
            this.textBox_name = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Image)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox_Image
            // 
            this.pictureBox_Image.Location = new System.Drawing.Point(136, 12);
            this.pictureBox_Image.Name = "pictureBox_Image";
            this.pictureBox_Image.Size = new System.Drawing.Size(258, 167);
            this.pictureBox_Image.TabIndex = 1;
            this.pictureBox_Image.TabStop = false;
            // 
            // button_Search
            // 
            this.button_Search.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_Search.Location = new System.Drawing.Point(136, 185);
            this.button_Search.Name = "button_Search";
            this.button_Search.Size = new System.Drawing.Size(82, 23);
            this.button_Search.TabIndex = 2;
            this.button_Search.Text = "SearchPhoto";
            this.button_Search.UseVisualStyleBackColor = true;
            this.button_Search.Click += new System.EventHandler(this.button_Search_Click);
            // 
            // button_AddPhoto
            // 
            this.button_AddPhoto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_AddPhoto.Location = new System.Drawing.Point(325, 185);
            this.button_AddPhoto.Name = "button_AddPhoto";
            this.button_AddPhoto.Size = new System.Drawing.Size(69, 23);
            this.button_AddPhoto.TabIndex = 3;
            this.button_AddPhoto.Text = "Add";
            this.button_AddPhoto.UseVisualStyleBackColor = true;
            this.button_AddPhoto.Click += new System.EventHandler(this.button_AddPhoto_Click);
            // 
            // textBox_name
            // 
            this.textBox_name.Location = new System.Drawing.Point(32, 282);
            this.textBox_name.Name = "textBox_name";
            this.textBox_name.Size = new System.Drawing.Size(100, 20);
            this.textBox_name.TabIndex = 4;
            this.textBox_name.Visible = false;
            // 
            // AddPhotos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(530, 450);
            this.Controls.Add(this.textBox_name);
            this.Controls.Add(this.button_AddPhoto);
            this.Controls.Add(this.button_Search);
            this.Controls.Add(this.pictureBox_Image);
            this.Name = "AddPhotos";
            this.Text = "AddPhotos";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Image)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox_Image;
        private System.Windows.Forms.Button button_Search;
        private System.Windows.Forms.Button button_AddPhoto;
        public System.Windows.Forms.TextBox textBox_name;
    }
}