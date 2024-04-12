using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace lab2
{
    internal class User : IObserver
    {
        public string Name { get; set; }

        public User(string name)
        {
            Name = name;
        }

        public void Update(Grade grade)
        {
            MessageBox.Show(
            $"{grade.Date} - Уважаемый пользователь {Name}, вы поставили {grade.Mark}",
            "",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information,
            MessageBoxDefaultButton.Button1,
            MessageBoxOptions.DefaultDesktopOnly);
        }
    }
}
