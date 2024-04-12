namespace Compression
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Huffman huffman = new Huffman();
            huffman.ComressFile("data.txt", "data.txt.huf");
            huffman.DecompressFile("data.txt.huf", "data.txt.huf.txt");
        }
    }
}