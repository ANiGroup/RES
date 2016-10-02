namespace Affinity.ftpSync.GUI
{
    partial class myExecution
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
            this.label1 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.chkRange = new System.Windows.Forms.CheckBox();
            this.myProfiles = new System.Windows.Forms.ComboBox();
            this.chkall = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.ckETLonly = new System.Windows.Forms.CheckBox();
            this.buttonX1 = new DevComponents.DotNetBar.ButtonX();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.buttonX2 = new DevComponents.DotNetBar.ButtonX();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(56, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Date";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.BackColor = System.Drawing.Color.White;
            this.dateTimePicker1.ForeColor = System.Drawing.Color.Black;
            this.dateTimePicker1.Location = new System.Drawing.Point(118, 33);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(186, 20);
            this.dateTimePicker1.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(57, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Date To";
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.BackColor = System.Drawing.Color.White;
            this.dateTimePicker2.Enabled = false;
            this.dateTimePicker2.ForeColor = System.Drawing.Color.Black;
            this.dateTimePicker2.Location = new System.Drawing.Point(118, 64);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(186, 20);
            this.dateTimePicker2.TabIndex = 4;
            // 
            // chkRange
            // 
            this.chkRange.AutoSize = true;
            this.chkRange.BackColor = System.Drawing.Color.White;
            this.chkRange.ForeColor = System.Drawing.Color.Black;
            this.chkRange.Location = new System.Drawing.Point(310, 35);
            this.chkRange.Name = "chkRange";
            this.chkRange.Size = new System.Drawing.Size(58, 17);
            this.chkRange.TabIndex = 5;
            this.chkRange.Text = "Range";
            this.chkRange.UseVisualStyleBackColor = false;
            this.chkRange.CheckedChanged += new System.EventHandler(this.chkRange_CheckedChanged);
            // 
            // myProfiles
            // 
            this.myProfiles.BackColor = System.Drawing.Color.White;
            this.myProfiles.Enabled = false;
            this.myProfiles.ForeColor = System.Drawing.Color.Black;
            this.myProfiles.FormattingEnabled = true;
            this.myProfiles.Location = new System.Drawing.Point(118, 94);
            this.myProfiles.Name = "myProfiles";
            this.myProfiles.Size = new System.Drawing.Size(186, 21);
            this.myProfiles.TabIndex = 6;
            this.myProfiles.SelectedIndexChanged += new System.EventHandler(this.myProfiles_SelectedIndexChanged);
            // 
            // chkall
            // 
            this.chkall.AutoSize = true;
            this.chkall.BackColor = System.Drawing.Color.White;
            this.chkall.Checked = true;
            this.chkall.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkall.ForeColor = System.Drawing.Color.Black;
            this.chkall.Location = new System.Drawing.Point(312, 96);
            this.chkall.Name = "chkall";
            this.chkall.Size = new System.Drawing.Size(36, 17);
            this.chkall.TabIndex = 7;
            this.chkall.Text = "all";
            this.chkall.UseVisualStyleBackColor = false;
            this.chkall.CheckedChanged += new System.EventHandler(this.chkall_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.White;
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(58, 99);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Profiles";
            // 
            // ckETLonly
            // 
            this.ckETLonly.AutoSize = true;
            this.ckETLonly.BackColor = System.Drawing.Color.White;
            this.ckETLonly.ForeColor = System.Drawing.Color.Black;
            this.ckETLonly.Location = new System.Drawing.Point(61, 133);
            this.ckETLonly.Name = "ckETLonly";
            this.ckETLonly.Size = new System.Drawing.Size(91, 17);
            this.ckETLonly.TabIndex = 9;
            this.ckETLonly.Text = "Run ETL only";
            this.ckETLonly.UseVisualStyleBackColor = false;
            this.ckETLonly.Visible = false;
            // 
            // buttonX1
            // 
            this.buttonX1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX1.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX1.Location = new System.Drawing.Point(163, 133);
            this.buttonX1.Name = "buttonX1";
            this.buttonX1.Size = new System.Drawing.Size(79, 36);
            this.buttonX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX1.TabIndex = 10;
            this.buttonX1.Text = "Execute";
            this.buttonX1.Click += new System.EventHandler(this.buttonX1_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.BackColor = System.Drawing.Color.White;
            this.checkBox1.ForeColor = System.Drawing.Color.Black;
            this.checkBox1.Location = new System.Drawing.Point(59, 156);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(90, 17);
            this.checkBox1.TabIndex = 11;
            this.checkBox1.Text = "Override Files";
            this.checkBox1.UseVisualStyleBackColor = false;
            this.checkBox1.Visible = false;
            // 
            // buttonX2
            // 
            this.buttonX2.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX2.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX2.Location = new System.Drawing.Point(269, 133);
            this.buttonX2.Name = "buttonX2";
            this.buttonX2.Size = new System.Drawing.Size(79, 36);
            this.buttonX2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX2.TabIndex = 12;
            this.buttonX2.Text = "Finish";
            this.buttonX2.Click += new System.EventHandler(this.buttonX2_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(58, 176);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(250, 13);
            this.label4.TabIndex = 16;
            this.label4.Text = "Be sure to hit finish to commit to database.";
            // 
            // myExecution
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(398, 196);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.buttonX2);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.buttonX1);
            this.Controls.Add(this.ckETLonly);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.chkall);
            this.Controls.Add(this.myProfiles);
            this.Controls.Add(this.chkRange);
            this.Controls.Add(this.dateTimePicker2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.label1);
            this.DoubleBuffered = true;
            this.Name = "myExecution";
            this.Text = "FTP Execution";
            this.Load += new System.EventHandler(this.myExecution_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.CheckBox chkRange;
        private System.Windows.Forms.ComboBox myProfiles;
        private System.Windows.Forms.CheckBox chkall;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox ckETLonly;
        private DevComponents.DotNetBar.ButtonX buttonX1;
        private System.Windows.Forms.CheckBox checkBox1;
        private DevComponents.DotNetBar.ButtonX buttonX2;
        private System.Windows.Forms.Label label4;
    }
}