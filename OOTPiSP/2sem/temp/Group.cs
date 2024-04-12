using lab2;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.Design.AxImporter;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace lab2
{
    internal class Group
    {
        private static int _objectCount = 0;
        public string className;
        private int _number;
        private string _name;
        private List<Grade> _grades = new List<Grade>();

        public Group()
        {
            this.className = $"Group #{_objectCount}";
            _objectCount++;
            this._number = 0;
            this._name = "_name";
        }

        public string Name => $"Возвращает {className}.Name";
        public string Grades => $"Возвращает {className}.Grades";

        public void PrintGrades() 
        {
            
        }
        public void AddGrade()
        {
            
        }
        public void EditGrade()
        {
            
        }
        public void DeleteGrade()
        {
            
        }
    }
}