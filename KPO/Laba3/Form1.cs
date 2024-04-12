using System;
using System.Collections;
using static Laba1.Program;

namespace Laba1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Person[] students = new Person[10];
        public int count = 0;

        private void label3_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "")
            {
                label4.Text = "Форма заполнена не правильно!";
                return;
            }

            string inputName = textBox1.Text;
            string inputGroup = textBox2.Text;
            string inputSes = textBox3.Text;

            students[count].name = inputName;
            students[count].group = inputGroup;
            students[count].ses = inputSes;

            label4.Text = $"Студент {students[0].name} был добавлен!";
            count++;

            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            label6.Text = "";
            if (students[0].name == null)
            {
                label4.Text = "Вы не добавили студетов";
                return;
            }

            int badMark = 0;

            for(int i = 0; i < count; i++)
            {
                if (students[i].ses.Contains("2"))
                {
                    badMark++;
                    label5.Text += $"Студент: {students[i].name } из группы {students[i].group }\n";
                }
            }

            if (badMark == 0)
                label4.Text = "Студентов с двойкой нет";
            else
                label4.Text = badMark + " студент(ов) с двойкой";
        }
    }
}