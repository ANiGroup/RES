using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OfficeOpenXml;
using Affinity.Data.Model;

namespace Affinity.Helper.Services
{


    public class ManualDataSync
    {

        private string FileName { get; set; }
        private int ImportType { get; set; }
        private double RevAmount { get; set; }
        private ExcelPackage _excelpkg;
        private ExcelWorksheet _ws;
        private Affinity.Data.Model.DbModel dbClient { get; set; }

        public ManualDataSync(string fileName,int importType,double monthlyRev=0.0)
        {
            FileName = fileName; 
            ImportType = importType;
            RevAmount = monthlyRev;
            dbClient = new DbModel();
        }

        public string SyncData(DateTime dtStart,string profileName="")
        {
            string resultSet = "Wrong Variables";
            if (ImportType==1)
            {
                resultSet = SyncPowerData(dtStart,profileName);
            }
            if(ImportType==2)
            {
                resultSet = SyncWeeklyData(dtStart);
            }
            if(ImportType==3)
            {
                resultSet = SyncMSData(profileName);
            }
            return resultSet;
        }

        private string SyncMSData(string profileName)
        {
            string resultSet = "";
            try
            {
                _excelpkg = new ExcelPackage(new System.IO.FileInfo(FileName));
                _ws = _excelpkg.Workbook.Worksheets[profileName];
                var excelRows = _ws.Dimension.End.Row;
                int rowIndex = 2; //Skip header.
                for (int i = 1; i < _ws.Dimension.End.Row; i++)
                {
                    if(profileName=="DM21")
                    {
                        var entry = new DM21MSData();
                        entry.MSDate =Convert.ToDateTime( _ws.GetValue(rowIndex, 1));
                        entry.POD21_MS =Convert.ToString( _ws.GetValue(rowIndex, 2));
                        entry.POD22_MS = Convert.ToString(_ws.GetValue(rowIndex, 3));
                        entry.POD23_MS = Convert.ToString(_ws.GetValue(rowIndex, 4));
                        entry.POD24_MS = Convert.ToString(_ws.GetValue(rowIndex, 5));
                        dbClient.DM21MSData.Add(entry);
                    }
                    if(profileName=="DM43")
                    {
                        var entry = new DM43MSData();
                        entry.MSDate = Convert.ToDateTime(_ws.GetValue(rowIndex, 1));
                        entry.POD34_MS = Convert.ToString(_ws.GetValue(rowIndex, 2));
                        entry.POD35_MS = Convert.ToString(_ws.GetValue(rowIndex, 3));
                        entry.POD41_MS = Convert.ToString(_ws.GetValue(rowIndex, 4));
                        entry.POD42_MS = Convert.ToString(_ws.GetValue(rowIndex, 5));
                        entry.POD43_MS = Convert.ToString(_ws.GetValue(rowIndex, 6));
                        entry.POD44_MS = Convert.ToString(_ws.GetValue(rowIndex, 7));
                        dbClient.DM43MSData.Add(entry);
                    }
                    if(profileName!="DM21" && profileName!="DM43")
                    {
                        resultSet = "Invalid Variable.";
                    }

                    rowIndex = rowIndex + 1;
                }
                dbClient.SaveChanges();

                if(profileName=="DM21")
                {
                    dbClient.Database.ExecuteSqlCommand("Exec [dbo].[GetMSValuesDM21]");
                }
                if (profileName == "DM43")
                {
                    dbClient.Database.ExecuteSqlCommand("Exec [dbo].[GetMSValuesDM43]");
                }
                resultSet = "Data saved successfully.";
            }
            catch (Exception ex)
            {
                resultSet = ex.Message.ToString();
            }
            return resultSet;
        }

        private string SyncWeeklyData(DateTime dtStart)
        {
            string resultSet = "";
            try
            {
                _excelpkg = new ExcelPackage(new System.IO.FileInfo(FileName));
                _ws = _excelpkg.Workbook.Worksheets["Digester Sites"];
                int rowIndex = 0;
                var farmDefinitions = dbClient.FarmDefinitions.ToList();
                rowIndex = 3; //Start of First Farm.
                foreach (var item in farmDefinitions.OrderBy(o=>o.OrderNo))
                {
                    for (int i = 0; i < item.BarnNo; i++)
                    {
                        //Here Add Data.
                        Affinity.Data.Model.FarmDefinitionsWLog entry = new FarmDefinitionsWLog
                        {
                             FarmName=item.FarmName,
                             Barn=i+1,
                             ProfileName=item.ProfileName,
                             DateConcern=dtStart
                             
                        };
                        entry.PlacedInBarn =Convert.ToInt32(_ws.GetValue(rowIndex, 3));
                        entry.PoundsPlaced =Convert.ToDouble( _ws.GetValue(rowIndex, 4));
                        entry.TotalMortlity = Convert.ToInt32(_ws.GetValue(rowIndex, 5));
                        entry.HeadSold = Convert.ToInt32(_ws.GetValue(rowIndex, 6));
                        entry.HeadRemaining =Convert.ToInt32(_ws.GetValue(rowIndex, 7));
                        entry.PlacedOrProjectedDate = Convert.ToDateTime(_ws.GetValue(rowIndex, 8));
                        var dtDiff = Microsoft.VisualBasic.DateAndTime.DateDiff(Microsoft.VisualBasic.DateInterval.Day, dtStart, entry.PlacedOrProjectedDate);                      
                        if(dtDiff>(7*25) || dtDiff<0)
                        {
                            entry.PigAge = 0;
                        }
                        else
                        {
                            entry.PigAge =float.Parse((Convert.ToDouble( dtDiff )/ Convert.ToDouble(7)).ToString());
                        }
                        dbClient.FarmDefinitionsWLogs.Add(entry);
                        rowIndex = rowIndex + 1;
                    }
                    rowIndex = rowIndex + 1;
                }
                dbClient.SaveChanges();

                dbClient.Database.ExecuteSqlCommand("Exec [dbo].[GetFarmValuesDM21] {0}", dtStart);
                dbClient.Database.ExecuteSqlCommand("Exec [dbo].[GetFarmValuesDM43] {0}", dtStart);
                resultSet = "Data inserted successfully.";

            }
            catch (Exception ex)
            {
                resultSet = ex.Message.ToString();
                
            }
            return resultSet;

        }

        private string SyncPowerData(DateTime dt,string profileName)
        {
            string resultSet = "";
            try
            {
                _excelpkg = new ExcelPackage(new System.IO.FileInfo(FileName));
                _ws = _excelpkg.Workbook.Worksheets["Hourly"]; //Bind to First Sheet.
                var excelRows = _ws.Dimension.End.Row;
                int rowIndex = 0;
                var sumOfPower = "0.0";
               
                for (int i = 0; i < _ws.Dimension.End.Row; i++)
                {
                    if(i==2)
                    {
                        sumOfPower = _ws.GetValue(i, 5).ToString();
                        var _rev = dbClient.PowerRevenueLogs.Where(o => o.LogDate == dt && o.ProfileName == profileName).FirstOrDefault();
                        if(_rev==null)
                        {
                            _rev = new PowerRevenueLog
                            {
                                LogDate = dt,
                                ProfileName = profileName,
                                RevenueAmtData = RevAmount
                            };
                            dbClient.PowerRevenueLogs.Add(_rev);
                            dbClient.SaveChanges();
                        }
                       



                    }
                    if(i>3)
                    {
                        var _power = _ws.GetValue(i, 3).ToString();
                        var dtDate =_ws.GetValue(i, 1).ToString();
                        var timeIndex = _ws.GetValue(i, 2).ToString();
                        if(timeIndex.Length==3)
                        {
                            timeIndex = timeIndex.Substring(0, 1);
                        }
                        else
                        {
                            timeIndex = timeIndex.Substring(0, 2);
                        }

                        if(timeIndex=="24")
                        {
                            timeIndex = "0";
                        }

                        var hourIndex = Convert.ToInt32(timeIndex);
                        var dtDateInt = Convert.ToInt32(dtDate);
                        var InsertionDate = new DateTime(dt.Year, dt.Month, dtDateInt, hourIndex, 0, 0);
                        var pdata = dbClient.PowerDataLogs.Where(o => o.LogDate == InsertionDate && o.ProfileName == profileName && o.SumLogDate == InsertionDate.Date).FirstOrDefault();
                        if (pdata == null)
                        {
                            pdata = new PowerDataLog
                            {
                                LogDate = InsertionDate,
                                SumLogDate = InsertionDate.Date,
                                ProfileName = profileName,
                                PowerData = Convert.ToInt32(_power)
                            };
                            dbClient.PowerDataLogs.Add(pdata);
                            dbClient.SaveChanges();
                        }

                       


                    }
                    rowIndex = rowIndex + 1;
                }
                if(profileName=="DM21")
                {
                    dbClient.Database.ExecuteSqlCommand("Exec [dbo].[procUpdatePowerDataDM21] {0}", dt);
                }
                else
                {
                    dbClient.Database.ExecuteSqlCommand("Exec [dbo].[procUpdatePowerDataDM43] {0}", dt);
                }
                

                resultSet = "Data Inserted Successfully.";
            }
            catch (Exception ex)
            {
                resultSet = ex.Message.ToString();
               
            }
            
           

            return resultSet;
        }
    }
}
