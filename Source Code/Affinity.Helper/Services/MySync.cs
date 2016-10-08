using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Affinity.Data.Model;
using System.Data.Entity.SqlServer;

namespace Affinity.Helper.Services
{
    public class MySync
    {
        /// <summary>
        /// The mail helper
        /// </summary>
        private mailNotificationHelper _mailHelper { get; set; }
        /// <summary>
        /// The db model
        /// </summary>
        private DbModel db { get; set; }
        /// <summary>
        /// Profile List
        /// </summary>
        private List<MySettings> Profiles { get; set; }


        /// <summary>
        /// MyAppSettings
        /// </summary>
        private myAppSettings _Settings { get; set; }
        /// <summary>
        /// Initialize 
        /// </summary>
        public MySync()
        {
            db = new DbModel();
            Profiles = db.MySettings.ToList();
            _Settings = db.myAppSettings.FirstOrDefault();
            _mailHelper = new mailNotificationHelper(_Settings.MailHost, _Settings.MailFrom, _Settings.MailUser,_Settings.MailPass, _Settings.MailPort, _Settings.MailUseSSL);

        }

        /// <summary>
        /// Save entry
        /// </summary>
        /// <param name="_m">array values</param>
        /// <param name="profile">The profile</param>
        /// <param name="item">the string item value</param>
        private Boolean SaveEntry(List<string[]> _m, MySettings profile, string item)
        {
            //one Row Here.
            //Date Created
            var resultSet = true;
            //Rows Count Saved.
            //File Name
            //Profile Name
            if (item.ToLower().Contains(".txt"))
            {
                var executionStrategy = new SqlAzureExecutionStrategy();

                MyDbConfiguration.SuspendExecutionStrategy = true;
               
                
                executionStrategy.Execute(
                    () =>
                    {
                        using (var db = new DbModel())
                        {

                            using (var trn = db.Database.BeginTransaction())
                            {
                                try
                                {
                              
                                DateTime dtDate = DateTime.Now.Date;
                                foreach (var im in _m)
                                {
                                    MyDataLogs _rec = new MyDataLogs
                                    {
                                        DateCreated = DateTime.UtcNow.AddHours(profile.TimeFromUTC),
                                        ETLComplete = false,
                                        ProfileName = profile.ProfileName,
                                        oProfileName = profile.ProfileName,
                                        oFileName = item,
                                        FileName = item,

                                        fl1 = im[0]
                                    };
                                   
                                    
                                    dtDate = Convert.ToDateTime(_rec.fl1);
                                    
                                  
                                    
                                    for (int i = 0; i < im.Length; i++)
                                    {
                                        if (i == 0)
                                        {
                                            _rec.fl1 = im[i];
                                        }

                                        if (i == 1)
                                        {
                                            _rec.fl2 = im[i];
                                        }
                                        if (i == 2)
                                        {
                                            _rec.fl3 = im[i];
                                        }

                                        if (i == 3)
                                        {
                                            _rec.fl4 = im[i];
                                        }

                                        if (i == 4)
                                        {
                                            _rec.fl5 = im[i];
                                        }

                                        if (i == 5)
                                        {
                                            _rec.fl6 = im[i];
                                        }


                                        if (i == 6)
                                        {
                                            _rec.fl7 = im[i];
                                        }

                                        if (i == 7)
                                        {
                                            _rec.fl8 = im[i];
                                        }

                                        if (i == 8)
                                        {
                                            _rec.fl9 = im[i];
                                        }

                                        if (i == 9)
                                        {
                                            _rec.fl10 = im[i];
                                        }

                                        if (i == 10)
                                        {
                                            _rec.fl11 = im[i];
                                        }

                                        if (i == 11)
                                        {
                                            _rec.fl12 = im[i];
                                        }



                                        if (i == 12)
                                        {
                                            _rec.fl13 = im[i];
                                        }

                                        if (i == 13)
                                        {
                                            _rec.fl14 = im[i];
                                        }


                                        if (i == 14)
                                        {
                                            _rec.fl15 = im[i];
                                        }

                                        if (i == 15)
                                        {
                                            _rec.fl16 = im[i];
                                        }
                                        if (i == 16)
                                        {
                                            _rec.fl17 = im[i];
                                        }
                                        if (i == 17)
                                        {
                                            _rec.fl18 = im[i];
                                        }
                                        if (i == 18)
                                        {
                                            _rec.fl19 = im[i];
                                        }
                                        if (i == 19)
                                        {
                                            _rec.fl20 = im[i];
                                        }
                                    }

                                       
                                            db.MyDataLogs.Add(_rec);
                                        

                                        
                                }

                                OperationLogs opLog = new OperationLogs
                                {
                                    FileName = item,
                                    profileName = profile.ProfileName,
                                    RowsCount = _m.Count(),
                                    DateCreated = DateTime.UtcNow.AddHours(profile.TimeFromUTC)
                                };
                                db.OperationLogs.Add(opLog);
                                db.SaveChanges();
                                //  var oLogDb = new affinitydev1Entities();


                                db.InsertedLogs.Add(
                                    new InsertedLog
                                    {
                                        ProfileName = profile.ProfileName,
                                        FileName = item,
                                        DateData = dtDate.Date
                                    });
                                db.SaveChanges();
                                    trn.Commit();
                                }
                                catch (Exception)
                                {

                                    trn.Rollback();
                                    resultSet = false;

                                }
                            }
                        }
                    });
            }
            else
            {
                resultSet = false;
            }
            MyDbConfiguration.SuspendExecutionStrategy = false;
            return resultSet;
        }

        public void DeleteDataForSelected(List<DateTime> forDateList, string profileName)
        {
           if(profileName=="FGO")
           {
                foreach (var item in forDateList)
                {                   
                    db.Database.ExecuteSqlCommand("Exec [dbo].[deleteFGO_1Hour_Table_1] {0}", item);
                    db.Database.ExecuteSqlCommand("Exec [dbo].[deleteFGO_1Minute_Table1] {0}", item);
                    db.Database.ExecuteSqlCommand("Exec [dbo].[deleteFGO_1Minute_Table2] {0}", item);
                    db.Database.ExecuteSqlCommand("Exec [dbo].[deleteFGO_24Hour_Table1] {0}", item);
                    db.Database.ExecuteSqlCommand("Exec [dbo].[deleteFGO_24Hour_Table2] {0}", item);
                }
           } 
           
           if(profileName=="OLD")
           {
                foreach (var item in forDateList)
                {
                    db.Database.ExecuteSqlCommand("Exec [dbo].[deleteOLD_1Hour_Table_1] {0}", item);
                    db.Database.ExecuteSqlCommand("Exec [dbo].[deleteOLD_1Hour_Table_2] {0}", item);
                    db.Database.ExecuteSqlCommand("Exec [dbo].[deleteOLD_1Minute_Table_1] {0}", item);
                    db.Database.ExecuteSqlCommand("Exec [dbo].[deleteOLD_1Minute_Table_2] {0}", item);
                    db.Database.ExecuteSqlCommand("Exec [dbo].[deleteOLD_24Hour_Table_1] {0}", item);
                    db.Database.ExecuteSqlCommand("Exec [dbo].[deleteOLD_24Hour_Table_2] {0}", item);
                }
           } 
           
           if(profileName=="LMD")
           {
                foreach (var item in forDateList)
                {
                    db.Database.ExecuteSqlCommand("Exec [dbo].[deleteLMD_1Hour_Table_1] {0}", item);
                    db.Database.ExecuteSqlCommand("Exec [dbo].[deleteLMD_1Hour_Table_2] {0}", item);
                    db.Database.ExecuteSqlCommand("Exec [dbo].[deleteLMD_1Minute_Table_1] {0}", item);
                    db.Database.ExecuteSqlCommand("Exec [dbo].[deleteLMD_1Minute_Table_2] {0}", item);
                    db.Database.ExecuteSqlCommand("Exec [dbo].[deleteLMD_24Hour_Table_1] {0}", item);
                    db.Database.ExecuteSqlCommand("Exec [dbo].[deleteLMD_24Hour_Table_2] {0}", item);
                }
           }   
           
           if(profileName=="DM21")
           {
                foreach (var item in forDateList)
                {
                    db.Database.ExecuteSqlCommand("Exec [dbo].[deleteDM2_1_1min_Central] {0}", item);
                    db.Database.ExecuteSqlCommand("Exec [dbo].[deleteDM2_1_1min_POD21] {0}", item);
                    db.Database.ExecuteSqlCommand("Exec [dbo].[deleteDM2_1_1min_POD22] {0}", item);
                    db.Database.ExecuteSqlCommand("Exec [dbo].[deleteDM2_1_1min_POD23] {0}", item);
                    db.Database.ExecuteSqlCommand("Exec [dbo].[deleteDM2_1_1min_POD24] {0}", item);
                    db.Database.ExecuteSqlCommand("Exec [dbo].[deleteDM2_1_24hour_Central] {0}", item);
                    db.Database.ExecuteSqlCommand("Exec [dbo].[deleteDM2_1_24hour_Central_2] {0}", item);
                }
            }  
           
           if(profileName=="DM43")
           {
                foreach (var item in forDateList)
                {
                    db.Database.ExecuteSqlCommand("Exec [dbo].[deleteDM4_3_1min_Central] {0}", item);
                    db.Database.ExecuteSqlCommand("Exec [dbo].[deleteDM4_3_1min_POD34] {0}", item);
                    db.Database.ExecuteSqlCommand("Exec [dbo].[deleteDM4_3_1min_POD35] {0}", item);
                    db.Database.ExecuteSqlCommand("Exec [dbo].[deleteDM4_3_1min_POD41] {0}", item);
                    db.Database.ExecuteSqlCommand("Exec [dbo].[deleteDM4_3_1min_POD42] {0}", item);
                    db.Database.ExecuteSqlCommand("Exec [dbo].[deleteDM4_3_1min_POD43] {0}", item);
                    db.Database.ExecuteSqlCommand("Exec [dbo].[deleteDM4_3_1min_POD44] {0}", item);
                    db.Database.ExecuteSqlCommand("Exec [dbo].[deleteDM4_3_24hour_Central] {0}", item);
                    db.Database.ExecuteSqlCommand("Exec [dbo].[deleteDM4_3_24hour_Central_2] {0}", item);
                }
            }   

            
        }

       

        public List<DateTime> SyncSingleFFS(string _folderName, MySettings profile, string dStr,Boolean overide=false)
        {
            var forDateList = new List<DateTime>();
            var _helper = new STFileHelper(_folderName);
            var myFiles = _helper._fileNames;
            myFiles = myFiles.Where(o => o.Replace("-","").ToUpper().Contains(profile.ProfileName.ToUpper())).ToList();  //ignore files of other profiles.
            StorageHelper _storageClient = new StorageHelper(_Settings.StorageAccName, _Settings.StorageAccKey,_Settings.StorageAccHttp);
            foreach (var item in myFiles)
            {

                //Check If Exist , Add Override Option Here
                
                db = new DbModel();
                var FileName = Path.GetFileName(item);
              //  var oDbModel = new affinitydev1Entities();
                var fOndb = db.InsertedLogs.Where(o => o.FileName.Contains(FileName) && o.ProfileName==profile.ProfileName).ToList();
                if (fOndb.Count() == 0)
                {
                    var myStream = _helper.DownloadToStream(item);
                    var _containerName = profile.ProfileName.Replace(' ', '0') + dStr;
                    _storageClient.UploadFile(myStream, _containerName, item);


                    var mem = _storageClient.DownLoadCloudFile(item, _containerName);
                    FileHelper _fhelper = new FileHelper(mem);
                    var _m = _fhelper.GetFileEntries();
                    var mFile = item.Replace(_folderName + "\\", "");
                    var _resulset=  SaveEntry(_m, profile, mFile);
                }
                else
                {
                    if (overide==true)
                    {
                        //But First Delete the existing Files.
                        var oFileName = Path.GetFileName(item);
                        var ofOndb = db.MyDataLogs.Where(o => o.FileName.Contains(oFileName)).ToList();

                      //  var oLogDbModel = new affinitydev1Entities();
                        var fOndbLog = db.InsertedLogs.Where(o => o.FileName.Contains(FileName) && o.ProfileName == profile.ProfileName).ToList();
                        foreach ( var iLogItem in fOndbLog)
                        {
                            db.InsertedLogs.Remove(iLogItem);
                            forDateList.Add(iLogItem.DateData);
                            forDateList.Add(iLogItem.DateData.AddDays(-1));
                            db.SaveChanges();
                        }
                        foreach (var odbItem in ofOndb)
                        {
                            db.MyDataLogs.Remove(odbItem);
                            db.SaveChanges();
                        }

                        var myStream = _helper.DownloadToStream(item);
                        var _containerName = profile.ProfileName.Replace(' ', '0') + dStr;
                        _storageClient.UploadFile(myStream, _containerName, item);


                        var mem = _storageClient.DownLoadCloudFile(item, _containerName);
                        FileHelper _fhelper = new FileHelper(mem);
                        var _m = _fhelper.GetFileEntries();
                        var mFile = item.Replace(_folderName + "\\", "");
                       var resultSet=   SaveEntry(_m, profile, mFile);
                    }
                }
            }
            return forDateList;
        }


        /// <summary>
        /// The profile
        /// </summary>
        /// <param name="profile">Profile name</param>
        /// <param name="dStr">The Date String</param>
        private string SyncSingle(MySettings profile, string dStr,Boolean OvverideCall=false)
        {
            var msg = "";

            FtpHelper _helper = new FtpHelper(profile.ftphost, profile.ftpuname, profile.ftppass, profile.ftpPort, profile.FtpFolder, profile.UseProxy, profile.ProxyURL, _Settings.UsePassive, _Settings.ExternalIP);
            var myFiles = _helper.ListDirFiles(dStr);
            var oFiles = new List<string>();
            oFiles.AddRange(myFiles);

            var h24_File = oFiles.Where(o => o.ToLower().Contains("24h")).FirstOrDefault();
            if (h24_File==null)
            {
                var _md = DateTime.Now;
                var _dstr2 = _md.AddDays(-2).ToString("yyMMdd"); //Try to find the file 2 days ago.
                var omyFiles = _helper.ListDirFiles(_dstr2);
                foreach (var item in omyFiles)
                {
                    if(item.ToLower().Contains("24h"))
                    {
                        oFiles.Add(item); //Add the 24h file.
                    }
                }
            }
            //Check Number of Files Here.
            var FilesCount = oFiles.Count();
            if (FilesCount>0)
            {
                msg = msg + " Found " + FilesCount.ToString() + " Files for Profile " + dStr + "<br />";
            }
            else
            {
                msg = msg + "FTP error no files found  for Profile "+dStr+"<br />";
            }
            
            foreach (var i in oFiles)
            {
                msg = msg + " File " + i + " retrieved from FTP Server <br />";
            }
             

            StorageHelper _storageClient = new StorageHelper(_Settings.StorageAccName, _Settings.StorageAccKey, _Settings.StorageAccHttp);
            foreach (var item in oFiles)
            {
                //Check if File Exist Here , 
                var FileIndb = db.InsertedLogs.Where(o => o.FileName.Equals(item) & o.ProfileName.Equals(profile.ProfileName)).ToList();
                if (FileIndb.Count() == 0)
                {
                    //File not in Database Proceed.
                  
                  
                    var myStream = _helper.DownLoadToStream(item);
                    var _containerName = profile.ProfileName.Replace(' ', '0') + dStr;
                    _storageClient.UploadFile(myStream, _containerName, item);


                    var mem = _storageClient.DownLoadCloudFile(item, _containerName);
                    FileHelper _fhelper = new FileHelper(mem);
                    var _m = _fhelper.GetFileEntries();

                  var resultSet = SaveEntry(_m, profile, item);
                    if(resultSet==true)
                    {
                        msg = msg + " File " + item + "  inserted.<br />";
                    }
                    else
                    {
                        msg = msg + " File " + item + "not  inserted.<br />";
                    }
                   
                }
                else
                {
                    //Here the Override Method.
                    //Add Override Option Here.


                    if (OvverideCall == true)
                    {
                        foreach (var iOndb in FileIndb)
                        {
                            var _file = db.MyDataLogs.Where(o => o.FileName == iOndb.FileName && o.ProfileName == iOndb.ProfileName).FirstOrDefault();
                            db.MyDataLogs.Remove(_file);
                            db.SaveChanges();

                        }
                        //Now Go Ahead and insert again the files.
                        var myStream = _helper.DownLoadToStream(item);
                        var _containerName = profile.ProfileName.Replace(' ', '0') + dStr;
                        _storageClient.UploadFile(myStream, _containerName, item);


                        var mem = _storageClient.DownLoadCloudFile(item, _containerName);
                        FileHelper _fhelper = new FileHelper(mem);
                        var _m = _fhelper.GetFileEntries();

                     var resultSet=   SaveEntry(_m, profile, item);
                        if(resultSet==true)
                        {
                            msg = msg + " File " + item + "  override.<br />";
                        }
                        else
                        {
                            msg = msg + " File " + item + "  override failed.<br />";
                        }
                        
                    }
                }

            }

            return msg;
        }

       


        public void Sync(string _dStr, string ProfileFilter = "",Boolean ovveride=false)
        {
            string dStr = "";
            if (ProfileFilter != "")
            {
                Profiles = Profiles.Where(o => o.ProfileName == ProfileFilter).ToList();
            }

            foreach (var item in Profiles)
            {

                dStr = _dStr;
                try
                {
                   var msg= SyncSingle(item, dStr,ovveride);
                    string _HtmlBody = System.IO.File.ReadAllText("C:\\Templates\\"+item.ProfileName+".html");
                    if (msg.Contains("FTP error no files found"))
                    {

                        string[] _to = _Settings.SendTo.Split(';');
                        string msBody = "The FTP call completed at " + DateTime.UtcNow + " Coordinated Universal Time (UTC) for Date string " + dStr + " for project " + item.ProfileName + "<br />Please see log for details.<br />" + msg;
                        _HtmlBody=_HtmlBody.Replace("#Content#" , msBody);
                        _mailHelper.mSend(_to, "FTP call error - no files found Site "+item.ProfileName, _HtmlBody);
                    }
                    else
                    {



                        string[] _to = _Settings.SendTo.Split(';');
                        string msbody = "The FTP call completed at " + DateTime.UtcNow + " Coordinated Universal Time (UTC) for Date string " + dStr + " for project " + item.ProfileName + "<br />Please see log for details.<br />" + msg;
                       _HtmlBody= _HtmlBody.Replace("#Content#", msbody);
                        _mailHelper.mSend(_to, "FTP call Success For Site "+item.ProfileName,_HtmlBody );
                    }
                    }
                catch (Exception ex)
                {
                    //Send mail message for failure Here.
                    string[] _mto = _Settings.SendTo.Split(';');
                    _mailHelper.mSend(_mto, "FTP call failure Site "+item.ProfileName, "The FTP call failed for site "+item.ProfileName+" at " + DateTime.UtcNow + " Coordinated Universal Time (UTC) for Date string " + _dStr+" -site "+item.ProfileName+"<br />Exception Details"+ex.InnerException+"<br />Please see log for details.");
                    //Error Log

                    Affinity.Data.Model.myErrorLog _erRec = new myErrorLog
                    {
                        ErrorCreated = DateTime.UtcNow,
                        DString = dStr,
                        ProfileName = item.ProfileName,
                        ReadError = false,
                        errorDescription = ex.Message.ToString()

                    };
                    db.myErrorLog.Add(_erRec);
                    db.SaveChanges();
                }

            }
            //no ETL Will be performed
          //  ETLOnly();

            

        }

      
    }
}
