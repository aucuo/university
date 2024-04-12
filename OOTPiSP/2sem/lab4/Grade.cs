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
        protected int _mark;
        protected DateTime _date;

        public Grade()
        {
            this.className = $"Grade #{_objectCount}";
            _objectCount++;
            this._fullName = "name";
            this._date = DateTime.Now;
            this._mark = 10;
            MessageBox.Show(
            "Метод Grade() вызван",
            $"{className}",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information,
            MessageBoxDefaultButton.Button1,
            MessageBoxOptions.DefaultDesktopOnly);
        }

        public string FullName => _fullName;
        public int Mark => _mark; // int
        public DateTime Date => _date; // DateTime

        public virtual void EditGrade()
        {
            MessageBox.Show(
            "Метод EditGrade() вызван",
            $"{className}",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information,
            MessageBoxDefaultButton.Button1,
            MessageBoxOptions.DefaultDesktopOnly);
        }
    }
}
