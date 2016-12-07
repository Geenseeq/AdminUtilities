using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Excel;
using System.Net.Mail;
using System.Net;

namespace PatientReportNotifier
{
    class Data
    {
        //a list of sample info records, contains patient name, checkup type, and salesperson name
        private static List<SampleInfoRecord> sampleInfoRecordList;
        //stores the list of reports from the input file
        private static List<ReportInfoRecord> reportInfoRecordList;
        //maps each patient name to their treatment comments
        private static Dictionary<string, string> patientCommentsDict;
        //stores the list of salespeople and their superiors from the input file
        private static List<SalespersonHierarchyRecord> salespersonHierarchyList;
        //maps salespersons to their work email addresses
        private static Dictionary<string, string> salespersonEmailDict;
        //stores a list of full paths to attachment PDF files corresponding to each record in reportInfoRecordList
        private static List<string> reportRecordPdfPathList;
        //stores a list of all the files found in the selected reports directory
        private static List<string> allFilesInDir;

        //a string to display information to the user via the main form
        internal static string userMessages;

        internal static bool loadSalespersonInfoFile(string inputFilePath)
        {
            List<worksheet> excelSheets = Workbook.Worksheets(inputFilePath).ToList();
            if (excelSheets.Count < 2)
            {
                userMessages += "Excel 文件格式不对，第二张应是销售人关系，第三张应是邮件地址\n";
                return false;
            }
            if (loadSalesPersonHierarchyList(excelSheets[0]) && loadSalespersonEmailList(excelSheets[1]))
                return true;
            else
                return false;
        }

        internal static bool loadReportInfoFile(string inputFilePath)
        {
            reportInfoRecordList = new List<ReportInfoRecord>();
            try
            {
                List<Row> rows = Workbook.Worksheets(inputFilePath).First().Rows.Skip(1).Where(x => (x.Cells[4] != null && !string.IsNullOrEmpty(x.Cells[4].Text))).ToList();
                List<string> patients = new List<string>();
                foreach (Row r in rows)
                    patients.Add(r.Cells[4].Text.Trim());

                foreach (string p in patients.Distinct())
                {
                    List<SampleInfoRecord> foundSampleRecs = sampleInfoRecordList.Where(x => x.PatientName == p).ToList();
                    if (foundSampleRecs.Count == 0)
                        throw new Exception("样本信息表里没有找到" + p);
                    if (!patientCommentsDict.ContainsKey(p))
                        throw new Exception("注释信息文件里没有找到" + p);

                    SampleInfoRecord sampleRec = foundSampleRecs.Last();
                    string dateString;
                    if (DateTime.Now.Hour <= 7)
                        dateString = DateTime.Today.AddDays(-1).ToString("yyyyMMdd");
                    else
                        dateString = DateTime.Today.ToString("yyyyMMdd");
                    reportInfoRecordList.Add(new ReportInfoRecord(p, dateString, sampleRec.ReportTypes, patientCommentsDict[p], sampleRec.SalespersonName));
                }
                return true;
            }
            catch (Exception e)
            {
                userMessages += "加载报告信息没有成功: " + e.Message + "\n";
                return false;
            }
        }

        private static bool loadSalesPersonHierarchyList(worksheet sheet)
        {
            salespersonHierarchyList = new List<SalespersonHierarchyRecord>();
            try
            {
                //skip rows that are completely empty
                foreach (Row row in sheet.Rows.Skip(1)
                    .Where(x => (!(x.Cells[0] == null && x.Cells[1] == null && x.Cells[2] == null && x.Cells[3] == null && x.Cells[4] == null &&
                string.IsNullOrEmpty(x.Cells[0].Text) && string.IsNullOrEmpty(x.Cells[1].Text) && string.IsNullOrEmpty(x.Cells[2].Text) && 
                string.IsNullOrEmpty(x.Cells[3].Text) && string.IsNullOrEmpty(x.Cells[4].Text)))))
                {
                    salespersonHierarchyList.Add(new SalespersonHierarchyRecord(row.Cells[0], row.Cells[1], row.Cells[2], row.Cells[3], row.Cells[4]));
                }
                return true;
            }
            catch (Exception e)
            {
                userMessages += "加载发送关系没有成功: " + e.Message + "\n";
                return false;
            }
        }

        private static bool loadSalespersonEmailList(worksheet sheet)
        {
            salespersonEmailDict = new Dictionary<string, string>();
            try
            {
                foreach (Row row in sheet.Rows.Skip(1).Where(x => (x.Cells[0] != null && x.Cells[1] != null && x.Cells[0].Text != "" && x.Cells[1].Text != "")))
                {
                    if (salespersonEmailDict.ContainsKey(row.Cells[0].Text))
                        userMessages += String.Format("{0}的邮箱有重复，{1}没有加载\n", row.Cells[0].Text, row.Cells[1].Text);
                    else
                        salespersonEmailDict.Add(row.Cells[0].Text, row.Cells[1].Text);
                    userMessages += "邮箱信息加载完毕\n";
                }
                return true;
            }
            catch (Exception e)
            {
                userMessages += "加载邮件地址没有成功: " + e.Message + "\n";
                return false;
            }
        }

        internal static bool setReportFolderPath(string path)
        {
            userMessages = "";
            bool success = true;
            try
            {
                reportRecordPdfPathList = new List<string>();
                allFilesInDir = Directory.GetFiles(path, "*.*", SearchOption.TopDirectoryOnly).ToList();
                foreach (ReportInfoRecord rec in reportInfoRecordList)
                {
                    //files should be at something like basepath/02月25日/20160225-宝宝*.pdf/.xlsx
                    //there may be extra chars between patient name and .pdf/.xlsx
                    string[] filesFound = Directory.GetFiles(path, rec.ReportDate + "-" + rec.PatientName + "*.*", SearchOption.TopDirectoryOnly);
                    if (filesFound.Length > 0)
                    {
                        reportRecordPdfPathList.Add(filesFound[0]);
                    }
                    else
                    {
                        userMessages += path + rec.ReportDate + "-" + rec.PatientName + "*.*\n";
                        success = false;
                    }
                }
                return success;
            }
            catch (Exception e)
            {
                userMessages += "设定报告文件夹没有成功：" + e.Message + "\n";
                return false;
            }
        }

        /// <summary>
        /// Send all emails to relevant salesReps and medReps for each report. Report PDFs are attached separately in each email.
        /// </summary>
        /// <param name="useremail">Email account (without domain name) of the person operating the program.</param>
        /// <param name="domain">Domain name (@geneseeq.com) of the email address of the sender.</param>
        /// <param name="password">Operating user's email password.</param>
        /// <param name="reportFolderPath">The main folder containing all the report directories, selected by the operator.</param>
        /// <param name="sendEmail">Operator can select whether to actually send the emails or not.</param>
        internal static string SendEmails(string useremail, string domain, string password, string reportFolderPath, bool sendEmail)
        {
            userMessages = "";
            int sentMailCount = 0;

            string mailserver = "smtp.exmail.qq.com";
            SmtpClient client = new SmtpClient(mailserver);
            client.Credentials = new NetworkCredential(useremail + domain, password);

            //foreach (ReportInfoRecord reportRecord in reportInfoRecordList)
            for (int i = 0; i < reportInfoRecordList.Count(); i++)
            {
                ReportInfoRecord reportRecord = reportInfoRecordList[i];
                string htmlContent = GetHtmlFromReportRecord(reportRecord);
                string salesperson = reportRecord.SalespersonName;
                List<string> ccList = GetSalespersonEmailCCList(salesperson);

                //if (ccList.Count == 0)
                //    userMessages += "没有找到有关病人 "+reportRecord.PatientName+" 的销售人员\n";

                if (sendEmail)
                {
                    try
                    {
                        if (!salespersonEmailDict.ContainsKey(salesperson))
                        {
                            throw new Exception("处理（" + reportRecord.PatientName + "）的报告时，没有找到销售人(" + salesperson + ")的邮箱\n");
                        }
                        MailMessage mail = new MailMessage(useremail + domain, salespersonEmailDict[salesperson]);
                        mail.From = new MailAddress(useremail + domain);
                        mail.Sender = new MailAddress(useremail + domain);
                        mail.Body = htmlContent;
                        mail.IsBodyHtml = true;
                        foreach (string superiorEmailAddr in ccList)
                            mail.CC.Add(new MailAddress(superiorEmailAddr));
                        mail.Subject = "报告 - " + reportRecord.ReportDate + " - " + reportRecord.PatientName;
                        mail.Attachments.Add(new Attachment(reportRecordPdfPathList[i]));
                        client.Send(mail);
                        sentMailCount++;
                        allFilesInDir.Remove(reportRecordPdfPathList[i]);
                    }
                    catch (Exception e)
                    {
                        userMessages += "发送文件" + reportRecordPdfPathList[i] + "没有成功: " + e.Message + "\n";
                    }
                }
                else
                {
                    userMessages += "模拟发送邮件给：" + salespersonEmailDict[salesperson] + "\n拷贝给：";
                    foreach (string addr in ccList)
                        userMessages += "\n\t" + addr;
                    userMessages += "\n附件为：" + reportRecordPdfPathList[i] + "\n\n";
                    sentMailCount++;
                    allFilesInDir.Remove(reportRecordPdfPathList[i]);
                }
            }

            if (sendEmail && userMessages == "")
                userMessages = "所有邮件成功发出。\n";
            userMessages += "一共发送了" + sentMailCount + "条邮件。\n";
            if (allFilesInDir.Count > 0)
            {
                userMessages += "有一部分报告文件没有发出：\n";
                foreach (string file in allFilesInDir)
                    userMessages += file + "\n";
            }
            return userMessages;
        }

        //read comments file into a dictionary that maps patient names to their comments;
        //input file contains blocks of comments that have the patient name as the first
        //portion of the first line, followed by one or more lines of comments;
        //file may contain empty lines between each block, but should not have gaps
        //between each line of comments.
        internal static bool loadCommentsInfoFile(string fileName)
        {
            patientCommentsDict = new Dictionary<string, string>();
            try
            {
                StreamReader reader = new StreamReader(fileName, Encoding.UTF8);
                string line;
                string currPatient = "";
                bool insideCommentBlock = false;
                while ((line = reader.ReadLine()) != null)
                {
                    if (!insideCommentBlock)
                    {
                        if (string.IsNullOrEmpty(line.Trim()))
                            continue;
                        else
                        {
                            insideCommentBlock = true;
                            currPatient = line.Split('-')[0].Trim();
                            currPatient = currPatient.Split(':')[0].Trim();
                            currPatient = currPatient.Split('：')[0].Trim();
                            if (!patientCommentsDict.ContainsKey(currPatient))
                                patientCommentsDict.Add(currPatient, "");
                        }
                    }
                    else
                    {
                        if (string.IsNullOrEmpty(line.Trim()))
                            insideCommentBlock = false;
                        else
                        {
                            patientCommentsDict[currPatient] += line.Trim() + "\n";
                        }
                    }
                }
                reader.Close();
                return true;
            }
            catch (Exception e)
            {
                userMessages = "加载注释信息没有成功：" + e.Message;
                return false;
            }
        }

        internal static bool loadSampleInfoFile(string fileName)
        {
            sampleInfoRecordList = new List<SampleInfoRecord>();

            try
            {
                worksheet sheet = Workbook.Worksheets(fileName).First();
                //sheet = ProcessWorksheet(sheet);
                if (sheet.Rows.First().Cells[0].Text != "各地样本接收信息表")
                    throw new Exception("Excel表第一页应该是‘各地样本接收信息表’");
                Console.WriteLine("num rows = " + sheet.Rows.Count());
                var rows = sheet.Rows.Skip(2).Where(x => (x.Cells[3] != null && x.Cells[3].Text.Length > 0)).ToList();
                foreach (Row r in rows)
                {
                    string patientName = GetStringFromCell(r.Cells[3]);
                    string reportTypes = GetStringFromCell(r.Cells[9]);
                    string salespersonName = GetStringFromCell(r.Cells[22]);

                    sampleInfoRecordList.Add(new SampleInfoRecord(patientName, reportTypes, salespersonName));
                }
                return true;
            }
            catch (Exception e)
            {
                userMessages = "加载样本接收信息表没成功：" + e.Message;
                return false;
            }

        }

        private static string GetStringFromCell(Cell cell)
        {
            if (cell != null && !string.IsNullOrEmpty(cell.Text))
                return cell.Text.Trim();
            else
                return "";
        }

        private static string GetHtmlFromReportRecord(ReportInfoRecord reportRecord)
        {
            try
            {
                string lineBegin = "<p>";
                string lineEnd = "</p>";

                string messageBody = "<meta http-equiv=\"Content-Type\" content=\"text/html; charset=UTF-8\"> <font>有关您的报告信息: </font><br><br>";

                messageBody += lineBegin + "检测人姓名：" + reportRecord.PatientName + lineEnd;
                messageBody += lineBegin + "报告日期：" + reportRecord.ReportDate + lineEnd;
                messageBody += lineBegin + "检测项目：" + reportRecord.ReportTypes + lineEnd;
                messageBody += lineBegin + "报告注释：" + reportRecord.ReportComments + lineEnd;
                messageBody += lineBegin + "销售员：" + reportRecord.SalespersonName + lineEnd;

                return messageBody;
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// Given the primary salesperson's name, get a string with all of the emails of the salesperson and his/her superiors, and the medRep; emails are separated by semicolons.
        /// </summary>
        /// <param name="reportSalesperson">Name of primary salesperson on the report.</param>
        private static List<string> GetSalespersonEmailCCList(string reportSalesperson)
        {
            List<SalespersonHierarchyRecord> salesHierarchyList = salespersonHierarchyList.Where(x => x.Salesperson.Equals(reportSalesperson)).ToList();
            if (salesHierarchyList.Count() == 0)
            {
                if ((salesHierarchyList = salespersonHierarchyList.Where(x => x.SalesAssistant.Equals(reportSalesperson)).ToList()).Count() == 0)
                {
                    if ((salesHierarchyList = salespersonHierarchyList.Where(x => x.AreaManager.Equals(reportSalesperson)).ToList()).Count() == 0)
                    {
                        if ((salesHierarchyList = salespersonHierarchyList.Where(x => x.RegionManager.Equals(reportSalesperson)).ToList()).Count() == 0)
                        {
                            //can't find a sales rep in the list
                            return new List<string>();
                        }
                    }
                }
            }

            List<string> superiorsList = salesHierarchyList.FirstOrDefault().GetSalespersonSuperiorsNamesList(reportSalesperson);
            List<string> emailsList = new List<string>();

            foreach (string superior in superiorsList)
            {
                if (salespersonEmailDict.ContainsKey(superior))
                    emailsList.Add(salespersonEmailDict[superior]);
                else
                    userMessages += "没有找到" + superior + "的邮箱\n";
            }
            return emailsList;
        }
    }
}
