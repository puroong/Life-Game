namespace LifeGame
{
    partial class MainForm
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.btnAuto = new System.Windows.Forms.Button();
            this.btnNextState = new System.Windows.Forms.Button();
            this.btnPrevState = new System.Windows.Forms.Button();
            this.btnInit = new System.Windows.Forms.Button();
            this.btnAutoStop = new System.Windows.Forms.Button();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.설정ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox
            // 
            this.pictureBox.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.pictureBox.Location = new System.Drawing.Point(19, 106);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(1081, 721);
            this.pictureBox.TabIndex = 0;
            this.pictureBox.TabStop = false;
            this.pictureBox.Click += new System.EventHandler(this.pictureBox_Click);
            this.pictureBox.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox_Paint);
            this.pictureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseDown);
            this.pictureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseMove);
            this.pictureBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseUp);
            // 
            // btnAuto
            // 
            this.btnAuto.Location = new System.Drawing.Point(139, 27);
            this.btnAuto.Name = "btnAuto";
            this.btnAuto.Size = new System.Drawing.Size(72, 33);
            this.btnAuto.TabIndex = 1;
            this.btnAuto.TabStop = false;
            this.btnAuto.Text = "자동";
            this.btnAuto.UseVisualStyleBackColor = true;
            this.btnAuto.Click += new System.EventHandler(this.btnAuto_Click);
            // 
            // btnNextState
            // 
            this.btnNextState.Location = new System.Drawing.Point(75, 66);
            this.btnNextState.Name = "btnNextState";
            this.btnNextState.Size = new System.Drawing.Size(34, 35);
            this.btnNextState.TabIndex = 2;
            this.btnNextState.TabStop = false;
            this.btnNextState.Text = ">";
            this.btnNextState.UseVisualStyleBackColor = true;
            this.btnNextState.Click += new System.EventHandler(this.btnNextState_Click);
            // 
            // btnPrevState
            // 
            this.btnPrevState.Location = new System.Drawing.Point(37, 66);
            this.btnPrevState.Name = "btnPrevState";
            this.btnPrevState.Size = new System.Drawing.Size(32, 35);
            this.btnPrevState.TabIndex = 3;
            this.btnPrevState.TabStop = false;
            this.btnPrevState.Text = "<";
            this.btnPrevState.UseVisualStyleBackColor = true;
            this.btnPrevState.Click += new System.EventHandler(this.btnPrevState_Click);
            // 
            // btnInit
            // 
            this.btnInit.Location = new System.Drawing.Point(37, 27);
            this.btnInit.Name = "btnInit";
            this.btnInit.Size = new System.Drawing.Size(72, 33);
            this.btnInit.TabIndex = 4;
            this.btnInit.TabStop = false;
            this.btnInit.Text = "초기화";
            this.btnInit.UseVisualStyleBackColor = true;
            this.btnInit.Click += new System.EventHandler(this.btnInit_Click);
            // 
            // btnAutoStop
            // 
            this.btnAutoStop.Enabled = false;
            this.btnAutoStop.Location = new System.Drawing.Point(139, 66);
            this.btnAutoStop.Name = "btnAutoStop";
            this.btnAutoStop.Size = new System.Drawing.Size(72, 35);
            this.btnAutoStop.TabIndex = 5;
            this.btnAutoStop.Text = "중지";
            this.btnAutoStop.UseVisualStyleBackColor = true;
            this.btnAutoStop.Click += new System.EventHandler(this.btnAutoStop_Click);
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.설정ToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(1114, 24);
            this.menuStrip.TabIndex = 6;
            this.menuStrip.Text = "menuStrip1";
            // 
            // 설정ToolStripMenuItem
            // 
            this.설정ToolStripMenuItem.Name = "설정ToolStripMenuItem";
            this.설정ToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.설정ToolStripMenuItem.Text = "설정";
            this.설정ToolStripMenuItem.Click += new System.EventHandler(this.설정ToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1114, 840);
            this.Controls.Add(this.btnAutoStop);
            this.Controls.Add(this.btnInit);
            this.Controls.Add(this.btnPrevState);
            this.Controls.Add(this.btnNextState);
            this.Controls.Add(this.btnAuto);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.menuStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "LifeGame";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Button btnAuto;
        private System.Windows.Forms.Button btnNextState;
        private System.Windows.Forms.Button btnPrevState;
        private System.Windows.Forms.Button btnInit;
        private System.Windows.Forms.Button btnAutoStop;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem 설정ToolStripMenuItem;
    }
}

