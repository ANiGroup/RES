using Affinity.Helper.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Affinity.ftpSync.GUI
{
    public partial class ManualData : DevComponents.DotNetBar.Metro.MetroForm
    {
        public ManualData()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBox1.SelectedIndex==0)
            {
                //Power Data.
                myProfiles.Enabled = true;
                textBox2.Enabled = true;
                dateTimePicker1.Enabled = true;
                profileLabel.Visible = true;
                labelRevenue.Visible = true;
                DateLabel.Visible = true;

            }
            if (comboBox1.SelectedIndex == 1)
            {
                myProfiles.Enabled = false;
                textBox2.Enabled = false;
                dateTimePicker1.Enabled = true; //Gets the month Information.
                profileLabel.Visible = false;
                labelRevenue.Visible = false;
                DateLabel.Visible = true;
            }
            if (comboBox1.SelectedIndex == 2)
            {
                //MS Data.
                myProfiles.Enabled = true;
                textBox2.Enabled = false;
                dateTimePicker1.Enabled = false;
                profileLabel.Visible = true;
                labelRevenue.Visible = false;
                DateLabel.Visible = false;
            }
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            var fileName = textBox1.Text;
            var rev = 0.0;
            if (comboBox1.SelectedIndex==0)
            {
                //Power Data
                rev = Convert.ToDouble(textBox2.Text); //in that method we have revenue.
                ManualDataSync manualClient = new ManualDataSync(fileName,1,rev);
                manualClient.SyncData(dateTimePicker1.Value, myProfiles.Text);
                
            }

            if(comboBox1.SelectedIndex==1)
            {

                //Weekly Data
                ManualDataSync manualClient = new ManualDataSync(fileName, 2);
                manualClient.SyncData(dateTimePicker1.Value, ""); //Weekly Data Sync for all DM sites.
            }

            if(comboBox1.SelectedIndex==2)
            {
                //MSData.
                ManualDataSync manualClient = new ManualDataSync(fileName, 3);
                manualClient.SyncData(DateTime.Now, myProfiles.Text);

            }
            MessageBox.Show("Operation Completed.");
        }

        private void textBox1_DoubleClick(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            textBox1.Text = openFileDialog1.FileName;

        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            Affinity.Data.Model.DbModel dbClient = new Data.Model.DbModel();
                dbClient.Database.ExecuteSqlCommand("Exec [dbo].[GetMSValuesDM21]");
            MessageBox.Show("all ok");
        }
    }
}
