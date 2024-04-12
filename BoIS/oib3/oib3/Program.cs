using System;

namespace oib3
{
    class program
    {
        public static void Main()
        {
            Console.WriteLine("Enter m: ");
            int m = Convert.ToInt32(Console.ReadLine());
            string numbers = "";
            
            var IsReversible = new Dictionary<int, string>();
            for(int i = 1; i < m; i++)
            {
                numbers += i + "  ";
                IsReversible.Add(i, "-");
            }

            Console.WriteLine("Z" + m + " |a   " + numbers);
            Console.WriteLine("     x");


            for (int i = 1; i < m; i++)
            {
                if(i <10)
                {
                    Console.Write("     " + i + "   ");
                }
                else
                {
                    Console.Write("     " + i + "  ");
                }
                for(int j = 1; j < m; j++)
                {
                    if(((i * j) % m) < 10)
                    {
                    Console.Write((i*j) % m + "  ");
                    }
                    else
                    {
                    Console.Write((i*j) % m + " ");
                    }
                    if ( (i*j) % m == 1)
                    {
                        IsReversible[i] = "+";
                    }
                }
                Console.WriteLine();
            }

            Console.Write("         ");
            for(int i = 1; i < m; i++)
            {
                Console.Write(IsReversible[i] + "  ");
            }

        }
    }
}