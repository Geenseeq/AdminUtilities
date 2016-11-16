using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SalesOrderNotifier
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

        private void button1_Click(object sender, EventArgs e)
        {
            OrderInfoTextBox.Text = "";
            SendEmailsButton.Visible = false;
            OpenFileDialog openOrderFileDialog = new OpenFileDialog();
            openOrderFileDialog.Filter = "Excel files (*.xls)|*.xls";
            openOrderFileDialog.Multiselect = false;
            openOrderFileDialog.Title = "请选择订单文件";

            if (openOrderFileDialog.ShowDialog() == DialogResult.OK)
            {
                OrderFileSelectionTextBox.Text = openOrderFileDialog.FileName;
                try
                {
                    int loadedOrders = 0;
                    if ((loadedOrders = Data.loadSalesPersonOrderList(openOrderFileDialog.FileName)) > 0)
                    {
                        emailAddressTextbox.Visible = true;
                        emailDomainTextbox.Visible = true;
                        emailPasswordTextbox.Visible = true;
                        SendEmailsButton.Visible = true;
                        emailCheckbox.Visible = true;
                        OrderInfoTextBox.Text = string.Format("加载订单文件成功，一共有{0}条订单，有关{1}位销售员。", loadedOrders, Data.salespersonOrderListDict.Keys.Count);
                    }
                    else
                    {
                        throw new Exception();
                    }

                }
                catch (Exception err)
                {
                    OrderInfoTextBox.Text = "加载订单文件没有成功，请重试。\n"+err.Message;
                }

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
                    OrderInfoTextBox.Text = "请输入你的邮箱地址与密码";
                }
                else
                {
                    OrderInfoTextBox.Text = Data.sendEmails(emailAddressTextbox.Text, emailDomainTextbox.Text, emailPasswordTextbox.Text, !emailCheckbox.Checked);
                    SendEmailsButton.Visible = false;
                    emailAddressTextbox.Visible = false;
                    emailDomainTextbox.Visible = false;
                    emailPasswordTextbox.Visible = false;
                    emailCheckbox.Visible = false;
                }
            }
            catch (Exception err)
            {
                OrderInfoTextBox.Text = "邮件没有成功发出，请重试。\n" + err.Message;
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

        private void emailPasswordTextbox_Click(object sender, EventArgs e)
        {
            emailPasswordTextbox_GotFocus(sender, e);
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
