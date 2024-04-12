namespace lab1._1
{
    public partial class Form1 : Form
    {
        int minNumber = 1;
        int maxNumber = 1000;
        int guess;

        public Form1()
        {
            InitializeComponent();
            InitializeGame();
        }

        private void InitializeGame()
        {
            guess = (minNumber + maxNumber) / 2;
            DialogResult result = MessageBox.Show($"Загадайте число от {minNumber} до {maxNumber} и нажмите \"OK\"", "Угадайка", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);

            if (result == DialogResult.Cancel)
            {
                Application.Exit();
            }

            label1.Text = $"Ваше число — это {guess}?";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("прочитал тебя", "Угадайка");
            Application.Exit();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show($"Ваше число меньше {guess}?", "Угадайка", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                maxNumber = guess - 1;
            }
            else
            {
                minNumber = guess + 1;
            }

            guess = (minNumber + maxNumber) / 2;
            label1.Text = $"Ваше число — это {guess}?";
        }
    }
}