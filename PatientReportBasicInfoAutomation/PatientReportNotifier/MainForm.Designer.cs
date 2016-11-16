using System;

namespace PatientReportBasicInfoAutomation
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
            this.WriteReportButton = new System.Windows.Forms.Button();
            this.SelectOutputFolderButton = new System.Windows.Forms.Button();
            this.SelectOutputFolderTextBox = new System.Windows.Forms.TextBox();
            this.SelectPatientInfoFileTextBox = new System.Windows.Forms.TextBox();
            this.SelectPatientInfoFileButton = new System.Windows.Forms.Button();
            this.SelectTemplateFileTextBox = new System.Windows.Forms.TextBox();
            this.SelectTemplateFileButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ReportInfoTextBox
            // 
            this.ReportInfoTextBox.BackColor = System.Drawing.Color.White;
            this.ReportInfoTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ReportInfoTextBox.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ReportInfoTextBox.Location = new System.Drawing.Point(13, 151);
            this.ReportInfoTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.ReportInfoTextBox.Name = "ReportInfoTextBox";
            this.ReportInfoTextBox.ReadOnly = true;
            this.ReportInfoTextBox.Size = new System.Drawing.Size(1172, 268);
            this.ReportInfoTextBox.TabIndex = 2;
            this.ReportInfoTextBox.Text = "";
            // 
            // WriteReportButton
            // 
            this.WriteReportButton.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.WriteReportButton.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.WriteReportButton.Location = new System.Drawing.Point(13, 427);
            this.WriteReportButton.Margin = new System.Windows.Forms.Padding(4);
            this.WriteReportButton.Name = "WriteReportButton";
            this.WriteReportButton.Size = new System.Drawing.Size(284, 38);
            this.WriteReportButton.TabIndex = 4;
            this.WriteReportButton.Text = "发送销售报告文件";
            this.WriteReportButton.UseVisualStyleBackColor = false;
            this.WriteReportButton.Click += new System.EventHandler(this.WriteReportButton_Click);
            // 
            // SelectOutputFolderButton
            // 
            this.SelectOutputFolderButton.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.SelectOutputFolderButton.CausesValidation = false;
            this.SelectOutputFolderButton.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.SelectOutputFolderButton.Location = new System.Drawing.Point(13, 105);
            this.SelectOutputFolderButton.Margin = new System.Windows.Forms.Padding(4);
            this.SelectOutputFolderButton.Name = "SelectOutputFolderButton";
            this.SelectOutputFolderButton.Size = new System.Drawing.Size(284, 38);
            this.SelectOutputFolderButton.TabIndex = 9;
            this.SelectOutputFolderButton.Text = "选择报告输出文件夹";
            this.SelectOutputFolderButton.UseVisualStyleBackColor = false;
            this.SelectOutputFolderButton.Click += new System.EventHandler(this.SelectOutputFolderButton_Click);
            // 
            // SelectOutputFolderTextBox
            // 
            this.SelectOutputFolderTextBox.BackColor = System.Drawing.Color.White;
            this.SelectOutputFolderTextBox.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.SelectOutputFolderTextBox.Location = new System.Drawing.Point(305, 106);
            this.SelectOutputFolderTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.SelectOutputFolderTextBox.Name = "SelectOutputFolderTextBox";
            this.SelectOutputFolderTextBox.ReadOnly = true;
            this.SelectOutputFolderTextBox.Size = new System.Drawing.Size(880, 38);
            this.SelectOutputFolderTextBox.TabIndex = 10;
            this.SelectOutputFolderTextBox.Text = "未选择文件夹";
            // 
            // SelectPatientInfoFileTextBox
            // 
            this.SelectPatientInfoFileTextBox.BackColor = System.Drawing.Color.White;
            this.SelectPatientInfoFileTextBox.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.SelectPatientInfoFileTextBox.Location = new System.Drawing.Point(305, 14);
            this.SelectPatientInfoFileTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.SelectPatientInfoFileTextBox.Name = "SelectPatientInfoFileTextBox";
            this.SelectPatientInfoFileTextBox.ReadOnly = true;
            this.SelectPatientInfoFileTextBox.Size = new System.Drawing.Size(880, 38);
            this.SelectPatientInfoFileTextBox.TabIndex = 12;
            this.SelectPatientInfoFileTextBox.Text = "未选择文件";
            // 
            // SelectPatientInfoFileButton
            // 
            this.SelectPatientInfoFileButton.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.SelectPatientInfoFileButton.CausesValidation = false;
            this.SelectPatientInfoFileButton.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.SelectPatientInfoFileButton.Location = new System.Drawing.Point(13, 13);
            this.SelectPatientInfoFileButton.Margin = new System.Windows.Forms.Padding(4);
            this.SelectPatientInfoFileButton.Name = "SelectPatientInfoFileButton";
            this.SelectPatientInfoFileButton.Size = new System.Drawing.Size(284, 38);
            this.SelectPatientInfoFileButton.TabIndex = 11;
            this.SelectPatientInfoFileButton.Text = "选择病人基本信息表";
            this.SelectPatientInfoFileButton.UseVisualStyleBackColor = false;
            this.SelectPatientInfoFileButton.Click += new System.EventHandler(this.PatientInfoFileSelectorButton_Click);
            // 
            // SelectTemplateFileTextBox
            // 
            this.SelectTemplateFileTextBox.BackColor = System.Drawing.Color.White;
            this.SelectTemplateFileTextBox.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.SelectTemplateFileTextBox.Location = new System.Drawing.Point(305, 60);
            this.SelectTemplateFileTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.SelectTemplateFileTextBox.Name = "SelectTemplateFileTextBox";
            this.SelectTemplateFileTextBox.ReadOnly = true;
            this.SelectTemplateFileTextBox.Size = new System.Drawing.Size(880, 38);
            this.SelectTemplateFileTextBox.TabIndex = 14;
            this.SelectTemplateFileTextBox.Text = "未选择文件";
            // 
            // SelectTemplateFileButton
            // 
            this.SelectTemplateFileButton.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.SelectTemplateFileButton.CausesValidation = false;
            this.SelectTemplateFileButton.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.SelectTemplateFileButton.Location = new System.Drawing.Point(13, 59);
            this.SelectTemplateFileButton.Margin = new System.Windows.Forms.Padding(4);
            this.SelectTemplateFileButton.Name = "SelectTemplateFileButton";
            this.SelectTemplateFileButton.Size = new System.Drawing.Size(284, 38);
            this.SelectTemplateFileButton.TabIndex = 13;
            this.SelectTemplateFileButton.Text = "选择报告模板文件";
            this.SelectTemplateFileButton.UseVisualStyleBackColor = false;
            this.SelectTemplateFileButton.Click += new System.EventHandler(this.SelectTemplateFileButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 35F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1203, 484);
            this.Controls.Add(this.SelectTemplateFileTextBox);
            this.Controls.Add(this.SelectTemplateFileButton);
            this.Controls.Add(this.SelectPatientInfoFileTextBox);
            this.Controls.Add(this.SelectPatientInfoFileButton);
            this.Controls.Add(this.SelectOutputFolderTextBox);
            this.Controls.Add(this.SelectOutputFolderButton);
            this.Controls.Add(this.WriteReportButton);
            this.Controls.Add(this.ReportInfoTextBox);
            this.Font = new System.Drawing.Font("Microsoft YaHei", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MainForm";
            this.Text = "报告基本信息自动化工具";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.RichTextBox ReportInfoTextBox;
        private System.Windows.Forms.Button WriteReportButton;
        private System.Windows.Forms.Button SelectOutputFolderButton;
        private System.Windows.Forms.TextBox SelectOutputFolderTextBox;
        private System.Windows.Forms.TextBox SelectPatientInfoFileTextBox;
        private System.Windows.Forms.Button SelectPatientInfoFileButton;
        private System.Windows.Forms.TextBox SelectTemplateFileTextBox;
        private System.Windows.Forms.Button SelectTemplateFileButton;
    }
}

