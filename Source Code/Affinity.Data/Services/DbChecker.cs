using Affinity.Helper.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Affinity.Helper.Services
{
    public class DbChecker
    {

        /// <summary>
        /// The mail helper
        /// </summary>
        private mailNotificationHelper _mailHelper { get; set; }
        /// <summary>
        /// The db model
        /// </summary>
        private Model.DbModel db { get; set; }
        /// <summary>
        /// Profile List
        /// </summary>
        private List<Model.MySettings> Profiles { get; set; }


        /// <summary>
        /// MyAppSettings
        /// </summary>
        private myAppSettings _Settings { get; set; }


        public DbChecker()
        {
            db = new Model.DbModel();
            Profiles = db.MySettings.ToList();
            _Settings = db.myAppSettings.FirstOrDefault();
            _mailHelper = new mailNotificationHelper(_Settings.MailHost, _Settings.MailFrom, _Settings.MailUser, _Settings.MailPass, _Settings.MailPort, _Settings.MailUseSSL);
        }


        private string checkFtp(DateTime dtStart, DateTime dtEnd, string profile, string FtpLogPath,Boolean LogOnly, Boolean OvverideDb,string SaveLocation)
        {
            var profileConfig = Profiles.Where(o => o.ProfileName == profile).FirstOrDefault();
            var ftpClient = new FtpHelper(profileConfig.ftphost, profileConfig.ftpuname, profileConfig.ftppass, profileConfig.ftpPort, FtpLogPath, profileConfig.UseProxy, profileConfig.ProxyURL, Affinity.Helper.Properties.Settings.Default.UsePassive,Affinity.Helper.Properties.Settings.Default.ExternalIP);

           var ftpFiles=  ftpClient.ListDirFiles("");
            
            

            foreach (var item in ftpFiles)
            {
               if (LogOnly==false) 
               {
                     
                  SaveEntry(profile,item, OvverideDb,FtpLogPath);
                    
               }

                if (SaveLocation!="")
                {
                    var fileContent = ftpClient.DownLoadToStream(item);
                    using (Stream s = File.Create(SaveLocation+"/"+item))
                    {
                        fileContent.BaseStream.CopyTo(s);
                    }

                }
            }

            if (LogOnly == true)
            {
                return GetLogEntryFromFTPFiles(dtStart, dtEnd, profile, ftpFiles);
            }
            return "Operation Completed";
        }

        private string GetLogEntryFromFTPFiles(DateTime dtStart, DateTime dtEnd, string profile, string[] ftpFiles)
        {
            var perProfileFiles = db.ProfileFileIndexes.Where(o => o.ProfileName == profile).ToList();
            var notFoundFiles = new List<string>();
            var notValidFile = new List<string>();
            var notFoundFilesInDb = new List<string>();
            var duplicateEntries = new List<string>();

            var ForDt = dtStart;
            var _profileString = profile;
            if(profile.Contains("DM"))
            {
                _profileString = profile.Substring(0, 3);
            }
            foreach (var item in ftpFiles)
            {
                if (item.ToUpper().Contains(_profileString)==false)
                {
                    if (!item.Contains("Alarm"))
                    {
                        notValidFile.Add(item);
                    }
                }
              var profileDateString=  item.Substring(item.Length - 10, 6);
                if(profileDateString.Substring(0,4)!=ForDt.ToString("yyMM"))
                {
                    notValidFile.Add(item);
                }
            }

            while(ForDt<=dtEnd)
            {
                var checkDateString = ForDt.ToString("yyMMdd");

                foreach (var item in perProfileFiles)
                {
                    var forDateFile = item.FileDefinition + checkDateString + ".txt";
                    if(item.OptionalFile==false)
                    {

                       if(ftpFiles.ToList().Contains(forDateFile)==false)
                       {
                            notFoundFiles.Add(forDateFile);
                       }
                        var LogDbFile = db.InsertedLogs.Where(o => o.ProfileName == profile && o.FileName == forDateFile).ToList();
                        if(LogDbFile.Count()!=0)
                        {
                            notFoundFilesInDb.Add(forDateFile);
                        }
                        if(LogDbFile.Count()>1)
                        {
                            duplicateEntries.Add(forDateFile);
                        }
                    }
                }

             ForDt=   ForDt.AddDays(1);
            }

            string errorLog = "";
            errorLog = "Error check for period " + dtStart.ToShortDateString() + "-" + dtEnd.ToShortDateString() + Environment.NewLine;
            foreach (var item in notFoundFiles)
            {
                errorLog += "Files not Found " +item+Environment.NewLine;
            }
            foreach (var item in notFoundFilesInDb)
            {
                errorLog += "Files not Found in Db " + item + Environment.NewLine;
            }

            foreach (var item in duplicateEntries)
            {
                errorLog += "Files with duplicate entries in Db " + item + Environment.NewLine;
            }

            foreach (var item in notValidFile)
            {
                errorLog += "No valid File for that period/profile " + item + Environment.NewLine;
            }


            var log = new CheckLogDatas
            {
                DateCreated = DateTime.Now,
                ProFileName = profile,
                ErrorLog = errorLog
            };
            db.CheckLogDatas.Add(log);
            db.SaveChanges();
            return errorLog;
        }

        private string GetLogEntryFromFiles(DateTime dtStart, DateTime dtEnd, string profile, string[] ftpFiles)
        {
            var perProfileFiles = db.ProfileFileIndexes.Where(o => o.ProfileName == profile).ToList();
            var notFoundFiles = new List<string>();
            var notValidFile = new List<string>();
            var notFoundFilesInDb = new List<string>();
            var duplicateEntries = new List<string>();

            var ForDt = dtStart;
            var _profileString = profile;
            if (profile.Contains("DM"))
            {
                _profileString = profile.Substring(0, 3);
            }
            foreach (var Fileitem in ftpFiles)
            {
                var item = Path.GetFileName(Fileitem);
                if (item.ToUpper().Contains(_profileString) == false)
                {
                    if (!item.Contains("Alarm"))
                    {
                        notValidFile.Add(item);
                    }
                }
                var profileDateString = item.Substring(item.Length - 10, 6);
                if (profileDateString.Substring(0, 4) != ForDt.ToString("yyMM"))
                {
                    notValidFile.Add(item);
                }
            }

            while (ForDt <= dtEnd)
            {
                var checkDateString = ForDt.ToString("yyMMdd");

                foreach (var item in perProfileFiles)
                {
                    var forDateFile = item.FileDefinition + checkDateString + ".txt";
                    if (item.OptionalFile == false)
                    {

                        if (ftpFiles.Select(o=>Path.GetFileName(o)).ToList().Contains(forDateFile) == false)
                        {
                            notFoundFiles.Add(forDateFile);
                        }
                        var LogDbFile = db.InsertedLogs.Where(o => o.ProfileName == profile && o.FileName == forDateFile).ToList();
                        if (LogDbFile.Count() != 0)
                        {
                            notFoundFilesInDb.Add(forDateFile);
                        }
                        if (LogDbFile.Count() > 1)
                        {
                            duplicateEntries.Add(forDateFile);
                        }
                    }
                }

             ForDt=   ForDt.AddDays(1);
            }

            string errorLog = "";
            errorLog = "Error check for period " + dtStart.ToShortDateString() + "-" + dtEnd.ToShortDateString() + Environment.NewLine;
            foreach (var item in notFoundFiles)
            {
                errorLog += "Files not Found " + item + Environment.NewLine;
            }
            foreach (var item in notFoundFilesInDb)
            {
                errorLog += "Files not Found in Db " + item + Environment.NewLine;
            }

            foreach (var item in duplicateEntries)
            {
                errorLog += "Files with duplicate entries in Db " + item + Environment.NewLine;
            }

            foreach (var item in notValidFile)
            {
                errorLog += "No valid File for that period/profile " + item + Environment.NewLine;
            }


            var log = new CheckLogDatas
            {
                DateCreated = DateTime.Now,
                ProFileName = profile,
                ErrorLog = errorLog
            };
            db.CheckLogDatas.Add(log);
            db.SaveChanges();
            return errorLog;

        }

        private void SaveEntry(string profile ,string item, bool v,string ftpLogPath)
        {
            //Check if Exists in Db
            var entryInDb = db.InsertedLogs.Where(o => o.ProfileName == profile && o.FileName == item).FirstOrDefault();

            if (entryInDb == null)
            {
                SaveToDbFromFTP(item, profile,ftpLogPath);
            }
            else
            {
                if(v==true)
                {
                    var insertedLogEntries = db.InsertedLogs.Where(o => o.ProfileName == profile && o.FileName == item).ToList();
                    foreach (var itemToDelete in insertedLogEntries)
                    {
                        db.InsertedLogs.Remove(itemToDelete);
                    }
                    var myLogEntries = db.MyDataLogs.Where(o => o.ProfileName == profile && o.FileName == item).ToList();
                    foreach (var itemToDelete in myLogEntries)
                    {
                        db.MyDataLogs.Remove(itemToDelete);
                    }
                    db.SaveChanges();
                    SaveToDbFromFTP(item, profile,ftpLogPath);
                }
            }

                //Get File From FTP
              
            //if ovveride Delete Entries
        }

        private void SaveToDbFromFTP(string item, string profile,string FtpLogPath)
        {
            var profileConfig = Profiles.Where(o => o.ProfileName == profile).FirstOrDefault();
            var ftpClient = new FtpHelper(profileConfig.ftphost, profileConfig.ftpuname, profileConfig.ftppass, profileConfig.ftpPort, FtpLogPath, profileConfig.UseProxy, profileConfig.ProxyURL, Affinity.Helper.Properties.Settings.Default.UsePassive, Affinity.Helper.Properties.Settings.Default.ExternalIP);

            var mem=   ftpClient.DownLoadToStream(item);
            var memStream = new MemoryStream();
            mem.BaseStream.CopyTo(memStream);
            FileHelper _fhelper = new FileHelper(memStream.ToArray());
            var _m = _fhelper.GetFileEntries();

            SaveEntryonDb(_m, profile, item);
        }

        public string CheckDb(DateTime dtStart ,DateTime dtEnd,string profile,string FtpLogPath,Boolean LogOnly,Boolean OvverideDb,string LoadLocation,string SaveLocation)
        {
            //Method Here.

            if (LoadLocation!="")
            {
                //Use Local Files
              return  GetFromFile(dtStart, dtEnd, profile, LoadLocation, LogOnly, OvverideDb);
            }
            else
            {
             return   checkFtp(dtStart, dtEnd, profile, FtpLogPath, LogOnly, OvverideDb, SaveLocation);
            }

        }

        private string GetFromFile(DateTime dtStart, DateTime dtEnd, string profile, string loadLocation, bool logOnly, bool ovverideDb)
        {

            var oFileEntries=   System.IO.Directory.GetFiles(loadLocation, "*");

           

            foreach (var  item in oFileEntries)
            {
                //Record Based on Period Selected.
                if(logOnly==false)
                {
                    SaveEntryFromFile(profile, item, ovverideDb);
                }


            }

            if (logOnly == true)
            {
               return GetLogEntryFromFiles(dtStart, dtEnd, profile, oFileEntries);
            }

            return "Operation Completed";

        }

        private void SaveEntryFromFile(string profile, string item, bool ovverideDb)
        {
            //Check if Value Exist in Database.
            var fileName = Path.GetFileName(item);
          var entryInDb=  db.InsertedLogs.Where(o => o.ProfileName == profile && o.FileName == fileName).FirstOrDefault();

            if(entryInDb==null)
            {
                SaveToDbFromFile(item, profile);
            }
            else
            {
                if(ovverideDb==true)
                {
                    var insertedLogEntries= db.InsertedLogs.Where(o => o.ProfileName == profile && o.FileName == fileName).ToList();
                    foreach (var itemToDelete in insertedLogEntries)
                    {
                        db.InsertedLogs.Remove(itemToDelete);
                    }
                    var myLogEntries = db.MyDataLogs.Where(o => o.ProfileName == profile && o.FileName == fileName).ToList();
                    foreach (var itemToDelete in myLogEntries)
                    {
                        db.MyDataLogs.Remove(itemToDelete);
                    }
                    db.SaveChanges();
                    SaveToDbFromFile(item, profile);
                }
            }
        }


        private void SaveEntryonDb(List<string[]> _m, string prof, string item)
        {
            //one Row Here.
            //Date Created

            //Rows Count Saved.
            //File Name
            //Profile Name

            var profile = db.MySettings.Where(o => o.ProfileName == prof).FirstOrDefault();

            if (item.ToLower().Contains(".txt"))
            {
                DateTime dtDate = DateTime.Now.Date;
                foreach (var im in _m)
                {
                    Model.MyDataLogs _rec = new Model.MyDataLogs
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

                Model.OperationLogs opLog = new Model.OperationLogs
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
            }
        }


        private void SaveToDbFromFile(string item, string profile)
        {
            var mem = System.IO.File.ReadAllBytes(item);
            FileHelper _fhelper = new FileHelper(mem);
            var _m = _fhelper.GetFileEntries();

            SaveEntryonDb(_m, profile, item);
        }
    }
}
