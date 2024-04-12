using System;
using System.Collections;
using System.Collections.Generic;

namespace Laba5._1
{
    public partial class Form1 : Form
    {
        //создаем очередь пациентов
        Queue<string> patient = new Queue<string>();

        //создаем очередь свободных мест
        Queue<string> places = new Queue<string>();

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length == 0)
            {
                label2.Text = "Введите имя пациента!";
                return;
            }

            // Добавляем в очередь пациентов
            patient.Enqueue(textBox1.Text);

            label2.Text = $"В больнице { patient.Count } пациента(ов)";
            textBox1.Text = "";
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (patient.Count == 0)
            {
                label3.Text = "Пациентов нет!";
                return;
            }
            label3.Text = "";
            // Вызываем пациентов. Первый вошел - первый вышел
            while (patient.Count > 0 & places.Count > 0)
            {
                if (places.Count > 0)
                {
                    string patientName = patient.Dequeue();
                    label3.Text += $"Пациент {patientName} --> {places.Dequeue()}\n";
                }
                else
                {
                    string patientName = patient.Peek();
                    label3.Text += $"Пациент {patientName} и все следующие за ним остаются ждать\n";
                }
            }
            if (patient.Count != 0)
            {
                if (places.Count > 0)
                {
                    string patientName = patient.Dequeue();
                    label3.Text += $"Пациент {patientName} --> {places.Dequeue()}\n";
                }
                else
                {
                    string patientName = patient.Peek();
                    label3.Text += $"Пациент {patientName} и все следующие за ним остаются ждать\n";
                }
            }
            label2.Text = $"В больнице {patient.Count} пациента(ов)";
            label5.Text = $"В больнице {places.Count} свободных мест";
        }
        private void button3_Click(object sender, EventArgs e)
        {
            // Добавление свободных мест в больницу
            places.Enqueue(Convert.ToString(places.Count));

            label5.Text = $"В больнице {places.Count} свободных мест";
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}