namespace SalesOrderNotifier
{
    partial class ExitForm
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
            this.exitInfoBox = new System.Windows.Forms.RichTextBox();
            this.exitButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // exitInfoBox
            // 
            this.exitInfoBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.exitInfoBox.Font = new System.Drawing.Font("Microsoft YaHei", 7.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.exitInfoBox.Location = new System.Drawing.Point(13, 13);
            this.exitInfoBox.Margin = new System.Windows.Forms.Padding(4);
            this.exitInfoBox.Name = "exitInfoBox";
            this.exitInfoBox.ReadOnly = true;
            this.exitInfoBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.exitInfoBox.Size = new System.Drawing.Size(479, 217);
            this.exitInfoBox.TabIndex = 0;
            this.exitInfoBox.Text = "";
            // 
            // exitButton
            // 
            this.exitButton.Font = new System.Drawing.Font("Microsoft YaHei UI", 7.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.exitButton.Location = new System.Drawing.Point(13, 238);
            this.exitButton.Margin = new System.Windows.Forms.Padding(4);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(479, 40);
            this.exitButton.TabIndex = 1;
            this.exitButton.Text = "退出";
            this.exitButton.UseVisualStyleBackColor = true;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // ExitForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 35F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(503, 288);
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.exitInfoBox);
            this.Font = new System.Drawing.Font("Microsoft YaHei", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ExitForm";
            this.Text = "退出程序";
            this.Load += new System.EventHandler(this.ExitForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox exitInfoBox;
        private System.Windows.Forms.Button exitButton;
    }
}