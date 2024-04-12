using System;
using System.IO.MemoryMappedFiles;
using System.Text;

class ServerShm
{
    static void Main(string[] args)
    {
        char[] message;
        int size;

        MemoryMappedFile sharedMemory = MemoryMappedFile.OpenExisting("malavatransportation");
        using (MemoryMappedViewAccessor reader = sharedMemory.CreateViewAccessor(0, 4, MemoryMappedFileAccess.Read))
        {
            size = reader.ReadInt32(0);
        }

        using (MemoryMappedViewAccessor reader = sharedMemory.CreateViewAccessor(4, size * 2, MemoryMappedFileAccess.Read))
        {
            message = new char[size];
            reader.ReadArray<char>(0, message, 0, size);
        }
        Console.WriteLine("получена малява:");
        Console.WriteLine(message);
        Console.WriteLine("щелкни enter для выхода");
        Console.ReadLine();
    }
}
