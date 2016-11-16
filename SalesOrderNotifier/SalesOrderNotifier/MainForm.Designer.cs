namespace SalesOrderNotifier
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
            this.OrderFileSelectorButton = new System.Windows.Forms.Button();
            this.OrderFileSelectionTextBox = new System.Windows.Forms.TextBox();
            this.OrderInfoTextBox = new System.Windows.Forms.RichTextBox();
            this.OrderInfoTitle = new System.Windows.Forms.TextBox();
            this.SendEmailsButton = new System.Windows.Forms.Button();
            this.emailAddressTextbox = new System.Windows.Forms.TextBox();
            this.emailPasswordTextbox = new System.Windows.Forms.TextBox();
            this.emailDomainTextbox = new System.Windows.Forms.TextBox();
            this.emailCheckbox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // OrderFileSelectorButton
            // 
            this.OrderFileSelectorButton.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.OrderFileSelectorButton.CausesValidation = false;
            this.OrderFileSelectorButton.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.OrderFileSelectorButton.Location = new System.Drawing.Point(16, 29);
            this.OrderFileSelectorButton.Margin = new System.Windows.Forms.Padding(4);
            this.OrderFileSelectorButton.Name = "OrderFileSelectorButton";
            this.OrderFileSelectorButton.Size = new System.Drawing.Size(428, 38);
            this.OrderFileSelectorButton.TabIndex = 0;
            this.OrderFileSelectorButton.Text = "选择订单文件";
            this.OrderFileSelectorButton.UseVisualStyleBackColor = false;
            this.OrderFileSelectorButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // OrderFileSelectionTextBox
            // 
            this.OrderFileSelectionTextBox.BackColor = System.Drawing.Color.White;
            this.OrderFileSelectionTextBox.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.OrderFileSelectionTextBox.Location = new System.Drawing.Point(16, 75);
            this.OrderFileSelectionTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.OrderFileSelectionTextBox.Name = "OrderFileSelectionTextBox";
            this.OrderFileSelectionTextBox.ReadOnly = true;
            this.OrderFileSelectionTextBox.Size = new System.Drawing.Size(1053, 38);
            this.OrderFileSelectionTextBox.TabIndex = 1;
            this.OrderFileSelectionTextBox.Text = "未选择文件";
            // 
            // OrderInfoTextBox
            // 
            this.OrderInfoTextBox.BackColor = System.Drawing.Color.White;
            this.OrderInfoTextBox.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.OrderInfoTextBox.Location = new System.Drawing.Point(16, 208);
            this.OrderInfoTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.OrderInfoTextBox.Name = "OrderInfoTextBox";
            this.OrderInfoTextBox.ReadOnly = true;
            this.OrderInfoTextBox.Size = new System.Drawing.Size(1053, 260);
            this.OrderInfoTextBox.TabIndex = 2;
            this.OrderInfoTextBox.Text = "";
            // 
            // OrderInfoTitle
            // 
            this.OrderInfoTitle.BackColor = System.Drawing.Color.White;
            this.OrderInfoTitle.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.OrderInfoTitle.Location = new System.Drawing.Point(16, 162);
            this.OrderInfoTitle.Margin = new System.Windows.Forms.Padding(4);
            this.OrderInfoTitle.Name = "OrderInfoTitle";
            this.OrderInfoTitle.ReadOnly = true;
            this.OrderInfoTitle.Size = new System.Drawing.Size(426, 38);
            this.OrderInfoTitle.TabIndex = 3;
            this.OrderInfoTitle.Text = "订单文件信息";
            this.OrderInfoTitle.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // SendEmailsButton
            // 
            this.SendEmailsButton.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.SendEmailsButton.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.SendEmailsButton.Location = new System.Drawing.Point(14, 539);
            this.SendEmailsButton.Margin = new System.Windows.Forms.Padding(4);
            this.SendEmailsButton.Name = "SendEmailsButton";
            this.SendEmailsButton.Size = new System.Drawing.Size(428, 38);
            this.SendEmailsButton.TabIndex = 4;
            this.SendEmailsButton.Text = "发送销售电子文件";
            this.SendEmailsButton.UseVisualStyleBackColor = false;
            this.SendEmailsButton.Visible = false;
            this.SendEmailsButton.Click += new System.EventHandler(this.SendEmailsButton_Click);
            // 
            // emailAddressTextbox
            // 
            this.emailAddressTextbox.ForeColor = System.Drawing.Color.Gray;
            this.emailAddressTextbox.Location = new System.Drawing.Point(16, 489);
            this.emailAddressTextbox.Name = "emailAddressTextbox";
            this.emailAddressTextbox.Size = new System.Drawing.Size(284, 43);
            this.emailAddressTextbox.TabIndex = 5;
            this.emailAddressTextbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.emailAddressTextbox.Text = "请输入您的世和邮箱";
            this.emailAddressTextbox.Visible = false;
            this.emailAddressTextbox.GotFocus += new System.EventHandler(this.emailAddressTextbox_GotFocus);
            this.emailAddressTextbox.LostFocus += new System.EventHandler(this.emailAddressTextbox_LostFocus);
            // 
            // emailPasswordTextbox
            // 
            this.emailPasswordTextbox.ForeColor = System.Drawing.Color.Gray;
            this.emailPasswordTextbox.Location = new System.Drawing.Point(551, 489);
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
            this.emailDomainTextbox.Location = new System.Drawing.Point(306, 492);
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
            this.emailCheckbox.Location = new System.Drawing.Point(551, 542);
            this.emailCheckbox.Name = "emailCheckbox";
            this.emailCheckbox.Size = new System.Drawing.Size(262, 35);
            this.emailCheckbox.TabIndex = 8;
            this.emailCheckbox.Text = "只保存邮件，不发出";
            this.emailCheckbox.UseVisualStyleBackColor = true;
            this.emailCheckbox.Visible = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 35F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1087, 600);
            this.Controls.Add(this.emailCheckbox);
            this.Controls.Add(this.emailDomainTextbox);
            this.Controls.Add(this.emailPasswordTextbox);
            this.Controls.Add(this.emailAddressTextbox);
            this.Controls.Add(this.SendEmailsButton);
            this.Controls.Add(this.OrderInfoTitle);
            this.Controls.Add(this.OrderInfoTextBox);
            this.Controls.Add(this.OrderFileSelectionTextBox);
            this.Controls.Add(this.OrderFileSelectorButton);
            this.Font = new System.Drawing.Font("Microsoft YaHei", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MainForm";
            this.Text = "销售邮件发送工具";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button OrderFileSelectorButton;
        private System.Windows.Forms.TextBox OrderFileSelectionTextBox;
        private System.Windows.Forms.RichTextBox OrderInfoTextBox;
        private System.Windows.Forms.TextBox OrderInfoTitle;
        private System.Windows.Forms.Button SendEmailsButton;
        private System.Windows.Forms.TextBox emailAddressTextbox;
        private System.Windows.Forms.TextBox emailPasswordTextbox;
        private System.Windows.Forms.TextBox emailDomainTextbox;
        private System.Windows.Forms.CheckBox emailCheckbox;
    }
}

