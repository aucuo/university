using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public static class Checks
{
    public static int ReadInt()
    {
        var input = Console.ReadLine();

        if (int.TryParse(input, out var output))
            return output;

        return ReadInt();
    }

    public static int ReadInt(int min, int max)
    {
        var input = ReadInt();

        if (input >= min && input <= max)
            return input;

        return ReadInt(min, max);
    }

    public static DateTime ReadDate()
    {
        var input = Console.ReadLine();

        if (DateTime.TryParse(input, out var output) && output < DateTime.Now)
            return output;

        return ReadDate();
    }

    public static string TypeChoise()
    {
        Console.WriteLine("Выберите тип платежа (1. картой; 2. наличными):");
        var n = Checks.ReadInt(1, 2);

        if (n == 1)
            return "Картой";
        else
            return "Наличными";
    }

    public static string ReadName()
    {
        var name = Console.ReadLine();

        if (name.All(char.IsLetter) && !string.IsNullOrEmpty(name))
            return name;

        return ReadName();
    }
}

