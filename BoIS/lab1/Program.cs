using System;
using System.Collections.Generic;
using System.Linq;

class RingTableAnalysis
{
    static void Main()
    {
        Console.Write("Введите порядок кольца (m): ");
        int m = int.Parse(Console.ReadLine());

        Console.WriteLine("\nТаблица сложения:");
        int[,] additionTable = GenerateAdditionTable(m);
        PrintTable(additionTable);
        AnalyzeTable(additionTable);

        Console.WriteLine("\nТаблица умножения:");
        int[,] multiplicationTable = GenerateMultiplicationTable(m);
        PrintTable(multiplicationTable);
        AnalyzeTable(multiplicationTable);

        Console.ReadLine(); // Для ожидания нажатия клавиши Enter перед закрытием окна  
    }

    static int[,] GenerateAdditionTable(int m)
    {
        int[,] table = new int[m, m];

        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < m; j++)
            {
                table[i, j] = (i + j) % m;
            }
        }

        return table;
    }

    static int[,] GenerateMultiplicationTable(int m)
    {
        int[,] table = new int[m, m];

        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < m; j++)
            {
                table[i, j] = (i * j) % m;
            }
        }

        return table;
    }

    static void PrintTable(int[,] table)
    {
        int m = table.GetLength(0);

        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < m; j++)
            {
                Console.Write(table[i, j].ToString().PadLeft(4));
            }
            Console.WriteLine();
        }
    }

    static void AnalyzeTable(int[,] table)
    {
        int m = table.GetLength(0);
        int totalValues = m * m;
        Dictionary<int, int> valueCounts = new Dictionary<int, int>();

        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < m; j++)
            {
                int value = table[i, j];
                if (valueCounts.ContainsKey(value))
                {
                    valueCounts[value]++;
                }
                else
                {
                    valueCounts[value] = 1;
                }
            }
        }

        Console.WriteLine("\nАнализ таблицы:");
        foreach (var kvp in valueCounts.OrderBy(x => x.Key))
        {
            double frequency = (double)kvp.Value / totalValues * 100.0;
            Console.WriteLine($"Вычет {kvp.Key}: Появляется {kvp.Value} раз ({frequency:F2}%)");
        }

        double maxFrequency = valueCounts.Values.Max();
        double minFrequency = valueCounts.Values.Min();
        double dispersionFactor = maxFrequency / minFrequency;

        Console.WriteLine($"Максимальная частота: {maxFrequency:F2}");
        Console.WriteLine($"Минимальная частота: {minFrequency:F2}");
        Console.WriteLine($"Коэффициент разброса: {dispersionFactor:F2}");
    }
}