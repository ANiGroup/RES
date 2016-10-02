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
    public partial class edtProfile : DevComponents.DotNetBar.Metro.MetroForm
    {
        public edtProfile()
        {
            InitializeComponent();
        }

        public int ProfileId { get; set; }

        private Affinity.Data.Model.DbModel db { get; set; }

        private void edtProfile_Load(object sender, EventArgs e)
        {
            db = new Data.Model.DbModel();
            var Profile = db.MySettings.Where(o => o.Id == ProfileId).FirstOrDefault();
            
            profileNametxt.DataBindings.Add("text", Profile, "ProfileName");
            timeZonetxt.DataBindings.Add("text", Profile, "TimeZone");
            timeFromUTCtxt.DataBindings.Add("text", Profile, "TimeFromUTC");
            ftpHost.DataBindings.Add("text", Profile, "ftphost");
            ftpUser.DataBindings.Add("text", Profile, "ftpuname");
            ftpPass.DataBindings.Add("text", Profile, "ftppass");
            ftpFolder.DataBindings.Add("text", Profile, "FtpFolder");
            ftpProxyURL.DataBindings.Add("text", Profile, "ProxyURL");
            ckProxy.DataBindings.Add("checked", Profile, "UseProxy");
            ftpPort.DataBindings.Add("text", Profile, "ftpPort");
            


        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            db.SaveChanges();
            this.Close();
        }
    }
}
