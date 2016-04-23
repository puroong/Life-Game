using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
namespace LifeGame
{
    public partial class Form1 : Form
    {
        #region variables
        private const int boxWidth = 20;
        private const int boxHeight = 20;

        private Brush boxErase = Brushes.White;//상자 원해 색
        private Brush boxPaint = Brushes.Black;//각 상자 칠할 색깔

        private HashSet<Point> pCurGen = new HashSet<Point>();//현재 색칠 된 상자의 좌표들 
        private HashSet<Point> pNewLife;

        private bool doAuto = false;
        private bool MouseDown = false;
        #endregion

        public Form1()
        {
            InitializeComponent();
        }

        #region control events
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnAuto_Click(object sender, EventArgs e)
        {
            btnNextState.Enabled = false;
            btnPrevState.Enabled = false;
            btnAutoStop.Enabled = true;
            btnAuto.Enabled = false;
            doAuto = true;

            Thread t = new Thread(AutoExe);
            t.IsBackground = true;
            t.Start();

        }
 
        private void btnAutoStop_Click(object sender, EventArgs e)
        {
            btnAuto.Enabled = true;
            btnNextState.Enabled = true;
            btnPrevState.Enabled = true;
            doAuto = false;
            btnAutoStop.Enabled = false;
        }

        private void pictureBox_Click(object sender, EventArgs e)
        {
            int pXClick = ((MouseEventArgs)e).X;
            int pYClick = ((MouseEventArgs)e).Y;


            int pXRect = pXClick - (pXClick % boxWidth);
            int pYRect = pYClick - (pYClick % boxHeight);
            Point nPoint = new Point(pXRect, pYRect);

            Graphics g;
            g = pictureBox.CreateGraphics();

            if (!pCurGen.Contains(nPoint))
            {
                NewLife(nPoint);
            }
            else {
                Die(nPoint);
            }
        }
        private void pictureBox_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Pen p = new Pen(Color.Black);

            int maxWidth = pictureBox.Width;
            int maxHeight = pictureBox.Height;

               for (int i = 0; i < maxWidth; i += boxWidth)
               {
                   for (int j = 0; j < maxHeight; j += boxHeight)
                   {
                       g.DrawRectangle(p, new Rectangle(i, j, boxWidth, boxHeight));
                   }
               }
        }

        private void btnInit_Click(object sender, EventArgs e)
        {
            pictureBox.Invalidate();
            pCurGen.Clear();
        }

        private void pictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            MouseDown = false;
        }
        private void pictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            MouseDown = true;
        }
        private void pictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (MouseDown && e.Button==MouseButtons.Left)
            {
                int pXClick = ((MouseEventArgs)e).X;
                int pYClick = ((MouseEventArgs)e).Y;


                int pXRect = pXClick - (pXClick % boxWidth);
                int pYRect = pYClick - (pYClick % boxHeight);
                Point nPoint = new Point(pXRect, pYRect);

                NewLife(nPoint);
            }
            else if (MouseDown && e.Button == MouseButtons.Right)
            {
                int pXClick = ((MouseEventArgs)e).X;
                int pYClick = ((MouseEventArgs)e).Y;


                int pXRect = pXClick - (pXClick % boxWidth);
                int pYRect = pYClick - (pYClick % boxHeight);
                Point nPoint = new Point(pXRect, pYRect);

                Die(nPoint);
            }
        }

 

        private void btnNextState_Click(object sender, EventArgs e)
        {
            NextGeneration();
        }
        private void btnPrevState_Click(object sender, EventArgs e)
        {
            PrevGeneration();
        }
        #endregion

        #region 프로그램 로직 관련 함수
        /// <summary>
        /// 자동실행 함수
        /// </summary>
        private void AutoExe()
        {
            while (doAuto)
            {
                pictureBox.Invoke(new MethodInvoker(NextGeneration));

                Thread.Sleep(1000);
            }
        }

        /// <summary>
        /// 주위에 이웃이 몇인지 센다
        /// </summary>
        /// <param name="point"></param>
        /// <returns></returns>
        private int CntNeighbor(Point point)
        {
            int cnt = 0;

            int px = point.X;
            int py = point.Y;

            if (pCurGen.Contains(new Point(px, py + boxHeight)))
                cnt++;
            if (pCurGen.Contains(new Point(px + boxWidth, py + boxHeight)))
                cnt++;
            if (pCurGen.Contains(new Point(px + boxWidth, py)))
                cnt++;
            if (pCurGen.Contains(new Point(px + boxWidth, py - boxHeight)))
                cnt++;
            if (pCurGen.Contains(new Point(px, py - boxHeight)))
                cnt++;
            if (pCurGen.Contains(new Point(px - boxWidth, py - boxHeight)))
                cnt++;
            if (pCurGen.Contains(new Point(px - boxWidth, py)))
                cnt++;
            if (pCurGen.Contains(new Point(px - boxWidth, py + boxHeight)))
                cnt++;
            return cnt;
        }
        
        /// <summary>
        /// 죽을 생명을 pCurGen과 화면에서 지운다
        /// </summary>
        /// <param name="point"></param>
        private void Die(Point point)
        {
            Graphics g = pictureBox.CreateGraphics();

            pCurGen.Remove(point);
            EraseLife(point);
        }
        /// <summary>
        /// 새로 생긴 생명을 pCurGen에 저장 및 출력한다
        /// </summary>
        /// <param name="point"></param>
        private void NewLife(Point point)
        {
            Graphics g = pictureBox.CreateGraphics();

            pCurGen.Add(point);
            ShowLife(point);
        }
        /// <summary>
        /// 존재하던 생명 화면에 보여주기
        /// </summary>
        /// <param name="point"></param>

        private void ShowLife(Point point)
        {
            Graphics g = pictureBox.CreateGraphics();
            g.FillRectangle(boxPaint, new Rectangle(point.X + 1, point.Y + 1, boxWidth - 1, boxHeight - 1));
        }
        /// <summary>
        /// 존재하는 생명 화면에서 숨기기
        /// </summary>
        /// <param name="point"></param>
        private void EraseLife(Point point)
        {
            Graphics g = pictureBox.CreateGraphics();
            g.FillRectangle(boxErase, new Rectangle(point.X + 1, point.Y + 1, boxWidth - 1, boxHeight - 1));
        }
        /// <summary>
        /// 지금은 없는 새로운 생명 찾는다
        /// </summary>
        private void FindNewLife()
        {
            pNewLife = new HashSet<Point>();

            foreach(Point point in pCurGen)
            {
                Chk(point);
            }
            //pCurGen.UnionWith(pNewLife);
        }

        private void Chk(Point point) {
            Point Up = (new Point(point.X, point.Y + boxHeight));
            Point Down = new Point(point.X, point.Y - boxHeight);
            Point Left = new Point(point.X + boxWidth, point.Y);
            Point Right = new Point(point.X - boxWidth, point.Y);

            Point[] PArr = { Up, Down, Left, Right };

            for (int i = 0; i < 4; i++) {
                if (CntNeighbor(PArr[i]) == 3)
                    pNewLife.Add(PArr[i]);
            }
        }
        
        /// <summary>
        /// 다음 세대 생명을 찾는다
        /// </summary>
        private void NextGeneration()
        { 
            int neighbor;
            int cntLife = pCurGen.Count;//현재 생명 수
            Point[] die = new Point[cntLife];//죽을 생명 list
            int countDie = 0;
            Point[] newLife;
            int countNew = 0;

            //새 생명들 좌표 찾는다
            FindNewLife();

            countNew = pNewLife.Count;
            newLife = new Point[countNew];

            int k = 0;
            foreach (Point point in pNewLife) {
                newLife[k++] = point;
            }
            //죽을 생명들 찾는다
            foreach (Point point in pCurGen)
            {
                neighbor = CntNeighbor(point);

                if (neighbor <= 1 || neighbor >= 4)
                    die[countDie++] = point;
            }
            for (int i = 0; i < countDie; i++)
            {
                Die(die[i]);
            }
            for (int i = 0; i < countNew; i++) {
                NewLife(newLife[i]);
            }
        
        }
        /// <summary>
        /// 이전 세대 생명을 불러온다
        /// </summary>
        private void PrevGeneration()
        {
            
        }

        #endregion
    }
}
