using System;

namespace oib8
{
    class Program
    {

        public static bool isPrime(int number)
        {
            if (number < 2)
            {
                return false;
            }
            else if (number == 2)
                return true;
            else
            {
                for (int i = 2; i < number; i++)
                {
                    if (i == number - 1 && number % i != 0)
                    {
                        return true;
                    }
                    else if (number % i == 0)
                    {
                        return false;
                    }
                }
            }
            return false;
        }

        public static List<int> PrimeList(int number)
        {
            List<int> primeConsistance = new List<int>();
            if (!isPrime(number))
            {
                while (!isPrime(number))
                {
                    for (int i = 2; i < number; i++)
                    {
                        if (number % i == 0 && isPrime(i))
                        {
                            number /= i;
                            primeConsistance.Add(i);
                            break;
                        }
                    }
                }
                primeConsistance.Add(number);
                return primeConsistance;
            }
            else
            {
                primeConsistance.Add(number);
                return primeConsistance;
            }
        }

        public static int GCD(int a, int b)
        {
            int gcd;
            List<int> first = PrimeList(a);
            List<int> second = PrimeList(b);
            List<int> common = new List<int>();
            first.Sort();
            second.Sort();
            for(int i = 0; i < first.Count(); i++)
            {
                for(int j = 0; j < second.Count(); j++)
                {
                    if (first[i] == second[j])
                    {
                        common.Add(first[i]);
                        second.RemoveAt(j);
                        break;
                    }
                }
            }
            gcd = common[0];
            common.RemoveAt(0);
            for(int i = 0; i < common.Count(); i++)
            {
                gcd *= common[i];
            }
            return gcd;
        }
        public static int SCM(int a, int b)
        {
            int scm;
            List<int> first = PrimeList(a);
            List<int> second = PrimeList(b);
            List<int> common = first;
            first.Sort();
            second.Sort();
            int countFirst = first.Count();
            int countSecond = second.Count();
            for (int i = 0; i < first.Count(); i++)
            {
                for (int j = 0; j < second.Count(); j++)
                {
                    if (first[i] == second[j])
                    {
                        second.RemoveAt(j);
                        break;
                    }
                }
            }
            common.AddRange(second);
            scm = common[0];
            common.RemoveAt(0);
            for (int i = 0; i < common.Count(); i++)
            {
                scm *= common[i];
            }
            return scm;
        }

        public static void Main()
        {
            int a, b, gcd, scm;
            while (true)
            {
                Console.WriteLine("Введите два числа для которых хотите найти НОД и НОК ");
                a = Convert.ToInt32(Console.ReadLine());
                b = Convert.ToInt32(Console.ReadLine());
                gcd = GCD(a, b);
                scm = SCM(a, b);
                Console.WriteLine("НОД чисел (" + a + ", " + b + ") = " +  gcd);
                Console.WriteLine("НОК чисел (" + a + ", " + b + ") = " + scm);
                Console.WriteLine("Провек тождества НОД(a,b)*НОК(a,b)=a*b");
                Console.WriteLine(gcd + " * " + scm + " = " + (gcd * scm));
                Console.WriteLine(a + " * " + b + " = " + (a * b));
                if(gcd * scm == a * b)
                {
                    Console.WriteLine("Тождество выполняется успешно");
                }
                else
                {
                    Console.WriteLine("Тождество не выполняется");
                }
                Console.ReadKey();
                Console.Clear();
            }
        }
    }
}