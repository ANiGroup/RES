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
    public partial class Form1new : DevComponents.DotNetBar.Metro.MetroForm
    {
        public Form1new()
        {
            InitializeComponent();
        }

        private void metroTileItem1_Click(object sender, EventArgs e)
        {
            Profiles _profile = new Profiles();
            _profile.Show();
        }

        private void metroTileItem1_Click_1(object sender, EventArgs e)
        {
            Profiles _profile = new Profiles();
            _profile.Show();
        }

        private void metroTileItem2_Click(object sender, EventArgs e)
        {
            Logs _log = new Logs();
            _log.Show();
        }

        private void metroTileItem3_Click(object sender, EventArgs e)
        {
            myExecution _mexec = new myExecution();
            _mexec.Show();
        }

        private void metroTileItem10_Click(object sender, EventArgs e)
        {
            fSettings _frm = new fSettings();
            _frm.Show();
        }

        private void metroTileItem11_Click(object sender, EventArgs e)
        {
            ManualData _mdata = new ManualData();
            _mdata.Show();
          //  errorLog _erF = new errorLog();
           // _erF.Show();
        }

        private void metroTileItem12_Click(object sender, EventArgs e)
        {
            FrmFile _f = new FrmFile();
            _f.Show();
        }

        private void metroTileItem13_Click(object sender, EventArgs e)
        {
            //Open and Run The Functionalllity.
            checkDbFrm _f = new checkDbFrm();
            _f.Show();
        }

        private void Form1new_Load(object sender, EventArgs e)
        {
            metroTileItem13.Visible = false;
        }
    }
}
