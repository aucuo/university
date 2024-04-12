namespace Laba5
{
    public partial class Form1 : Form
    {
        private static string[] operators = new string[] { "+", "-", "*", "/" };

        private static string DoConvert(Queue<string> tokens)
        {
            var token = tokens.Dequeue();

            if (operators.Contains(token))
            {
                return String.Format("({0} {1} {2})", DoConvert(tokens), token, DoConvert(tokens));
            }
            else
            {
                return token;
            }
        }
        public Form1()
        {
            InitializeComponent();

            textBox1.Text = "- 5 * 6 7"; // - * / 15 - 7 + 1 1 3 + 2 + 1 1
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string source = textBox1.Text;

            var tokens = new Queue<string>(source.Split());

            textBox2.Text = DoConvert(tokens);
        }
    }
}