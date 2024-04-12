using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Laba_3_temp
{
    internal class Check
    {
        public static string ReadName()
        {
            var name = Console.ReadLine();

            if (!name.All(char.IsLetter) || name.Length < 2 || name.Length > 20)
            {
                Console.WriteLine("Неправильный ввод. Введите снова:");
                return ReadName();
            }
            return name;
        }
        public static int ReadInt()
        {
            var input = Console.ReadLine();

            if (int.TryParse(input, out var output))
            {
                Console.WriteLine("Неправильный ввод. Введите снова:");
                return output;
            }

            return ReadInt();
        }
        public static int ReadInt(int a, int b)
        {
            int n;
            string str;

            do
                str = Console.ReadLine();
            while (!int.TryParse(str, out n));

            n = Convert.ToInt16(str);

            if (n < a || n > b) ReadInt(a, b);

            return n;
        }
        static public string ReadDate()
        {
            var date = Console.ReadLine();

            if (!DateTime.TryParse(date, out DateTime dt))
            {
                Console.WriteLine("Неправильный ввод. Введите снова:");
                return ReadDate();
            }

            return date;
        }
        public static string ReadCardNum()
        {
            var cardNum = Console.ReadLine();

            if (!cardNum.All(char.IsDigit) || cardNum.Length != 4)
            {
                Console.WriteLine("Неправильный ввод. Введите снова:");
                return ReadCardNum();
            }
            return cardNum;
        }
        public static string ReadCvv()
        {
            var cvv = Console.ReadLine();

            if (!cvv.All(char.IsDigit) || cvv.Length != 3)
            {
                Console.WriteLine("Неправильный ввод. Введите снова:");
                return ReadCvv();
            }
            return cvv;
        }
        public static string ReadCurrency()
        {
            var currency = Console.ReadLine();

            if (!currency.All(char.IsLetter) || currency.Length != 3)
            {
                Console.WriteLine("Неправильный ввод. Введите снова:");
                return ReadCurrency();
            }
            return currency;
        }
        public static string ReadIssuer()
        {
            var issuer = Console.ReadLine();

            if (!issuer.All(char.IsLetter) || issuer.Length < 2 || issuer.Length > 20)
            {
                Console.WriteLine("Неправильный ввод. Введите снова:");
                return ReadIssuer();
            }
            return issuer;
        }
        public static string GetPaymentType()
        {
            int n;
            string type;
            Console.WriteLine("Выберите тип платежа (1. картой; 2. наличными):");
            n = Check.ReadInt(1, 2);

            if (n == 1)
                type = "Картой";
            else
                type = "Наличными";

            return type;
        }
        public static Subscriber GetSub(List<Subscriber> subscribers, string name)
        {
            if (subscribers.Count == 0)
                return null;

            foreach (Subscriber sub in subscribers)
            {
                if (sub.Name == name)
                    return sub;
            }
            return null;
        }
    }
}
