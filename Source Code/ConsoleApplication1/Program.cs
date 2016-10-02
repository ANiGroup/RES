using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new Affinity.Helper.Services.ManualDataSync(@"C:\ResCode\PowerData\HourlyData.xlsx", 1, 12333.00);
            var dt = new DateTime(2016, 4, 30);
            client.SyncData(dt, "DM43");
        }
    }
}
