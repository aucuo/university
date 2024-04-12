using lab2;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.Design.AxImporter;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace lab2
{
    internal class Subscriber
    {
        private static int _objectCount = 0;
        public string className;
        private string _name;
        private List<Payment> _payments = new List<Payment>();

        public Subscriber()
        {
            this.className = $"Subscriber #{_objectCount}";
            _objectCount++;
            this._name = $"sub{_objectCount}";

            MessageBox.Show(
            "Метод Subscriber() вызван",
            $"{className}",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information,
            MessageBoxDefaultButton.Button1,
            MessageBoxOptions.DefaultDesktopOnly);
        }

        public string Name => _name;
        public List<Payment> Payments => _payments;
        public void EditSubscriber()
        {
            MessageBox.Show(
            "EditSubscriber",
            $"{className}",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information,
            MessageBoxDefaultButton.Button1,
            MessageBoxOptions.DefaultDesktopOnly);
        }
        public void AddPayment()
        {
            var result = MessageBox.Show(
            "Тип платежа (да - карта; нет - нал)",
            "AddPayment",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question,
            MessageBoxDefaultButton.Button1,
            MessageBoxOptions.DefaultDesktopOnly);

            if (result == DialogResult.Yes)
            {
                _payments.Add(new Card());
            }
            else if (result == DialogResult.No)
            {
                _payments.Add(new Cash());
            }
        }
        public void EditPayment(string className)
        {
            _payments.FirstOrDefault(g => g.className == className)?.EditPayment();

            MessageBox.Show(
            "Метод EditPayment() вызван",
            $"{className}",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information,
            MessageBoxDefaultButton.Button1,
            MessageBoxOptions.DefaultDesktopOnly);
        }
        public void DeletePayment(string className)
        {
            _payments.RemoveAll(g => g.className == className);

            MessageBox.Show(
            "Метод DeletePayment() вызван",
            $"{this.className}",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information,
            MessageBoxDefaultButton.Button1,
            MessageBoxOptions.DefaultDesktopOnly);
        }
    }
}