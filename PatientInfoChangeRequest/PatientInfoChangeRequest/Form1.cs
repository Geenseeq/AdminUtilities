using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PatientInfoUpdateRequest
{
    public partial class Form1 : Form
    {
        private string emailAddressLabel = "请输入您的世和邮箱";
        private string emailPasswordLabel = "请输入密码";
        public Form1()
        {
            InitializeComponent();
        }

        private void loadSalespersonInfoFileButton_Click(object sender, EventArgs e)
        {
            try
            {
                //ReportFileSelectionTextBox.Text = "";
                OpenFileDialog openReportFileDialog = new OpenFileDialog();
                openReportFileDialog.Filter = "Excel files (*.xlsx)|*.xlsx";
                openReportFileDialog.Multiselect = false;
                openReportFileDialog.Title = "请选择销售信息文件";

                if (openReportFileDialog.ShowDialog() == DialogResult.OK)
                {
                    loadSalespersonInfoFileTextbox.Text = openReportFileDialog.FileName;
                    if (Data.LoadSalespersonEmailList(openReportFileDialog.FileName))
                    {
                        selectSendFilesFolderButton.Visible = true;
                        selectSendFilesFolderTextbox.Visible = true;
                        reportInfoTextBox.Text = string.Format("加载销售信息文件成功。");
                    }
                    else
                    {
                        throw new Exception(Data.userMessages);
                    }

                }
            }
            catch (Exception err)
            {
                reportInfoTextBox.Text = "加载销售信息表没有成功，请重试。\n" + err.Message;
            }
        }

        private void selectSendFilesFolderButton_Click(object sender, EventArgs e)
        {
            try
            {
                emailAddressTextbox.Visible = false;
                emailPasswordTextbox.Visible = false;
                emailDomainTextbox.Visible = false;
                sendEmailsButton.Visible = false;

                //PdfFolderSelectionTextBox.Text = "";
                FolderBrowserDialog folderBrowser = new FolderBrowserDialog();
                folderBrowser.Description = "请选择销售问题文件夹";
                folderBrowser.ShowNewFolderButton = false;
                if (folderBrowser.ShowDialog() == DialogResult.OK)
                {
                    selectSendFilesFolderTextbox.Text = folderBrowser.SelectedPath + "\\";
                    if (Data.SetFilesFolderPath(selectSendFilesFolderTextbox.Text))
                    {
                        emailAddressTextbox.Visible = true;
                        emailDomainTextbox.Visible = true;
                        emailPasswordTextbox.Visible = true;
                        sendEmailsButton.Visible = true;

                        reportInfoTextBox.Text = "选择文件夹成功，可以发送电子邮件。\n";
                    }
                    else
                    {
                        reportInfoTextBox.Text = "选择文件夹没有成功：\n" + Data.userMessages;
                    }
                }
                else
                {
                    reportInfoTextBox.Text = "选择文件夹没有成功，请重试\n";
                }
            }
            catch (Exception err)
            {
                reportInfoTextBox.Text = err.Message;
            }
        }

        private void SendEmailsButton_Click(object sender, EventArgs e)
        {
            try
            {
                if ((string.IsNullOrEmpty(emailAddressTextbox.Text) || string.IsNullOrEmpty(emailPasswordTextbox.Text) ||
                    emailAddressTextbox.Text == emailAddressLabel || emailPasswordTextbox.Text == emailPasswordLabel))
                {
                    reportInfoTextBox.Text = "请输入你的邮箱地址与密码";
                }
                else
                {
                    sendEmailsButton.Visible = false;
                    emailAddressTextbox.Visible = false;
                    emailDomainTextbox.Visible = false;
                    emailPasswordTextbox.Visible = false;
                    reportInfoTextBox.Text = "正在发送邮件，请稍等。";
                    reportInfoTextBox.Text = Data.SendEmails(emailAddressTextbox.Text, emailDomainTextbox.Text, emailPasswordTextbox.Text);
                }
            }
            catch (Exception err)
            {
                reportInfoTextBox.Text = "邮件没有成功发出，请重试。\n" + err.Message;
            }
        }

        private void emailAddressTextbox_GotFocus(object sender, EventArgs e)
        {
            if (emailAddressTextbox.Text == emailAddressLabel)
            {
                emailAddressTextbox.Text = "";
                emailAddressTextbox.ForeColor = Color.Black;
            }
        }

        private void emailAddressTextbox_LostFocus(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(emailAddressTextbox.Text))
            {
                emailAddressTextbox.Text = emailAddressLabel;
                emailAddressTextbox.ForeColor = Color.Gray;
            }
        }

        private void emailPasswordTextbox_GotFocus(object sender, EventArgs e)
        {
            if (emailPasswordTextbox.Text == emailPasswordLabel)
            {
                emailPasswordTextbox.Text = "";
                emailPasswordTextbox.PasswordChar = '*';
                emailPasswordTextbox.ForeColor = Color.Black;
            }
        }

        private void emailPasswordTextbox_LostFocus(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(emailPasswordTextbox.Text))
            {
                emailPasswordTextbox.Text = emailPasswordLabel;
                emailPasswordTextbox.PasswordChar = '\0';
                emailPasswordTextbox.ForeColor = Color.Gray;
            }
        }

    }
}
