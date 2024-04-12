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
    internal class Group : ISubject
    {
        private static int _objectCount = 0;
        public string className;
        private string _name;
        private List<Grade> _grades = new List<Grade>();
        public static List<IObserver> _observers = new List<IObserver>();

        public void RegisterObserver(IObserver observer)
        {
            _observers.Add(observer);
        }
        public void RemoveObserver(IObserver observer)
        {
            _observers.Remove(observer);
        }

        public void Notify(Grade grade)
        {
            foreach (var observer in _observers)
            {
                observer.Update(grade);
            }
        }

        public Group()
        {
            this.className = $"Group #{_objectCount}";
            _objectCount++;
            this._name = $"group{_objectCount}";

            MessageBox.Show(
            "Метод Group() вызван",
            $"{className}",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information,
            MessageBoxDefaultButton.Button1,
            MessageBoxOptions.DefaultDesktopOnly);
        }

        public string Name => _name;
        public List<Grade> Grades => _grades;
        public void EditGroup()
        {
            MessageBox.Show(
            "Метод EditGroup() вызван",
            $"{className}",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information,
            MessageBoxDefaultButton.Button1,
            MessageBoxOptions.DefaultDesktopOnly);
        }
        public void AddGrade()
        {
            var result = MessageBox.Show(
            "Какой тип оценки хотите добавить?",
            $"({_name}) Group - AddGrade",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question,
            MessageBoxDefaultButton.Button1,
            MessageBoxOptions.DefaultDesktopOnly);

            if (result == DialogResult.Yes)
            {
                var grade = new Exam();
                // "Yes" выбран для "Exam"
                _grades.Add(grade);
                Notify(grade);
            }
            else if (result == DialogResult.No)
            {
                var grade = new Credit();
                // "No" выбран для "Credit"
                _grades.Add(grade);
                Notify(grade);
            }
        }
        public void EditGrade(string className)
        {
            _grades.FirstOrDefault(g => g.className == className)?.EditGrade();

            MessageBox.Show(
            "Метод EditGrade() вызван",
            $"{className}",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information,
            MessageBoxDefaultButton.Button1,
            MessageBoxOptions.DefaultDesktopOnly);
        }
        public void DeleteGrade(string className)
        {
            _grades.RemoveAll(g => g.className == className);

            MessageBox.Show(
            "Метод DeleteGrade() вызван",
            $"{this.className}",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information,
            MessageBoxDefaultButton.Button1,
            MessageBoxOptions.DefaultDesktopOnly);
        }
    }
}