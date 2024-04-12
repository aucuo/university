using System;
using System.Collections.Generic;

class Program
{
    static int FindGCD(int a, int b)
    {
        while (b != 0)
        {
            int temp = b;
            b = a % b;
            a = temp;
        }
        return a;
    }

    static void Main()
    {
        int m = 6; 

        Console.WriteLine($"Делители нуля в кольце Z{m}:");
        Console.WriteLine("--------------------------------");
        Console.WriteLine("Элемент | Аннуляторы | Делитель нуля");
        Console.WriteLine("--------|------------|---------------");

        Dictionary<int, List<int>> annulators = new Dictionary<int, List<int>>();

        for (int a = 0; a < m; a++)
        {
            bool isZeroDivider = false; 
            List<int> annulatorList = new List<int>();

            for (int b = 1; b < m; b++)
            {
                if ((a * b) % m == 0)
                {
                    isZeroDivider = true;
                    annulatorList.Add(b);
                }
            }

            string annulatorString = string.Join(", ", annulatorList);
            Console.WriteLine($"{a,8} | {annulatorString,-10} | {(isZeroDivider ? "Да" : "Нет")}");
        }

    }
}
