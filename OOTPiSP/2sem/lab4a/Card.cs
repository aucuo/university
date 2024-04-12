using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2
{
    internal class Card : Payment
    {
        private static int _objectCount = 0;
        public string className;
        private long _cardNumber;
        private short _cvv;

        public Card() : base()
        {
            this.className = $"Card #{_objectCount}";
            _objectCount++;
            this._cardNumber = 1234572394851923;
            this._cvv = 231;
            MessageBox.Show(
            "Метод Card() вызван",
            $"{className}",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information,
            MessageBoxDefaultButton.Button1,
            MessageBoxOptions.DefaultDesktopOnly);
        }

        public long CardNumber => _cardNumber;
        public short Cvv => _cvv;

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