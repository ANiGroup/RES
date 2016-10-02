using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Affinity.Data.Model;
namespace Affinity.ftpSync.GUI
{
    public partial class Profiles : DevComponents.DotNetBar.Metro.MetroForm
    {
        private DbModel db { get; set; }

        public Profiles()
        {
            InitializeComponent();
        }

        private void Profiles_Load(object sender, EventArgs e)
        {
            db = new DbModel();
            dataGridView1.DataSource = db.MySettings.ToList();
        }

     

             

       

        private void buttonX1_Click(object sender, EventArgs e)
        {
            newProfile _profile = new newProfile();
            _profile.Show();
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            edtProfile _editRec = new edtProfile();
            _editRec.ProfileId = (int)dataGridView1.CurrentRow.Cells[0].Value;
            _editRec.Show();

        }

        private void buttonX3_Click(object sender, EventArgs e)
        {
            var ProfileId = (int)dataGridView1.CurrentRow.Cells[0].Value;
            var Todelete = db.MySettings.Where(o => o.Id == ProfileId).FirstOrDefault();
            db.MySettings.Remove(Todelete);
            db.SaveChanges();
            buttonX4_Click(sender, e);
        }

        private void buttonX4_Click(object sender, EventArgs e)
        {
            db = new DbModel();
            dataGridView1.DataSource = db.MySettings.ToList();
        }
    }
}
