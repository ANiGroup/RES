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
    public partial class Form1 : DevComponents.DotNetBar.Metro.MetroForm
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Profiles _profile = new Profiles();
            _profile.Show();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Logs _log = new Logs();
            _log.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            myExecution _mexec = new myExecution();
            _mexec.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //Settings.
            fSettings _frm = new fSettings();
            _frm.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Affinity.Data.Model.DbModel db = new Data.Model.DbModel();
            var myErrors = db.myErrorLog.Where(o => o.ReadError == false).ToList();
            if (myErrors.Count()>0)
            {
                label1.Text = "Service Errors, Please see Log";
                label1.ForeColor = Color.Red;
            }
            else
            {
                label1.Text = "Service Active";
                label1.ForeColor = Color.Green;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            errorLog _erF = new errorLog();
            _erF.Show();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Affinity.Data.Model.DbModel db = new Data.Model.DbModel();
            var myErrors = db.myErrorLog.Where(o => o.ReadError == false).ToList();
            if (myErrors.Count() > 0)
            {
                label1.Text = "Service Errors, Please see Log";
                label1.ForeColor = Color.Red;
            }
            else
            {
                label1.Text = "Service Active";
                label1.ForeColor = Color.Green;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {

        }
    }
}
