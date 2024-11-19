using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        // Задание 1: Удалить столбец двухмерного массива с максимальным элементом
        double[,] matrix = {
            { 1.2, 2.3, 3.4 },
            { 4.5, 5.6, 6.7 },
            { 9.0, 9.0, 9.0 }
        };
        PrintMatrix(matrix);
        Console.WriteLine("\n ");

        matrix = RemoveColumnsWithMaxElement(matrix);
        PrintMatrix(matrix);

        // Задание 2: Удалить подряд идущие дубликаты слов в предложениях
        string text = "Привет привет! Как как дела. Это тест тест.";
        string resultText = RemoveDuplicateWords(text);
        Console.WriteLine("Отредактированный текст: " + resultText);

        // Задание 3: Извлечь все e-mail адреса из текста
        string emailText = "Контакты: test@test.com, example@example.org.";
        string[] emails = ExtractEmails(emailText);
        Console.WriteLine("Найденные e-mail адреса:");
        foreach (var email in emails)
        {
            Console.WriteLine(email);
        }
    }

    // Задание 1: Удалить столбец с максимальным элементом
    static double[,] RemoveColumnsWithMaxElement(double[,] matrix)
    {
        int rows = matrix.GetLength(0);
        int cols = matrix.GetLength(1);
        double maxElement = matrix[0, 0];
        List<int> maxColIndices = new List<int>();

        // Поиск максимального элемента
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                if (matrix[i, j] > maxElement)
                {
                    maxElement = matrix[i, j];
                    maxColIndices.Clear(); // Очищаем список, если найден новый максимальный элемент
                    maxColIndices.Add(j);
                }
                else if (matrix[i, j] == maxElement)
                {
                    if (!maxColIndices.Contains(j))
                    {
                        maxColIndices.Add(j);
                    }
                }
            }
        }

        // Создание новой матрицы без столбцов с максимальными элементами
        double[,] newMatrix = new double[rows, cols - maxColIndices.Count];
        for (int i = 0; i < rows; i++)
        {
            int newCol = 0;
            for (int j = 0; j < cols; j++)
            {
                if (!maxColIndices.Contains(j))
                {
                    newMatrix[i, newCol] = matrix[i, j];
                    newCol++;
                }
            }
        }
        return newMatrix;
    }


    static void PrintMatrix(double[,] matrix)
    {
        int rows = matrix.GetLength(0);
        int cols = matrix.GetLength(1);
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                Console.Write(matrix[i, j] + "\t");
            }
            Console.WriteLine();
        }
    }

    // Задание 2: Удалить подряд идущие дубликаты слов в предложениях
    static string RemoveDuplicateWords(string text)
    {
        string[] sentences = text.Split(new char[] { '.', '!', '?' }, StringSplitOptions.RemoveEmptyEntries);
        StringBuilder result = new StringBuilder();

        for (int i = 0; i < sentences.Length; i++)
        {
            string[] words = sentences[i].Trim().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            StringBuilder sentenceBuilder = new StringBuilder();

            if (words.Length > 0)
            {
                sentenceBuilder.Append(words[0]);

                for (int j = 1; j < words.Length; j++)
                {
                    if (!string.Equals(words[j], words[j - 1], StringComparison.OrdinalIgnoreCase))
                    {
                        sentenceBuilder.Append(" ").Append(words[j]);
                    }
                }
            }

            result.Append(sentenceBuilder.ToString().Trim());

            if (i < sentences.Length - 1)
            {
                result.Append(". ");
            }
        }

        return result.ToString().Trim() + ".";
    }

    // Задание 3: Извлечение e-mail адресов из текста
    static string[] ExtractEmails(string text)
    {
        MatchCollection matches = Regex.Matches(text, @"[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}");
        return matches.Cast<Match>().Select(m => m.Value).ToArray();
    }
}
