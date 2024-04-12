using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace lab2
{
    internal class JsonFormatStrategy : IFormatStrategy
    {
        public void Format(List<Grade> grades)
        {
            string json = "";

            foreach (var grade in grades)
            {
                // Рефлексия для вызова всех геттеров текущего типа grade
                var properties = grade.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);
                json += $"'{grade.className}' : ";

                foreach (var property in properties)
                {
                    if (property.CanRead)
                    {
                        var value = property.GetValue(grade);
                        json += $"{{{property.Name}: '{value}',";
                    }
                }
                json += "},";

            }
            MessageBox.Show(
            $"{json}",
            "JsonFormatStrategy",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information,
            MessageBoxDefaultButton.Button1,
            MessageBoxOptions.DefaultDesktopOnly);
        }
    }
}
