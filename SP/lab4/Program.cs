using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

class Program
{
    static Mutex mutex = new Mutex();
    static int threadCount;

    static void Main()
    {
        string[] directories = {
            "D:\\Desktop\\Learning\\SP\\lab4",
            "D:\\Desktop",
            "D:\\Desktop\\Learning",
            "D:\\Desktop\\Portfolio"
        };
        threadCount = directories.Length / 2;

        List<Thread> threads = new List<Thread>();

        foreach (string directory in directories)
        {
            Thread thread = new Thread(SearchFiles);
            threads.Add(thread);
            thread.Start(directory);
        }

        foreach (Thread thread in threads)
        {
            thread.Join();
        }

        Console.WriteLine("Поиск завершен.");
    }

    static void SearchFiles(object directory)
    {
        string targetDirectory = (string)directory;
        string[] files = Directory.GetFiles(targetDirectory, "*", SearchOption.AllDirectories);

        foreach (string file in files)
        {
            mutex.WaitOne();
            if (File.ReadAllText(file).Contains("егорчик"))
            {
                Console.WriteLine("Найден файл: " + file);
            }
            mutex.ReleaseMutex();
        }

        Interlocked.Decrement(ref threadCount);
        if (threadCount == 0)
        {
            Console.WriteLine("Все потоки завершили работу.");
        }
    }
}
