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
    public partial class checkDbFrm : DevComponents.DotNetBar.Metro.MetroForm
    {
        public checkDbFrm()
        {
            InitializeComponent();
        }

        private void checkDbFrm_Load(object sender, EventArgs e)
        {
            var _db = new Affinity.Data.Model.DbModel();
            var _myprofiles = _db.MySettings.ToList();
            foreach (var item in _myprofiles)
            {
                myProfiles.Items.Add(item.ProfileName);
            }

        }

        private void useLoadLocation_CheckedChanged(object sender, EventArgs e)
        {
            loadLocation.ReadOnly =! useLoadLocation.Checked;

        }

        private void useSaveLocation_CheckedChanged(object sender, EventArgs e)
        {
            saveLocation.ReadOnly =! useSaveLocation.Checked;
        }

        private void LoadLocation_Click(object sender, EventArgs e)
        {
            if (loadLocation.ReadOnly==false)
            {
                folderBrowserDialog1.ShowDialog();
                loadLocation.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void saveLocation_Click(object sender, EventArgs e)
        {
            if (saveLocation.ReadOnly==false)
            {
                folderBrowserDialog2.ShowDialog();
                saveLocation.Text = folderBrowserDialog2.SelectedPath;
            }
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            Affinity.Helper.Services.DbChecker checkDb = new Helper.Services.DbChecker();

            var resultSet=  checkDb.CheckDb(dateTimePicker1.Value, dateTimePicker2.Value,myProfiles.Text, ftpLogPath.Text, chkLogOnly.Checked, chkOvverideDb.Checked, loadLocation.Text,saveLocation.Text);
            textBox1.Text = resultSet;
            MessageBox.Show("Operation Completed.");
        }
    }
}
