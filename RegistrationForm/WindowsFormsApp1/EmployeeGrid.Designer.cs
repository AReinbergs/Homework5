namespace WindowsFormsApp1
{
    partial class EmployeeGrid
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
            this.dgwEmployee = new System.Windows.Forms.DataGridView();
            this.btnSaveToDatabase = new System.Windows.Forms.Button();
            this.btnGetFromDatabase = new System.Windows.Forms.Button();
            this.lblSearch = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtSearchName = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgwEmployee)).BeginInit();
            this.SuspendLayout();
            // 
            // dgwEmployee
            // 
            this.dgwEmployee.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgwEmployee.Location = new System.Drawing.Point(2, 64);
            this.dgwEmployee.Name = "dgwEmployee";
            this.dgwEmployee.Size = new System.Drawing.Size(816, 198);
            this.dgwEmployee.TabIndex = 0;
            // 
            // btnSaveToDatabase
            // 
            this.btnSaveToDatabase.Location = new System.Drawing.Point(13, 13);
            this.btnSaveToDatabase.Name = "btnSaveToDatabase";
            this.btnSaveToDatabase.Size = new System.Drawing.Size(111, 23);
            this.btnSaveToDatabase.TabIndex = 1;
            this.btnSaveToDatabase.Text = "Save to database";
            this.btnSaveToDatabase.UseVisualStyleBackColor = true;
            this.btnSaveToDatabase.Click += new System.EventHandler(this.btnSaveToDatabase_Click);
            // 
            // btnGetFromDatabase
            // 
            this.btnGetFromDatabase.Location = new System.Drawing.Point(153, 13);
            this.btnGetFromDatabase.Name = "btnGetFromDatabase";
            this.btnGetFromDatabase.Size = new System.Drawing.Size(111, 23);
            this.btnGetFromDatabase.TabIndex = 2;
            this.btnGetFromDatabase.Text = "Get from database";
            this.btnGetFromDatabase.UseVisualStyleBackColor = true;
            this.btnGetFromDatabase.Click += new System.EventHandler(this.btnGetFromDatabase_Click);
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Location = new System.Drawing.Point(498, 18);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(86, 13);
            this.lblSearch.TabIndex = 3;
            this.lblSearch.Text = "Search by Name";
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(732, 13);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 4;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtSearchName
            // 
            this.txtSearchName.Location = new System.Drawing.Point(599, 15);
            this.txtSearchName.Name = "txtSearchName";
            this.txtSearchName.Size = new System.Drawing.Size(117, 20);
            this.txtSearchName.TabIndex = 5;
            // 
            // EmployeeGrid
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(819, 261);
            this.Controls.Add(this.txtSearchName);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.lblSearch);
            this.Controls.Add(this.btnGetFromDatabase);
            this.Controls.Add(this.btnSaveToDatabase);
            this.Controls.Add(this.dgwEmployee);
            this.Name = "EmployeeGrid";
            this.Text = "EmployeeGrid";
            ((System.ComponentModel.ISupportInitialize)(this.dgwEmployee)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgwEmployee;
        private System.Windows.Forms.Button btnSaveToDatabase;
        private System.Windows.Forms.Button btnGetFromDatabase;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtSearchName;
    }
}