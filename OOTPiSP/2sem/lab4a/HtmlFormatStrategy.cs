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
        public void Format(List<Payment> payments)
        {
            string html = "";

            foreach (var grade in payments)
            {
                var properties = grade.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);
                html += $"{grade.className}<br/>";

                foreach (var property in properties)
                {
                    if (property.CanRead)
                    {
                        var value = property.GetValue(grade);
                        html += $"{property.Name}: {value}<br/>";
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
