namespace Affinity.ftpSync.GUI
{
    partial class checkDbFrm
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.chkOvverideDb = new System.Windows.Forms.CheckBox();
            this.useLoadLocation = new System.Windows.Forms.CheckBox();
            this.useSaveLocation = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.myProfiles = new System.Windows.Forms.ComboBox();
            this.ftpLogPath = new System.Windows.Forms.TextBox();
            this.loadLocation = new System.Windows.Forms.TextBox();
            this.saveLocation = new System.Windows.Forms.TextBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.buttonX1 = new DevComponents.DotNetBar.ButtonX();
            this.chkLogOnly = new System.Windows.Forms.CheckBox();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.folderBrowserDialog2 = new System.Windows.Forms.FolderBrowserDialog();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(84, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Period ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(64, 100);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Log Folder";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.White;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(33, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Profile to Check";
            // 
            // chkOvverideDb
            // 
            this.chkOvverideDb.AutoSize = true;
            this.chkOvverideDb.BackColor = System.Drawing.Color.White;
            this.chkOvverideDb.ForeColor = System.Drawing.Color.Black;
            this.chkOvverideDb.Location = new System.Drawing.Point(32, 169);
            this.chkOvverideDb.Name = "chkOvverideDb";
            this.chkOvverideDb.Size = new System.Drawing.Size(121, 17);
            this.chkOvverideDb.TabIndex = 4;
            this.chkOvverideDb.Text = "Ovveride Db Entries";
            this.chkOvverideDb.UseVisualStyleBackColor = false;
            // 
            // useLoadLocation
            // 
            this.useLoadLocation.AutoSize = true;
            this.useLoadLocation.BackColor = System.Drawing.Color.White;
            this.useLoadLocation.ForeColor = System.Drawing.Color.Black;
            this.useLoadLocation.Location = new System.Drawing.Point(32, 134);
            this.useLoadLocation.Name = "useLoadLocation";
            this.useLoadLocation.Size = new System.Drawing.Size(99, 17);
            this.useLoadLocation.TabIndex = 5;
            this.useLoadLocation.Text = "Use Local Path";
            this.useLoadLocation.UseVisualStyleBackColor = false;
            this.useLoadLocation.CheckedChanged += new System.EventHandler(this.useLoadLocation_CheckedChanged);
            // 
            // useSaveLocation
            // 
            this.useSaveLocation.AutoSize = true;
            this.useSaveLocation.BackColor = System.Drawing.Color.White;
            this.useSaveLocation.ForeColor = System.Drawing.Color.Black;
            this.useSaveLocation.Location = new System.Drawing.Point(32, 203);
            this.useSaveLocation.Name = "useSaveLocation";
            this.useSaveLocation.Size = new System.Drawing.Size(117, 17);
            this.useSaveLocation.TabIndex = 6;
            this.useSaveLocation.Text = "Save to Local Path";
            this.useSaveLocation.UseVisualStyleBackColor = false;
            this.useSaveLocation.CheckedChanged += new System.EventHandler(this.useSaveLocation_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.White;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(155, 207);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Save Location";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.White;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(157, 138);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(88, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Load Location";
            // 
            // myProfiles
            // 
            this.myProfiles.BackColor = System.Drawing.Color.White;
            this.myProfiles.ForeColor = System.Drawing.Color.Black;
            this.myProfiles.FormattingEnabled = true;
            this.myProfiles.Location = new System.Drawing.Point(148, 68);
            this.myProfiles.Name = "myProfiles";
            this.myProfiles.Size = new System.Drawing.Size(196, 21);
            this.myProfiles.TabIndex = 9;
            // 
            // ftpLogPath
            // 
            this.ftpLogPath.BackColor = System.Drawing.Color.White;
            this.ftpLogPath.ForeColor = System.Drawing.Color.Black;
            this.ftpLogPath.Location = new System.Drawing.Point(148, 100);
            this.ftpLogPath.Name = "ftpLogPath";
            this.ftpLogPath.Size = new System.Drawing.Size(402, 20);
            this.ftpLogPath.TabIndex = 10;
            // 
            // loadLocation
            // 
            this.loadLocation.BackColor = System.Drawing.Color.White;
            this.loadLocation.ForeColor = System.Drawing.Color.Black;
            this.loadLocation.Location = new System.Drawing.Point(251, 134);
            this.loadLocation.Name = "loadLocation";
            this.loadLocation.ReadOnly = true;
            this.loadLocation.Size = new System.Drawing.Size(299, 20);
            this.loadLocation.TabIndex = 11;
            this.loadLocation.Click += new System.EventHandler(this.LoadLocation_Click);
            // 
            // saveLocation
            // 
            this.saveLocation.BackColor = System.Drawing.Color.White;
            this.saveLocation.ForeColor = System.Drawing.Color.Black;
            this.saveLocation.Location = new System.Drawing.Point(250, 204);
            this.saveLocation.Name = "saveLocation";
            this.saveLocation.ReadOnly = true;
            this.saveLocation.Size = new System.Drawing.Size(300, 20);
            this.saveLocation.TabIndex = 12;
            this.saveLocation.Click += new System.EventHandler(this.saveLocation_Click);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.BackColor = System.Drawing.Color.White;
            this.dateTimePicker1.ForeColor = System.Drawing.Color.Black;
            this.dateTimePicker1.Location = new System.Drawing.Point(148, 30);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(196, 20);
            this.dateTimePicker1.TabIndex = 13;
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.BackColor = System.Drawing.Color.White;
            this.dateTimePicker2.ForeColor = System.Drawing.Color.Black;
            this.dateTimePicker2.Location = new System.Drawing.Point(350, 30);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker2.TabIndex = 14;
            // 
            // buttonX1
            // 
            this.buttonX1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX1.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX1.Location = new System.Drawing.Point(571, 30);
            this.buttonX1.Name = "buttonX1";
            this.buttonX1.Size = new System.Drawing.Size(109, 43);
            this.buttonX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX1.TabIndex = 15;
            this.buttonX1.Text = "Execute";
            this.buttonX1.Click += new System.EventHandler(this.buttonX1_Click);
            // 
            // chkLogOnly
            // 
            this.chkLogOnly.AutoSize = true;
            this.chkLogOnly.BackColor = System.Drawing.Color.White;
            this.chkLogOnly.ForeColor = System.Drawing.Color.Black;
            this.chkLogOnly.Location = new System.Drawing.Point(202, 169);
            this.chkLogOnly.Name = "chkLogOnly";
            this.chkLogOnly.Size = new System.Drawing.Size(66, 17);
            this.chkLogOnly.TabIndex = 16;
            this.chkLogOnly.Text = "Log only";
            this.chkLogOnly.UseVisualStyleBackColor = false;
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.White;
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.textBox1.ForeColor = System.Drawing.Color.Black;
            this.textBox1.Location = new System.Drawing.Point(0, 258);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(699, 287);
            this.textBox1.TabIndex = 17;
            // 
            // checkDbFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(699, 545);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.chkLogOnly);
            this.Controls.Add(this.buttonX1);
            this.Controls.Add(this.dateTimePicker2);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.saveLocation);
            this.Controls.Add(this.loadLocation);
            this.Controls.Add(this.ftpLogPath);
            this.Controls.Add(this.myProfiles);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.useSaveLocation);
            this.Controls.Add(this.useLoadLocation);
            this.Controls.Add(this.chkOvverideDb);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.DoubleBuffered = true;
            this.Name = "checkDbFrm";
            this.Text = "Check & correct Db Entries";
            this.Load += new System.EventHandler(this.checkDbFrm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox chkOvverideDb;
        private System.Windows.Forms.CheckBox useLoadLocation;
        private System.Windows.Forms.CheckBox useSaveLocation;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox myProfiles;
        private System.Windows.Forms.TextBox ftpLogPath;
        private System.Windows.Forms.TextBox loadLocation;
        private System.Windows.Forms.TextBox saveLocation;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private DevComponents.DotNetBar.ButtonX buttonX1;
        private System.Windows.Forms.CheckBox chkLogOnly;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog2;
        private System.Windows.Forms.TextBox textBox1;
    }
}