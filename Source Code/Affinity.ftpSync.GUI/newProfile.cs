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
    public partial class newProfile : DevComponents.DotNetBar.Metro.MetroForm
    {
        public newProfile()
        {
            InitializeComponent();
        }

     

        private void buttonX1_Click(object sender, EventArgs e)
        {
            Affinity.Data.Model.DbModel db = new Data.Model.DbModel();
            db.MySettings.Add(
             new Data.Model.MySettings
             {
                 ProfileName = profileNametxt.Text,
                 TimeFromUTC = Convert.ToInt32(timeFromUTCtxt.Text),
                 TimeZone = timeZonetxt.Text,
                 ftphost = ftpHost.Text,
                 ftpuname = ftpUser.Text,
                 ftppass = ftpPass.Text,
                 ftpPort = Convert.ToInt32(ftpPort.Text),
                 FtpFolder = ftpFolder.Text,
                 ProxyURL = ftpProxyURL.Text,
                 UseProxy = ckProxy.Checked

             }
                );
            db.SaveChanges();
            this.Close();
        }
    }
}
