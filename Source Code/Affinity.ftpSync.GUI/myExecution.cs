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
using Microsoft.VisualBasic;
using Affinity.Data.Model;
namespace Affinity.ftpSync.GUI
{
    public partial class myExecution : DevComponents.DotNetBar.Metro.MetroForm
    {
        public myExecution()
        {
            InitializeComponent();
        }

       

        private void chkRange_CheckedChanged(object sender, EventArgs e)
        {
            dateTimePicker2.Enabled = chkRange.Checked;
        }

        private void chkall_CheckedChanged(object sender, EventArgs e)
        {
            myProfiles.Enabled = !chkall.Checked;
        }

        private void myExecution_Load(object sender, EventArgs e)
        {
            var _db = new DbModel();
            var _myprofiles = _db.MySettings.ToList();
            foreach (var item in _myprofiles)
            {
                myProfiles.Items.Add(item.ProfileName);
            }
            dateTimePicker1.Value = DateTime.Now.AddDays(-1);
            dateTimePicker2.Value = DateTime.Now.AddDays(-1);
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            if(dateTimePicker1.Value.Date==DateTime.Now.Date)
            {
                MessageBox.Show("You cannot execution the action for today.");
            }
            else
            {
                if(dateTimePicker2.Value.Date==DateTime.Now.Date)
                {
                    MessageBox.Show("You cannot execution the action for today.");
                }
                else
                {
                    this.Cursor = Cursors.WaitCursor;
                    MySync _helper = new MySync();
                    DateTime _dt = dateTimePicker1.Value;
                    DateTime _dtTo = dateTimePicker2.Value;
                    if (false == false)
                    {
                        if (chkRange.Checked == true)
                        {
                            //Date Diff For the 2 Days.
                            var wD = DateAndTime.DateDiff(DateInterval.DayOfYear, _dt, _dtTo);
                            for (int i = 0; i < wD; i++)
                            {
                                DateTime _md;
                                if (i != 0)
                                {
                                    _md = _dt.AddDays(i);
                                }
                                else
                                {
                                    _md = _dt;
                                }
                                if (chkall.Checked == false)
                                {
                                    string _dStr = _md.ToString("yyMMdd");
                                    _helper.Sync(_dStr, myProfiles.Text, checkBox1.Checked);
                                }
                                else
                                {
                                    string _dStr = _md.ToString("yyMMdd");
                                    _helper.Sync(_dStr, "", checkBox1.Checked);

                                }
                            }


                        }
                        else
                        {
                            if (chkall.Checked == false)
                            {
                                string _dStr = _dt.ToString("yyMMdd");
                                _helper.Sync(_dStr, myProfiles.Text, checkBox1.Checked);
                            }
                            else
                            {
                                string _dStr = _dt.ToString("yyMMdd");
                                _helper.Sync(_dStr, "", checkBox1.Checked);

                            }
                        }
                    }
                    else
                    {

                    }
                    this.Cursor = Cursors.Default;
                    MessageBox.Show("Operation Completed");
                }
            }


            
        }

        private void myProfiles_SelectedIndexChanged(object sender, EventArgs e)
        {

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
