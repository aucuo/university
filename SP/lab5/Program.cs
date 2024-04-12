using System;
using System.Threading;

class Program
{
    static int sharedNumber = 0;
    static object lockObject = new object();

    static void FirstThread()
    {
        lock (lockObject)
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("Thread 1: " + sharedNumber);
            }
        }
    }

    static void SecondThread()
    {
        lock (lockObject)
        {
            for (int i = 0; i < 10; i++)
            {
                sharedNumber++;
                Console.WriteLine("Thread 2: " + sharedNumber);
            }
        }
    }

    static void Main()
    {
        Thread thread1 = new Thread(FirstThread);
        Thread thread2 = new Thread(SecondThread);

        thread1.Start();
        thread2.Start();

        thread1.Join();
        thread2.Join();

        Console.WriteLine("Главный поток завершен.");
    }
}
