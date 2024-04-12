using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2
{
    internal class Cash : Payment
    {
        private static int _objectCount = 0;
        public string className;
        private string _currency;
        private string _name;

        public Cash() : base()
        {
            this.className = $"Cash #{_objectCount}";
            _objectCount++;
            this._currency = "byn";
            this._name = "Anya";
            MessageBox.Show(
            "Метод Cash() вызван",
            $"{className}",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information,
            MessageBoxDefaultButton.Button1,
            MessageBoxOptions.DefaultDesktopOnly);
        }

        public string Currency => _currency;
        public string Name => _name;
        public override void EditPayment()
        {
            MessageBox.Show(
            "Метод EditPayment() вызван",
            $"{className}",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information,
            MessageBoxDefaultButton.Button1,
            MessageBoxOptions.DefaultDesktopOnly);
        }

    }
}