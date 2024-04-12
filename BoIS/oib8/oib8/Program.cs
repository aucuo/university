using System;

namespace oib8
{
    class program
    {
        public static bool isPrime(int number)
        {
            if (number < 2)
            {
                Console.WriteLine(number + " - Не простое и не составное число");
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
            if(!isPrime(number))
            {
                while (!isPrime(number))
                {
                    for(int i = 2; i < number; i++)
                    {
                        if(number % i == 0 && isPrime(i))
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

        public static void Main()
        {
            int number = -2;
            List<int> primeMultiplyers = new List<int>();
            while(number != -1)
            {
            int count = 1;
                Console.WriteLine("Введите число чтобы проверить является ли ваше число простым");
                string enter = Console.ReadLine();
                if (enter != "")
                {
                    number = Convert.ToInt32(enter);
                    if (isPrime(number))
                        Console.WriteLine(number + " - Простое число");
                    else if(number > 2)
                        Console.WriteLine(number + " - Составное число");
                    primeMultiplyers = PrimeList(number);
                        Console.WriteLine("Разложение числа " + number + " на простые множители: ");
                    for(int i = 0; i < primeMultiplyers.Count(); i++)
                    {
                        if(i == 0)
                        {
                            Console.Write(primeMultiplyers[i]);
                            continue;
                        }
                        if (primeMultiplyers[i] == primeMultiplyers[i - 1]) { count++; }
                        if (primeMultiplyers[i] != primeMultiplyers[i - 1])
                        {
                            Console.Write("^" + count + " * " + primeMultiplyers[i]);
                            count = 1;
                        }
                        else if(i == primeMultiplyers.Count() - 1)
                        {
                            Console.Write("^" + count);
                        }
                    }
                    Console.Write(" = " + number);
                    Console.WriteLine();
                    //for(int i = 0; i < primeMultiplyers.Count(); i++)
                    //{
                    //    if(i == primeMultiplyers.Count() - 1)
                    //        Console.WriteLine(primeMultiplyers[i] + " = " + number);
                    //    else
                    //        Console.Write(primeMultiplyers[i] + " * ");
                    //}
                }
            }
        }
    }
}