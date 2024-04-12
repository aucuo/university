using System;
using System.Security.Cryptography.X509Certificates;

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
            if (a == 1 || b == 1)
            {
                return 1;
            }
            int gcd;
            List<int> first = PrimeList(a);
            List<int> second = PrimeList(b);
            List<int> common = new List<int>();
            first.Sort();
            second.Sort();
            for (int i = 0; i < first.Count(); i++)
            {
                for (int j = 0; j < second.Count(); j++)
                {
                    if (first[i] == second[j])
                    {
                        common.Add(first[i]);
                        second.RemoveAt(j);
                        break;
                    }
                }
            }
            if (common.Count == 0)
            {
                return 1;
            }
            else
            {
                gcd = common[0];
                common.RemoveAt(0);
                for (int i = 0; i < common.Count(); i++)
                {
                    gcd *= common[i];
                }
                return gcd;
            }
        }
        public static int SCM(int a, int b)
        {

            int scm;
            List<int> first = PrimeList(a);
            List<int> second = PrimeList(b);
            List<int> common = first;
            first.Sort();
            second.Sort();
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
        public static int RekGCD(int a, int b)
        {
            if (b == 0)
                return a;
            else
                return RekGCD(b, a % b);
        }

        public static int RekSCM(int a, int b)
        {
            return a * b / RekGCD(a, b);
        }

        public static int ManyGCD(int n, int[] elements)
        {
            int gcd = 0;
            for (int i = 0; i < n; i++)
            {
                if (i == 0) gcd = elements[i];
                else gcd = GCD(gcd, elements[i]);
            }
            return gcd; 
        }

        public static int ManySCM(int n, int[] elements)
        {
            int scm = elements[0];
            for(int i = 1; i < n; i++)
            {
                scm = SCM(scm, elements[i]);
            }
            return scm;
        }
        public static void Main()
        {
            int n, gcd, scm;
            int[] elements;
            while (true)
            {
                Console.WriteLine("Веберите количество элементов: ");
                n = Convert.ToInt32(Console.ReadLine());
                elements = new int[n];
                Console.WriteLine("Введите " + n + " чисел для которых хотите найти НОД и НОК ");
                for (int i = 0; i < n; i++)
                {
                    elements[i] = Convert.ToInt32(Console.ReadLine());
                }
                gcd = ManyGCD(n, elements);
                scm = ManySCM(n, elements);
                Console.Write("НОД (");
                for(int i = 0; i < n; i++)
                {
                    if (i == n - 1)
                        Console.Write(elements[i] + ") = ");
                    else
                        Console.Write(elements[i] + ", ");
                }
                Console.WriteLine(gcd);
                Console.Write("НОК (");
                for (int i = 0; i < n; i++)
                {
                    if (i == n - 1)
                        Console.Write(elements[i] + ") = ");
                    else
                        Console.Write(elements[i] + ", ");
                }
                Console.WriteLine(scm);
                //Console.WriteLine("НОД чисел (" + a + ", " + b + ") с помощью разложения на простые числа = " + gcd);
                //Console.WriteLine("НОК чисел (" + a + ", " + b + ") с помощью разложения на простые числа = " + scm);
                //gcd = RekGCD(a, b);
                //scm = RekSCM(a, b, RekGCD(a,b));
                //Console.WriteLine("НОД чисел (" + a + ", " + b + ") (рекурентным способом) = " + gcd);
                //Console.WriteLine("НОК чисел (" + a + ", " + b + ") (рекурентным способом) = " + scm);

                Console.ReadKey();
                Console.Clear();
            }
        }
    }
}