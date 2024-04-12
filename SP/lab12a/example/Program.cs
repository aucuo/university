class Program
{
    static void Main(string[] args)
    {
        double[,] matrixA = {   { 1, 2 }, 
                                { 3, 4 } };

        double[,] matrixB = {   { 5, 6 }, 
                                { 7, 8 } };

        try
        {
            double[,] resultAdd = MatrixOperation.AddMatrices(matrixA, matrixB);
            double[,] resultSubtract = MatrixOperation.SubtractMatrices(matrixA, matrixB);
            double[,] resultMultiply = MatrixOperation.MultiplyMatrices(matrixA, matrixB);

            Console.WriteLine("Результат сложения матриц:");
            PrintMatrix(resultAdd);

            Console.WriteLine("\nРезультат вычитания матриц:");
            PrintMatrix(resultSubtract);

            Console.WriteLine("\nРезультат умножения матриц:");
            PrintMatrix(resultMultiply);
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
    private static void PrintMatrix(double[,] matrix)
    {
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                Console.Write(matrix[i, j] + "\t");
            }
            Console.WriteLine();
        }
    }
}
