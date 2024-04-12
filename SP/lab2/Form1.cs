using System.Media;

namespace lab2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }


        List<string> note = new List<string>();
        private void button1_Click(object sender, EventArgs e) //add
        {
            int index = listBox1.SelectedIndex;
            listBox1.Items.Add(dateTimePicker1.Value);
            note.Add(richTextBox1.Text);
        }

        private void button_delete_Click(object sender, EventArgs e)
        {
            int index = listBox1.SelectedIndex;
            listBox1.ClearSelected();
            listBox1.Items.RemoveAt(index);
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = listBox1.SelectedIndex;
            if (index < note.Count() && index > 0)
            {
                richTextBox2.Text = note[index];
            }
        }
    }
}