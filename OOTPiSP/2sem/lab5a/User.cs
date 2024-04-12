using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2
{
    internal class User : IObserver
    {
        public string Name { get; set; }

        public User(string name)
        {
            Name = name;
        }

        public void Update(Payment payment)
        {
            MessageBox.Show(
            $"Уважаемый {Name}, поступил новый платеж: {payment.Amount} на дату {payment.Date}",
            $"User",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information,
            MessageBoxDefaultButton.Button1,
            MessageBoxOptions.DefaultDesktopOnly);
        }
    }
}
