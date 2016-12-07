using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PatientReportNotifier
{
    public partial class MainForm : Form
    {
        private string emailAddressLabel = "请输入您的世和邮箱";
        private string emailPasswordLabel = "请输入密码";
        //private string emailDomainLabel = "@geneseeq.com";
        public MainForm()
        {
            InitializeComponent();
        }

        private void ReportFileSelectorButton_Click(object sender, EventArgs e)
        {
            try
            {
                //ReportFileSelectionTextBox.Text = "";
                OpenFileDialog openReportFileDialog = new OpenFileDialog();
                openReportFileDialog.Filter = "Excel files (*.xlsx)|*.xlsx";
                openReportFileDialog.Multiselect = false;
                openReportFileDialog.Title = "请选择报告信息文件";

                if (openReportFileDialog.ShowDialog() == DialogResult.OK)
                {
                    ReportFileSelectionTextBox.Text = openReportFileDialog.FileName;
                    if (Data.loadReportInfoFile(openReportFileDialog.FileName))
                    {
                        SelectSalespersonInfoFileButton.Visible = true;
                        SelectSalespersonInfoFileTextBox.Visible = true;
                        ReportInfoTextBox.Text = string.Format("加载报告信息文件成功。");
                    }
                    else
                    {
                        throw new Exception(Data.userMessages);
                    }

                }
            }
            catch (Exception err)
            {
                ReportInfoTextBox.Text = "加载报告信息表没有成功，请重试。\n" + err.Message;
            }
        }

        private void PdfFolderSelectorButton_Click(object sender, EventArgs e)
        {
            try
            {
                emailAddressTextbox.Visible = false;
                emailPasswordTextbox.Visible = false;
                emailDomainTextbox.Visible = false;
                SendEmailsButton.Visible = false;
                emailCheckbox.Visible = false;

                //PdfFolderSelectionTextBox.Text = "";
                FolderBrowserDialog folderBrowser = new FolderBrowserDialog();
                folderBrowser.Description = "请选择报告PDF的文件夹";
                folderBrowser.ShowNewFolderButton = false;
                if (folderBrowser.ShowDialog() == DialogResult.OK)
                {
                    PdfFolderSelectionTextBox.Text = folderBrowser.SelectedPath+"\\";
                    if (Data.setReportFolderPath(PdfFolderSelectionTextBox.Text))
                    {
                        emailAddressTextbox.Visible = true;
                        emailDomainTextbox.Visible = true;
                        emailPasswordTextbox.Visible = true;
                        SendEmailsButton.Visible = true;
                        emailCheckbox.Visible = true;

                        ReportInfoTextBox.Text = "选择PDF文件夹成功，可以发送电子邮件。\n";
                    }
                    else
                    {
                        ReportInfoTextBox.Text = "选择PDF文件夹没有成功，以下的文件没有找到：\n"+Data.userMessages;
                    }
                }
                else
                {
                    ReportInfoTextBox.Text = "选择PDF文件夹没有成功，请重试\n";
                }
            }
            catch(Exception err)
            {
                ReportInfoTextBox.Text = err.Message;
            }

        }

        private void SendEmailsButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (!emailCheckbox.Checked &&
                    (string.IsNullOrEmpty(emailAddressTextbox.Text) || string.IsNullOrEmpty(emailPasswordTextbox.Text) ||
                    emailAddressTextbox.Text == emailAddressLabel || emailPasswordTextbox.Text == emailPasswordLabel))
                {
                    ReportInfoTextBox.Text = "请输入你的邮箱地址与密码";
                }
                else
                {
                    SendEmailsButton.Visible = false;
                    emailAddressTextbox.Visible = false;
                    emailDomainTextbox.Visible = false;
                    emailPasswordTextbox.Visible = false;
                    emailCheckbox.Visible = false;
                    ReportInfoTextBox.Text = "正在发送邮件，请稍等。";
                    ReportInfoTextBox.Text = Data.SendEmails(emailAddressTextbox.Text, emailDomainTextbox.Text, emailPasswordTextbox.Text, PdfFolderSelectionTextBox.Text, !emailCheckbox.Checked);
                }
            }
            catch (Exception err)
            {
                ReportInfoTextBox.Text = "邮件没有成功发出，请重试。\n" + err.Message;
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

        private void SelectCommentsFileButton_Click(object sender, EventArgs e)
        {
            try
            {
                //SelectCommentsFileTextBox.Text = "";
                OpenFileDialog openCommentFileDialog = new OpenFileDialog();
                openCommentFileDialog.Filter = "Text files (*.txt)|*.txt";
                openCommentFileDialog.Multiselect = false;
                openCommentFileDialog.Title = "请选择注释信息文件";

                if (openCommentFileDialog.ShowDialog() == DialogResult.OK)
                {
                    SelectCommentsFileTextBox.Text = openCommentFileDialog.FileName;
                    if (Data.loadCommentsInfoFile(openCommentFileDialog.FileName))
                    {
                        ReportFileSelectorButton.Visible = true;
                        ReportFileSelectionTextBox.Visible = true;
                        ReportInfoTextBox.Text = string.Format("加载注释告信息文件成功。");
                    }
                    else
                    {
                        throw new Exception(Data.userMessages);
                    }

                }
            }
            catch (Exception err)
            {
                ReportInfoTextBox.Text = "加载注释信息表没有成功，请重试。\n" + err.Message;
            }
        }

        private void SelectSampleInfoFileButton_Click(object sender, EventArgs e)
        {
            try
            {
                //SelectSampleInfoFileTextBox.Text = "";
                OpenFileDialog openSampleFileDialog = new OpenFileDialog();
                openSampleFileDialog.Filter = "Excel files (*.xlsx)|*.xlsx";
                openSampleFileDialog.Multiselect = false;
                openSampleFileDialog.Title = "请选择样本接收信息文件";

                if (openSampleFileDialog.ShowDialog() == DialogResult.OK)
                {
                    SelectSampleInfoFileTextBox.Text = openSampleFileDialog.FileName;
                    if (Data.loadSampleInfoFile(openSampleFileDialog.FileName))
                    {
                        SelectCommentsFileButton.Visible = true;
                        SelectCommentsFileTextBox.Visible = true;
                        ReportInfoTextBox.Text = string.Format("加载样本接收信息文件成功。");
                    }
                    else
                    {
                        throw new Exception(Data.userMessages);
                    }

                }
            }
            catch (Exception err)
            {
                ReportInfoTextBox.Text = "加载样本接收信息表没有成功，请重试。\n" + err.Message;
            }
        }

        private void SelectSalespersonInfoFileButton_Click(object sender, EventArgs e)
        {
            try
            {
                //SelectSalespersonInfoFileTextBox.Text = "";
                OpenFileDialog openSalespersonInfoFileDialog = new OpenFileDialog();
                openSalespersonInfoFileDialog.Filter = "Excel files (*.xlsx)|*.xlsx";
                openSalespersonInfoFileDialog.Multiselect = false;
                openSalespersonInfoFileDialog.Title = "请选择销售人事信息文件";

                if (openSalespersonInfoFileDialog.ShowDialog() == DialogResult.OK)
                {
                    SelectSalespersonInfoFileTextBox.Text = openSalespersonInfoFileDialog.FileName;
                    if (Data.loadSalespersonInfoFile(openSalespersonInfoFileDialog.FileName))
                    {
                        PdfFolderSelectorButton.Visible = true;
                        PdfFolderSelectionTextBox.Visible = true;
                        ReportInfoTextBox.Text = string.Format("加载销售人事信息文件成功。");
                    }
                    else
                    {
                        throw new Exception(Data.userMessages);
                    }

                }
            }
            catch (Exception err)
            {
                ReportInfoTextBox.Text = "加载销售人事信息文件没有成功，请重试。\n" + err.Message;
            }

        }
    }
}
