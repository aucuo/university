using System;
using System.Collections.Generic;

internal class Program
{
    // Алгоритм "в столбик" для вычисления суммы
    public static string Add(string num1, string num2)
    {
        int len1 = num1.Length;
        int len2 = num2.Length;
        int len = Math.Max(len1, len2);
        int[] sum = new int[len + 1];

        for (int i = 0; i < len; i++)
        {
            int x = i < len1 ? num1[len1 - 1 - i] - '0' : 0;
            int y = i < len2 ? num2[len2 - 1 - i] - '0' : 0;
            int s = x + y + sum[len - i];
            sum[len - i] = s % 10;
            sum[len - i - 1] = s / 10;
        }

        string result = "";
        int j = 0;
        if (sum[0] > 0)
        {
            result += sum[0];
            j = 1;
        }

        for (int i = j; i <= len; i++)
        {
            result += sum[i];
        }

        return result.Substring(1);
    }
    // Алгоритм "в столбик" для вычисления произведения
    public static string Multiply(string num1, string num2)
    {
        int len1 = num1.Length;
        int len2 = num2.Length;
        int[] prod = new int[len1 + len2];

        for (int i = len1 - 1; i >= 0; i--)
        {
            int x = num1[i] - '0';
            int carry = 0;

            for (int j = len2 - 1; j >= 0; j--)
            {
                int y = num2[j] - '0';
                int p = x * y + carry + prod[i + j + 1];
                prod[i + j + 1] = p % 10;
                carry = p / 10;
            }

            prod[i] += carry;
        }

        string result = "";
        int t = 0;
        while (t < prod.Length && prod[t] == 0)
        {
            t++;
        }

        for (int i = t; i < prod.Length; i++)
        {
            result += prod[i];
        }

        return result.Length == 0 ? "0" : result;
    }
    // Алгоритм "в столбик" для вычисления частного
    private static void Solve(int[] a, int[] b)
    {
        long count = 0;
        while (BiggerOrEqual(a, b))
        {
            a = Minus(a, b);
            count++;
        }

        Console.WriteLine("Целая часть: {0}", String.Join("", count));
        Console.WriteLine("Остаток: {0}", String.Join("", a));
    }

    private static bool BiggerOrEqual(int[] a, int[] b)
    {
        // a больше b
        bool result = true;

        for (int i = 0; i < a.Length; i++)
        {
            if (a[i] > b[i]) return true;
            else if (a[i] < b[i]) return false;
        }

        return result;
    }

    private static int[] Minus(int[] first, int[] second)
    {
        int[] result = new int[first.Length];

        for (int i = first.Length - 1; i >= 0; i--)
        {
            if (first[i] < second[i] || first[i] < 0)
            {
                first[i - 1] -= 1;
                first[i] = 10 + first[i];
            }


            result[i] = first[i] - second[i];
        }

        return result;
    }
    // Крацуба
    public class KaratsubaMultiplication
    {
        public static long Multiply(long x, long y)
        {
            // Convert to string representation
            string xs = x.ToString();
            string ys = y.ToString();

            // If either number is less than 10, use simple multiplication
            if (x < 10 || y < 10)
            {
                return x * y;
            }

            // Make both numbers have the same length by adding leading zeros
            while (xs.Length < ys.Length)
            {
                xs = "0" + xs;
            }
            while (ys.Length < xs.Length)
            {
                ys = "0" + ys;
            }

            int n = xs.Length;
            int m = n / 2;

            // Split the numbers into two parts
            string xl = xs.Substring(0, m);
            string xr = xs.Substring(m);
            string yl = ys.Substring(0, m);
            string yr = ys.Substring(m);

            // Compute the three products needed
            long p1 = Multiply(long.Parse(xl), long.Parse(yl));
            long p2 = Multiply(long.Parse(xr), long.Parse(yr));
            long p3 = Multiply(long.Parse(xl) + long.Parse(xr), long.Parse(yl) + long.Parse(yr));

            // Combine the products into the final result
            return p1 * (long)Math.Pow(10, 2 * m) + (p3 - p1 - p2) * (long)Math.Pow(10, m) + p2;
        }
    }

    private static void Main(string[] args)
    {
        string n = "", num1, num2, result;

        while (n != "0")
        {
            Console.WriteLine("Выберите пункт:");
            Console.WriteLine("1. Алгоритм `в столбик` для суммы");
            Console.WriteLine("2. Алгоритм `в столбик` для произведения");
            Console.WriteLine("3. Алгоритм `в столбик` для частного");
            Console.WriteLine("4. Алгоритм Крацубы");
            Console.WriteLine("0. Выход");
            n = Console.ReadLine();
            Console.Clear();

            switch(n)
            {
                case "1":
                    Console.WriteLine("Алгоритм `в столбик` для суммы");
                    Console.WriteLine("Введите первое и второе число");
                    num1 = Console.ReadLine();
                    num2 = Console.ReadLine();
                    result = Add(num1, num2);
                    Console.WriteLine(result);
                    break;
                case "2":
                    Console.WriteLine("Алгоритм `в столбик` для произведения");
                    Console.WriteLine("Введите первое и второе число");
                    num1 = Console.ReadLine();
                    num2 = Console.ReadLine();
                    result = Multiply(num1, num2);
                    Console.WriteLine(result);
                    break;
                case "3":
                    Console.WriteLine(" Алгоритм `в столбик` для частного");
                    string first = Console.ReadLine();
                    string second = Console.ReadLine();
                    // Длинны строк(массивов) должны совпадать
                    int[] fNum = first.Select(f => f - '0').ToArray();
                    int[] sNum = second.Select(f => f - '0').ToArray();

                    Solve(fNum, sNum);
                    break;
                case "4":
                    Console.WriteLine("Алгоритм Крацубы");
                    Console.WriteLine("Введите первое и второе число");
                    long l1 = long.Parse(Console.ReadLine());
                    long l2 = long.Parse(Console.ReadLine());
                    long res = KaratsubaMultiplication.Multiply(l1, l2);
                    Console.WriteLine(Convert.ToString(res));
                    break;
                case "0":
                    break;

                default:
                    break;
            }
        }
    }
}