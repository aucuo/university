using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2
{
    abstract internal class Grade
    {
        private static int _objectCount = 0;
        public string className;
        protected string _fullName;
        protected DateTime _date;
        protected int _grade;

        public Grade()
        {
            this.className = $"Grade #{_objectCount}";
            _objectCount++;
            this._fullName = "name";
            this._date = DateTime.Now;
            this._grade = 10;
            MessageBox.Show(
            "Метод Grade() вызван",
            $"{className}",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information,
            MessageBoxDefaultButton.Button1,
            MessageBoxOptions.DefaultDesktopOnly);
        }

        public string FullName => $"Возвращает {className}.Duration";
        public string Date => $"Возвращает {className}.Date";
        public string Mark => $"Возвращает {className}.Mark";
    }
}
