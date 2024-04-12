using System;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

namespace Laba6
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Graphics g = pictureBox1.CreateGraphics();
            g.Clear(Color.White);

            SolidBrush gray = new SolidBrush(Color.LightGray);
            SolidBrush orange = new SolidBrush(Color.Orange);
            SolidBrush black = new SolidBrush(Color.Black);

            Pen myPen = new Pen(Color.Gray, 2);

            g.FillEllipse(gray, 400, 400, 200, 200);
            g.FillEllipse(gray, 425, 250, 150, 150);
            g.FillEllipse(gray, 450, 150, 100, 100);

            g.DrawEllipse(myPen, 400, 400, 200, 200); // низ
            g.DrawEllipse(myPen, 425, 250, 150, 150); // середина
            g.DrawEllipse(myPen, 450, 150, 100, 100); // голова

            // Нос
            PointF point1 = new PointF(500, 200);
            PointF point2 = new PointF(525, 225);
            PointF point3 = new PointF(500, 225);

            // 450, 125
            // 475, 150
            // 450, 150
            PointF[] curvePoints =
                     {
                 point1,
                 point2,
                 point3,
             };

            g.FillClosedCurve(orange, curvePoints);

            // Колпак
            point1 = new PointF(500, 100);
            point2 = new PointF(525, 150);
            point3 = new PointF(475, 150);

            PointF[] curvePoints2 =
                     {
                 point1,
                 point2,
                 point3,
             };

            g.FillClosedCurve(black, curvePoints2);

            g.FillEllipse(black, 475, 180, 15, 15); // глаза
            g.FillEllipse(black, 515, 180, 15, 15);
        }
    }
}