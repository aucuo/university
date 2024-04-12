using System;

namespace lab1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public Point GetPoint(Point old_p)
        {
            Random random = new Random();
            Point p = new Point(random.Next(0, 861), random.Next(0, 519));
            while (p == old_p)
            {
                p = new Point(random.Next(0, 861), random.Next(0, 519));
            }
            return p;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.button1.Location = GetPoint(this.button1.Location);
        }
    }
}