
namespace SuperMarketManagement.Forms
{
    partial class AddUser
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddUser));
            this.textBox_AddUsername = new System.Windows.Forms.TextBox();
            this.textBox_Password = new System.Windows.Forms.TextBox();
            this.comboBox_UserType = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button_AddUser = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dataGridView_Users = new System.Windows.Forms.DataGridView();
            this.button_Edit = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Users)).BeginInit();
            this.SuspendLayout();
            // 
            // textBox_AddUsername
            // 
            this.textBox_AddUsername.Location = new System.Drawing.Point(95, 67);
            this.textBox_AddUsername.Name = "textBox_AddUsername";
            this.textBox_AddUsername.Size = new System.Drawing.Size(100, 20);
            this.textBox_AddUsername.TabIndex = 0;
            // 
            // textBox_Password
            // 
            this.textBox_Password.Location = new System.Drawing.Point(95, 135);
            this.textBox_Password.Name = "textBox_Password";
            this.textBox_Password.Size = new System.Drawing.Size(100, 20);
            this.textBox_Password.TabIndex = 1;
            this.textBox_Password.UseSystemPasswordChar = true;
            // 
            // comboBox_UserType
            // 
            this.comboBox_UserType.FormattingEnabled = true;
            this.comboBox_UserType.Items.AddRange(new object[] {
            "user",
            "admin"});
            this.comboBox_UserType.Location = new System.Drawing.Point(107, 233);
            this.comboBox_UserType.Name = "comboBox_UserType";
            this.comboBox_UserType.Size = new System.Drawing.Size(100, 21);
            this.comboBox_UserType.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.Image = ((System.Drawing.Image)(resources.GetObject("label1.Image")));
            this.label1.Location = new System.Drawing.Point(15, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 45);
            this.label1.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.Image = ((System.Drawing.Image)(resources.GetObject("label2.Image")));
            this.label2.Location = new System.Drawing.Point(15, 120);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 54);
            this.label2.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.Image = ((System.Drawing.Image)(resources.GetObject("label3.Image")));
            this.label3.Location = new System.Drawing.Point(15, 207);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 57);
            this.label3.TabIndex = 5;
            // 
            // button_AddUser
            // 
            this.button_AddUser.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.button_AddUser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_AddUser.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_AddUser.Location = new System.Drawing.Point(82, 289);
            this.button_AddUser.Name = "button_AddUser";
            this.button_AddUser.Size = new System.Drawing.Size(115, 35);
            this.button_AddUser.TabIndex = 6;
            this.button_AddUser.Text = "Add User";
            this.button_AddUser.UseVisualStyleBackColor = false;
            this.button_AddUser.Click += new System.EventHandler(this.button_AddUser_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panel1.Controls.Add(this.button_Edit);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.textBox_Password);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.textBox_AddUsername);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.button_AddUser);
            this.panel1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(242, 426);
            this.panel1.TabIndex = 7;
            // 
            // dataGridView_Users
            // 
            this.dataGridView_Users.AllowUserToAddRows = false;
            this.dataGridView_Users.AllowUserToDeleteRows = false;
            this.dataGridView_Users.AllowUserToResizeColumns = false;
            this.dataGridView_Users.AllowUserToResizeRows = false;
            this.dataGridView_Users.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView_Users.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Users.Location = new System.Drawing.Point(260, 12);
            this.dataGridView_Users.Name = "dataGridView_Users";
            this.dataGridView_Users.ReadOnly = true;
            this.dataGridView_Users.Size = new System.Drawing.Size(398, 426);
            this.dataGridView_Users.TabIndex = 8;
            this.dataGridView_Users.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_Users_CellContentClick);
            // 
            // button_Edit
            // 
            this.button_Edit.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.button_Edit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_Edit.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Edit.Location = new System.Drawing.Point(82, 289);
            this.button_Edit.Name = "button_Edit";
            this.button_Edit.Size = new System.Drawing.Size(115, 35);
            this.button_Edit.TabIndex = 7;
            this.button_Edit.Text = "Edit";
            this.button_Edit.UseVisualStyleBackColor = false;
            this.button_Edit.Click += new System.EventHandler(this.button_Edit_Click);
            // 
            // AddUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(659, 443);
            this.Controls.Add(this.dataGridView_Users);
            this.Controls.Add(this.comboBox_UserType);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "AddUser";
            this.Text = "AddUser";
            this.Load += new System.EventHandler(this.AddUser_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Users)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_AddUsername;
        private System.Windows.Forms.TextBox textBox_Password;
        private System.Windows.Forms.ComboBox comboBox_UserType;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button_AddUser;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dataGridView_Users;
        private System.Windows.Forms.Button button_Edit;
    }
}