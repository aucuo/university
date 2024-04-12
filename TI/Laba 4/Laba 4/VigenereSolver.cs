using System;
using System.IO;
using System.Text;

public class VigenereSolver
{
    private string cipherText;
    private int keyLength;

    public VigenereSolver(string cipherText, int keyLength)
    {
        this.cipherText = cipherText;
        this.keyLength = keyLength;
    }

    public string Solve()
    {
        string[] columns = new string[keyLength];
        StringBuilder key = new StringBuilder();

        // Split the ciphertext into columns
        for (int i = 0; i < cipherText.Length; i++)
        {
            int columnIndex = i % keyLength;
            columns[columnIndex] += cipherText[i].ToString();
        }

        // Find the most frequent character in each column
        foreach (string column in columns)
        {
            char mostFrequentChar = ' ';
            int highestFrequency = 0;

            for (char c = 'A'; c <= 'Z'; c++)
            {
                int frequency = CountOccurrences(column, c);

                if (frequency > highestFrequency)
                {
                    mostFrequentChar = c;
                    highestFrequency = frequency;
                }
            }

            // Add the most frequent character to the key
            key.Append((char)(((mostFrequentChar - 'A' - 4) % 26) + 'A'));
        }

        return key.ToString();
    }

    private int CountOccurrences(string str, char c)
    {
        int count = 0;

        for (int i = 0; i < str.Length; i++)
        {
            if (str[i] == c)
            {
                count++;
            }
        }

        return count;
    }
}