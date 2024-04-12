using System;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using System.Threading;

class Program
{
    static int finalValue = 0;

    static void Main()
    {
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();

        Search(@"D:\Desktop\Learning");
        Search(@"D:\Desktop\Portfolio");
        Console.WriteLine($"финальное значение {finalValue}");

        stopwatch.Stop();
        Console.WriteLine($"время выполнения {stopwatch.ElapsedMilliseconds} мс");
    }

    static void Search(string catalog)
    {
        string fileName = "файлик.txt";

        foreach (string findedFile in Directory.EnumerateFiles(catalog, fileName,
            SearchOption.AllDirectories))
        {
            FileInfo FI;
            try
            {
                FI = new FileInfo(findedFile);
                Console.WriteLine(FI.Name + " " + FI.FullName + " " + FI.Length + "_байт" +
                    " Создан: " + FI.CreationTime);

            }
            catch
            {
                continue;
            }

        }
    }
}
