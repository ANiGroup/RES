#region Copyright Syncfusion Inc. 2001-2016.
// Copyright Syncfusion Inc. 2001-2016. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
namespace Affinity.ftpSync.GUI
{
    partial class Office2010Form1
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
            this.textBoxExt1 = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
            this.checkBoxAdv1 = new Syncfusion.Windows.Forms.Tools.CheckBoxAdv();
            ((System.ComponentModel.ISupportInitialize)(this.textBoxExt1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkBoxAdv1)).BeginInit();
            this.SuspendLayout();
            // 
            // textBoxExt1
            // 
            this.textBoxExt1.BeforeTouchSize = new System.Drawing.Size(190, 20);
            this.textBoxExt1.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.textBoxExt1.Location = new System.Drawing.Point(60, 110);
            this.textBoxExt1.Metrocolor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(211)))), ((int)(((byte)(212)))));
            this.textBoxExt1.Name = "textBoxExt1";
            this.textBoxExt1.Size = new System.Drawing.Size(190, 20);
            this.textBoxExt1.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Default;
            this.textBoxExt1.TabIndex = 0;
            this.textBoxExt1.Text = "textBoxExt1";
            // 
            // checkBoxAdv1
            // 
            this.checkBoxAdv1.BeforeTouchSize = new System.Drawing.Size(150, 21);
            this.checkBoxAdv1.Location = new System.Drawing.Point(41, 182);
            this.checkBoxAdv1.MetroColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(89)))), ((int)(((byte)(91)))));
            this.checkBoxAdv1.Name = "checkBoxAdv1";
            this.checkBoxAdv1.Size = new System.Drawing.Size(150, 21);
            this.checkBoxAdv1.TabIndex = 1;
            this.checkBoxAdv1.Text = "checkBoxAdv1";
            this.checkBoxAdv1.ThemesEnabled = false;
            // 
            // Office2010Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(374, 263);
            this.Controls.Add(this.checkBoxAdv1);
            this.Controls.Add(this.textBoxExt1);
            this.Name = "Office2010Form1";
            this.Text = "Office2010Form1";
            ((System.ComponentModel.ISupportInitialize)(this.textBoxExt1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkBoxAdv1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Syncfusion.Windows.Forms.Tools.TextBoxExt textBoxExt1;
        private Syncfusion.Windows.Forms.Tools.CheckBoxAdv checkBoxAdv1;
    }
}