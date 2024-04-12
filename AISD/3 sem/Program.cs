using System;
using System.Linq;
static class Program
{
    private static long inverseCount;

    public static int[] MergeSort(int[] array)
    {
        inverseCount = 0;
        if (array == null) return null!;
        if (array.Length == 0) return array;
        return MergeSort(array, 0, array.Length - 1);
    }

    static int[] MergeSort(int[] array, int low, int high)
    {
        if (low > high - 1) return new int[] { array[low] };
        int mid = low + (high - low) / 2;

        return Merge(MergeSort(array, low, mid), MergeSort(array, mid + 1, high));
    }

    static int[] Merge(int[] array1, int[] array2)
    {
        int cursor1 = 0;
        int cursor2 = 0;
        int[] merged = new int[array1.Length + array2.Length];
        int mergedCursor = 0;

        while (cursor1 < array1.Length && cursor2 < array2.Length)
        {

            if (array1[cursor1] <= array2[cursor2])
                merged[mergedCursor++] = array1[cursor1++];
            else
            {
                merged[mergedCursor++] = array2[cursor2++];
                inverseCount += (array1.Length - cursor1);
            }
        }

        while (cursor1 < array1.Length)
            merged[mergedCursor++] = array1[cursor1++];

        while (cursor2 < array2.Length)
            merged[mergedCursor++] = array2[cursor2++];

        return merged;
    }
    static void Main()
    {
        var inputN = int.Parse(Console.ReadLine()!);
        string stringInput = Console.ReadLine()!;

        int[] array = stringInput.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

        MergeSort(array);
        System.Console.WriteLine(inverseCount);
    }
}