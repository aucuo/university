internal class Program
{
    static void SymbolsCount(string str)
    {
        int plusCount = 0, minusCount = 0, plusZeroCount = 0;
        for (int i = 0; i < str.Length; i++)
        {
            if (str[i] == '+')
            {
                plusCount++;
                if (str[i + 1] == '0')
                    plusZeroCount++;
            }
            else if (str[i] == '-')
                minusCount++;
        }
        System.Console.WriteLine("Плюсы: " + plusCount + " Минусы: " + minusCount + " Плисы с след. нулем: " + plusZeroCount);
    }
    static string SymbolsRandom(string str)
    {
        Random rand = new Random();
        char[] str1 = str.ToCharArray();
        int temp;

        for (int i = 1; i < str.Length; i += 3)
        {
            temp = rand.Next(97, 122);
            while ((char)temp == str1[i])
                temp = rand.Next(97, 122);

            str1[i] = (char) temp;
        }

        return new string(str1);
    }
    static string StringSort(string str)
    {
        char[] str1 = str.ToCharArray();

        Array.Sort(str1);

        return new string(str1);
    }
    static void GenerateEmail()
    {
        Random rand = new Random();
        int length = rand.Next(6, 15);

        for (int i = 0; i < length; i++)
        {
            System.Console.Write((char) rand.Next(97, 122));
        }

        System.Console.Write("@gmail.com");
    }
    static void Hooks(string str)
    {
        int f = 0, s = 0, f1 = 0, s1 = 0, f2 = 0, s2 = 0;
        for (int i = 0; i < str.Length-1; i++)
        {
            if (str[i] == '[')
                f++;
            if (str[i] == ']')
                s++;
            if (str[i] == '(')
                f1++;
            if (str[i] == ')')
                s1++;
            if (str[i] == '{')
                f2++;
            if (str[i] == '}')
                s2++;
        }

        if (f != s || f1 != s1 || f2 != s2)
            System.Console.WriteLine("yes");
        else
            System.Console.WriteLine(-1);

    }
    private static void Main(string[] args)
    {
        string str = "+-+-+0-+0--";

        SymbolsCount(str); // 1 задание

        str = "abcdefg";

        System.Console.WriteLine(str); // 2 задание
        str = SymbolsRandom(str);
        System.Console.WriteLine(str);
        str = StringSort(str);
        System.Console.WriteLine(str);

        GenerateEmail(); // 3 задание

        System.Console.WriteLine();

        Hooks("[](){}}"); // 4 задание
    }
}