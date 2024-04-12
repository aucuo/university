internal class Program
{
    static int[] FillArray(int[] array, int min, int max)
    {
        Random rand = new Random();
        for (int i = 0; i < array.Length; i++)
        {
            array[i] = rand.Next(min, max);
        }

        return array;
    }
    static void PrintArray(int[] array)
    {
        for (int i = 0; i < array.Length; i++)
        {
            System.Console.Write(array[i] + " ");
        }
        System.Console.WriteLine();
    }
    static int FindMin(int[] array)
    {
        int minIndex = 0, min = array[0];
        for (int i = 1; i < array.Length; i++)
        {
            if (array[i] < min)
            {
                minIndex = i;
                min = array[i];
            }
        }
        return minIndex;
    }
    static int[] Replace(int[] array, int firstIndex, int secondIndex)
    {
        int temp = array[firstIndex];
        array[firstIndex] = array[secondIndex];
        array[secondIndex] = temp;

        return array;
    }
    static void SameElements(int[] array1, int[] array2)
    {
        Console.Write(string.Join(" ", array1.Intersect(array2)));
    }
    static int[][] FillMatrix(int[][] matrix, int min, int max)
    {
        Random rand = new Random();

        for (int i = 0; i < matrix.Length; i++)
        {
            matrix[i] = new int[matrix.Length];
            for (int j = 0; j < matrix[i].Length; j++)
            {
                matrix[i][j] = rand.Next(min, max);
            }
        }
        return matrix;
    }
    static void PrintMatrix(int[][] matrix)
    {
        for (int i = 0; i < matrix.Length; i++)
        {
            for (int j = 0; j < matrix[i].Length; j++)
            {
                System.Console.Write(matrix[i][j] + " ");
            }
            System.Console.WriteLine();
        }
    }
    static void FindTrack(int[][] matrix)
    {
        int track = 0;
        for (int i = 0; i < matrix.Length; i++)
        {
            track += matrix[i][i];
        }
        System.Console.WriteLine(track);
    }
    static void FindMin(int[][] matrix)
    {
        int minIndex = 0, min = matrix[0][0], temp = 0;
        for (int i = 0; i < matrix.Length; i++)
        {
            for (int j = 0; j < matrix[i].Length; j++)
            {
                if (matrix[i][j] < min)
                {
                    minIndex = i;
                    temp = j;
                    min = matrix[i][j];
                }
            }
        }
        System.Console.WriteLine("Min Index: " + minIndex + ", " + temp + " Min Element: " + min);
    }
    static void FindMax(int[][] matrix)
    {
        int maxIndex = 0, max = matrix[0][0], temp = 0;
        for (int i = 0; i < matrix.Length; i++)
        {
            for (int j = 0; j < matrix[i].Length; j++)
            {
                if (matrix[i][j] > max)
                {
                    maxIndex = i;
                    temp = j;
                    max = matrix[i][j];
                }
            }
        }
        System.Console.WriteLine("Min Index: " + maxIndex + ", " + temp + " Min Element: " + max);
    }
    private static void Main(string[] args)
    {
        int[] array1 = new int[15], array2 = new int[15];

        FillArray(array1, 10, 90); // Первое задание
        PrintArray(array1);
        Replace(array1, 0, FindMin(array1));
        PrintArray(array1);

        System.Console.WriteLine();

        FillArray(array1, 0, 9); // Второе задание
        FillArray(array2, 0, 9);
        PrintArray(array1);
        PrintArray(array2);
        SameElements(array1, array2);

        System.Console.WriteLine("\n");

        int[][] matrix = new int[10][]; // Третье задание
        FillMatrix(matrix, 0, 9);
        PrintMatrix(matrix);
        FindTrack(matrix);

        System.Console.WriteLine();

        FindMin(matrix); // Четвертое задание
        FindMax(matrix);
    }
}