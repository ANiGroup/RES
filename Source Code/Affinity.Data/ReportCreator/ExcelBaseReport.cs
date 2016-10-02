using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OfficeOpenXml;
using System.IO;
namespace Affinity.Helper.ReportCreator
{
    public class ExcelBaseReport
    {
        public ExcelBaseReport(string _fileName)
        {
            if (!File.Exists(_fileName))
            {
                _excelpkg = new ExcelPackage(new System.IO.FileInfo(_fileName));
                //If not exist create an excel sheet.
                _ws = _excelpkg.Workbook.Worksheets.Add("Default");
               
            }
            else
            {
                _excelpkg = new ExcelPackage(new System.IO.FileInfo(_fileName));
                _ws = _excelpkg.Workbook.Worksheets[0]; //Bind to First Sheet.
            }
        

        }


        public void Save()
        {
            _excelpkg.Save();
        }


        public ExcelWorksheet SetHeaders(string[] headers)
        {
            var _row = 1;
            var _col = 1;
            foreach (string item in headers)
            {
                _ws.Cells[_row+1, _col].Value = item;
                _col = _col + 1;
            }
            return _ws;
        }

        public ExcelPackage _excelpkg;
        public ExcelWorksheet _ws;

    }
}
