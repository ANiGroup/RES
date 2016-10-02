using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using EnterpriseDT.Net.Ftp;
namespace Affinity.Helper.Services
{
    /// <summary>
    /// Ftp Helper
    /// </summary>
    public class FtpHelper
    {
        /// <summary>
        /// Private FTPWebRequest method
        /// </summary>
        private FtpWebRequest _ftprequest { get; set; }
        /// <summary>
        /// The FTP User Name
        /// </summary>
        private string _UserName { get; set; }
        /// <summary>
        /// The FTP PassWord
        /// </summary>
        private string _PassWord { get; set; }
        /// <summary>
        /// The Server Host
        /// </summary>
        private string _SrvHost { get; set; }
        /// <summary>
        /// The Port Number
        /// </summary>
        private int _PortNo { get; set; }
        /// <summary>
        /// The folder Name
        /// </summary>
        /// <remarks>
        /// This a folder name inside the root folder define for the specific FTP Account.
        /// </remarks>
        private string _folderName { get; set; }
        /// <summary>
        /// Use Proxy true or false
        /// </summary>
        private Boolean _useProxy { get; set; }
        /// <summary>
        /// The Proxy URL
        /// </summary>
        private string _ProxyURL { get; set; }
        /// <summary>
        /// Use Passive
        /// </summary>
        private Boolean _usePassive { get; set; }
        /// <summary>
        /// External IP
        /// </summary>
        private string _ExternalIP { get; set; }

        /// <summary>
        /// Initialization of FTP method
        /// </summary>
        /// <param name="SrvHost">The FTP Host</param>
        /// <param name="usrName">The username</param>
        /// <param name="PassStr">The PassWord</param>
        /// <param name="FtpPort">The Port number</param>
        /// <param name="FolderPath">Folder Path</param>
        /// <param name="UseProxy">True or False</param>
        /// <param name="ProxyURL">The Proxy Address</param>
        /// <param name="usePassive">use Passive</param>
        public FtpHelper(string SrvHost,string usrName,string PassStr,int FtpPort,string FolderPath,Boolean UseProxy, string ProxyURL,Boolean usePassive=false,string ExternalIP="")
        {
            _SrvHost = SrvHost;
            _UserName = usrName;
            _PassWord = PassStr;
            _PortNo = FtpPort;
            _folderName = FolderPath;
            _useProxy = UseProxy;
            _ProxyURL = ProxyURL;
            _usePassive = usePassive;
            _ExternalIP = ExternalIP;

        }

        /// <summary>
        /// List Of Files 
        /// </summary>
        /// <param name="FilterStr">String to Filter the Files Selection</param>
        /// <returns>an array of String</returns>
        public string[] ListDirFiles(string FilterStr)
        {
                    

            FTPConnection _ftp = new FTPConnection();
            _ftp.ServerAddress = _SrvHost;
            _ftp.ServerPort = _PortNo;
            _ftp.UserName = _UserName;
            _ftp.Password = _PassWord;
                           
            if (_usePassive == false)
            {
                _ftp.ConnectMode = FTPConnectMode.ACTIVE;
            }
            else
            {
                _ftp.ConnectMode = FTPConnectMode.PASV;
            }
            if (_ExternalIP!="")
            {
                _ftp.PublicIPAddress = _ExternalIP;
            }
          
            _ftp.Connect();
            if (_folderName != "")
            {
                _ftp.ChangeWorkingDirectory(_folderName);
                if(FilterStr!="")
                {
                    return _ftp.GetFiles().Where(o => o.Contains(FilterStr)).ToArray();
                }
                else
                {
                    return _ftp.GetFiles().ToArray();
                }
                    
               
             
            }
            else
            {
               return _ftp.GetFiles().Where(o => o.Contains(FilterStr)).ToArray();
            }
          
               
                     
          
           
            
        }


        /// <summary>
        /// Download a File to Stream
        /// </summary>
        /// <param name="FileName">The File Name to Download</param>
        /// <returns>StreamReader</returns>
        public StreamReader DownLoadToStream(string FileName)
        {
            FTPConnection _ftp = new FTPConnection();
            _ftp.ServerAddress = _SrvHost;
            _ftp.ServerPort = _PortNo;
            _ftp.UserName = _UserName;
            _ftp.Password = _PassWord;

            if (_usePassive == false)
            {
                _ftp.ConnectMode = FTPConnectMode.ACTIVE;
            }
            else
            {
                _ftp.ConnectMode = FTPConnectMode.PASV;
            }
            if (_ExternalIP != "")
            {
                _ftp.PublicIPAddress = _ExternalIP;
            }
            _ftp.Connect();

          
          
           var myFile= _ftp.DownloadByteArray(_folderName+"/"+FileName);
            MemoryStream responseStream = new MemoryStream(myFile);
            StreamReader myreader = new StreamReader(responseStream);
            return myreader;
         

        }



    }
}
