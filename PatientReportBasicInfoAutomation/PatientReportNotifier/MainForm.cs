using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PatientReportBasicInfoAutomation
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void PatientInfoFileSelectorButton_Click(object sender, EventArgs e)
        {
            try
            {
                //ReportFileSelectionTextBox.Text = "";
                OpenFileDialog openReportFileDialog = new OpenFileDialog();
                openReportFileDialog.Filter = "Excel files (*.xlsx)|*.xlsx";
                openReportFileDialog.Multiselect = false;
                openReportFileDialog.Title = "请选择病人基本信息文件";

                if (openReportFileDialog.ShowDialog() == DialogResult.OK)
                {
                    SelectPatientInfoFileTextBox.Text = openReportFileDialog.FileName;
                }
            }
            catch (Exception err)
            {
                ReportInfoTextBox.Text = "加载病人基本信息表没有成功，请重试。\n" + err.Message;
            }
        }

        private void SelectTemplateFileButton_Click(object sender, EventArgs e)
        {
            try
            {
                //ReportFileSelectionTextBox.Text = "";
                OpenFileDialog openTemplateFileDialog = new OpenFileDialog();
                openTemplateFileDialog.Filter = "Word files (*.doc)|*.doc";
                openTemplateFileDialog.Multiselect = false;
                openTemplateFileDialog.Title = "请选择报告模板文件";

                if (openTemplateFileDialog.ShowDialog() == DialogResult.OK)
                    SelectTemplateFileTextBox.Text = openTemplateFileDialog.FileName;
                else
                    throw new Exception(Data.userMessages);
            }
            catch (Exception err)
            {
                ReportInfoTextBox.Text = "加载报告模板文件没有成功，请重试。\n" + err.Message;
            }
        }

        private void SelectOutputFolderButton_Click(object sender, EventArgs e)
        {
            try
            {
                FolderBrowserDialog folderBrowser = new FolderBrowserDialog();
                folderBrowser.Description = "请选择报告输出文件夹";
                folderBrowser.ShowNewFolderButton = false;
                if (folderBrowser.ShowDialog() == DialogResult.OK)
                {
                    SelectOutputFolderTextBox.Text = folderBrowser.SelectedPath + "\\";
                }
                else
                {
                    ReportInfoTextBox.Text = "选择报告输出文件夹没有成功，请重试\n";
                }
            }
            catch (Exception err)
            {
                ReportInfoTextBox.Text = err.Message;
            }

        }

        private void WriteReportButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(SelectPatientInfoFileTextBox.Text))
                ReportInfoTextBox.Text = "请选择病人基本信息文件";

            if (string.IsNullOrEmpty(SelectTemplateFileTextBox.Text))
                ReportInfoTextBox.Text = "请选择报告模板文件";

            if (string.IsNullOrEmpty(SelectOutputFolderTextBox.Text))
                ReportInfoTextBox.Text = "请选择报告输出文件夹";

            if (Data.writeOutputFile(SelectPatientInfoFileTextBox.Text, SelectTemplateFileTextBox.Text, SelectOutputFolderTextBox.Text))
            {
                ReportInfoTextBox.Text = "报告输出成功";
            }
            else
            {
                ReportInfoTextBox.Text = "报告输出没有成功，请重试:\n"+Data.userMessages;
            }
        }
    }
}
