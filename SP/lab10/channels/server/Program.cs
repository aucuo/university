using System;
using System.IO;
using System.IO.Pipes;
using System.Threading;

class Server
{
    static NamedPipeServerStream serverStream;

    public static void Main()
    {
        // именованный канал
        serverStream = new NamedPipeServerStream("pipipupu");

        Console.WriteLine("Сервер запущен. Ожидание подключения клиента...");

        serverStream.WaitForConnection();
        Console.WriteLine("Клиент подключен.");

        // поток для приема сообщений от клиента
        Thread receiveThread = new Thread(ReceiveMessage);
        receiveThread.Start();

        Console.WriteLine("Для завершения нажмите Enter.");
        Console.ReadLine();
    }

    static void ReceiveMessage()
    {
        StreamReader reader = new StreamReader(serverStream);

        while (true)
        {
            // ожидание сообщения
            string message = reader.ReadLine();

            if (message == null)
                break;

            Console.WriteLine($"Сервер получил сообщение: {message}");
        }
    }
}
