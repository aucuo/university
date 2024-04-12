using System;
using System.Collections.Generic;
using System.Linq;

public class CipherAnalyzer
{
    private string ciphertext;
    private int l;

    public CipherAnalyzer(string ciphertext, int l)
    {
        this.ciphertext = ciphertext;
        this.l = l;
    }

    public int FindKeyLength()
    {
        var ngrams = FindNgrams();
        var distances = ComputeDistances(ngrams);
        var gcd = ComputeGCD(distances);
        return gcd;
    }

    private List<string> FindNgrams()
    {
        var ngrams = new List<string>();
        for (int i = 0; i <= ciphertext.Length - l; i++)
        {
            var ngram = ciphertext.Substring(i, l);
            if (ngrams.Contains(ngram))
            {
                continue;
            }
            if (ciphertext.IndexOf(ngram, i + 1) != -1)
            {
                ngrams.Add(ngram);
            }
        }
        return ngrams;
    }

    private List<int> ComputeDistances(List<string> ngrams)
    {
        var distances = new List<int>();
        foreach (var ngram in ngrams)
        {
            var indices = AllIndexesOf(ciphertext, ngram);
            for (int i = 1; i < indices.Count; i++)
            {
                distances.Add(indices[i] - indices[i - 1]);
            }
        }
        return distances;
    }

    private int ComputeGCD(List<int> numbers)
    {
        if (numbers.Count == 0)
        {
            return 1;
        }
        var gcd = numbers[0];
        for (int i = 1; i < numbers.Count; i++)
        {
            gcd = GCD(gcd, numbers[i]);
        }
        return gcd;
    }

    private int GCD(int a, int b)
    {
        return b == 0 ? a : GCD(b, a % b);
    }

    private List<int> AllIndexesOf(string str, string substr)
    {
        var indexes = new List<int>();
        for (int i = 0; i <= str.Length - substr.Length; i++)
        {
            if (str.Substring(i, substr.Length) == substr)
            {
                indexes.Add(i);
            }
        }
        return indexes;
    }
}
