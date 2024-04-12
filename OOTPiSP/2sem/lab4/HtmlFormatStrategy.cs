using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace lab2
{
    internal class HtmlFormatStrategy : IFormatStrategy
    {
        public void Format(List<Grade> grades)
        {
            string html = "";

            foreach (var grade in grades)
            {
                // Рефлексия для вызова всех геттеров текущего типа grade
                var properties = grade.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);
                html += $"<h2>{grade.className}</h2>";

                foreach (var property in properties)
                {
                    if (property.CanRead)
                    {
                        var value = property.GetValue(grade);
                        html += $"<p>{property.Name}: {value}</p><br>";
                    }
                }

            }
            MessageBox.Show(
            $"{html}",
            "HtmlFormatStrategy",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information,
            MessageBoxDefaultButton.Button1,
            MessageBoxOptions.DefaultDesktopOnly);
        }
    }
}
