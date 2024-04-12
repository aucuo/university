using System;
using System.IO;
using System.Text;

namespace Laba4
{
    public partial class Form1 : Form
    {
        public static bool HasDigits(string str)
        {
            foreach (char chr in str)
            {
                if (char.IsDigit(chr))
                    return true;
            }
            return false;
        }
        public Form1()
        {
            InitializeComponent();

            // Вставка текста из файла
            string line;
            try
            {
                //Pass the file path and file name to the StreamReader constructor
                StreamReader sr = new StreamReader("C:\\Users\\aucuo\\Desktop\\Learning\\KPO\\Laba4\\file.txt");
                //Read the first line of text
                line = sr.ReadLine();
                //Continue to read until you reach end of file
                while (line != null)
                {
                    //write the line
                    label1.Text = label1.Text + line;
                    //Read the next line
                    line = sr.ReadLine();
                }
                //close the file
                sr.Close();
                Console.ReadLine();
            }
            catch (Exception e)
            {
                label4.Text = e.Message;
            }
            finally
            {
                label4.Text = "Файл успешно открыт";
            }

            // Обработка текста из файла
            string text = label1.Text;

            string[] words = text.Split();
            label2.Text = string.Join(" ", words.Where(w => !HasDigits(w)));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text.Length != 1)
            {
                label4.Text = "Введите 1 букву!";
                return;
            }

            char letter = Convert.ToChar(textBox1.Text);
            int count = 0;
            string text = label1.Text;

            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] == letter)
                    count++;
            }

            label4.Text = $"Частота повторяемости буквы { letter }: { count }";
        }
    }
}