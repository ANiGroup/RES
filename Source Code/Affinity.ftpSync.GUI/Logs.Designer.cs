namespace Affinity.ftpSync.GUI
{
    partial class Logs
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ErrorCreated = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProfileName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DString = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.errorDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ReadError = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Top;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(684, 190);
            this.dataGridView1.TabIndex = 0;
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AllowUserToDeleteRows = false;
            this.dataGridView2.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.ErrorCreated,
            this.ProfileName,
            this.DString,
            this.errorDescription,
            this.ReadError});
            this.dataGridView2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dataGridView2.Location = new System.Drawing.Point(0, 211);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ReadOnly = true;
            this.dataGridView2.Size = new System.Drawing.Size(684, 271);
            this.dataGridView2.TabIndex = 2;
            this.dataGridView2.DoubleClick += new System.EventHandler(this.dataGridView2_DoubleClick);
            // 
            // Id
            // 
            this.Id.DataPropertyName = "Id";
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            // 
            // ErrorCreated
            // 
            this.ErrorCreated.DataPropertyName = "ErrorCreated";
            this.ErrorCreated.HeaderText = "Error Created";
            this.ErrorCreated.Name = "ErrorCreated";
            this.ErrorCreated.ReadOnly = true;
            // 
            // ProfileName
            // 
            this.ProfileName.DataPropertyName = "ProfileName";
            this.ProfileName.HeaderText = "Profile Name";
            this.ProfileName.Name = "ProfileName";
            this.ProfileName.ReadOnly = true;
            // 
            // DString
            // 
            this.DString.DataPropertyName = "DString";
            this.DString.HeaderText = "Date String";
            this.DString.Name = "DString";
            this.DString.ReadOnly = true;
            this.DString.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // errorDescription
            // 
            this.errorDescription.DataPropertyName = "errorDescription";
            this.errorDescription.HeaderText = "Description";
            this.errorDescription.Name = "errorDescription";
            this.errorDescription.ReadOnly = true;
            // 
            // ReadError
            // 
            this.ReadError.DataPropertyName = "ReadError";
            this.ReadError.HeaderText = "IsRead";
            this.ReadError.Name = "ReadError";
            this.ReadError.ReadOnly = true;
            // 
            // Logs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(684, 482);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.dataGridView1);
            this.DoubleBuffered = true;
            this.Name = "Logs";
            this.Text = "Logs";
            this.Load += new System.EventHandler(this.Logs_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn ErrorCreated;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProfileName;
        private System.Windows.Forms.DataGridViewTextBoxColumn DString;
        private System.Windows.Forms.DataGridViewTextBoxColumn errorDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn ReadError;
    }
}