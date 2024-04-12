using System;
using System.Threading;

class Program
{
    static int[,] matrix; // Массив чисел
    static int n; // Размерность матрицы
    static Semaphore semaphore1 = new Semaphore(0, 1); // Семафор для первого потока
    static Semaphore semaphore2 = new Semaphore(0, 1); // Семафор для второго потока
    static int sum1 = 0; // Переменная для суммы первого потока
    static int sum2 = 0; // Переменная для суммы второго потока

    static void Main()
    {
        // Ввод размерности и элементов массива
        Console.Write("Введите размерность n: ");
        n = int.Parse(Console.ReadLine());
        matrix = new int[n, n];
        Console.WriteLine("Введите элементы массива:");
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                matrix[i, j] = int.Parse(Console.ReadLine());
            }
        }

        PrintMatrix(matrix);

        // Создаем и запускаем потоки
        Thread thread1 = new Thread(Thread1Method);
        Thread thread2 = new Thread(Thread2Method);
        thread1.Start();
        thread2.Start();

        // Ждем завершения потоков
        thread1.Join();
        thread2.Join();

        // Сравниваем суммы и выводим результат
        if (sum1 > sum2)
        {
            Console.WriteLine("Сумма всех положительных чисел выше главной диагонали больше.");
        }
        else
        {
            Console.WriteLine("Сумма модулей всех отрицательных чисел выше второй главной диагонали больше.");
        }
    }

    static void PrintMatrix(int[,] matrix)
    {
        int n = matrix.GetLength(0);

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                Console.Write($"{matrix[i, j],4}"); // Используем форматированный вывод для выравнивания чисел
            }
            Console.WriteLine(); // Переход на новую строку после каждой строки матрицы
        }
    }

    static void Thread1Method()
    {
        // Вычисляем сумму всех положительных чисел выше главной диагонали и ниже второй главной диагонали
        for (int i = 0; i < n; i++)
        {
            for (int j = i + 1; j < n; j++)
            {
                if (matrix[i, j] > 0)
                {
                    sum1 += matrix[i, j];
                }
            }
        }
        semaphore1.Release(); // Освобождаем семафор для второго потока
    }

    static void Thread2Method()
    {
        // Вычисляем сумму модулей всех отрицательных чисел выше второй главной диагонали и ниже главной диагонали
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n - i - 1; j++)
            {
                if (matrix[i, j] < 0)
                {
                    sum2 += Math.Abs(matrix[i, j]);
                }
            }
        }
        semaphore2.Release(); // Освобождаем семафор для первого потока
    }
}
