namespace Laba_4
{
    internal class Program
    {
        // Генерация ключа для шифрования Виженера
        public static string GenerateVigenereKey(int length)
        {
            const string letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            Random random = new Random();
            return new string(Enumerable.Repeat(letters, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        private static void Main(string[] args)
        {
            string vigenereKey = GenerateVigenereKey(6);
            Console.WriteLine("Реальный ключ шифрования: {0}", vigenereKey);

            var cipher = new VigenereCipher(vigenereKey);
            cipher.EncryptFile("input.txt", "encrypted.txt");
            cipher.DecryptFile("encrypted.txt", "decrypted.txt");

            //

            var cipherAnalyzer = new CipherAnalyzer(File.ReadAllText("encrypted.txt"), 6);

            int keyLength = cipherAnalyzer.FindKeyLength();
            Console.WriteLine("Предполагаемая длинна ключа: {0}", keyLength);

            //

            string cipherText = File.ReadAllText("encrypted.txt");

            VigenereSolver solver = new VigenereSolver(cipherText, keyLength);
            string key = solver.Solve();

            Console.WriteLine("Предполагаемый ключ: {0}", key);

        }
    }
}