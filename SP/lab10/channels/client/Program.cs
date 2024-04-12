using System;
using System.IO;
using System.IO.Pipes;

class Client
{
    public static void Main()
    {
        Console.WriteLine("Клиент запущен. Подключение к серверу...");

        // подключение к каналу
        using (NamedPipeClientStream clientStream = new NamedPipeClientStream("pipipupu"))
        {
            clientStream.Connect();

            // отправка
            using (StreamWriter writer = new StreamWriter(clientStream))
            {
                Console.Write("Введите сообщение для сервера: ");
                string message = Console.ReadLine();
                writer.WriteLine(message);
            }
        }
    }
}