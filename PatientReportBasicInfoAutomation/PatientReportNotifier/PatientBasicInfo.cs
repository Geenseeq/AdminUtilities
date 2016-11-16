using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Excel;

namespace PatientReportBasicInfoAutomation
{
    class PatientBasicInfo
    {
        private List<DateTime> sampleReceivingDates;
        private List<string> internalSampleIDList;
        private string patientName;
        private string gender;
        private DateTime birthdate;
        private string citizenshipID;
        private string phone;
        private string contactName;
        private string hospital;
        private string doctorName;
        private List<string> sampleStructureList;
        private List<string> sampleTypeList;
        private List<DateTime> sampleCollectionDateList;
        private string tumorCellPercentage;
        private string diagnosis;
        private string drugHistory;
        private string familyHistory;
        private DateTime paymentDate;
        private DateTime reportDate;

        public PatientBasicInfo(Worksheet sheet)
        {
            Dictionary<string, int> indices = new Dictionary<string, int>();
            Range headerRow = sheet.UsedRange.Rows[1];
            for (int i = 1; i <= headerRow.Columns.Count; i++)
                indices.Add(headerRow.Cells[1, i].Value, i);

            sampleReceivingDates = getDateListFromColumn(sheet.UsedRange.Columns[indices["收样日期"]]);
            internalSampleIDList = getStringListFromColumn(sheet.UsedRange.Columns[indices["样本编号"]]);
            patientName = getStringListFromColumn(sheet.UsedRange.Columns[indices["病人姓名"]])[0];
            gender = getStringListFromColumn(sheet.UsedRange.Columns[indices["性别"]])[0];
            birthdate = getDateListFromColumn(sheet.UsedRange.Columns[indices["出生日期"]])[0];
            citizenshipID = getStringListFromColumn(sheet.UsedRange.Columns[indices["身份证"]])[0];
            phone = getStringListFromColumn(sheet.UsedRange.Columns[indices["联系方式"]])[0];
            contactName = getStringListFromColumn(sheet.UsedRange.Columns[indices["联系人"]])[0];
            hospital = getStringListFromColumn(sheet.UsedRange.Columns[indices["送检医院"]])[0];
            doctorName = getStringListFromColumn(sheet.UsedRange.Columns[indices["送检医生"]])[0];
            if (!doctorName.Contains("医生"))
                doctorName += "医生";
            sampleStructureList = getStringListFromColumn(sheet.UsedRange.Columns[indices["样本组织"]]);
            sampleTypeList = getStringListFromColumn(sheet.UsedRange.Columns[indices["样本类型"]]);
            sampleCollectionDateList = getDateListFromColumn(sheet.UsedRange.Columns[indices["采样日期"]]);
            tumorCellPercentage = getStringListFromColumn(sheet.UsedRange.Columns[indices["肿瘤细胞含量"]])[0];
            diagnosis = getStringListFromColumn(sheet.UsedRange.Columns[indices["临床诊断"]])[0];
            drugHistory = getStringListFromColumn(sheet.UsedRange.Columns[indices["用药史"]])[0];
            familyHistory = getStringListFromColumn(sheet.UsedRange.Columns[indices["家族病史"]])[0];
            paymentDate = getDateListFromColumn(sheet.UsedRange.Columns[indices["收费"]])[0];
            reportDate = DateTime.Now;

        }

        private List<string> getStringListFromColumn(Range column)
        {
            List<string> output = new List<string>();
            for(int i=2; i<=column.Cells.Count;i++)
            {
                Range cell = column.Cells[i];
                if (!string.IsNullOrEmpty(cell.Value) && !string.IsNullOrWhiteSpace(cell.Value))
                    output.Add(cell.Value);
            }
            return output;
        }

        private List<DateTime> getDateListFromColumn(Range column)
        {
            List<DateTime> output = new List<DateTime>();
            for (int i = 2; i <= column.Cells.Count; i++)
            {
                Range cell = column.Cells[i];
                if (cell.Value!=null)
                {
                    DateTime currDate;
                    double currDateDouble;
                    //if (double.TryParse(cell.Value, out currDateDouble))
                        //output.Add(DateTime.FromOADate(currDateDouble));
                    if (DateTime.TryParse(cell.Value.ToString(), out currDate))
                        output.Add(currDate);
                    else if (!string.IsNullOrWhiteSpace(cell.Value))
                        output.Add(getDateFromString(cell.Value));
                }
            }
            return output;
        }

        private DateTime getDateFromString(string dateString)
        {
            string year;
            string month;
            string day;
            //DateTime outputDate;
            //if (DateTime.TryParse(dateString, out outputDate))
            //    return outputDate;

            if (dateString.Contains('/'))
            {
                year = dateString.Split('/')[0];
                month = dateString.Split('/')[1];
                day = dateString.Split('/')[2];
            }
            else if (dateString.Contains('年'))
            {
                year = dateString.Split('年')[0];
                month = dateString.Split('年')[1].Split('月')[0];
                day = dateString.Split('年')[1].Split('月')[1].Split('日')[0];
            }
            else if (dateString.Contains('.'))
            {
                year = dateString.Split('.')[0];
                month = dateString.Split('.')[1];
                day = dateString.Split('.')[2];
            }
            else if (dateString.Contains('-'))
            {
                year = dateString.Split('-')[0];
                month = dateString.Split('-')[1];
                day = dateString.Split('-')[2];
            }
            else
            {
                year = dateString.Substring(0, 4);
                month = dateString.Substring(5, 2);
                day = dateString.Substring(8, 2);
            }

            return new DateTime(Int32.Parse(year), Int32.Parse(month), Int32.Parse(day));
        }
    }
}
