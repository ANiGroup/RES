using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage;
using System.IO;
using Microsoft.WindowsAzure.Storage.Blob;

namespace Affinity.Helper.Services
{
    /// <summary>
    /// Storage Helper
    /// </summary>
    public class StorageHelper
    {
        /// <summary>
        /// Private CloudStorageAccount object
        /// </summary>
        private CloudStorageAccount _StorageAccount { get; set; }
        /// <summary>
        /// The Connection String for this Storage Client.
        /// </summary>
        private string _ConStr { get; set; }
      
        /// <summary>
        /// Initialization method.
        /// </summary>
        /// <param name="AccName">Account Name</param>
        /// <param name="AccKey">Account Key</param>
        /// <param name="UseSSL">Use https?</param>
       public StorageHelper(string AccName,string AccKey,Boolean UseSSL)
       {
            _ConStr = "DefaultEndpointsProtocol=";
           if (UseSSL==true)
            {
                _ConStr += "https;";
            }
           else
            {
                _ConStr += "http";
            }
            
            _ConStr += "AccountName="+AccName+";";
            _ConStr += "AccountKey=" + AccKey + ";";
            _StorageAccount = CloudStorageAccount.Parse(_ConStr);

       }
        /// <summary>
        /// Upload File To Storage From Stream
        /// </summary>
        /// <param name="File">File Stream, The FTP File Stream</param>
        /// <param name="ContainerName">Container Name</param>
        public void UploadFile(StreamReader myFileStream,string myContainerName,string myFileName)
        {
            CloudBlobClient blobclient = _StorageAccount.CreateCloudBlobClient();
            CloudBlobContainer blobContainer = blobclient.GetContainerReference(myContainerName.ToLower());
            blobContainer.CreateIfNotExists();
            BlobContainerPermissions _perm = new BlobContainerPermissions();
            _perm.PublicAccess = BlobContainerPublicAccessType.Off;
            blobContainer.SetPermissions(_perm);
            CloudBlockBlob _blob = blobContainer.GetBlockBlobReference(myFileName);
            _blob.UploadFromStream(myFileStream.BaseStream);
        }

        /// <summary>
        /// Get the private file from Storage.
        /// </summary>
        /// <param name="FileName">The Cloud File Name</param>
        /// <param name="ContainerName">The Container</param>
        public byte[] DownLoadCloudFile(string myFileName,string myContainerName)
        {
            CloudBlobClient blobclient = _StorageAccount.CreateCloudBlobClient();
            CloudBlobContainer blobContainer = blobclient.GetContainerReference(myContainerName.ToLower());


            CloudBlockBlob blockBlob = blobContainer.GetBlockBlobReference(myFileName);

            byte[] fileBytes;
            using (var fileStream = new MemoryStream())
            {
                blockBlob.DownloadToStream(fileStream);
                fileBytes = fileStream.ToArray();
            }

            return fileBytes;
           
        }



    }
}
