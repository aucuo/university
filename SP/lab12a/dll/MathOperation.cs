public class MatrixOperation
{
    public static double[,] AddMatrices(double[,] a, double[,] b)
    {
        if (a.GetLength(0) != b.GetLength(0) || a.GetLength(1) != b.GetLength(1))
            throw new InvalidOperationException("Матрицы разного размера не могут быть сложены.");

        double[,] result = new double[a.GetLength(0), a.GetLength(1)];
        for (int i = 0; i < a.GetLength(0); i++)
        {
            for (int j = 0; j < a.GetLength(1); j++)
            {
                result[i, j] = a[i, j] + b[i, j];
            }
        }
        return result;
    }

    public static double[,] SubtractMatrices(double[,] a, double[,] b)
    {
        if (a.GetLength(0) != b.GetLength(0) || a.GetLength(1) != b.GetLength(1))
            throw new InvalidOperationException("Матрицы разного размера не могут быть вычтены.");

        double[,] result = new double[a.GetLength(0), a.GetLength(1)];
        for (int i = 0; i < a.GetLength(0); i++)
        {
            for (int j = 0; j < a.GetLength(1); j++)
            {
                result[i, j] = a[i, j] - b[i, j];
            }
        }
        return result;
    }

    public static double[,] MultiplyMatrices(double[,] a, double[,] b)
    {
        if (a.GetLength(1) != b.GetLength(0))
            throw new InvalidOperationException("Число столбцов первой матрицы должно быть равно числу строк второй матрицы.");

        double[,] result = new double[a.GetLength(0), b.GetLength(1)];
        for (int i = 0; i < result.GetLength(0); i++)
        {
            for (int j = 0; j < result.GetLength(1); j++)
            {
                for (int k = 0; k < a.GetLength(1); k++)
                {
                    result[i, j] += a[i, k] * b[k, j];
                }
            }
        }
        return result;
    }
}
