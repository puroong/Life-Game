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
    public partial class MainForm : Form
    {
        #region variables
        internal static readonly int maxBoxLen=720;

        internal static int boxLen = 20;

        private Brush boxErase = Brushes.White;//상자 원해 색
        private Brush boxPaint = Brushes.Black;//각 상자 칠할 색깔

        private HashSet<Point> pCurGen = new HashSet<Point>();//현재 색칠 된 상자의 좌표들 
        private HashSet<Point> pNewLife;
        private HashSet<Point> pPrevGen;

        private Stack<HashSet<Point>> history = new Stack<HashSet<Point>>();

        private bool doAuto = false;
        private new bool MouseDown = false;

        /// <summary>
        /// 자동실행 간격 (단위는 초)
        /// </summary>
        internal static double autoRunInterval = 1;
        #endregion

        public MainForm()
        {
            InitializeComponent();
        }

        #region control events
        private void Form1_Load(object sender, EventArgs e)
        {
         
        }

        private void btnAuto_Click(object sender, EventArgs e)
        {
            if (pCurGen.Count == 0)
                return; 

            btnNextState.Enabled = false;
            btnPrevState.Enabled = false;
            btnAutoStop.Enabled = true;
            btnInit.Enabled = false;
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
            btnInit.Enabled = true;
            doAuto = false;
            btnAutoStop.Enabled = false;
        }

        private void pictureBox_Click(object sender, EventArgs e)
        {
            int pXClick = ((MouseEventArgs)e).X;
            int pYClick = ((MouseEventArgs)e).Y;


            int pXRect = pXClick - (pXClick % boxLen);
            int pYRect = pYClick - (pYClick % boxLen);
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

               for (int i = 0; i < maxWidth; i += boxLen)
               {
                   for (int j = 0; j < maxHeight; j += boxLen)
                   {
                       g.DrawRectangle(p, new Rectangle(i, j, boxLen, boxLen));
                   }
               }
        }

        private void btnInit_Click(object sender, EventArgs e)
        {
            pictureBox.Invalidate();
            history.Clear();
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
            int pXClick = ((MouseEventArgs)e).X;
            int pYClick = ((MouseEventArgs)e).Y;


            int pXRect = pXClick - (pXClick % boxLen);
            int pYRect = pYClick - (pYClick % boxLen);
            Point nPoint = new Point(pXRect, pYRect);

            if (MouseDown && e.Button==MouseButtons.Left)
            {
                NewLife(nPoint);
            }
            else if (MouseDown && e.Button == MouseButtons.Right)
            {
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

                Thread.Sleep((int)(autoRunInterval*1000));
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

            if (pCurGen.Contains(new Point(px, py + boxLen)))
                cnt++;
            if (pCurGen.Contains(new Point(px + boxLen, py + boxLen)))
                cnt++;
            if (pCurGen.Contains(new Point(px + boxLen, py)))
                cnt++;
            if (pCurGen.Contains(new Point(px + boxLen, py - boxLen)))
                cnt++;
            if (pCurGen.Contains(new Point(px, py - boxLen)))
                cnt++;
            if (pCurGen.Contains(new Point(px - boxLen, py - boxLen)))
                cnt++;
            if (pCurGen.Contains(new Point(px - boxLen, py)))
                cnt++;
            if (pCurGen.Contains(new Point(px - boxLen, py + boxLen)))
                cnt++;
            return cnt;
        }
        
        /// <summary>
        /// 죽을 생명을 pCurGen과 화면에서 지운다
        /// </summary>
        /// <param name="point"></param>
        private void Die(Point point)
        {
            pCurGen.Remove(point);
            EraseLife(point);
        }
        /// <summary>
        /// 새로 생긴 생명을 pCurGen에 저장 및 출력한다
        /// </summary>
        /// <param name="point"></param>
        private void NewLife(Point point)
        {
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
            g.FillRectangle(boxPaint, new Rectangle(point.X + 1, point.Y + 1, boxLen - 1, boxLen - 1));
        }
        /// <summary>
        /// 존재하는 생명 화면에서 숨기기
        /// </summary>
        /// <param name="point"></param>
        private void EraseLife(Point point)
        {
            Graphics g = pictureBox.CreateGraphics();
            g.FillRectangle(boxErase, new Rectangle(point.X + 1, point.Y + 1, boxLen - 1, boxLen - 1));
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
            Point Up = (new Point(point.X, point.Y + boxLen));
            Point Down = new Point(point.X, point.Y - boxLen);
            Point Left = new Point(point.X + boxLen, point.Y);
            Point Right = new Point(point.X - boxLen, point.Y);

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

            //현재 새명들 저장
            history.Push(new HashSet<Point>(pCurGen));

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
            try
            {
                pPrevGen = history.Pop();
                int cntLife = pCurGen.Count;//현재 생명 수
                Point[] die = new Point[cntLife];//죽을 생명 list
                int countDie = pCurGen.Count;

                int k = -1;

                foreach (Point p in pCurGen)
                {
                    k++;
                    die[k] = p;
                }

                for (int i = 0; i < countDie; i++)
                {
                    Die(die[i]);
                }

                foreach (Point p in pPrevGen)
                {
                    NewLife(p);
                }
            }
            catch (InvalidOperationException exp)
            {
                MessageBox.Show("더 이상 뒤로 갈 수 없습니다");
            }
            catch (Exception exp) {
                MessageBox.Show("알 수 없는 에러");
            }
        }

        #endregion

        private void 설정ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnAutoStop_Click(btnAutoStop, new EventArgs());
            btnInit_Click(btnInit, new EventArgs());

            Setting st = new Setting();
            st.ShowDialog();
            

            pictureBox.Invalidate();
        }
    }
}
