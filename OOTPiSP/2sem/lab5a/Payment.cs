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

        private static List<IObserver> _observers = new List<IObserver>();

        public static void Attach(IObserver observer)
        {
            _observers.Add(observer);
        }

        public static void Detach(IObserver observer)
        {
            _observers.Remove(observer);
        }

        protected void Notify()
        {
            foreach (var observer in _observers)
            {
                observer.Update(this);
            }
        }

        public Payment()
        {
            this.className = $"Payment #{_objectCount}";
            _objectCount++;
            this._date = DateTime.Now;
            this._amount = 10;
            Notify();
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
