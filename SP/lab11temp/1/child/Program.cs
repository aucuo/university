using System;
using System.Diagnostics;
using System.IO;

class ChildApp
{
    static void Main(string[] args)
    {
        if (args.Length < 2)
        {
            Console.WriteLine("Необходимо передать два аргумента: ID процесса и путь к файлу лога.");
            return;
        }

        int managedProcessId = int.Parse(args[0]);
        string logFilePath = args[1];

        Process managedProcess = Process.GetProcessById(managedProcessId);

        // Логика для изменения приоритета управляемого процесса
        // и записи в лог-файл
        // ...

        // Запись в лог-файл и завершение
        using (StreamWriter writer = new StreamWriter(logFilePath, true))
        {
            writer.WriteLine("Controller process is exiting.");
        }
    }
}
