using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Excel;
using System.Collections;

namespace PatientReportBasicInfoAutomation
{
    class PatientBasicInfo
    {
        private List<DateTime> sampleReceivingDateList;
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
        private List<string> hospitalSampleIDList;
        private List<string> sampleTypeList;
        private List<DateTime> sampleCollectionDateList;
        private string tumorCellPercentage;
        private string diagnosis;
        private string drugHistory;
        private string familyHistory;
        private DateTime paymentDate;
        private DateTime reportDate;
        private int recordsCount;

        public List<DateTime> SampleReceivingDateList { get { return sampleReceivingDateList; } }
        public List<string> InternalSampleIDList { get { return internalSampleIDList; } }
        public string PatientName { get { return patientName; } }
        public string Gender { get { return gender; } }
        public DateTime Birthdate { get { return birthdate; } }
        public string CitizenshipID { get { return citizenshipID; } }
        public string Phone { get { return phone; } }
        public string ContactName { get { return contactName; } }
        public string Hospital { get { return hospital; } }
        public string DoctorName { get { return doctorName; } }
        public List<string> SampleStructureList { get { return sampleStructureList; } }
        public List<string> HospitalSampleIDList { get { return hospitalSampleIDList; } }
        public List<string> SampleTypeList { get { return sampleTypeList; } }
        public List<DateTime> SampleCollectionDateList { get { return sampleCollectionDateList; } }
        public string TumorCellPercentage { get { return tumorCellPercentage; } }
        public string Diagnosis { get { return diagnosis; } }
        public string DrugHistory { get { return drugHistory; } }
        public string FamilyHistory { get { return familyHistory; } }
        public DateTime PaymentDate { get { return paymentDate; } }
        public DateTime ReportDate { get { return reportDate; } }
        public int RecordsCount { get { return recordsCount; } }


        public PatientBasicInfo(Worksheet sheet)
        {
            Dictionary<string, int> indices = new Dictionary<string, int>();
            Range headerRow = sheet.UsedRange.Rows[1];
            for (int i = 1; i <= headerRow.Columns.Count; i++)
                indices.Add(headerRow.Cells[1, i].Text, i);
            recordsCount = sheet.UsedRange.Rows.Count-1;

            sampleReceivingDateList = getDateListFromColumn(sheet.UsedRange.Columns[indices["收样日期"]]);
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
            hospitalSampleIDList = getStringListFromColumn(sheet.UsedRange.Columns[indices["医院样本号"]],true);
            sampleTypeList = getStringListFromColumn(sheet.UsedRange.Columns[indices["样本类型"]]);
            sampleCollectionDateList = getDateListFromColumn(sheet.UsedRange.Columns[indices["采样日期"]]);
            tumorCellPercentage = getStringListFromColumn(sheet.UsedRange.Columns[indices["肿瘤细胞含量"]])[0];
            diagnosis = getStringListFromColumn(sheet.UsedRange.Columns[indices["临床诊断"]])[0];
            drugHistory = getStringListFromColumn(sheet.UsedRange.Columns[indices["用药史"]])[0];
            familyHistory = getStringListFromColumn(sheet.UsedRange.Columns[indices["家族病史"]])[0];
            paymentDate = getDateListFromColumn(sheet.UsedRange.Columns[indices["收费"]])[0];
            reportDate = DateTime.Now;

        }

        private List<string> getStringListFromColumn(Range column, bool includeNulls = false)
        {
            List<string> output = new List<string>();
            for(int i=2; i<=column.Cells.Count;i++)
            {
                Range cell = column.Cells[i];
                if (includeNulls)
                {
                    output.Add(cell.Text.Trim());
                    continue;
                }
                if (!string.IsNullOrEmpty(cell.Text) && !string.IsNullOrWhiteSpace(cell.Text))
                    output.Add(cell.Text);
            }
            return output;
        }

        private List<DateTime> getDateListFromColumn(Range column)
        {
            List<DateTime> output = new List<DateTime>();
            for (int i = 2; i <= column.Cells.Count; i++)
            {
                Range cell = column.Cells[i];
                if ( !string.IsNullOrEmpty(cell.Text) && !string.IsNullOrWhiteSpace(cell.Text))
                {
                    DateTime currDate;
                    if (DateTime.TryParse(cell.Text, out currDate))
                        output.Add(currDate);
                    //else if (!string.IsNullOrWhiteSpace(cell.Text))
                    //    output.Add(getDateFromString(cell.Text));
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
