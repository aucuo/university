namespace lab2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(946, 539);
            this.Name = "Form1";
            this.ResumeLayout(false);

        }
        List<Group> groups = new List<Group>();
        private void button1_Click(object sender, EventArgs e)
        {
            groups[0].AddGrade();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            groups[0].AddGrade();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            groups[0].PrintGrades();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            groups[0].EditGrade();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            groups.Add(new Group());
            MessageBox.Show(
            $"{groups[groups.Count-1].className} добавлена",
            "Forms",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information,
            MessageBoxDefaultButton.Button1,
            MessageBoxOptions.DefaultDesktopOnly);
        }
    }
}