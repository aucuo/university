using System;
using System.Diagnostics;
using System.IO;

class ParentApp
{
    static void Main(string[] args)
    {
        // Создание файла лога
        string logFilePath = "D:\\Desktop\\log.txt";
        FileStream logFile = new FileStream(logFilePath, FileMode.Create);

        // Запуск управляемого процесса (например, Notepad)
        Process managedProcess = Process.Start("notepad.exe");

        // Запуск управляющего процесса
        ProcessStartInfo controllerStartInfo = new ProcessStartInfo("ControllerApp.exe");
        controllerStartInfo.UseShellExecute = false;
        controllerStartInfo.ArgumentList.Add(managedProcess.Id.ToString());
        controllerStartInfo.ArgumentList.Add(logFilePath);
        Process controllerProcess = Process.Start(controllerStartInfo);

        // Ожидание завершения дочерних процессов
        managedProcess.WaitForExit();
        controllerProcess.WaitForExit();

        // Запись в лог-файл о завершении работы
        using (StreamWriter writer = new StreamWriter(logFilePath, true))
        {
            writer.WriteLine("Controller process is exiting.");
        }

        // Закрытие файла лога
        logFile.Close();
    }
}
