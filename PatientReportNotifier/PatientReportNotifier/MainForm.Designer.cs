namespace PatientReportNotifier
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ReportInfoTextBox = new System.Windows.Forms.RichTextBox();
            this.SendEmailsButton = new System.Windows.Forms.Button();
            this.emailAddressTextbox = new System.Windows.Forms.TextBox();
            this.emailPasswordTextbox = new System.Windows.Forms.TextBox();
            this.emailDomainTextbox = new System.Windows.Forms.TextBox();
            this.emailCheckbox = new System.Windows.Forms.CheckBox();
            this.PdfFolderSelectorButton = new System.Windows.Forms.Button();
            this.PdfFolderSelectionTextBox = new System.Windows.Forms.TextBox();
            this.SelectSampleInfoFileTextBox = new System.Windows.Forms.TextBox();
            this.SelectSampleInfoFileButton = new System.Windows.Forms.Button();
            this.SelectCommentsFileTextBox = new System.Windows.Forms.TextBox();
            this.SelectCommentsFileButton = new System.Windows.Forms.Button();
            this.SelectSalespersonInfoFileTextBox = new System.Windows.Forms.TextBox();
            this.SelectSalespersonInfoFileButton = new System.Windows.Forms.Button();
            this.ReportFileSelectionTextBox = new System.Windows.Forms.TextBox();
            this.ReportFileSelectorButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ReportInfoTextBox
            // 
            this.ReportInfoTextBox.BackColor = System.Drawing.Color.White;
            this.ReportInfoTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ReportInfoTextBox.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ReportInfoTextBox.Location = new System.Drawing.Point(13, 277);
            this.ReportInfoTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.ReportInfoTextBox.Name = "ReportInfoTextBox";
            this.ReportInfoTextBox.ReadOnly = true;
            this.ReportInfoTextBox.Size = new System.Drawing.Size(1172, 268);
            this.ReportInfoTextBox.TabIndex = 2;
            this.ReportInfoTextBox.Text = "";
            // 
            // SendEmailsButton
            // 
            this.SendEmailsButton.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.SendEmailsButton.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.SendEmailsButton.Location = new System.Drawing.Point(13, 602);
            this.SendEmailsButton.Margin = new System.Windows.Forms.Padding(4);
            this.SendEmailsButton.Name = "SendEmailsButton";
            this.SendEmailsButton.Size = new System.Drawing.Size(284, 38);
            this.SendEmailsButton.TabIndex = 4;
            this.SendEmailsButton.Text = "发送销售报告文件";
            this.SendEmailsButton.UseVisualStyleBackColor = false;
            this.SendEmailsButton.Visible = false;
            this.SendEmailsButton.Click += new System.EventHandler(this.SendEmailsButton_Click);
            // 
            // emailAddressTextbox
            // 
            this.emailAddressTextbox.ForeColor = System.Drawing.Color.Gray;
            this.emailAddressTextbox.Location = new System.Drawing.Point(13, 552);
            this.emailAddressTextbox.Name = "emailAddressTextbox";
            this.emailAddressTextbox.Size = new System.Drawing.Size(284, 43);
            this.emailAddressTextbox.TabIndex = 5;
            this.emailAddressTextbox.Text = "请输入您的世和邮箱";
            this.emailAddressTextbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.emailAddressTextbox.Visible = false;
            this.emailAddressTextbox.GotFocus += new System.EventHandler(this.emailAddressTextbox_GotFocus);
            this.emailAddressTextbox.LostFocus += new System.EventHandler(this.emailAddressTextbox_LostFocus);
            // 
            // emailPasswordTextbox
            // 
            this.emailPasswordTextbox.ForeColor = System.Drawing.Color.Gray;
            this.emailPasswordTextbox.Location = new System.Drawing.Point(550, 552);
            this.emailPasswordTextbox.Name = "emailPasswordTextbox";
            this.emailPasswordTextbox.Size = new System.Drawing.Size(518, 43);
            this.emailPasswordTextbox.TabIndex = 6;
            this.emailPasswordTextbox.Text = "请输入密码";
            this.emailPasswordTextbox.Visible = false;
            this.emailPasswordTextbox.Click += new System.EventHandler(this.emailPasswordTextbox_Click);
            this.emailPasswordTextbox.GotFocus += new System.EventHandler(this.emailPasswordTextbox_GotFocus);
            this.emailPasswordTextbox.LostFocus += new System.EventHandler(this.emailPasswordTextbox_LostFocus);
            // 
            // emailDomainTextbox
            // 
            this.emailDomainTextbox.BackColor = System.Drawing.Color.White;
            this.emailDomainTextbox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.emailDomainTextbox.Location = new System.Drawing.Point(305, 555);
            this.emailDomainTextbox.Name = "emailDomainTextbox";
            this.emailDomainTextbox.ReadOnly = true;
            this.emailDomainTextbox.Size = new System.Drawing.Size(239, 36);
            this.emailDomainTextbox.TabIndex = 7;
            this.emailDomainTextbox.Text = "@geneseeq.com";
            this.emailDomainTextbox.Visible = false;
            // 
            // emailCheckbox
            // 
            this.emailCheckbox.AutoSize = true;
            this.emailCheckbox.Checked = true;
            this.emailCheckbox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.emailCheckbox.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.emailCheckbox.Location = new System.Drawing.Point(305, 605);
            this.emailCheckbox.Name = "emailCheckbox";
            this.emailCheckbox.Size = new System.Drawing.Size(262, 35);
            this.emailCheckbox.TabIndex = 8;
            this.emailCheckbox.Text = "只保存邮件，不发出";
            this.emailCheckbox.UseVisualStyleBackColor = true;
            this.emailCheckbox.Visible = false;
            // 
            // PdfFolderSelectorButton
            // 
            this.PdfFolderSelectorButton.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.PdfFolderSelectorButton.CausesValidation = false;
            this.PdfFolderSelectorButton.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.PdfFolderSelectorButton.Location = new System.Drawing.Point(13, 197);
            this.PdfFolderSelectorButton.Margin = new System.Windows.Forms.Padding(4);
            this.PdfFolderSelectorButton.Name = "PdfFolderSelectorButton";
            this.PdfFolderSelectorButton.Size = new System.Drawing.Size(284, 38);
            this.PdfFolderSelectorButton.TabIndex = 9;
            this.PdfFolderSelectorButton.Text = "选择报告PDF文件夹";
            this.PdfFolderSelectorButton.UseVisualStyleBackColor = false;
            this.PdfFolderSelectorButton.Visible = false;
            this.PdfFolderSelectorButton.Click += new System.EventHandler(this.PdfFolderSelectorButton_Click);
            // 
            // PdfFolderSelectionTextBox
            // 
            this.PdfFolderSelectionTextBox.BackColor = System.Drawing.Color.White;
            this.PdfFolderSelectionTextBox.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.PdfFolderSelectionTextBox.Location = new System.Drawing.Point(305, 197);
            this.PdfFolderSelectionTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.PdfFolderSelectionTextBox.Name = "PdfFolderSelectionTextBox";
            this.PdfFolderSelectionTextBox.ReadOnly = true;
            this.PdfFolderSelectionTextBox.Size = new System.Drawing.Size(880, 38);
            this.PdfFolderSelectionTextBox.TabIndex = 10;
            this.PdfFolderSelectionTextBox.Text = "未选择文件";
            this.PdfFolderSelectionTextBox.Visible = false;
            // 
            // SelectSampleInfoFileTextBox
            // 
            this.SelectSampleInfoFileTextBox.BackColor = System.Drawing.Color.White;
            this.SelectSampleInfoFileTextBox.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.SelectSampleInfoFileTextBox.Location = new System.Drawing.Point(305, 14);
            this.SelectSampleInfoFileTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.SelectSampleInfoFileTextBox.Name = "SelectSampleInfoFileTextBox";
            this.SelectSampleInfoFileTextBox.ReadOnly = true;
            this.SelectSampleInfoFileTextBox.Size = new System.Drawing.Size(880, 38);
            this.SelectSampleInfoFileTextBox.TabIndex = 12;
            this.SelectSampleInfoFileTextBox.Text = "未选择文件";
            // 
            // SelectSampleInfoFileButton
            // 
            this.SelectSampleInfoFileButton.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.SelectSampleInfoFileButton.CausesValidation = false;
            this.SelectSampleInfoFileButton.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.SelectSampleInfoFileButton.Location = new System.Drawing.Point(13, 13);
            this.SelectSampleInfoFileButton.Margin = new System.Windows.Forms.Padding(4);
            this.SelectSampleInfoFileButton.Name = "SelectSampleInfoFileButton";
            this.SelectSampleInfoFileButton.Size = new System.Drawing.Size(284, 38);
            this.SelectSampleInfoFileButton.TabIndex = 11;
            this.SelectSampleInfoFileButton.Text = "选择样本接收信息表";
            this.SelectSampleInfoFileButton.UseVisualStyleBackColor = false;
            this.SelectSampleInfoFileButton.Click += new System.EventHandler(this.SelectSampleInfoFileButton_Click);
            // 
            // SelectCommentsFileTextBox
            // 
            this.SelectCommentsFileTextBox.BackColor = System.Drawing.Color.White;
            this.SelectCommentsFileTextBox.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.SelectCommentsFileTextBox.Location = new System.Drawing.Point(305, 59);
            this.SelectCommentsFileTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.SelectCommentsFileTextBox.Name = "SelectCommentsFileTextBox";
            this.SelectCommentsFileTextBox.ReadOnly = true;
            this.SelectCommentsFileTextBox.Size = new System.Drawing.Size(880, 38);
            this.SelectCommentsFileTextBox.TabIndex = 14;
            this.SelectCommentsFileTextBox.Text = "未选择文件";
            this.SelectCommentsFileTextBox.Visible = false;
            // 
            // SelectCommentsFileButton
            // 
            this.SelectCommentsFileButton.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.SelectCommentsFileButton.CausesValidation = false;
            this.SelectCommentsFileButton.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.SelectCommentsFileButton.Location = new System.Drawing.Point(13, 59);
            this.SelectCommentsFileButton.Margin = new System.Windows.Forms.Padding(4);
            this.SelectCommentsFileButton.Name = "SelectCommentsFileButton";
            this.SelectCommentsFileButton.Size = new System.Drawing.Size(284, 38);
            this.SelectCommentsFileButton.TabIndex = 13;
            this.SelectCommentsFileButton.Text = "选择注释信息文件";
            this.SelectCommentsFileButton.UseVisualStyleBackColor = false;
            this.SelectCommentsFileButton.Visible = false;
            this.SelectCommentsFileButton.Click += new System.EventHandler(this.SelectCommentsFileButton_Click);
            // 
            // SelectSalespersonInfoFileTextBox
            // 
            this.SelectSalespersonInfoFileTextBox.BackColor = System.Drawing.Color.White;
            this.SelectSalespersonInfoFileTextBox.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.SelectSalespersonInfoFileTextBox.Location = new System.Drawing.Point(305, 152);
            this.SelectSalespersonInfoFileTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.SelectSalespersonInfoFileTextBox.Name = "SelectSalespersonInfoFileTextBox";
            this.SelectSalespersonInfoFileTextBox.ReadOnly = true;
            this.SelectSalespersonInfoFileTextBox.Size = new System.Drawing.Size(880, 38);
            this.SelectSalespersonInfoFileTextBox.TabIndex = 16;
            this.SelectSalespersonInfoFileTextBox.Text = "未选择文件";
            this.SelectSalespersonInfoFileTextBox.Visible = false;
            // 
            // SelectSalespersonInfoFileButton
            // 
            this.SelectSalespersonInfoFileButton.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.SelectSalespersonInfoFileButton.CausesValidation = false;
            this.SelectSalespersonInfoFileButton.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.SelectSalespersonInfoFileButton.Location = new System.Drawing.Point(13, 151);
            this.SelectSalespersonInfoFileButton.Margin = new System.Windows.Forms.Padding(4);
            this.SelectSalespersonInfoFileButton.Name = "SelectSalespersonInfoFileButton";
            this.SelectSalespersonInfoFileButton.Size = new System.Drawing.Size(284, 38);
            this.SelectSalespersonInfoFileButton.TabIndex = 15;
            this.SelectSalespersonInfoFileButton.Text = "选择销售人事信息表";
            this.SelectSalespersonInfoFileButton.UseVisualStyleBackColor = false;
            this.SelectSalespersonInfoFileButton.Visible = false;
            this.SelectSalespersonInfoFileButton.Click += new System.EventHandler(this.SelectSalespersonInfoFileButton_Click);
            // 
            // ReportFileSelectionTextBox
            // 
            this.ReportFileSelectionTextBox.BackColor = System.Drawing.Color.White;
            this.ReportFileSelectionTextBox.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ReportFileSelectionTextBox.Location = new System.Drawing.Point(305, 106);
            this.ReportFileSelectionTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.ReportFileSelectionTextBox.Name = "ReportFileSelectionTextBox";
            this.ReportFileSelectionTextBox.ReadOnly = true;
            this.ReportFileSelectionTextBox.Size = new System.Drawing.Size(880, 38);
            this.ReportFileSelectionTextBox.TabIndex = 18;
            this.ReportFileSelectionTextBox.Text = "未选择文件";
            this.ReportFileSelectionTextBox.Visible = false;
            // 
            // ReportFileSelectorButton
            // 
            this.ReportFileSelectorButton.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ReportFileSelectorButton.CausesValidation = false;
            this.ReportFileSelectorButton.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ReportFileSelectorButton.Location = new System.Drawing.Point(13, 105);
            this.ReportFileSelectorButton.Margin = new System.Windows.Forms.Padding(4);
            this.ReportFileSelectorButton.Name = "ReportFileSelectorButton";
            this.ReportFileSelectorButton.Size = new System.Drawing.Size(284, 38);
            this.ReportFileSelectorButton.TabIndex = 17;
            this.ReportFileSelectorButton.Text = "选择报告信息表";
            this.ReportFileSelectorButton.UseVisualStyleBackColor = false;
            this.ReportFileSelectorButton.Visible = false;
            this.ReportFileSelectorButton.Click += new System.EventHandler(this.ReportFileSelectorButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 35F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1203, 652);
            this.Controls.Add(this.ReportFileSelectionTextBox);
            this.Controls.Add(this.ReportFileSelectorButton);
            this.Controls.Add(this.SelectSalespersonInfoFileTextBox);
            this.Controls.Add(this.SelectSalespersonInfoFileButton);
            this.Controls.Add(this.SelectCommentsFileTextBox);
            this.Controls.Add(this.SelectCommentsFileButton);
            this.Controls.Add(this.SelectSampleInfoFileTextBox);
            this.Controls.Add(this.SelectSampleInfoFileButton);
            this.Controls.Add(this.PdfFolderSelectionTextBox);
            this.Controls.Add(this.PdfFolderSelectorButton);
            this.Controls.Add(this.emailCheckbox);
            this.Controls.Add(this.emailDomainTextbox);
            this.Controls.Add(this.emailPasswordTextbox);
            this.Controls.Add(this.emailAddressTextbox);
            this.Controls.Add(this.SendEmailsButton);
            this.Controls.Add(this.ReportInfoTextBox);
            this.Font = new System.Drawing.Font("Microsoft YaHei", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MainForm";
            this.Text = "销售报告邮件发送工具";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.RichTextBox ReportInfoTextBox;
        private System.Windows.Forms.Button SendEmailsButton;
        private System.Windows.Forms.TextBox emailAddressTextbox;
        private System.Windows.Forms.TextBox emailPasswordTextbox;
        private System.Windows.Forms.TextBox emailDomainTextbox;
        private System.Windows.Forms.CheckBox emailCheckbox;
        private System.Windows.Forms.Button PdfFolderSelectorButton;
        private System.Windows.Forms.TextBox PdfFolderSelectionTextBox;
        private System.Windows.Forms.TextBox SelectSampleInfoFileTextBox;
        private System.Windows.Forms.Button SelectSampleInfoFileButton;
        private System.Windows.Forms.TextBox SelectCommentsFileTextBox;
        private System.Windows.Forms.Button SelectCommentsFileButton;
        private System.Windows.Forms.TextBox SelectSalespersonInfoFileTextBox;
        private System.Windows.Forms.Button SelectSalespersonInfoFileButton;
        private System.Windows.Forms.TextBox ReportFileSelectionTextBox;
        private System.Windows.Forms.Button ReportFileSelectorButton;
    }
}

