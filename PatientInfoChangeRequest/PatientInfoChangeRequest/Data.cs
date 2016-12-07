using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Excel;
using System.Net.Mail;
using System.Net;

namespace PatientInfoUpdateRequest
{
    class Data
    {
        //maps salespersons to their work email addresses
        private static Dictionary<string, string> salespersonEmailDict;
        //stores a list of all valid files found in the selected reports directory
        private static List<string> filesToSend;

        //a string to display information to the user via the main form
        internal static string userMessages;

        internal static bool LoadSalespersonEmailList(string inputFilePath)
        {
            List<worksheet> excelSheets = Workbook.Worksheets(inputFilePath).ToList();
            if (excelSheets.Count < 2)
            {
                userMessages += "Excel 文件格式不对，第一张应是销售人关系，第二张应是邮件地址\n";
                return false;
            }

            worksheet sheet = excelSheets[1];
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

        internal static bool SetFilesFolderPath(string path)
        {
            userMessages = "";
            filesToSend = new List<string>();
            bool success = true;
            try
            {
                List<string> allFiles = Directory.GetFiles(path, "*.*", SearchOption.TopDirectoryOnly).ToList();
                List<string> erroneousFiles = new List<string>();
                foreach (string file in allFiles)
                {
                    List<string> fileNameList = file.Split('.')[0].Split('-').ToList();
                    if (file.EndsWith("doc") || file.EndsWith("docx"))
                    {
                        if (fileNameList.Count() != 4)
                        {
                            erroneousFiles.Add(file);
                            userMessages += file + ":\n文件命名规则为：A-病人姓名-订单号-销售姓名.doc\n";
                            continue;
                        }
                        if (!salespersonEmailDict.ContainsKey(fileNameList[3]))
                        {
                            erroneousFiles.Add(file);
                            userMessages += file + ":\n没有找到姓名为" + fileNameList[3] + "的销售\n";
                            continue;
                        }
                        filesToSend.Add(file);
                    }
                    else
                    {
                        userMessages += file + ":\n文件不是WORD文件\n";
                        erroneousFiles.Add(file);
                    }
                }


                userMessages += "成功加载以下"+filesToSend.Count+"个文件：\n";
                foreach (string file in filesToSend)
                    userMessages += "\t" + file + "\n";

                if (erroneousFiles.Count == 0)
                    return success;
                else
                {
                    //userMessages += "\n以下" + erroneousFiles.Count + "个文件有问题：\n";
                    //foreach (string file in erroneousFiles)
                    //    userMessages += "\t" + file + "\n";
                    throw new Exception();
                }
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
        /// <param name="sendEmail">Operator can select whether to actually send the emails or not.</param>
        internal static string SendEmails(string useremail, string domain, string password)
        {
            userMessages = "";
            int sentMailCount = 0;

            string mailserver = "smtp.exmail.qq.com";
            SmtpClient client = new SmtpClient(mailserver);
            client.Credentials = new NetworkCredential(useremail + domain, password);

            //foreach (ReportInfoRecord reportRecord in reportInfoRecordList)
            foreach (string file in filesToSend)
            {
                string patientName = file.Split('-')[1];
                string orderNumber = file.Split('-')[2];
                string salesperson = file.Split('-')[3].Split('.')[0];
                string htmlContent = GetHtml(patientName, orderNumber, salesperson);

                try
                {
                    MailMessage mail = new MailMessage(useremail + domain, salespersonEmailDict[salesperson]);
                    mail.From = new MailAddress(useremail + domain);
                    mail.Sender = new MailAddress(useremail + domain);
                    mail.Body = htmlContent;
                    mail.IsBodyHtml = true;
                    mail.Subject = "订单 " + orderNumber + " 需要你的回复";
                    mail.Attachments.Add(new Attachment(file));
                    client.Send(mail);
                    sentMailCount++;
                }
                catch (Exception e)
                {
                    userMessages += "发送文件" + file + "没有成功:\n" + e.Message + "\n";
                }
            }

            if (userMessages == "")
                userMessages = "所有邮件成功发出。\n";
            userMessages += "一共发送了" + sentMailCount + "条邮件。\n";
            return userMessages;
        }
       
        private static string GetHtml(string patientName, string orderNumber, string salesperson)
        {
            try
            {
                string lineBegin = "<p>";
                string lineEnd = "</p>";

                string messageBody = "<meta http-equiv=\"Content-Type\" content=\"text/html; charset=UTF-8\"> <font>有关您的订单信息需要回复: </font><br><br>";

                messageBody += lineBegin + "检测人姓名：" + patientName + lineEnd;
                messageBody += lineBegin + "订单号：" + orderNumber + lineEnd;
                messageBody += lineBegin + "请查看附件，然后尽快回复。" + lineEnd;

                Console.WriteLine(messageBody);
                return messageBody;
            }
            catch (Exception)
            {
                return null;
            }
        }

    }
}
