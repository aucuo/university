using System;
using System.Diagnostics;
using System.Threading;

class Program
{
    static object lockObject = new object();
    static int finalValue = 0;

    static void Main()
    {
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();

        Thread thread1 = new Thread(new ThreadStart(delegate { Search(@"D:\Desktop\Learning"); }));
        Thread thread2 = new Thread(new ThreadStart(delegate { Search(@"D:\Desktop\Portfolio"); }));

        thread1.Start();
        thread2.Start();

        thread1.Join();
        thread2.Join();

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
            lock (lockObject)
            {
                Monitor.Pulse(lockObject);
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
}
