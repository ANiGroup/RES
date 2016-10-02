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
    public partial class Logs : DevComponents.DotNetBar.Metro.MetroForm
    {

        private DbModel db { get; set; }

        public Logs()
        {
            InitializeComponent();
        }


        private void Logs_Load(object sender, EventArgs e)
        {
            db = new DbModel();
            dataGridView1.DataSource = db.OperationLogs.ToList();
            dataGridView2.DataSource = db.myErrorLog.Where(o => o.ReadError == false).ToList();
        }

        private void dataGridView2_DoubleClick(object sender, EventArgs e)
        {
            var ErrorId = (int)dataGridView2.CurrentRow.Cells[0].Value;
            var Tomodify = db.myErrorLog.Where(o => o.Id == ErrorId).FirstOrDefault();
            Tomodify.ReadError = !Tomodify.ReadError;
            db.Entry(Tomodify).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();


            db = new Data.Model.DbModel();
            dataGridView2.DataSource = db.myErrorLog.Where(o => o.ReadError == false).ToList();
        }
    }
}
