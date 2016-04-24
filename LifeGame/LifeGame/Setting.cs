using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LifeGame
{
    public partial class Setting : Form
    {
        public Setting()
        {
            InitializeComponent();
            InitializeTxtBoxes();
        }

        #region
        /// <summary>
        /// 설정 txtbox들에 현재 값을 넣어준다
        /// </summary>
        void InitializeTxtBoxes() {
            txtRunInterval.Text = MainForm.autoRunInterval.ToString();
            txtBoxLen.Text = MainForm.boxLen.ToString();
        }
        #endregion

        #region control events
        private void txtRunInterval_Enter(object sender, EventArgs e)
        {
            txtRunInterval.Text = MainForm.autoRunInterval.ToString();
        }
        private void txtRunInterval_Validating(object sender, CancelEventArgs e)
        {
            double num;
            bool shouldCancel = false;
            try
            {
                num = Convert.ToDouble(txtBoxLen.Text);

                if (num < 0)
                {
                    MessageBox.Show("양수인 정수만 입력해야 합니다");
                    shouldCancel = true;
                }
            }
            catch (FormatException exp)
            {
                shouldCancel = true;
                MessageBox.Show("숫자를 입력해야 합니다");
            }

            if (shouldCancel)
                e.Cancel = true;
        }


        private void txtBoxLen_Enter(object sender, EventArgs e)
        {
            txtBoxLen.Text = MainForm.boxLen.ToString();
        }
        private void txtBoxLen_Validating(object sender, CancelEventArgs e)
        {
            int num;
            bool shouldCancel = false;
            try
            {
                num = Convert.ToInt32(txtBoxLen.Text);

                if (num < 10)
                {
                    MessageBox.Show("10보다 크거나 같은 정수만 입력해야 합니다");
                    shouldCancel = true;
                }
                else if (num > MainForm.maxBoxLen)
                {
                    MessageBox.Show("최대 " + MainForm.maxBoxLen.ToString() + "까지 입력할 수 있습니다");
                    shouldCancel = true;
                }
            }
            catch (FormatException exp) {
                shouldCancel = true;
                MessageBox.Show("숫자를 입력해야 합니다");
            }

            if (shouldCancel)
                e.Cancel = true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            int boxLen= Convert.ToInt32(txtBoxLen.Text); ;

            MainForm.autoRunInterval = Convert.ToDouble(txtRunInterval.Text);
            MainForm.boxLen = boxLen - boxLen % 10;
            //Form1.boxLen = boxLen;
            this.Close();
        }

        #endregion
    }
}
