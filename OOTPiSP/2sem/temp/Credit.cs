﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2
{
    internal class Credit : Grade
    {
        private static int _objectCount = 0;
        public string className;
        private string _name;
        private string _status;
        private string _type;

        public Credit() : base()
        {
            this.className = $"Credit #{_objectCount}";
            _objectCount++;
            this._name = "creditName";
            this._status = "creditStatus";
            this._type = "creditType";
            MessageBox.Show(
            "Метод Credit() вызван",
            $"{className}",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information,
            MessageBoxDefaultButton.Button1,
            MessageBoxOptions.DefaultDesktopOnly);
        }

        public string Name => $"Возвращает {className}.Name";
        public string Status => $"Возвращает {className}.Status";
        public string Type => $"Возвращает {className}.Type";
    }
}