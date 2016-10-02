using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OfficeOpenXml;
namespace Affinity.Helper.Services
{


    public class ManualDataSync
    {

        private string FileName { get; set; }
        private int ImportType { get; set; }
        private double RevAmount { get; set; }
        private ExcelPackage _excelpkg;
        private ExcelWorksheet _ws;
        private Affinity.Helper.Model.DbModel dbClient { get; set; }

        public ManualDataSync(string fileName,int importType,double monthlyRev=0.0)
        {
            FileName = fileName; 
            ImportType = importType;
            RevAmount = monthlyRev;
            dbClient = new Model.DbModel();
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
                resultSet = SyncWeeklyData();
            }
            return resultSet;
        }

        private string SyncWeeklyData()
        {
            throw new NotImplementedException();
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
                            _rev = new Model.PowerRevenueLog
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
                            pdata = new Model.PowerDataLog
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
