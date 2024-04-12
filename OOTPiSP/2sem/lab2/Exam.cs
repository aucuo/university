using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2
{
    internal class Exam : Grade
    {
        private static int _objectCount = 0;
        public string className;
        private string _name;
        private string _difficulty;
        private string _duration;

        public Exam() : base()
        {
            this.className = $"Exam #{_objectCount}";
            _objectCount++;
            this._name = "examName";
            this._difficulty = "examDifficulty";
            this._duration = "examDuration";
            MessageBox.Show(
            "Метод Exam() вызван",
            $"{className}",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information,
            MessageBoxDefaultButton.Button1,
            MessageBoxOptions.DefaultDesktopOnly);
        }

        public string Name => _name;
        public string Difficulty => _difficulty;
        public string Duration => _duration;

        public override void EditGrade()
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