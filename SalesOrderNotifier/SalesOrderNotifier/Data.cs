using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excel;
using System.Net.Mail;
using System.Net;

namespace SalesOrderNotifier
{
    class Data
    {
        //A list of indices for all orders in the selected input file
        //private List<SalesOrder> salesOrderList;
        //maps salespersons to their immediate supervisor
        public static Dictionary<string, string> salespersonSupervisorDict;
        //maps salespersons to their work email addresses
        public static Dictionary<string, string> salespersonEmailDict;
        //maps salespersons to a list of order numbers
        public static Dictionary<string, List<SalesOrderV2>> salespersonOrderListDict;

        //a string to display information to the user via the main form
        public static string userMessages;

        public static bool loadSalespersonEmailList()
        {
            salespersonEmailDict = new Dictionary<string, string>();
            try
            {
                using (var reader = new StreamReader(File.OpenRead("salesperson_email_list.csv")))
                {
                    while (!reader.EndOfStream)
                    {
                        string[] line = reader.ReadLine().Split(',');
                        if (salespersonEmailDict.ContainsKey(line[0]))
                            userMessages += String.Format("{0}的邮箱有重复，{1}没有加载\n", line[0], line[1]);
                        else
                            salespersonEmailDict.Add(line[0], line[1]);
                    }
                    userMessages += "邮箱信息加载完毕";
                    return true;
                }
            }
            catch (Exception e)
            {
                userMessages += "Error in loadSalespersonEmailList(): " + e.Message + "\n";
                return false;
            }
        }

        public static bool loadSalespersonSupervisorList()
        {
            salespersonSupervisorDict = new Dictionary<string, string>();
            try
            {
                using (var reader = new StreamReader(File.OpenRead("salesperson_supervisor_list.csv")))
                {
                    while (!reader.EndOfStream)
                    {
                        string[] line = reader.ReadLine().Split(',');
                        if (salespersonSupervisorDict.ContainsKey(line[0]))
                            userMessages += String.Format("{0}的上级人员有重复，{1}没有加载\n", line[0], line[1]);
                        else
                            salespersonSupervisorDict.Add(line[0], line[1]);
                    }
                    userMessages += "上级人员信息加载完毕\n";
                    return true;
                }
            }
            catch (Exception e)
            {
                userMessages += "Error in loadSalespersonSupervisorList(): " + e.Message + "\n";
                return false;
            }


        }

        public static int loadSalesPersonOrderList(string orderFilePath)
        {

            salespersonOrderListDict = new Dictionary<string, List<SalesOrderV2>>();
            List<List<string>> orderSheet = ExcelParser.GetExcelSheetRows(orderFilePath, SalesOrderV2.excelSheetName);
            Dictionary<string, int> headerIndexDict = new Dictionary<string, int>();
            int rowCount = -1;
            foreach (List<string> row in orderSheet)
            {
                if (row.Count() < 3)
                    continue;

                //read headers
                if (rowCount < 0)
                {
                    int columnCount = 0;
                    foreach (string c in row)
                    {
                        headerIndexDict.Add(c, columnCount);
                        columnCount++;
                    }
                    rowCount++;
                    continue;
                }

                //process each record
                SalesOrderV2 currentOrder = new SalesOrderV2(row[headerIndexDict[SalesOrderV2.OrderNumberHeader]], row[headerIndexDict[SalesOrderV2.PatientNameHeader]], row[headerIndexDict[SalesOrderV2.CancerTypeHeader]],
                    row[headerIndexDict[SalesOrderV2.CheckupTypeHeader]], row[headerIndexDict[SalesOrderV2.OrderDateHeader]].Split('T')[0], row[headerIndexDict[SalesOrderV2.CurrentStateHeader]], row[headerIndexDict[SalesOrderV2.ReportDateHeader]].Split('T')[0],
                    row[headerIndexDict[SalesOrderV2.HospitalHeader]], row[headerIndexDict[SalesOrderV2.DepartmentHeader]], row[headerIndexDict[SalesOrderV2.DoctorNameHeader]], row[headerIndexDict[SalesOrderV2.SalespersonHeader]],
                    row[headerIndexDict[SalesOrderV2.PaymentStatusHeader]], row[headerIndexDict[SalesOrderV2.CityHeader]], row[headerIndexDict[SalesOrderV2.ProvinceHeader]]);

                if (row[headerIndexDict[SalesOrderV2.SalespersonHeader]] == "")
                    continue;
                else
                {
                    addOrderToSalespersonOrderList(currentOrder, currentOrder.Salesperson);
                    rowCount++;
                }
            }

            return rowCount;
        }

        private static void addOrderToSalespersonOrderList(SalesOrderV2 currentOrder, string salesperson)
        {
            if (!salespersonOrderListDict.ContainsKey(salesperson))
                salespersonOrderListDict.Add(salesperson, new List<SalesOrderV2>());

            salespersonOrderListDict[salesperson].Add(currentOrder);
            if (salespersonSupervisorDict.ContainsKey(salesperson) && salespersonSupervisorDict[salesperson] != "")
                addOrderToSalespersonOrderList(currentOrder, salespersonSupervisorDict[salesperson]);
        }

        private static string GetHtmlFromOrdersList(string salesperson, List<SalesOrderV2> orders)
        {
            try
            {
                string messageBody = "<meta http-equiv=\"Content-Type\" content=\"text/html; charset=UTF-8\"> <font>有关您的订单信息: </font><br><br>";

                if (orders.Count == 0)
                    return messageBody;
                string htmlTableStart = "<table style=\"border-collapse:collapse; text-align:center;\" >";
                string htmlTableEnd = "</table>";
                string htmlHeaderRowStart = "<tr style =\"background-color:#6FA1D2; color:#ffffff;\">";
                string htmlHeaderRowEnd = "</tr>";
                string htmlTrStart = "<tr style =\"color:#555555;\">";
                string htmlTrEnd = "</tr>";
                string htmlTdStart = "<td style=\" border-color:#5c87b2; border-style:solid; border-width:thin; padding: 5px;\">";
                string htmlTdStartNoWrap = "<td style=\" border-color:#5c87b2; border-style:solid; border-width:thin; padding: 5px; white-space:nowrap;\">";
                string htmlTdEnd = "</td>";

                messageBody += htmlTableStart;
                messageBody += htmlHeaderRowStart;
                foreach (string header in orders.FirstOrDefault().GetHeaderArray())
                    messageBody += htmlTdStartNoWrap + header + htmlTdEnd;
                messageBody += htmlHeaderRowEnd;

                foreach (SalesOrderV2 order in orders.OrderBy(x => x.Salesperson).ThenBy(x => x.OrderDate))
                {
                    messageBody += htmlTrStart;
                    foreach (string cell in order.ToArray())
                    {
                        //if (cell.Length <=10)
                        //messageBody += htmlTdStartNoWrap + cell + htmlTdEnd;
                        //else
                        messageBody += htmlTdStart + cell + htmlTdEnd;
                    }
                    messageBody += htmlTrEnd;
                }
                messageBody = messageBody + htmlTableEnd;


                return messageBody;
            }
            catch (Exception)
            {
                return null;
            }
        }

        internal static string sendEmails(string useremail, string domain, string password, bool sendEmail)
        {
            string dir = "./订单邮件记录 - " + DateTime.Now.ToString("yyyy年M月d日H点m分") + "/";
            Directory.CreateDirectory(dir);
            DirectoryInfo df = new DirectoryInfo(dir);

            string response = "";

            string mailserver = "smtp.exmail.qq.com";
            SmtpClient client = new SmtpClient(mailserver);
            client.Credentials = new NetworkCredential(useremail + domain, password);

            foreach (string salesperson in salespersonOrderListDict.Keys)
            {
                string htmlContent = GetHtmlFromOrdersList(salesperson, salespersonOrderListDict[salesperson]);
                try
                {
                    StreamWriter sw = new StreamWriter(dir + salesperson + ".html");
                    sw.Write(htmlContent);
                    sw.Close();
                }
                catch (Exception e)
                {
                    response += salesperson + "的邮件记录保存没有成功: " + e.Message + "\n";
                }

                if (sendEmail && salespersonEmailDict.ContainsKey(salesperson))
                {
                    if (string.IsNullOrEmpty(salespersonEmailDict[salesperson]))
                    {
                        response += "没有" + salesperson + "的邮箱信息";
                        continue;
                    }

                    try
                    {
                        MailMessage mail = new MailMessage(useremail + domain, salespersonEmailDict[salesperson]);
                        mail.Body = htmlContent;
                        mail.IsBodyHtml = true;
                        mail.Subject = "订单信息 - " + DateTime.Today.ToString("yyyy年M月d日");
                        client.Send(mail);
                    }
                    catch (Exception e)
                    {
                        response += "发邮件送给" + salesperson + "没有成功: " + e.Message + "\n";
                    }
                }
            }

            if (sendEmail && response == "")
                response = "所有邮件成功发出。";
            response += "记录保存在：" + df.FullName + "\n";
            return response;
        }

        
    }
}
