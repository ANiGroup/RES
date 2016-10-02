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
    public partial class errorLog : DevComponents.DotNetBar.Metro.MetroForm
    {
        public errorLog()
        {
            InitializeComponent();
        }

        private Affinity.Data.Model.DbModel db { get; set; }

        private void errorLog_Load(object sender, EventArgs e)
        {
            db = new Data.Model.DbModel();
            dataGridView1.DataSource=db.myErrorLog.Where(o=>o.ReadError==false).ToList();
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            var ErrorId = (int)dataGridView1.CurrentRow.Cells[0].Value;
            var Tomodify = db.myErrorLog.Where(o => o.Id == ErrorId).FirstOrDefault();
            Tomodify.ReadError = !Tomodify.ReadError;
            db.Entry(Tomodify).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();


            db = new Data.Model.DbModel();
            dataGridView1.DataSource = db.myErrorLog.Where(o=>o.ReadError==false).ToList();
        }
    }
}
