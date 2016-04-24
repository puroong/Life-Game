namespace LifeGame
{
    partial class Setting
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
            this.lblRunInterval = new System.Windows.Forms.Label();
            this.settingAuto = new System.Windows.Forms.GroupBox();
            this.txtRunInterval = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtBoxLen = new System.Windows.Forms.TextBox();
            this.lblBoxLen = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.settingAuto.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblRunInterval
            // 
            this.lblRunInterval.AutoSize = true;
            this.lblRunInterval.Location = new System.Drawing.Point(15, 31);
            this.lblRunInterval.Name = "lblRunInterval";
            this.lblRunInterval.Size = new System.Drawing.Size(57, 12);
            this.lblRunInterval.TabIndex = 0;
            this.lblRunInterval.Text = "실행 간격";
            // 
            // settingAuto
            // 
            this.settingAuto.Controls.Add(this.txtRunInterval);
            this.settingAuto.Controls.Add(this.lblRunInterval);
            this.settingAuto.Location = new System.Drawing.Point(12, 9);
            this.settingAuto.Name = "settingAuto";
            this.settingAuto.Size = new System.Drawing.Size(353, 71);
            this.settingAuto.TabIndex = 1;
            this.settingAuto.TabStop = false;
            this.settingAuto.Text = "자동 실행";
            // 
            // txtRunInterval
            // 
            this.txtRunInterval.Location = new System.Drawing.Point(78, 28);
            this.txtRunInterval.Name = "txtRunInterval";
            this.txtRunInterval.Size = new System.Drawing.Size(100, 21);
            this.txtRunInterval.TabIndex = 1;
            this.txtRunInterval.Enter += new System.EventHandler(this.txtRunInterval_Enter);
            this.txtRunInterval.Validating += new System.ComponentModel.CancelEventHandler(this.txtRunInterval_Validating);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtBoxLen);
            this.groupBox1.Controls.Add(this.lblBoxLen);
            this.groupBox1.Location = new System.Drawing.Point(12, 90);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(353, 71);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "칸 크기";
            // 
            // txtBoxLen
            // 
            this.txtBoxLen.Location = new System.Drawing.Point(78, 28);
            this.txtBoxLen.Name = "txtBoxLen";
            this.txtBoxLen.Size = new System.Drawing.Size(100, 21);
            this.txtBoxLen.TabIndex = 1;
            this.txtBoxLen.Enter += new System.EventHandler(this.txtBoxLen_Enter);
            this.txtBoxLen.Validating += new System.ComponentModel.CancelEventHandler(this.txtBoxLen_Validating);
            // 
            // lblBoxLen
            // 
            this.lblBoxLen.AutoSize = true;
            this.lblBoxLen.Location = new System.Drawing.Point(15, 31);
            this.lblBoxLen.Name = "lblBoxLen";
            this.lblBoxLen.Size = new System.Drawing.Size(45, 12);
            this.lblBoxLen.TabIndex = 0;
            this.lblBoxLen.Text = "칸 길이";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(290, 167);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "취소";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(209, 167);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 4;
            this.btnOK.Text = "확인";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // Setting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(377, 198);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.settingAuto);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Setting";
            this.Text = "설정";
            this.settingAuto.ResumeLayout(false);
            this.settingAuto.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblRunInterval;
        private System.Windows.Forms.GroupBox settingAuto;
        private System.Windows.Forms.TextBox txtRunInterval;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtBoxLen;
        private System.Windows.Forms.Label lblBoxLen;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
    }
}