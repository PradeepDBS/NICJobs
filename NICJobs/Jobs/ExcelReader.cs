using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NICJobs.DAL;

namespace NICJobs.Jobs
{
    public class cExcelReader
    {
        string logFile = ConfigurationManager.AppSettings["LogFile"];
        string sourcepath = ConfigurationManager.AppSettings["SourcePath"];
        string destinationpath = ConfigurationManager.AppSettings["DestinationPath"];
        DataImport objdataImport = new DataImport();
        int totaldatacount = 0;

        public void ReadExcelData()
        {
            DirectoryInfo dir = new DirectoryInfo(sourcepath);
            foreach (FileInfo file in dir.GetFiles())
            {
                if (file.Name.Contains(".ini"))
                {
                    continue;
                }
                string name = file.Name;
                var filepath = Path.Combine(sourcepath, name);
                //var bitmap = new Bitmap(file.FullName);
                //Save(bitmap, 100, filepath);
                readXLS(filepath);
            }
            Console.WriteLine("Total data imported :{0} " , totaldatacount);
            Console.ReadKey();

        }
        public void readXLS(string FilePath)
        {
            FileInfo existingFile = new FileInfo(FilePath);
            using (ExcelPackage package = new ExcelPackage(existingFile))
            {
                //get the first worksheet in the workbook
                ExcelWorksheet worksheet = package.Workbook.Worksheets[0];
                int colCount = worksheet.Dimension.End.Column;  //get Column Count
                int rowCount = worksheet.Dimension.End.Row;     //get row count

                for (int row = 2; row <= rowCount; row++)
                {
                    string Unique_BenID = worksheet.Cells[row,1].Text.Replace("&nbsp;", string.Empty).Replace("&#160;", string.Empty).Trim();
                    string StateName = worksheet.Cells[row, 2].Text.Replace("&nbsp;", string.Empty).Replace("&#160;", string.Empty).Trim();
                    string StateCode = worksheet.Cells[row, 3].Text.Replace("&nbsp;", string.Empty).Replace("&#160;", string.Empty).Trim();
                    string DistrictName = worksheet.Cells[row, 4].Text.Replace("&nbsp;", string.Empty).Replace("&#160;", string.Empty).Trim();
                    string DistrictCode = worksheet.Cells[row, 5].Text.Replace("&nbsp;", string.Empty).Replace("&#160;", string.Empty).Trim();
                    string SubDistrictName = worksheet.Cells[row, 6].Text.Replace("&nbsp;", string.Empty).Replace("&#160;", string.Empty).Trim();
                    string SubDistrictCode = worksheet.Cells[row, 7].Text.Replace("&nbsp;", string.Empty).Replace("&#160;", string.Empty).Trim();
                    string VillageName = worksheet.Cells[row, 8].Text.Replace("&nbsp;", string.Empty).Replace("&#160;", string.Empty).Trim();
                    string VillageCode = worksheet.Cells[row, 9].Text.Replace("&nbsp;", string.Empty).Replace("&#160;", string.Empty).Trim();
                    string Farmer_Name = worksheet.Cells[row, 10].Text.Replace("&nbsp;", string.Empty).Replace("&#160;", string.Empty).Trim();
                    string Father_Name = worksheet.Cells[row, 11].Text.Replace("&nbsp;", string.Empty).Replace("&#160;", string.Empty).Trim();

                    int intreturn = objdataImport.ImportDatatoDatabase( Unique_BenID, StateName,StateCode, DistrictName, DistrictCode,
                                        SubDistrictName, SubDistrictCode,VillageName,VillageCode, Farmer_Name,Father_Name);

                    totaldatacount = totaldatacount + intreturn;
                }
                
            }
        }
    }
}
