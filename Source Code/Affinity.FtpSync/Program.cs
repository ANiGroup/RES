using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Affinity.Helper.Services;
using Affinity.Data.Model;

namespace ftpSync
{
    class Program
    {
        static void Main(string[] args)
        {
     
            MySync _helper = new MySync();
            if (args.Count()>0)
            {
                //Make the Call manual for the selected date.

                _helper.Sync(args[0]);
            }
            else
            {
                var _md = DateTime.Now;
                string _dStr = _md.AddDays(-1).ToString("yyMMdd");
                _helper.Sync(_dStr);
              
            }

            System.Diagnostics.Process proc = new System.Diagnostics.Process();
            proc.EnableRaisingEvents = false;
            proc.StartInfo.FileName = @"C:\Templates\RunMe.bat";
            proc.Start();


            //Here Update the Table Based On Date.
            affinitydev1Entities spClient = new affinitydev1Entities();
            spClient.Database.CommandTimeout = 36000;
            spClient.myUpdDataSP2016(DateTime.Now.Year);
            spClient.GetKws2016();
            //Calculate Kws 

           
        }
    }
}
