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

        private static bool LoadPatientInfoFile(string fileName)
        {
            Microsoft.Office.Interop.Excel.Application excelApp = null;
            Workbook wb = null;
            try
            {
                excelApp = new Microsoft.Office.Interop.Excel.Application();
                excelApp.Visible = false;
                wb = excelApp.Workbooks.Open(fileName, ReadOnly: true);
                patientInfo = new PatientBasicInfo(wb.Sheets[1]);
                return true;
            }
            catch (Exception e)
            {
                userMessages = "加载病人基本信息没有成功：\n" + e.Message;
                return false;
            }
            finally
            {
                if (wb != null)
                    wb.Close();
                if (excelApp != null)
                    excelApp.Quit();
            }
        }


        internal static bool WriteOutputFile(string patientInfoFilePath, string templateFilePath, string outputFolderPath)
        {
            Microsoft.Office.Interop.Word.Application wordApp = null;
            Document doc = null;
            try
            {
                wordApp = new Microsoft.Office.Interop.Word.Application();
                wordApp.Visible = false;
                if (!LoadPatientInfoFile(patientInfoFilePath))
                    throw new Exception(userMessages);

                string outputFileName = outputFolderPath + patientInfo.ReportDate.ToString("yyyyMMdd-") + patientInfo.PatientName + "-未完成报告.doc";
                File.Copy(templateFilePath, outputFileName, true);
                doc = wordApp.Documents.Open(outputFileName);
                foreach (Table t in doc.Tables)
                {
                    if (t.Cell(1, 1).Range.Text.Contains("基本信息"))
                    {
                        for (int i = 1; i <= t.Rows.Count; i++)
                        {
                            for (int j = 1; j <= t.Columns.Count; j++)
                            {
                                try
                                {
                                    if (t.Cell(i, j) == null)
                                        continue;
                                }
                                catch (System.Runtime.InteropServices.COMException)
                                {
                                    continue;
                                }
                                if (t.Cell(i, j).Range.Text.StartsWith("姓名："))
                                    t.Cell(i, j).Range.Text = "姓名：" + patientInfo.PatientName;
                                else if (t.Cell(i, j).Range.Text.StartsWith("出生日期："))
                                    t.Cell(i, j).Range.Text = "出生日期：" + patientInfo.Birthdate.ToString("yyyy年MM月dd日");
                                else if (t.Cell(i, j).Range.Text.StartsWith("性别："))
                                    t.Cell(i, j).Range.Text = "性别：" + patientInfo.Gender;
                                else if (t.Cell(i, j).Range.Text.StartsWith("身份证号码："))
                                    t.Cell(i, j).Range.Text = "身份证号码：" + patientInfo.CitizenshipID;
                                else if (t.Cell(i, j).Range.Text.StartsWith("联系电话："))
                                    t.Cell(i, j).Range.Text = "联系电话：" + patientInfo.Phone;

                                else if (t.Cell(i, j).Range.Text.StartsWith("样本来源："))
                                    t.Cell(i, j).Range.Text = "样本来源：" + patientInfo.Hospital;
                                else if (t.Cell(i, j).Range.Text.StartsWith("主治医生："))
                                    t.Cell(i, j).Range.Text = "主治医生：" + patientInfo.DoctorName;
                                else if (t.Cell(i, j).Range.Text.StartsWith("样本组织："))
                                    t.Cell(i, j).Range.Text = "样本组织：" + ProcessStringsList(patientInfo.SampleStructureList, false);
                                else if (t.Cell(i, j).Range.Text.StartsWith("样本类型："))
                                    t.Cell(i, j).Range.Text = "样本类型：" + ProcessStringsList(patientInfo.SampleTypeList, false);
                                else if (t.Cell(i, j).Range.Text.StartsWith("肿瘤细胞含量："))
                                    t.Cell(i, j).Range.Text = "肿瘤细胞含量：" + patientInfo.TumorCellPercentage;
                                else if (t.Cell(i, j).Range.Text.StartsWith("采样日期："))
                                    t.Cell(i, j).Range.Text = "采样日期：" + ProcessDateList(patientInfo.SampleCollectionDateList, true, 17);
                                else if (t.Cell(i, j).Range.Text.StartsWith("收样日期："))
                                    t.Cell(i, j).Range.Text = "收样日期：" + ProcessDateList(patientInfo.SampleReceivingDateList, true, 17);
                                else if (t.Cell(i, j).Range.Text.StartsWith("收款日期："))
                                    t.Cell(i, j).Range.Text = "收款日期：" + patientInfo.PaymentDate.ToString("yyyy年MM月dd日");
                                else if (t.Cell(i, j).Range.Text.StartsWith("报告日期："))
                                    t.Cell(i, j).Range.Text = "报告日期：" + patientInfo.ReportDate.ToString("yyyy年MM月dd日");
                                else if (t.Cell(i, j).Range.Text.StartsWith("医院样本号："))
                                    t.Cell(i, j).Range.Text = "医院样本号：" + ProcessStringsList(patientInfo.HospitalSampleIDList, true, 20,true);
                                else if (t.Cell(i, j).Range.Text.StartsWith("内部样本号："))
                                    t.Cell(i, j).Range.Text = "内部样本号：" + ProcessStringsList(patientInfo.InternalSampleIDList, true, 20, false);

                                else if (t.Cell(i, j).Range.Text.StartsWith("癌症种类："))
                                    t.Cell(i, j).Range.Text = "癌症种类：" + patientInfo.Diagnosis;
                                else if (t.Cell(i, j).Range.Text.StartsWith("家族病史："))
                                    t.Cell(i, j).Range.Text = "家族病史：" + patientInfo.FamilyHistory;
                                else if (t.Cell(i, j).Range.Text.StartsWith("用药史："))
                                    t.Cell(i, j).Range.Text = "用药史：" + patientInfo.DrugHistory;
                            }
                        }
                        break;
                    }
                }
                return true;

            }
            catch (Exception e)
            {
                userMessages = e.GetType() + ": " + e.Message;
                return false;
            }
            finally
            {
                if (doc != null)
                {
                    doc.Save();
                    doc.Close();
                }
                if (wordApp != null)
                    wordApp.Quit();
            }
        }

        private static string ProcessDateList(List<DateTime> list, bool insertNewLine, int leadingSpaces=0)
        {
            string output = "";
            if (list.Distinct().Count() == 1)
                output = list.Distinct().FirstOrDefault().ToString("yyyy年MM月dd日");
            else
            {
                int i = 0;
                for (i = 0; i < patientInfo.RecordsCount - 1; i++)
                {
                    output += list[i].ToString("yyyy年MM月dd日") + "（" + patientInfo.SampleStructureList[i] + "），";
                    if (insertNewLine)
                        output += "\n" + new string(' ', leadingSpaces);
                }
                output += list[patientInfo.RecordsCount - 1].ToString("yyyy年MM月dd日") + "（" + patientInfo.SampleStructureList[patientInfo.RecordsCount - 1] + "）";
            }
            return output;
        }
        private static string ProcessStringsList(List<string> list, bool insertNewLine, int leadingSpaces=0, bool appendSampleStructures=false)
        {
            string output = "";
            int lineCount = 0;
            for (int i = 0; i < patientInfo.RecordsCount - 1; i++)
            {
                if (string.IsNullOrWhiteSpace(list[i]))
                    continue;
                output += list[i];
                if (appendSampleStructures)
                    output += "（" + patientInfo.SampleStructureList[i] + "）";
                output += "，";
                lineCount++;
                if (insertNewLine)
                    output += "\n" + new string(' ', leadingSpaces);
            }
            output += list[patientInfo.RecordsCount - 1];
            if (appendSampleStructures)
                output += "（" + patientInfo.SampleStructureList[patientInfo.RecordsCount - 1] + "）";
            return output;
        }
    }
}
