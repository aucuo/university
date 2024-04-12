public class MathOperation
{
    public static int AddUsingIncrement(int a, int b)
    {
        int sum = a;
        for (int i = 0; i < b; i++)
        {
            sum++;  // Прибавляем 1 к sum b раз
        }
        return sum;
    }
}
