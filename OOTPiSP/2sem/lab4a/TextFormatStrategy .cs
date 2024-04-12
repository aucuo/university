using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace lab2
{
    internal class TextFormatStrategy : IFormatStrategy
    {
        public void Format(List<Payment> payments)
        {
            string text = "";

            foreach (var payment in payments)
            {
                var properties = payment.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);
                text += $"{payment.className}:\n";

                foreach (var property in properties)
                {
                    if (property.CanRead)
                    {
                        var value = property.GetValue(payment);
                        text += $"{property.Name}: {value}\n";
                    }
                }
                text += "\n";
            }
            MessageBox.Show(
            $"{text}",
            "TextFormatStrategy",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information,
            MessageBoxDefaultButton.Button1,
            MessageBoxOptions.DefaultDesktopOnly);
        }
    }
}
