using System;
using System.Drawing;

class Table
{
    public static int Main()
    {
        Console.WriteLine("Enter first letter number of your name");
        int number = Convert.ToInt32(Console.ReadLine()) % 5 + 4;
        List<double> sumN = new List<double>();
        List<double> mulN = new List<double>();
        //sum

        Console.WriteLine("\tSum table");
        Console.Write("\t+ |");
        for (int i = 0; i < number; i++)
        {
            Console.Write("\t" + i);
        }
        
        Console.WriteLine("\n\t" + new string('-', number * 8 + 2) + "\n\t  |");
        
        for (int i = 0; i < number; i ++)
        {
            Console.Write("\t" + i + " |\t");
            for (int j = 0; j < number; j ++)
            {
                int result = (i + j) % number;
                sumN.Add(result);
                Console.Write(result + "\t");
            }
            Console.WriteLine("\n\t  |");
        }
        
        // multyply

        Console.WriteLine("\n\tMultyply table");
        Console.Write("\t* |");
        for (int i = 0; i < number; i++)
        {
            Console.Write("\t" + i);
        }

        Console.WriteLine("\n\t" + new string('-', number * 8 + 2) + "\n\t  |");

        for (int i = 0; i < number; i++)
        {
            Console.Write("\t" + i + " |\t");
            for (int j = 0; j < number; j++)
            {
                int result = (i * j) % number;
                mulN.Add(result);
                Console.Write(result + "\t");
            }
            Console.WriteLine("\n\t  |");
        }

        // frequency
        List<double> frequencyS = new List<double>();
        List<double> frequencyM = new List<double>();

        Console.WriteLine("\nsum frequency");
        foreach (int val in sumN.Distinct())
        {
            frequencyS.Add(sumN.Where(x => x == val).Count());
            Console.WriteLine(val + " - " + sumN.Where(x => x == val).Count() + " times " + "frequency: " + Convert.ToDouble(100 * Convert.ToDouble(sumN.Where(x => x == val).Count()) / sumN.Count) + "%");
        }

        Console.WriteLine("\nMul frequency");
        foreach (int val in mulN.Distinct())
        {
            frequencyM.Add(mulN.Where(x => x == val).Count());
            Console.WriteLine(val + " - " + mulN.Where(x => x == val).Count() + " times " + "frequency: " + Convert.ToDouble(100 * Convert.ToDouble(mulN.Where(x => x == val).Count()) / mulN.Count) + "%");
        }

        double sumFrequency = 0;

        foreach (int val in sumN.Distinct())
        {
            sumFrequency += 100 * Convert.ToDouble(Convert.ToDouble(sumN.Where(x => x == val).Count()) / sumN.Count);
        }
        Console.WriteLine("\nsum frequency of sum table " + sumFrequency + "%");

        sumFrequency = 0;
        foreach (int val in mulN.Distinct())
        {
            sumFrequency += 100 * Convert.ToDouble(Convert.ToDouble(mulN.Where(x => x == val).Count()) / mulN.Count);
        }
        Console.WriteLine("sum frequency of multiply table " + sumFrequency + "%");

        Console.Write("\nsum of appearances = ");
        foreach (int val in sumN.Distinct())
        {
            Console.Write(mulN.Where(x => x == val).Count() + " + ");
        }

        Console.WriteLine("= " + number * number + " = " + number + " * " + number);

        Console.WriteLine("\nmax frequency of sum table: " + frequencyS.Max());
        Console.WriteLine("min frequency of sum table: " + frequencyS.Min());
        Console.WriteLine("max frequency of multyply table: " + frequencyM.Max());
        Console.WriteLine("min frequency of multyply table: " + frequencyM.Min());

        double DS = frequencyS.Max() / frequencyS.Min();
        Console.WriteLine("Diametr of sum frequency: " + DS);
        double DM = frequencyM.Max() / frequencyM.Min();
        Console.WriteLine("Diametr of mul frequency: " + DM);
        if(DS > DM)
        {
            Console.WriteLine("DS > DB)");
        }
        else { Console.WriteLine("DS < DB"); }
        return 0;
    }
}