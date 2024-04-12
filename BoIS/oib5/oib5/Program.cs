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

            //Console.Write("         ");
            //for (int i = 0; i < m; i++)
            //{
            //    Console.Write(IsReversible[i] + "  ");
            //}

            //Console.WriteLine();
            //Console.Write("         ");
            //for (int i = 0; i < m; i++)
            //{
            //    if (IsReversible[i] == "+")
            //    {
            //        IsReversible[i] = "-";
            //    }
            //    else
            //    {
            //        IsReversible[i] = "+";
            //    }
            //}
            //for (int i = 0; i < m; i++)
            //{
            //    Console.Write(IsReversible[i] + "  ");
            //}
            bool prost = true;
            for (int i = 2; i <= m / 2; i++)
            {
                if (m % i == 0)
                {
                    prost = false;
                    break;
                }
            }
            if (prost)
            {
                Console.WriteLine("Число простое");
            }
            else
            {
                Console.WriteLine("Число не простое");
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

        }
    }
}