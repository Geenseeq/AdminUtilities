namespace PatientInfoUpdateRequest
{
    partial class Form1
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
            this.loadSalespersonInfoFileButton = new System.Windows.Forms.Button();
            this.selectSendFilesFolderButton = new System.Windows.Forms.Button();
            this.loadSalespersonInfoFileTextbox = new System.Windows.Forms.TextBox();
            this.selectSendFilesFolderTextbox = new System.Windows.Forms.TextBox();
            this.reportInfoTextBox = new System.Windows.Forms.RichTextBox();
            this.emailDomainTextbox = new System.Windows.Forms.TextBox();
            this.emailPasswordTextbox = new System.Windows.Forms.TextBox();
            this.emailAddressTextbox = new System.Windows.Forms.TextBox();
            this.sendEmailsButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // loadSalespersonInfoFileButton
            // 
            this.loadSalespersonInfoFileButton.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.loadSalespersonInfoFileButton.Location = new System.Drawing.Point(12, 12);
            this.loadSalespersonInfoFileButton.Name = "loadSalespersonInfoFileButton";
            this.loadSalespersonInfoFileButton.Size = new System.Drawing.Size(289, 50);
            this.loadSalespersonInfoFileButton.TabIndex = 0;
            this.loadSalespersonInfoFileButton.Text = "加载销售信息文件";
            this.loadSalespersonInfoFileButton.UseVisualStyleBackColor = true;
            this.loadSalespersonInfoFileButton.Click += new System.EventHandler(this.loadSalespersonInfoFileButton_Click);
            // 
            // selectSendFilesFolderButton
            // 
            this.selectSendFilesFolderButton.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.selectSendFilesFolderButton.Location = new System.Drawing.Point(12, 68);
            this.selectSendFilesFolderButton.Name = "selectSendFilesFolderButton";
            this.selectSendFilesFolderButton.Size = new System.Drawing.Size(289, 50);
            this.selectSendFilesFolderButton.TabIndex = 1;
            this.selectSendFilesFolderButton.Text = "选择发送文件夹";
            this.selectSendFilesFolderButton.UseVisualStyleBackColor = true;
            this.selectSendFilesFolderButton.Visible = false;
            this.selectSendFilesFolderButton.Click += new System.EventHandler(this.selectSendFilesFolderButton_Click);
            // 
            // loadSalespersonInfoFileTextbox
            // 
            this.loadSalespersonInfoFileTextbox.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loadSalespersonInfoFileTextbox.Location = new System.Drawing.Point(307, 12);
            this.loadSalespersonInfoFileTextbox.Name = "loadSalespersonInfoFileTextbox";
            this.loadSalespersonInfoFileTextbox.Size = new System.Drawing.Size(627, 42);
            this.loadSalespersonInfoFileTextbox.TabIndex = 2;
            // 
            // selectSendFilesFolderTextbox
            // 
            this.selectSendFilesFolderTextbox.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.selectSendFilesFolderTextbox.Location = new System.Drawing.Point(307, 68);
            this.selectSendFilesFolderTextbox.Name = "selectSendFilesFolderTextbox";
            this.selectSendFilesFolderTextbox.Size = new System.Drawing.Size(627, 42);
            this.selectSendFilesFolderTextbox.TabIndex = 3;
            this.selectSendFilesFolderTextbox.Visible = false;
            // 
            // reportInfoTextBox
            // 
            this.reportInfoTextBox.BackColor = System.Drawing.Color.White;
            this.reportInfoTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.reportInfoTextBox.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.reportInfoTextBox.Location = new System.Drawing.Point(12, 125);
            this.reportInfoTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.reportInfoTextBox.Name = "reportInfoTextBox";
            this.reportInfoTextBox.ReadOnly = true;
            this.reportInfoTextBox.Size = new System.Drawing.Size(922, 224);
            this.reportInfoTextBox.TabIndex = 4;
            this.reportInfoTextBox.Text = "";
            // 
            // emailDomainTextbox
            // 
            this.emailDomainTextbox.BackColor = System.Drawing.Color.White;
            this.emailDomainTextbox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.emailDomainTextbox.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.emailDomainTextbox.Location = new System.Drawing.Point(307, 356);
            this.emailDomainTextbox.Name = "emailDomainTextbox";
            this.emailDomainTextbox.ReadOnly = true;
            this.emailDomainTextbox.Size = new System.Drawing.Size(239, 35);
            this.emailDomainTextbox.TabIndex = 11;
            this.emailDomainTextbox.Text = "@geneseeq.com";
            this.emailDomainTextbox.Visible = false;
            // 
            // emailPasswordTextbox
            // 
            this.emailPasswordTextbox.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.emailPasswordTextbox.ForeColor = System.Drawing.Color.Gray;
            this.emailPasswordTextbox.Location = new System.Drawing.Point(552, 356);
            this.emailPasswordTextbox.Name = "emailPasswordTextbox";
            this.emailPasswordTextbox.Size = new System.Drawing.Size(382, 42);
            this.emailPasswordTextbox.TabIndex = 10;
            this.emailPasswordTextbox.Text = "请输入密码";
            this.emailPasswordTextbox.Visible = false;
            this.emailPasswordTextbox.GotFocus += new System.EventHandler(this.emailPasswordTextbox_GotFocus);
            this.emailPasswordTextbox.LostFocus += new System.EventHandler(this.emailPasswordTextbox_LostFocus);
            // 
            // emailAddressTextbox
            // 
            this.emailAddressTextbox.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.emailAddressTextbox.ForeColor = System.Drawing.Color.Gray;
            this.emailAddressTextbox.Location = new System.Drawing.Point(12, 356);
            this.emailAddressTextbox.Name = "emailAddressTextbox";
            this.emailAddressTextbox.Size = new System.Drawing.Size(289, 42);
            this.emailAddressTextbox.TabIndex = 9;
            this.emailAddressTextbox.Text = "请输入您的世和邮箱";
            this.emailAddressTextbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.emailAddressTextbox.Visible = false;
            this.emailAddressTextbox.GotFocus += new System.EventHandler(this.emailAddressTextbox_GotFocus);
            this.emailAddressTextbox.LostFocus += new System.EventHandler(this.emailAddressTextbox_LostFocus);
            // 
            // sendEmailsButton
            // 
            this.sendEmailsButton.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.sendEmailsButton.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.sendEmailsButton.Location = new System.Drawing.Point(12, 405);
            this.sendEmailsButton.Margin = new System.Windows.Forms.Padding(4);
            this.sendEmailsButton.Name = "sendEmailsButton";
            this.sendEmailsButton.Size = new System.Drawing.Size(289, 50);
            this.sendEmailsButton.TabIndex = 8;
            this.sendEmailsButton.Text = "发送销售报告文件";
            this.sendEmailsButton.UseVisualStyleBackColor = false;
            this.sendEmailsButton.Visible = false;
            this.sendEmailsButton.Click += new System.EventHandler(this.SendEmailsButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(949, 484);
            this.Controls.Add(this.emailDomainTextbox);
            this.Controls.Add(this.emailPasswordTextbox);
            this.Controls.Add(this.emailAddressTextbox);
            this.Controls.Add(this.sendEmailsButton);
            this.Controls.Add(this.reportInfoTextBox);
            this.Controls.Add(this.selectSendFilesFolderTextbox);
            this.Controls.Add(this.loadSalespersonInfoFileTextbox);
            this.Controls.Add(this.selectSendFilesFolderButton);
            this.Controls.Add(this.loadSalespersonInfoFileButton);
            this.Name = "Form1";
            this.Text = "病人信息更新通知工具";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button loadSalespersonInfoFileButton;
        private System.Windows.Forms.Button selectSendFilesFolderButton;
        private System.Windows.Forms.TextBox loadSalespersonInfoFileTextbox;
        private System.Windows.Forms.TextBox selectSendFilesFolderTextbox;
        private System.Windows.Forms.RichTextBox reportInfoTextBox;
        private System.Windows.Forms.TextBox emailDomainTextbox;
        private System.Windows.Forms.TextBox emailPasswordTextbox;
        private System.Windows.Forms.TextBox emailAddressTextbox;
        private System.Windows.Forms.Button sendEmailsButton;
    }
}

