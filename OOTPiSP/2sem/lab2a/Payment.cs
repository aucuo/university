using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2
{
    abstract internal class Payment
    {
        private static int _objectCount = 0;
        public string className;
        protected int _amount;
        protected DateTime _date;

        public Payment()
        {
            this.className = $"Payment #{_objectCount}";
            _objectCount++;
            this._date = DateTime.Now;
            this._amount = 10;
            MessageBox.Show(
            "Метод Payment() вызван",
            $"{className}",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information,
            MessageBoxDefaultButton.Button1,
            MessageBoxOptions.DefaultDesktopOnly);
        }

        public int Amount => _amount;
        public DateTime Date => _date;

        public virtual void EditPayment()
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
