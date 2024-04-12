using System;
using System.Collections;
using System.Collections.Generic;

namespace Laba5._1
{
    public partial class Form1 : Form
    {
        //������� ������� ���������
        Queue<string> patient = new Queue<string>();

        //������� ������� ��������� ����
        Queue<string> places = new Queue<string>();

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length == 0)
            {
                label2.Text = "������� ��� ��������!";
                return;
            }

            // ��������� � ������� ���������
            patient.Enqueue(textBox1.Text);

            label2.Text = $"� �������� { patient.Count } ��������(��)";
            textBox1.Text = "";
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (patient.Count == 0)
            {
                label3.Text = "��������� ���!";
                return;
            }
            label3.Text = "";
            // �������� ���������. ������ ����� - ������ �����
            while (patient.Count > 0 & places.Count > 0)
            {
                if (places.Count > 0)
                {
                    string patientName = patient.Dequeue();
                    label3.Text += $"������� {patientName} --> {places.Dequeue()}\n";
                }
                else
                {
                    string patientName = patient.Peek();
                    label3.Text += $"������� {patientName} � ��� ��������� �� ��� �������� �����\n";
                }
            }
            if (patient.Count != 0)
            {
                if (places.Count > 0)
                {
                    string patientName = patient.Dequeue();
                    label3.Text += $"������� {patientName} --> {places.Dequeue()}\n";
                }
                else
                {
                    string patientName = patient.Peek();
                    label3.Text += $"������� {patientName} � ��� ��������� �� ��� �������� �����\n";
                }
            }
            label2.Text = $"� �������� {patient.Count} ��������(��)";
            label5.Text = $"� �������� {places.Count} ��������� ����";
        }
        private void button3_Click(object sender, EventArgs e)
        {
            // ���������� ��������� ���� � ��������
            places.Enqueue(Convert.ToString(places.Count));

            label5.Text = $"� �������� {places.Count} ��������� ����";
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}