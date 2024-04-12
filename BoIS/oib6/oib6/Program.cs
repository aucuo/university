using System;

namespace oib6
{
    class Program
    {
        static int gcd(int first, int second)
        {
            int result;
            if(second > first)
            {
                int temp = first;
                first = second;
                second = temp;
            }
            int remainder;
            do
            {
                remainder = first % second;
                result = second;
                first = second;
                second = remainder;

            } while (remainder != 0);
            return result;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Введите два числа");
            int first, second;
             first = Convert.ToInt32(Console.ReadLine());
            second = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("НОД для " + first + " и " + second + " = " + gcd(first, second));
        }
    }
}