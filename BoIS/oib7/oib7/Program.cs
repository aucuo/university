using System;

namespace oib3
{
    class program
    {
        static int gcd(int first, int second)
        {
            int result;
            if (second > first)
            {
                int temp = first;
                first = second;
                second = temp;
            }
            int remainder;
            do
            {
                if(second == 0)
                {
                    return first;
                }
                remainder = first % second;
                result = second;
                first = second;
                second = remainder;

            } while (remainder != 0);
            return result;
        }
        public static void Main()
        {
            Console.WriteLine("Enter m: ");
            int m = Convert.ToInt32(Console.ReadLine());
            string numbers = "";
            string reversible = "";
            List<string> zerosI = new List<string>();
            List<string> zerosJ = new List<string>();
            var IsReversible = new Dictionary<int, string>();


            for (int i = 0; i < m; i++)
            {
                numbers += i + "  ";
                IsReversible.Add(i, "-");
            }

            Console.WriteLine("Z" + m + "  |a   " + numbers);
            Console.WriteLine("     x");


            for (int i = 0; i < m; i++)
            {
                zerosI.Add("s");
                zerosJ.Add("");
                if (i < 10)
                {
                    Console.Write("     " + i + "   ");
                }
                else
                {
                    Console.Write("     " + i + "  ");
                }
                for (int j = 0; j < m; j++)
                {
                    if (((i * j) % m) < 10)
                    {
                        Console.Write((i * j) % m + "  ");
                    }
                    else
                    {
                        Console.Write((i * j) % m + " ");
                    }
                    if (IsReversible[i] == "+")
                    {
                        continue;
                    }
                    if ((i * j) % m == 1)
                    {
                        IsReversible[i] = "+";
                        reversible += i + " ";
                    }
                    if ((i * j) % m == 0)
                    {

                        zerosI[i] = i.ToString();
                        zerosJ[i] += " " + j;
                    }
                }
                Console.WriteLine();
            }

            Console.WriteLine();
            Console.Write("Обратимые элементы: " + reversible);
            Console.WriteLine();
            Console.Write("Делители нуля: ");
            for (int i = 0; i < m - 1; i++)
            {
                if (zerosI[i] != "s" && (zerosJ[i] != " 0"))
                {
                    Console.Write(zerosI[i] + " ");

                }
            }
            Console.WriteLine();
            for (int i = 0; i < m; i++)
            {
                if(gcd(i,m) == 1)
                {
                Console.WriteLine("\n" + i + " Элемент(Делитель нуля) - НОД(" + i + "," + m + "): " + gcd(i, m));
                }
                else
                {
                    Console.WriteLine("\n" + i + " Элемент(Обратимый) - НОД(" + i + "," + m + "): " + gcd(i, m));
                }

            }
        }
    }
}