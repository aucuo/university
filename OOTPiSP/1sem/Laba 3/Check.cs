using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Laba_3
{
    internal class Check
    {
        static public int GetInt()
        {
            int n;
            string str;

            do
                str = Console.ReadLine();
            while (!int.TryParse(str, out n));

            n = Convert.ToInt16(str);

            return n;
        }

        static public int GetInt(int a, int b)
        {
            int n;
            string str;

            do
                str = Console.ReadLine();
            while (!int.TryParse(str, out n));

            n = Convert.ToInt16(str);

            if (n < a || n > b) GetInt(a, b);

            return n;
        }

        static public string GetDate()
        {
            string date;
            do
                date = Console.ReadLine();
            while (!DateTime.TryParse(date, out DateTime dt));

            return date;
        }
        static public string GetGroup()
        {
            string group;
            string pattern = @"^([1-9]|1[0-1])[А-Яа-я]{1,2}$";
            Regex regex = new Regex(pattern);

            do
                group = Console.ReadLine();
            while (!regex.IsMatch(group));

            return group.ToUpper();
        }

        static public string GetName()
        {
            string name;
            do
                name = Console.ReadLine();
            while (name.Any(char.IsDigit) || name.Length < 2 || name.Length > 20);
            return name;
        }
    }
}
