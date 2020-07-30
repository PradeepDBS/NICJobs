using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NICJobs.Jobs;

namespace NICJobs
{
    class Program
    {
        static void Main(string[] args)
        {
            cExcelReader cExcelReader = new cExcelReader();
            cExcelReader.ReadExcelData();
        }
    }
}
