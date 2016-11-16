using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesOrderNotifier
{
    class ExcelParser
    {
        public static List<List<string>> GetExcelSheetRows(string fileName, string sheetName)
        {
            List<List<string>> output = new List<List<string>>();

            //have to split file string manually due to excel file format issue in the auto-generated report file
            string fileContents = File.ReadAllText(fileName).Split(new[] { "<Worksheet ss:Name=\"" + sheetName + "\"" }, StringSplitOptions.None)[1];

            foreach (string row in fileContents.Split(new[] { "<Row" }, StringSplitOptions.None))
            {
                if (!row.Contains("<Cell"))
                    continue;

                List<string> rowText = row.Split(new[] { "<Cell" }, StringSplitOptions.None).ToList();
                List<string> currentRow = new List<string>();

                for (int i = 1; i < rowText.Count(); i++)
                {
                    string cellText = "";
                    if (rowText[i].Contains("<Data"))
                        cellText = rowText[i].Split(new[] { "<Data" }, StringSplitOptions.None)[1].Split(new[] { ">" }, StringSplitOptions.None)[1].Split(new[] { "</Data" }, StringSplitOptions.None)[0];
                    currentRow.Add(cellText);
                }

                output.Add(currentRow);
            }

            return output;
        }
    }
}
