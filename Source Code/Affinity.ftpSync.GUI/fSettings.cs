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
    public partial class fSettings : DevComponents.DotNetBar.Metro.MetroForm
    {
        public fSettings()
        {
            InitializeComponent();
        }

        private void fSettings_Load(object sender, EventArgs e)
        {
            Affinity.Data.Model.DbModel db = new Affinity.Data.Model.DbModel();
            var _settings = db.myAppSettings.FirstOrDefault();
            accNametxt.Text = _settings.StorageAccName;
            accKeytxt.Text = _settings.StorageAccKey;
            checkusehttp.Checked =_settings.StorageAccHttp;
            mUsertxt.Text = _settings.MailUser;
            passtxt.Text = _settings.MailPass;
            mHosttxt.Text = _settings.MailHost;
            mPorttxt.Text = Convert.ToString(_settings.MailPort);
            Fromtxt.Text =_settings.MailFrom;
            ckuseSSL.Checked =_settings.MailUseSSL;
            sendTotxt.Text = _settings.SendTo;
            externalIPtxt.Text = _settings.ExternalIP;
            ckPassive.Checked = _settings.UsePassive;
        }

       

        private void buttonX1_Click(object sender, EventArgs e)
        {
           DbModel db = new DbModel();
            var _settings = db.myAppSettings.FirstOrDefault();
            _settings.StorageAccName = accNametxt.Text;
            _settings.StorageAccKey = accKeytxt.Text;
            _settings.StorageAccHttp = checkusehttp.Checked;
            _settings.MailUser = mUsertxt.Text;
            _settings.MailPass = passtxt.Text;
            _settings.MailHost = mHosttxt.Text;
            _settings.MailPort = Convert.ToInt32(mPorttxt.Text);
            _settings.MailFrom = Fromtxt.Text;
            _settings.MailUseSSL = ckuseSSL.Checked;
            _settings.SendTo = sendTotxt.Text;
            _settings.ExternalIP = externalIPtxt.Text;
            _settings.UsePassive = ckPassive.Checked;

            db.Entry(_settings).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            this.Close();
        }
    }
}
