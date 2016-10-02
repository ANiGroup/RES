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
    public partial class FrmFile : DevComponents.DotNetBar.Metro.MetroForm
    {

        public List<DateTime> forDateList { get; set; }

        public FrmFile()
        {
            InitializeComponent();
        }

        private void FrmFile_Load(object sender, EventArgs e)
        {
            var _db = new Affinity.Data.Model.DbModel();
            var _myprofiles = _db.MySettings.ToList();
            foreach (var item in _myprofiles)
            {
                myProfiles.Items.Add(item.ProfileName);
            }
        }

        private void chkall_CheckedChanged(object sender, EventArgs e)
        {
            myProfiles.Enabled = !chkall.Checked;
        }

        

        private void buttonX1_Click(object sender, EventArgs e)
        {
            forDateList = new List<DateTime>();
            forDateList.Clear();
            this.Cursor = Cursors.WaitCursor;
            MySync _helper = new MySync();
            var db = new Data.Model.DbModel();
            var profiles = db.MySettings.ToList();
            if (chkall.Checked == false)
            {
                var profile = profiles.Where(o => o.ProfileName == myProfiles.Text).FirstOrDefault();
                 if (checkBox1.Checked==false)
                {
                   forDateList= _helper.SyncSingleFFS(textBox1.Text, profile, "",checkBox2.Checked);
                }
                 else
                {
                    var myDirs = System.IO.Directory.GetDirectories(textBox1.Text);
                    foreach (var item in myDirs)
                    {

                        _helper.SyncSingleFFS(item, profile, "");
                        if (System.IO.Directory.GetDirectories(item)!=null)
                        {
                            foreach (var itmSub  in System.IO.Directory.GetDirectories(item))
                            {
                                _helper.SyncSingleFFS(itmSub, profile, "",checkBox2.Checked);
                            }
                        }
                    }
                }
               
            }
            else
            {
                foreach (var item in profiles)
                {
                    _helper.SyncSingleFFS(textBox1.Text, item, "");
                }
            }
            this.Cursor = Cursors.Default;

            if(checkBox2.Checked==true)
            {
                if(forDateList.Count()>0)
                {
                    _helper.DeleteDataForSelected(forDateList,myProfiles.Text);
                }
            }

            MessageBox.Show("Operation Completed.");
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowDialog();
            textBox1.Text = folderBrowserDialog1.SelectedPath;
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            
            
                System.Diagnostics.Process proc = new System.Diagnostics.Process();
                proc.EnableRaisingEvents = false;
                proc.StartInfo.UseShellExecute = false;
                proc.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                proc.StartInfo.FileName = @"C:\Templates\RunMe.bat";
                proc.Start();
                this.Cursor = Cursors.Default;
                this.Close();
            
            
            
        }
    }
}
