using System;
using System.IO.MemoryMappedFiles;
using System.Text;

class ClientShm
{
    static void Main(string[] args)
    {
        Console.WriteLine("базарь:");
        char[] message = Console.ReadLine().ToCharArray();
        int size = message.Length;

        MemoryMappedFile sharedMemory = MemoryMappedFile.CreateOrOpen("malavatransportation", size * 2 + 4);
        using (MemoryMappedViewAccessor writer = sharedMemory.CreateViewAccessor(0, size * 2 + 4))
        {
            writer.Write(0, size);
            writer.WriteArray<char>(4, message, 0, size);
        }

        Console.WriteLine("малява отправлена");
        Console.WriteLine("щелкни enter для выхода");
        Console.ReadLine();
    }
}
