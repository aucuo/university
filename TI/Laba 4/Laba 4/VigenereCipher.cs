using System;
using System.IO;
using System.Linq;

namespace Laba_4
{
    class VigenereCipher
    {
        private readonly string key;

        public VigenereCipher(string key)
        {
            this.key = key.ToUpper();
        }

        public void EncryptFile(string inputFile, string outputFile)
        {
            using (var reader = new StreamReader(inputFile))
            using (var writer = new StreamWriter(outputFile))
            {
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    string encryptedLine = Encrypt(line);
                    writer.WriteLine(encryptedLine);
                }
            }
        }

        public void DecryptFile(string inputFile, string outputFile)
        {
            using (var reader = new StreamReader(inputFile))
            using (var writer = new StreamWriter(outputFile))
            {
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    string decryptedLine = Decrypt(line);
                    writer.WriteLine(decryptedLine);
                }
            }
        }

        private string Encrypt(string message)
        {
            return Shift(message, 1);
        }

        private string Decrypt(string message)
        {
            return Shift(message, -1);
        }

        private string Shift(string message, int direction)
        {
            string normalizedMessage = message.ToUpper();
            string normalizedKey = key;

            while (normalizedKey.Length < normalizedMessage.Length)
            {
                normalizedKey += normalizedKey;
            }

            normalizedKey = normalizedKey.Substring(0, normalizedMessage.Length);

            char[] result = new char[normalizedMessage.Length];

            for (int i = 0; i < normalizedMessage.Length; i++)
            {
                char c = normalizedMessage[i];
                if (char.IsLetter(c))
                {
                    int keyIndex = i % normalizedKey.Length;
                    int keyCharValue = normalizedKey[keyIndex] - 'A';
                    int charValue = c - 'A';
                    int shiftedValue = (charValue + direction * keyCharValue + 26) % 26;
                    char shiftedChar = (char)(shiftedValue + 'A');
                    result[i] = shiftedChar;
                }
                else
                {
                    result[i] = c;
                }
            }

            return new string(result);
        }
    }
}
