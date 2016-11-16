using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Mail;
using System.Net;
using Microsoft.Office.Interop.Excel;
using Microsoft.Office.Interop.Word;

namespace PatientReportBasicInfoAutomation
{
    class Data
    {
        //class to store patient data
        private static PatientBasicInfo patientInfo;
        //a string to display information to the user via the main form
        internal static string userMessages;

        private static bool loadPatientInfoFile(string fileName)
        {
            Microsoft.Office.Interop.Excel.Application excelApp = new Microsoft.Office.Interop.Excel.Application();
            try
            {
                Workbook wb = excelApp.Workbooks.Open(fileName);
                patientInfo = new PatientBasicInfo(wb.Sheets[1]);
                return true;
            }
            catch (Exception e)
            {
                excelApp.Workbooks.Close();
                userMessages = "加载病人基本信息没有成功：\n" + e.Message;
                return false;
            }
        }


        internal static bool writeOutputFile(string patientInfoFilePath, string templateFilePath, string outputFolderPath)
        {
            try
            {
                if (loadPatientInfoFile(patientInfoFilePath))
                {
                    return true;
                }
                else
                {
                    throw new Exception(userMessages);
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
