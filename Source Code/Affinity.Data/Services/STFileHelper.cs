using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace Affinity.Helper.Services
{
    public class STFileHelper
    {
        public List<string> _fileNames { get; set; }

        public STFileHelper(string _folderName)
        {
            //List all Files

            _fileNames = Directory.GetFiles(_folderName).ToList();
        }

        public StreamReader DownloadToStream(string _fileName)
        {
            Byte[] myFile = System.IO.File.ReadAllBytes(_fileName);
            MemoryStream responseStream = new MemoryStream(myFile);
            StreamReader myreader = new StreamReader(responseStream);
            return myreader;
        }
    }
}
